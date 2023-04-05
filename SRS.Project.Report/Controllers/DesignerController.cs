using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace SRS.Project.Report.Controllers
{
    public class DesignerController : Controller
    {
        private static string _fileName;
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult GetReport([FromQuery] string templateName)
        {
            var report = new StiReport();
            _fileName = templateName ?? null;
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
            var path = "wwwroot/ReportTemplates/" + _fileName;
            if (System.IO.File.Exists(path))
            {
                var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Write);
                stream.Close();
            }
            report.SaveReportInResources = true;
            report.Save(path);

            // Completion of the report saving without dialog box
            return StiNetCoreDesigner.SaveReportResult(this);
        }

        public IActionResult OpenReport()
        {
            StiReport report = StiNetCoreDesigner.GetActionReportObject(this);
            //report.SaveReportInResources = false;
            _fileName = report.ReportFile;

            return StiNetCoreDesigner.GetReportResult(this, report);
        }
        public IActionResult PreviewReport()
        {
            // Get the report template
            var report = StiNetCoreDesigner.GetActionReportObject(this);

            //// Register data, if necessary           

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
