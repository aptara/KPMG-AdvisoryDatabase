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

            AdvisoryDatabase.Business.Controllers.CourseDropdownMasterDataController courseDropdownMasterDataController = new CourseDropdownMasterDataController();

            dropdownData = courseDropdownMasterDataController.GetCourseDropdownMasterData();

            //dropdownData.CourseOwnerMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().CourseOwnerMasters;
            //dropdownData.ProgramTypeMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().ProgramTypeMasters;
            //dropdownData.DeliveryTypeMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().DeliveryTypeMasters;
            //dropdownData.ProjectStatusMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().ProjectStatusMasters;
            //dropdownData.StatusMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().StatusMasters;
            //dropdownData.CompetencyMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().CompetencyMasters;
            //dropdownData.ServiceGroupMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().ServiceGroupMasters;
            //dropdownData.ServiceLineMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().ServiceLineMasters;
            //dropdownData.ServiceNetworkMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().ServiceNetworkMasters;
            //dropdownData.AudienceLevelMasters = courseDropdownMasterDataController.GetCourseDropdownMasterData().AudienceLevelMasters;
            //dropdownData.FieldOfFieldOfStudyMaster = courseDropdownMasterDataController.GetCourseDropdownMasterData().FieldOfFieldOfStudyMaster;
            //dropdownData.ProgramKnowledgeLevelMaster = courseDropdownMasterDataController.GetCourseDropdownMasterData().ProgramKnowledgeLevelMaster;


            return new APIResponse<DropdownData>
            {
                Success = true,
                Data = dropdownData,
                Count = 0,
            };

        }
    }
}

