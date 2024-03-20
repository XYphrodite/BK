using BK.Model;
using System.IO;

namespace BK.Services;

public class Loader
{
    public static List<RuleModel> Load()
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data/rules.txt");
        string content;
        using (StreamReader reader = new StreamReader(path))
        {
            content = reader.ReadToEnd();
        }
        IEnumerable<string> strRules = content.Split('\n');
        List<RuleModel> rules = new List<RuleModel>();
        foreach (var item in strRules)
            rules.Add(RuleParser.Parse(item));
        return rules;
    }
}
