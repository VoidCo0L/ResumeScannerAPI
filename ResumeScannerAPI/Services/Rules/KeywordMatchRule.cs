using ResumeScannerAPI.Models;

namespace ResumeScannerAPI.Services.Rules
{
    public class KeywordMatchRule : IScoringRule
    {
        private readonly List<string> _keywords;

        public KeywordMatchRule(List<string> keywords)
        {
            _keywords = keywords;
        }

        public string RuleName => nameof(KeywordMatchRule);

        public ScoringResult Evaluate(string content)
        {
            var found = _keywords
                .Where(k => content.Contains(k, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new ScoringResult
            {
                RuleName = RuleName,
                Score = found.Count * 10,
                Matches = found
            };
        }
    }
}
