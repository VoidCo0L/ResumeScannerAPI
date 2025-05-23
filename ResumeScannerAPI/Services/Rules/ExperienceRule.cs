using System.Text.RegularExpressions;

namespace ResumeScannerAPI.Services.Rules
{
    public class ExperienceRule : IScoringRule
    {
        public string RuleName => "Years of Experience Rule";

        public int CalculateScore(string content)
        {
            //using Regex to find "X years" or "X+ years" patterns
            var match = Regex.Match(content, @"(\d+)\s*(\+)?\s*years?", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                int years = int.Parse(match.Groups[1].Value);
                return years * 5; // 5 points per year
            }
            return 0;
        }
    }
}
