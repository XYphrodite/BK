using BK.ViewModel;
using System.Windows;

namespace BK.View;

/// <summary>
/// Логика взаимодействия для Diagnosis.xaml
/// </summary>
public partial class Diagnosis : Window
{
    public Diagnosis()
    {
        InitializeComponent();
        DataContext = new DiagnosisVM();
    }
}
