using BK.Model;
using BK.Services;
using BK.ViewModels;

namespace BK.ViewModel;

public class DiagnosisVM : ViewModelBase
{
    public ICollection<SymptomModel> Symptoms { get; set; } = new List<SymptomModel>();
    public ICollection<RuleModel> Rules { get; set; }
    public DiagnosisVM()
    {
        Rules = Loader.Load();
        var s = Rules.SelectMany(r => r.Symptoms).Distinct().ToList();
        s.ForEach(o => Symptoms.Add(new SymptomModel { Name = o }));
    }
}

public class SymptomModel
{
    public string Name { get; set; }
}