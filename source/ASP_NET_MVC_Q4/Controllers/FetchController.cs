using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ASP_NET_MVC_Q4.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASP_NET_MVC_Q4.Controllers
{
    public class FetchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDepartment()
        {
            string jsonString = "";
            using (StreamReader sr = new StreamReader(Server.MapPath(@"~/App_Data/department.json")))
            {
                jsonString = sr.ReadToEnd();
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSubdepartment(string parentId)
        {
            string jsonString = "";
            List<Subdepartment> subdepartments = new List<Subdepartment>();
           
            using (StreamReader sr = new StreamReader(Server.MapPath(@"~/App_Data/sub_department.json")))
            {
                jsonString = sr.ReadToEnd();
                subdepartments = JsonConvert.DeserializeObject<List<Subdepartment >>(jsonString);
            }

            int intId = 0;
            bool conversionSuccessful = int.TryParse(parentId, out intId);
            if (conversionSuccessful)
            {
                var x = from b in subdepartments
                        where b.ParentId == Convert.ToInt32(parentId)
                        select b;

                jsonString = new JavaScriptSerializer().Serialize(x);

            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}