using System.Linq;
using TY.LinkConverter.Data.Entity;
using TY.LinkConverter.Data.Interface;

namespace TY.LinkConverter.Data.Service
{
    public class LinkConverterService : ILinkConverterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LinkConverterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string ToWebURL(string url) => Convert(url);

        public string ToDeeplink(string url) => Convert(url, true);

        private string Convert(string url, bool toDeeplink = false)
        {
            IQueryable<Link> links = toDeeplink ? (IQueryable<Link>) _unitOfWork.ToDeeplinkService.ActiveRecords() : _unitOfWork.ToWebURLService.ActiveRecords();

            var (groupCollection, link) = Helper.RegexHelper.FindMatch(links, url);

            if (groupCollection != null)
            {
                return Helper.RegexHelper.ParametersFromLink(link.ParameterizedLink)
                    .Aggregate(link.ParameterizedLink,
                        (current, parameter) =>
                            current.Replace($"[{parameter}]", groupCollection[parameter].Value));
            }

            return link.ParameterizedLink;
        }
    }
}