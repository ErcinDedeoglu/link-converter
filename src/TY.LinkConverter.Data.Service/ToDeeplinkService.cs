using System.Linq;
using TY.LinkConverter.Context;
using TY.LinkConverter.Data.Entity;
using TY.LinkConverter.Data.Interface;

namespace TY.LinkConverter.Data.Service
{
    public class ToDeeplinkService : Repository<ToDeeplink>, IToDeeplinkService
    {
        private readonly DataContext _dataContext;

        public ToDeeplinkService(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<ToDeeplink> ActiveRecords()
        {
            return _dataContext.ToDeeplinks.Where(a => a.Active && !a.Deleted);
        }
    }
}