using Microsoft.AspNet.Identity.Owin;
using StagesCycling.Web.Infrastructure;
using System.Net.Http;
using System.Web.Http;
using StagesCycling.Web.Models;
using StagesCycling.BLL.Services.Interfaces;
using StagesCycling.BLL.DTO;

namespace StagesCycling.Web.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private ApplicationRoleManager _appRoleManager;

        private IAdminService _adminService;
        private IUpdateService _updateService;

        public AdminController(IAdminService adminService, IUpdateService updateService)
        {
            _adminService = adminService;
            _updateService = updateService;
        }

        [Route("items"), HttpGet]
        public IHttpActionResult GetItemsToEdit()
        {
            var items = _adminService.GetAllItems();

            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        #region Update

        [Route("updateconfiguration"), HttpPut]
        public IHttpActionResult UpdateConfiguration(UpdateConfiguration model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateConfiguration(model);

            return Ok();
        }

        [Route("updateprice"), HttpPut]
        public IHttpActionResult UpdatePrice(UpdatePrice model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdatePrice(model);

            return Ok();
        }

        [Route("updateaerobar"), HttpPut]
        public IHttpActionResult UpdateAerobar(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateAerobar(model);

            return Ok();
        }

        [Route("updatehandlebarpost"), HttpPut]
        public IHttpActionResult UpdateHandlebarPost(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateHandlebarPost(model);

            return Ok();
        }

        [Route("updatemediashelf"), HttpPut]
        public IHttpActionResult UpdateMediaShelf(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateMediaShelf(model);

            return Ok();
        }

        [Route("updatephoneholder"), HttpPut]
        public IHttpActionResult UpdatePhoneHolder(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdatePhoneHolder(model);

            return Ok();
        }

        [Route("updateseatpost"), HttpPut]
        public IHttpActionResult UpdateSeatPost(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateSeatPost(model);

            return Ok();
        }

        [Route("updatestagesbikenumberplate"), HttpPut]
        public IHttpActionResult UpdateStagesBikeNumberPlate(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateStagesBikeNumberPlate(model);

            return Ok();
        }

        [Route("updatestagesdumbbellholder"), HttpPut]
        public IHttpActionResult UpdateStagesDumbbellHolder(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateStagesDumbbellHolder(model);

            return Ok();
        }

        [Route("updatetabletholder"), HttpPut]
        public IHttpActionResult UpdateTabletHolder(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateTabletHolder(model);

            return Ok();
        }

        [Route("updateconsoletype"), HttpPut]
        public IHttpActionResult UpdateConsoleType(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateConsoleType(model);

            return Ok();
        }

        [Route("updatehandlebartype"), HttpPut]
        public IHttpActionResult UpdateHandlebarType(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateHandlebarType(model);

            return Ok();
        }

        [Route("updatemodel"), HttpPut]
        public IHttpActionResult UpdateModel(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateModel(model);

            return Ok();
        }

        [Route("updatepedaltype"), HttpPut]
        public IHttpActionResult UpdatePedalType(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdatePedalType(model);

            return Ok();
        }

        [Route("updateplasticscolortype"), HttpPut]
        public IHttpActionResult UpdatePlasticsColorType(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdatePlasticsColorType(model);

            return Ok();
        }

        [Route("updatepowermetertype"), HttpPut]
        public IHttpActionResult UpdatePowerMeterType(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdatePowerMeterType(model);

            return Ok();
        }

        [Route("updateseattype"), HttpPut]
        public IHttpActionResult UpdateSeatType(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateSeatType(model);

            return Ok();
        }

        [Route("updatesprintshifttype"), HttpPut]
        public IHttpActionResult UpdateSprintShiftType(UpdateDetail model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _updateService.UpdateSprintShiftType(model);

            return Ok();
        }

        #endregion
    }
}
