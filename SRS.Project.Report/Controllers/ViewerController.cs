using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Mvc;
using System.Data;
using Stimulsoft.Report;
using SRS.Project.Report.Model;
using System.Net.Http.Headers;
using System.Net;
using SRS.Project.Report.Services;
using Newtonsoft.Json;

namespace SRS.Project.Report.Controllers
{
    public class ViewerController : Controller
    {
        // GET: View
        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult GetReport([FromQuery] string orderId, string templateName)
        {
            // Create the report object and load data from xml file
            var report = new StiReport();
            var result2 = new Invoice();
            //var report = StiNetCoreDesigner.GetActionReportObject(this);
            if(orderId != null)
            {
                var result = GetData.FetchData(orderId);
                result2 = JsonConvert.DeserializeObject<Invoice>(result);
            }
            
            // Load report from MDZ document file
            // If not found - load from MRT template
            if (!string.IsNullOrWhiteSpace(templateName))
            {
               
               
                report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/ReportTemplates/" + templateName + ".mrt"));
                report.RegData("invoice", result2);
            }
            else
                report.RegData("invoice", new Invoice());

            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }

        public IActionResult Design(string id)
        {
            return RedirectToAction("Reports", "Design", new { id });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}