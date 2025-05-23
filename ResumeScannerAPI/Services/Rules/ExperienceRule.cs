using System.Text.RegularExpressions;
using ResumeScannerAPI.Models;

namespace ResumeScannerAPI.Services.Rules
{
    public class ExperienceRule : IScoringRule
    {
        public string RuleName => nameof(ExperienceRule);

        public ScoringResult Evaluate(string content)
        {
            var matches = Regex.Matches(content, @"(\d+)\s*(\+)?\s*(years|yrs)", RegexOptions.IgnoreCase);
            var yearsList = matches.Select(m => m.Value).ToList();

            int totalYears = matches.Sum(m => int.Parse(m.Groups[1].Value));
            int score = totalYears * 5;

            return new ScoringResult
            {
                RuleName = RuleName,
                Score = score,
                Matches = yearsList
            };
        }
    }
}
