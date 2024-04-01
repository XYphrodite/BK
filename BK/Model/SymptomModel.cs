namespace BK.Model;

public class SymptomModel
{
    public string Name { get; set; }
    public bool IsChecked { get; set; }

    public ICollection<SymptomModel> Symptoms { get; set; }

    public SymptomModel(string name)
    {
        Name = name;
    }
    public SymptomModel(string name, params string[] args)
    {
        Name = name;
        Symptoms = new List<SymptomModel>();
        foreach (var item in args)
        {
            Symptoms.Add(new SymptomModel(item));
        }
    }
    public SymptomModel()
    {
        
    }
}
