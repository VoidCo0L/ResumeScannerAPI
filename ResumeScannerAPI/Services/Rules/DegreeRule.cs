using ResumeScannerAPI.Models;

namespace ResumeScannerAPI.Services.Rules
{
    public class DegreeRule : IScoringRule
    {
        private readonly List<string> _degrees;

        public DegreeRule(List<string> degrees)
        {
            _degrees = degrees;
        }

        public string RuleName => nameof(DegreeRule);

        public ScoringResult Evaluate(string content)
        {
            var found = _degrees
                .Where(d => content.Contains(d, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new ScoringResult
            {
                RuleName = RuleName,
                Score = found.Count * 15,
                Matches = found
            };
        }
    }
}
