using System.Linq;

namespace TY.LinkConverter.Data.Interface
{
    public interface IToDeeplinkService : IRepository<Entity.ToDeeplink>
    {
        public IQueryable<Entity.ToDeeplink> ActiveRecords();
    }
}