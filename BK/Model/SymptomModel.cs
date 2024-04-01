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
    public SymptomModel(string name, IEnumerable<SymptomModel> s)
    {
        Name = name;
        Symptoms = s.ToList();
    }
    public SymptomModel()
    {
        
    }
}
