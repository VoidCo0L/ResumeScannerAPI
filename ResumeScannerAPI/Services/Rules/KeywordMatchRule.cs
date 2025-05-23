using System.Text.RegularExpressions;

namespace ResumeScannerAPI.Services.Rules
{
    public class KeywordMatchRule : IScoringRule
    {
        private readonly List<string> _keywords;

        public string RuleName => "Keyword Match Rule";

        public KeywordMatchRule(List<string> keywords)
        {
            _keywords = keywords;
        }

        public int CalculateScore(string content)
        {
            int score = 0;
            foreach (var keyword in _keywords)
            {
                if (Regex.IsMatch(content, $@"\b{keyword}\b", RegexOptions.IgnoreCase))
                {
                    score += 10;
                }
            }
            return score;
        }
    }
}
