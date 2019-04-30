using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using mvc_Q4_using_Fetch.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mvc_Q4_using_Fetch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDepartment()
        {
            string json = "";
            using (StreamReader sr = new StreamReader(Server.MapPath("~/App_Data/department.json")))
            {
                json = sr.ReadToEnd();
                // List<Department> departments = JsonConvert.DeserializeObject<List<Department>>(json);
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSubDepartment(string Id)
        {
            List<SubDepartment> subDepartments = new List<SubDepartment>();
            string json = "";
            using (StreamReader sr = new StreamReader(Server.MapPath("~/App_Data/sub_department.json")))
            {
                json = sr.ReadToEnd();
                subDepartments = JsonConvert.DeserializeObject<List<SubDepartment>>(json);
            }

            int intId = 0;
            bool conversionSuccessful = int.TryParse(Id, out intId);
            if (conversionSuccessful)
            {
                var x = from b in subDepartments
                        where b.ParentId == Convert.ToInt32(Id)
                        select b;

                json = new JavaScriptSerializer().Serialize(x);

            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}