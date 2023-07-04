using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;
using AdvisoryDatabase.Business.Service;
namespace AdvisoryDatabase.Business.Controllers
{
    public class CourseListDataController : BaseController
    {
        public List<GetCourseList> GetCourseListDetails(GetCourseList ObjInputParameters)
        {
            List<GetCourseList> CourseListData = new List<GetCourseList>();
            try
            {
                CourseListDataService service = new CourseListDataService();
                CourseListData = service.GetAll(ObjInputParameters);

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return CourseListData;
        }
    }
}



/*
namespace AdvisoryDatabase.Business.Controllers
{
    public class GETExcelForClarizenFieldsController : BaseController
    {
        public List<ExcelForClarizen> ExcelforclarizenfeildsDetails(ExcelForClarizen ObjInputParameters)
        {
            List<ExcelForClarizen> ClarizenFieldsData = new List<ExcelForClarizen>();
            try
            {
                ExcelForClarizenFeildDataService service = new ExcelForClarizenFeildDataService();
                ClarizenFieldsData = service.GetAll(ObjInputParameters);

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return ClarizenFieldsData;
        }

    }
}

*/