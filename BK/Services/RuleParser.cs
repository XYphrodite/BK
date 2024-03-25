using BK.Model;

namespace BK.Services;

public class RuleParser
{
    public static RuleModel Parse(string rule)
    {
        RuleModel model = new RuleModel();

        var words = rule.Split(' ');
        string lastWord = words[words.Count() - 1];
        model.Diagnisis = lastWord.Trim().Replace('_', ' ');
        for (int i = 1;i<words.Count() - 1; i++)
        {
            if (words[i] == "да" || words[i] == "=") continue;
            if (words[i] == "И" || words[i] == "ТО") continue;
            if (words[i] == "болезнь") continue;
            model.Symptoms.Add(words[i].Replace('_', ' '));
        }
        return model;
    }
}
