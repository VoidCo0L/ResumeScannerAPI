using Microsoft.AspNetCore.Mvc;
using ResumeScannerAPI.Models;
using ResumeScannerAPI.Services;

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

            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();

            var results = _ruleEngine.Evaluate(content);

            return Ok(new
            {
                FileName = file.FileName,
                Results = results
            });
        }

    }
}
