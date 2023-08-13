using Microsoft.AspNetCore.Mvc;
using ResponseSystem.Business;

namespace ResponseSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsSystemController : ControllerBase
    {
        IResponseDetails _responseDetails;

        private readonly ILogger<ResponsSystemController> _logger;

        public ResponsSystemController(ILogger<ResponsSystemController> logger, IResponseDetails responseDetails)
        {
            _logger = logger;
            _responseDetails = responseDetails;
        }

        [HttpGet(Name = "GetResponseObject")]
        public ResponseDetail Get(string responseMessage)
        {
            return _responseDetails.ParseResponse(responseMessage);
        }
    }
}