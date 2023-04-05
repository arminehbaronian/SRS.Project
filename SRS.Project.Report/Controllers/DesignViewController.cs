using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SRS.Project.Report.Model;
using SRS.Project.Report.Services;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;

namespace SRS.Project.Report.Controllers
{
    public class DesignViewController : Controller
    {
        private static string _fileName;
        private static string _orderId;
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult GetReport([FromQuery] string templateName, string orderId)
        {
            var report = new StiReport();
            _fileName = templateName ?? null;
            _orderId = orderId ?? null;
            if (templateName != null)
                _fileName = templateName + ".mrt";


            report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/ReportTemplates/" + _fileName));

            return StiNetCoreDesigner.GetReportResult(this, report);
        }

        public IActionResult SaveReport()
        {
            var report = StiNetCoreDesigner.GetReportObject(this);

            // string packedReport = report.SavePackedReportToString();
            // ...
            // The save report code here
            // ...
           
            // Completion of the report saving without dialog box
            return StiNetCoreDesigner.SaveReportResult(this);
        }

        
        public IActionResult PreviewReport()
        {
            // Get the report template
            var report = StiNetCoreDesigner.GetActionReportObject(this);

            //// Register data, if necessary           
           
            var result = GetData.FetchData(_orderId);
            var result2 = JsonConvert.DeserializeObject<Invoice>(result);

            // Registering data in the report
            report.RegData("invoice", result2);
            // Return the report snapshot result to the client
            return StiNetCoreDesigner.PreviewReportResult(this, report);
        }

        public IActionResult DesignerEvent()
        {
            return StiNetCoreDesigner.DesignerEventResult(this);
        }

        public IActionResult ExitDesigner(string id)
        {
            return RedirectToAction("Reports", "View", new { id });
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
