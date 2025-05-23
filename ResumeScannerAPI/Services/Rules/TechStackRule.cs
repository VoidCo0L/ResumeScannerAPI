using ResumeScannerAPI.Models;

namespace ResumeScannerAPI.Services.Rules
{
    // checks the presence of technologies from a list
    public class TechStackRule : IScoringRule
    {
        private readonly List<string> _technologies;

        public TechStackRule(List<string> technologies)
        {
            _technologies = technologies;
        }

        public string RuleName => nameof(TechStackRule);

        public ScoringResult Evaluate(string content)
        {
            var found = _technologies
                .Where(t => content.Contains(t, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new ScoringResult
            {
                RuleName = RuleName,
                Score = found.Count * 7,
                Matches = found
            };
        }
    }
}
