using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using WebApplication8_PDF.Models;

namespace WebApplication8_PDF.Controllers;

[Route("[controller]")]
[Controller]
public class ReportController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ReportController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    }

    [HttpPost]
    public IActionResult Index(User user)
    {
        string mimetype = "";
        int extension = 1;
        var path = Path.Combine(_webHostEnvironment.WebRootPath, "Reports", "Report.rdlc");
        Dictionary<string, string?> parameters = user.ToDict();
        
        LocalReport localReport = new(path);
        var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);

        return File(result.MainStream, "application/pdf");
    }
}
