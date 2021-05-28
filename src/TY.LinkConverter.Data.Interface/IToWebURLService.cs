using System.Linq;
using TY.LinkConverter.Data.Entity;

namespace TY.LinkConverter.Data.Interface
{
    public interface IToWebURLService
    {
        public IQueryable<ToWebURL> ActiveRecords();
    }
}