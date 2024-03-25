using BK.Model;
using BK.ViewModel;
using System.IO;

namespace BK.Services;

public class Loader
{
    public static List<RuleModel> LoadRules()
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

    internal static ICollection<SymptomModel> LoadSymptoms(int n)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Data/S{n}.txt");
        string content;
        using (StreamReader reader = new StreamReader(path))
        {
            content = reader.ReadToEnd();
        }
        IEnumerable<string> strs = content.Split('\n');
        List<SymptomModel> symptoms = new List<SymptomModel>();
        foreach (var item in strs)
            symptoms.Add(new SymptomModel { Name = item.Trim()});
        return symptoms;
    }
}
