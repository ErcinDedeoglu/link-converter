using System;
using System.Threading.Tasks;

namespace TY.LinkConverter.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IToDeeplinkService ToDeeplinkService { get; }

        IToWebURLService ToWebURLService { get; }

        ILinkConverterService LinkConverterService { get; }

        int Complete();

        Task<int> CompleteAsync();
    }
}