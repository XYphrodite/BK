using BK.Commands;
using BK.Model;
using BK.Services;
using BK.View;
using BK.ViewModels;
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

    private ICollection<RuleModel> _diagnisis = new List<RuleModel>();
    public ICollection<RuleModel> Diagnisis
    {
        get => _diagnisis;
        set
        {
            _diagnisis = value;
            OnPropertyChanged(nameof(Diagnisis));
        }
    }

    private string _output;

    public string Output
    {
        get => _output;
        set
        {
            _output = value;
            OnPropertyChanged(nameof(Output));
        }
    }


    public ICollection<RuleModel> Rules { get; set; }

    public DiagnosisVM()
    {
        Rules = Loader.LoadRules();
        CurrentSymtoms = Loader.LoadSymptoms(1);
        Diagnisis = Rules;
        Next = new RelayCommand(execute => next());
        D = new RelayCommand(execute => d());
        LevelLabel = $"Симптомы";
    }


    public ICommand Next { get; }
    public ICommand D { get; }

    public void next()
    {
        Output = string.Empty;
        //set diagnisis
        List<SymptomModel> mySymptoms =
        [
            //1
            .. CurrentSymtoms.Where(s => s.IsChecked),
        ];
        foreach (var s in mySymptoms)
        {
            Output += "Вы выбрали " + s.Name + Environment.NewLine;
        }
        //2
        foreach (var item in Loader.LoadSymptoms(2))
        {
            bool h = true;
            foreach (var s in item.Symptoms)
            {
                if (!mySymptoms.Any(o => o.Name == s.Name))
                    h = false;
            }
            if (h)
            {
                Output += "Обнаружение " + item.Name + " как вторичного симптома" + Environment.NewLine;
                mySymptoms.Add(item);
            }
        }
        //3
        foreach (var item in Loader.LoadSymptoms(3))
        {
            bool h = true;
            foreach (var s in item.Symptoms)
            {
                if (!mySymptoms.Any(o => o.Name == s.Name))
                    h = false;
            }
            if (h)
            {
                Output += "Обнаружение " + item.Name + " как третичного симптома" + Environment.NewLine;
                mySymptoms.Add(item);
            }
        }
        Output += Environment.NewLine;

        foreach (var rule in Rules)
        {
            int a = 0;
            foreach (var symptom in rule.Symptoms)
            {
                if (mySymptoms.Any(s => s.Name == symptom))
                    a++;
            }

            double percent = a / (double)rule.Symptoms.Count;
            if (percent != 0)
                Output += $"{rule.Diagnisis}" + Environment.NewLine + $"Вероятность = {Math.Round(percent, 2) * 100}%" + Environment.NewLine;
        }
    }

    public void d()
    {
        Output = string.Empty;
        var symptioms = new List<SymptomModel>();
        //find illness
        foreach (var item in Diagnisis)
        {
            if (item.IsChecked)
            {
                // 3
                var s3 = Loader.LoadSymptoms(3);
                foreach (var symptom in s3)
                {

                }
                // 2 
                var s2 = Loader.LoadSymptoms(2);
                item.Symptoms.ForEach(_s =>
                {
                    var s_2 = s2.FirstOrDefault(s => s.Name == _s);
                    if (s_2 != null)
                    {
                        symptioms.Add(s_2);
                        symptioms.AddRange(s_2.Symptoms);
                    }
                });
                // 1
                var s1 = Loader.LoadSymptoms(1);
                item.Symptoms.ForEach(_s =>
                {
                    var s_1 = s1.FirstOrDefault(s => s.Name == _s);
                    if (s_1 != null)
                    {
                        symptioms.Add(s_1);
                    }
                });
                break;
            }
        }
        CurrentSymtoms = symptioms;
    }
}

