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

        [HttpPost("scan")]
        public IActionResult ScanResume([FromBody] Resume resume)
        {
            var results = _ruleEngine.Evaluate(resume.Content);
            return Ok(new { resume.Name, Results = results });
        }
    }
}
