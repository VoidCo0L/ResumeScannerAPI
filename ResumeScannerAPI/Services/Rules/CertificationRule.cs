using ResumeScannerAPI.Models;

namespace ResumeScannerAPI.Services.Rules
{
    public class CertificationRule : IScoringRule
    {
        private readonly List<string> _certifications;

        public CertificationRule(List<string> certifications)
        {
            _certifications = certifications;
        }

        public string RuleName => nameof(CertificationRule);

        public ScoringResult Evaluate(string content)
        {
            var found = _certifications
                .Where(c => content.Contains(c, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new ScoringResult
            {
                RuleName = RuleName,
                Score = found.Count * 20,
                Matches = found
            };
        }
    }
}
