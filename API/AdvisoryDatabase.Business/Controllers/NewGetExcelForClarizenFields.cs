﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Logger;
using AdvisoryDatabase.Business.Service;


namespace AdvisoryDatabase.Business.Controllers
{
    public class GETExcelForClarizenFieldsController1 : BaseController
    {
        public List<ExcelForClarizen> ExcelforclarizenfeildsDetails1(ExcelForClarizen ObjInputParameters)
        {
            List<ExcelForClarizen> ClarizenFieldsData = new List<ExcelForClarizen>();
            try
            {
                ExcelForClarizenFeildDataService service = new ExcelForClarizenFeildDataService();
                ClarizenFieldsData = service.GetAll();

            }
            catch (Exception ex)
            {

                Log4NetLogger.Error(ex.Message);
            }

            return ClarizenFieldsData;
        }

    }

}


*//*
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
    public class GETExcelForClarizenFieldsController : BaseController
    {
        public List<ExcelForClarizen> ExcelforclarizenfeildsDetails(ExcelForClarizen ObjInputParameters)
        {
            List<ExcelForClarizen> ClarizenFieldsData = new List<ExcelForClarizen>();
            try
            {
                ExcelForClarizenFeildDataService service = new ExcelForClarizenFeildDataService();
                ClarizenFieldsData = service.GetAll();

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