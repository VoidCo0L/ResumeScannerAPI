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

        public Dictionary<string, int> Evaluate(string content)
        {
            var results = new Dictionary<string, int>();

            foreach (var rule in _rules)
            {
                results.Add(rule.RuleName, rule.CalculateScore(content));
            }

            return results;
        }
    }
}
