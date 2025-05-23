using ResumeScannerAPI.Models;
using ResumeScannerAPI.Services.Rules;

namespace ResumeScannerAPI.Services
{
    public class RuleEngineService
    {
        private readonly List<IScoringRule> _rules;

        public RuleEngineService(List<IScoringRule> rules)
        {
            _rules = rules;
        }

        public List<ScoringResult> Evaluate(string content)
        {
            var results = new List<ScoringResult>();

            foreach (var rule in _rules)
            {
                var result = rule.Evaluate(content);
                results.Add(result);
            }

            return results;
        }
    }
}
