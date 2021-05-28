using System.Threading.Tasks;
using TY.LinkConverter.Context;
using TY.LinkConverter.Data.Interface;

namespace TY.LinkConverter.Data.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        private ILinkConverterService _linkConverterService;

        public ILinkConverterService LinkConverterService
        {
            get { return _linkConverterService ??= new LinkConverterService(this); }
        }

        private IToDeeplinkService _toDeeplinkService;

        public IToDeeplinkService ToDeeplinkService
        {
            get { return _toDeeplinkService ??= new ToDeeplinkService(_dataContext); }
        }

        private IToWebURLService _webURLService;

        public IToWebURLService ToWebURLService
        {
            get { return _webURLService ??= new ToWebURLService(_dataContext); }
        }
        
        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}