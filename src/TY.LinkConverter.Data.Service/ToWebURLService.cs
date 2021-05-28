using System.Linq;
using TY.LinkConverter.Context;
using TY.LinkConverter.Data.Entity;
using TY.LinkConverter.Data.Interface;

namespace TY.LinkConverter.Data.Service
{
    public class ToWebURLService : Repository<ToWebURL>, IToWebURLService
    {
        private readonly DataContext _dataContext;

        public ToWebURLService(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<ToWebURL> ActiveRecords()
        {
            return _dataContext.ToWebUrls.Where(a => a.Active && !a.Deleted);
        }
    }
}