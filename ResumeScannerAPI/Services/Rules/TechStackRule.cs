using System.Text.RegularExpressions;

namespace ResumeScannerAPI.Services.Rules
{
    // checks the presence of technologies from a list
    public class TechStackRule : IScoringRule
    {
        private readonly List<string> _techStack;

        public string RuleName => "Tech Stack Match Rule";

        public TechStackRule(List<string> techStack)
        {
            _techStack = techStack;
        }

        public int CalculateScore(string content)
        {
            int score = 0;
            foreach (var tech in _techStack)
            {
                if (Regex.IsMatch(content, $@"\b{tech}\b", RegexOptions.IgnoreCase))
                {
                    score += 8;
                }
            }
            return score;
        }
    }
}
