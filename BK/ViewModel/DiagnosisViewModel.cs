using BK.Commands;
using BK.Model;
using BK.Services;
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
        Next = new RelayCommand(execute => next());

        LevelLabel = $"Симптомы";
    }


    public ICommand Next { get; }

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

