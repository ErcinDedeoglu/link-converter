using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TY.LinkConverter.Data.Entity;

namespace TY.LinkConverter.Helper
{
    public class RegexHelper
    {
        public static List<string> ParametersFromLink(string parameterizedLink)
        {
            var result = new List<string>();

            foreach (Match match in Regex.Matches(parameterizedLink, @"(?<=\[).+?(?=\])"))
            {
                result.Add(match.Value);
            }

            return result;
        }

        public static (GroupCollection groupCollection, Link link) FindMatch(IQueryable<Link> toLinks, string url)
        {
            GroupCollection groupCollection = null;
            Link link = null;

            if (url != null)
            {
                Parallel.ForEach(toLinks.Where(a => a.Pattern != null), (i, parallelLoopState) =>
                {
                    var result = new Regex(i.Pattern).Matches(url);

                    if (result.Count > 0 && result[0].Groups.Count > 0)
                    {
                        groupCollection = result[0].Groups;
                        link = i;
                        parallelLoopState.Stop();
                    }
                });
            }

            link ??= toLinks.FirstOrDefault(a => a.Pattern == null);

            return (groupCollection, link);
        }
    }
}