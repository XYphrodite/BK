using BK.Commands;
using BK.Model;
using BK.Services;
using BK.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace BK.ViewModel;

public class DiagnosisVM : ViewModelBase
{
    private string _levelLabel;
    public string LevelLabel
    {
        get => _levelLabel;
        set
        {
            _levelLabel = value;
            OnPropertyChanged(nameof(LevelLabel));
        }
    }
    public ICollection<SymptomModel> Symptoms1 { get; set; } = new List<SymptomModel>();
    public ICollection<SymptomModel> Symptoms2 { get; set; } = new List<SymptomModel>();
    public ICollection<SymptomModel> Symptoms3 { get; set; } = new List<SymptomModel>();

    private ICollection<SymptomModel> _currentSymtoms = new List<SymptomModel>();
    public ICollection<SymptomModel> CurrentSymtoms
    {
        get => _currentSymtoms;
        set
        {
            _currentSymtoms = value;
            OnPropertyChanged(nameof(CurrentSymtoms));
        }
    }

    private string _output;

    public string Output
    {
        get => _output;
        set { 
            _output = value;
            OnPropertyChanged(nameof(Output));
        }
    }


    public ICollection<RuleModel> Rules { get; set; }

    public DiagnosisVM()
    {
        Rules = Loader.LoadRules();
        CurrentSymtoms = Loader.LoadSymptoms(3);
        Next = new RelayCommand(execute => next());

        LevelLabel = $"Симптомы";
    }


    public ICommand Next { get; }

    public void next()
    {

    }

    //private void next()
    //{
    //    Output = string.Empty;
    //    switch (LevelNum)
    //    {
    //        case 1:
    //            Symptoms1 = CurrentSymtoms;
    //            break;
    //        case 2:
    //            Symptoms2 = CurrentSymtoms;
    //            break;
    //        case 3:
    //            Symptoms3 = CurrentSymtoms;
    //            break;
    //        default:break;
    //    }



    //    //set diagnisis
    //    List<string> mySymptoms = new List<string>();
    //    foreach (var item in Symptoms1.Where(s => s.IsChecked))
    //        mySymptoms.Add(item.Name);
    //    foreach (var item in Symptoms2.Where(s => s.IsChecked))
    //        mySymptoms.Add(item.Name);
    //    foreach (var item in Symptoms3.Where(s => s.IsChecked))
    //        mySymptoms.Add(item.Name);


    //    foreach(var rule in Rules)
    //    {
    //        var symptoms = rule.Symptoms.Where(mySymptoms.Contains).ToList();
    //        double percent = (double)symptoms.Count / (double)rule.Symptoms.Count;
    //        if (percent != 0)
    //            Output += $"Вероятность = {Math.Round(percent, 2) * 100}%" + Environment.NewLine + $"{rule.Diagnisis} = " + Environment.NewLine+ Environment.NewLine;
    //    }

        
    //    if (LevelNum >= 3)
    //    {
    //        MessageBox.Show("Окончательный диагноз");
    //        return;
    //    }
    //    else
    //    {
    //        LevelNum++;
    //        LevelLabel = levelLabels[LevelNum];
    //        CurrentSymtoms = Loader.LoadSymptoms(LevelNum);
    //    }
    //}
}

