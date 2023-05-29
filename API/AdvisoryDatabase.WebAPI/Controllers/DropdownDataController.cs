using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AdvisoryDatabase.Framework.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
//using System.Web.Http;
using AdvisoryDatabase.Business;
using AdvisoryDatabase.Framework.Logger;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using AdvisoryDatabase.Framework.Response;
using AdvisoryDatabase.Business.Controllers;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace AdvisoryDatabase.WebAPI.Controllers
{
    public class DropdownDataController : ApiController
    {
        [HttpGet]
        public APIResponse<DropdownData> GetDropdownData()
        {
            DropdownData dropdownData = new DropdownData();

            AdvisoryDatabase.Business.Controllers.CourseOwnerMasterController courseOwnerController = new AdvisoryDatabase.Business.Controllers.CourseOwnerMasterController();
            AdvisoryDatabase.Business.Controllers.ProgramTypeMasterController programTypeMasterController = new AdvisoryDatabase.Business.Controllers.ProgramTypeMasterController();
            AdvisoryDatabase.Business.Controllers.DeliveryTypeMasterController deliveryTypeMasterController = new AdvisoryDatabase.Business.Controllers.DeliveryTypeMasterController();
            AdvisoryDatabase.Business.Controllers.ProjectStatusMasterController projectStatusMasterController = new AdvisoryDatabase.Business.Controllers.ProjectStatusMasterController();
            AdvisoryDatabase.Business.Controllers.StatusMasterController statusMasterController = new AdvisoryDatabase.Business.Controllers.StatusMasterController();

            dropdownData.CourseOwnerMasters = courseOwnerController.GetAllCourseOwner();
            dropdownData.ProgramTypeMasters = programTypeMasterController.GetAllProgramType();
            dropdownData.DeliveryTypeMasters = deliveryTypeMasterController.GetAllDeliveryType();
            dropdownData.ProjectStatusMasters = projectStatusMasterController.GetProjectStatus();
            dropdownData.StatusMasters = statusMasterController.GetStatusData();

            return new APIResponse<DropdownData>
            {
                Success = true,
                Data = dropdownData,
                Count = 0,
            };

        }
    }
}

