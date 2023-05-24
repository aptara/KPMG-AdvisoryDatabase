/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;
using AdvisoryDatabase.Framework.Entities;

namespace AdvisoryDatabase.WebAPI.Controllers
{
   



public class testController : Controller
    {

        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                AdvisoryDatabaseEntities3 objdemoentity = new AdvisoryDatabaseEntities3();
                var studentercord = objdemoentity.ExcelForClarizen1().ToList();
                InfoModel objmodel = new InfoModel();
                objmodel.infoData = new List<info>();
                foreach (var item in studentercord.ToList())
                {
                    objmodel.infoData.Add(new info
                    {
                        CourseName = item.CourseName,
                        LDIntakeOwner = item.LDIntakeOwner,
                        ProjectManagerContact = item.ProjectManagerContact,
                        BusinessSponsor = item.BusinessSponsor,
                        InstructionalDesigner = item.InstructionalDesigner,
                        ProgramType = item.ProgramType,
                        DeliveryType = item.DeliveryType,
                        TotalCPECredit = item.TotalCPECredit,
                        CourseID = item.CourseID,
                       
LevelofEffort = item.LevelofEffort,
                        Duration = item.Duration
                    });
                }
                return View(objmodel);
            }
        }

    }

}

*/
