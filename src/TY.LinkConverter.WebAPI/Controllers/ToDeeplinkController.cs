using System.Threading;
using Microsoft.AspNetCore.Mvc;
using TY.LinkConverter.Data.Interface;

namespace TY.LinkConverter.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDeeplinkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDeeplinkController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public string Post(string link)
        {
            return _unitOfWork.LinkConverterService.ToDeeplink(link);
        }
    }
}