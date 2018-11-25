namespace StagesCycling.Web.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using StagesCycling.BLL.DTO;
    using StagesCycling.BLL.Services.Interfaces;

    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private IDetailsService _detailsService;
        private IAccessoriesService _accessoriesService;
        private IOrderService _orderService;
        private IConfigurationService _configurationService;

        public OrderController(IDetailsService detailsService, IAccessoriesService accessoriesService,
            IOrderService orderService, IConfigurationService configurationService)
        {
            _detailsService = detailsService;
            _accessoriesService = accessoriesService;
            _orderService = orderService;
            _configurationService = configurationService;
        }

        [Route("details")]
        public IHttpActionResult GetDetailOptions()
        {
            var details = _detailsService.GetAllDetails();

            if (details == null)
            {
                return NotFound();
            }
           
            return Ok(details);
        }

        [Route("configurations")]
        public IHttpActionResult GetConfigurations()
        {
            var configurations = _configurationService.GetAllConfigurations();

            if (configurations == null)
            {
                return NotFound();
            }

            return Ok(configurations);
        }

        [Route("accessories")]
        public IHttpActionResult GetAccessoryOptions()
        {
            var accessories = _accessoriesService.GetAllAccessories();

            if(accessories == null)
            {
                return NotFound();
            }

            return Ok(accessories);
        }

        [Route("check"), HttpPost]
        public IHttpActionResult Check(long id)
        {
            _configurationService.Check(id);

            return Ok();
        }

        [Route("create"), HttpPost]
        public IHttpActionResult AddOrder([FromBody] OrderToSave model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _orderService.AddOrder(model);

            return Ok();
        }

        [Route("savedorder"), HttpGet]
        public IHttpActionResult GetSavedOrder(long id)
        {
            var savedOrders = _configurationService.GetSavedOrder(id);

            return Ok(savedOrders);
        }

        [Route("upload"), HttpPost]
        public HttpResponseMessage UploadJsonFile()
        {
            //HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;

            string filePath = string.Empty;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, filePath);
            //return response;
        }
    }
}
