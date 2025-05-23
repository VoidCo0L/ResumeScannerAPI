using ResumeScannerAPI.Models;

namespace ResumeScannerAPI.Services.Rules
{
    public class SoftSkillsRule : IScoringRule
    {
        private readonly List<string> _softSkills;

        public SoftSkillsRule(List<string> softSkills)
        {
            _softSkills = softSkills;
        }

        public string RuleName => nameof(SoftSkillsRule);

        public ScoringResult Evaluate(string content)
        {
            var found = _softSkills
                .Where(s => content.Contains(s, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new ScoringResult
            {
                RuleName = RuleName,
                Score = found.Count * 5,
                Matches = found
            };
        }
    }
}
