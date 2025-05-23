using Microsoft.AspNetCore.Mvc;
using ResumeScannerAPI.Services;
using System.Text;
using UglyToad.PdfPig;

namespace ResumeScannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly RuleEngineService _ruleEngine;

        public ResumeController(RuleEngineService ruleEngine)
        {
            _ruleEngine = ruleEngine;
        }

        [HttpPost("scan-file")]
        public async Task<IActionResult> ScanResumeFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            string content = string.Empty;
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (extension == ".txt")
            {
                using var reader = new StreamReader(file.OpenReadStream());
                content = await reader.ReadToEndAsync();
            }
            else if (extension == ".pdf")
            {
                using var pdfStream = file.OpenReadStream();
                using var pdfDocument = PdfDocument.Open(pdfStream);

                var text = new StringBuilder();
                foreach (var page in pdfDocument.GetPages())
                {
                    text.AppendLine(page.Text);
                }

                content = text.ToString();
            }
            else
            {
                return BadRequest("Unsupported file type. Only .txt and .pdf are allowed.");
            }

            var results = _ruleEngine.Evaluate(content);

            return Ok(new
            {
                FileName = file.FileName,
                Results = results,
                EvaluatedAgainst = new
                {
                    Keywords = new List<string> { "C#", "ASP.NET", "React", "SQL", "Microservices", "Blazor", "REST API", "Unit Testing" },
                    TechStack = new List<string> { "JavaScript", "Docker", "Kubernetes", "Azure", "Entity Framework", "RabbitMQ", "GraphQL", "TypeScript" },
                    Degrees = new List<string> { "Computer Science", "Software Engineering", "IT" },
                    SoftSkills = new List<string> { "Team player", "Agile", "Problem-solving", "Communication" },
                    Certifications = new List<string> { "Azure Fundamentals", "AWS Certified", "Scrum Master", "MCSD" }
                }
            });

        }
    }
}
