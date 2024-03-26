using BK.Model;
using BK.ViewModel;
using System.IO;

namespace BK.Services;

public class Loader
{
    public static List<RuleModel> LoadRules() => new List<RuleModel>
{
    new RuleModel
    {
        Symptoms = new List<string> { "Нарушение салоотделения", "Повышенная сальность_волос", "Поредение волос по всей части_головы", "Шелушение кожи" },
        Diagnisis = "алопеция"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Апатия", "Боли в суставах и мышцах", "Вялость", "Запоры", "Затоможенность", "Зябкость", "Понижение_аппетита", "Слабость", "Сонливость", "Утомляемость", "Ухудшение памяти" },
        Diagnisis = "гипотиреоз"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Жажда", "Снижение массы тела", "Отсутствие аппетита", "Раздражительность", "Утомляемость", "Сухость кожи", "Снижение потоотделения", "Нарушение функции желудочно кишечного тракта", "Бессонница" },
        Diagnisis = "диабет_несахарный"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Раздражительность", "Слабость", "Утомляемость", "Температура", "Бессонница", "Потливость", "Дрожание рук", "Боли в области сердца", "Учащенное сердцебиение", "Чувство давление и неловкости в облести шеи" },
        Diagnisis = "диффузный токсический зоб"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Избыточное отложение жира в области лица,шеи,туловища", "Кожа сухая,истонченная" },
        Diagnisis = "иценко кушинга болезнь"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Мышечная слабость", "Снижение массы тела", "Желудочно-кишечные_растройства", "Гиперпигменция кожных покровов лица,шеи,ладонных складок" },
        Diagnisis = "надпочечная_недостаточность"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Боль в области передней поверхности шеи", "Шейные лимфатические узлы увеличены", "Температура", "Озноб" },
        Diagnisis = "тиреоидит"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Избыточное отложение жира в области лица,шеи,туловища" },
        Diagnisis = "ожирение"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Сильные боли в суставах", "Озноб", "Температура" },
        Diagnisis = "подагра"
    },
    new RuleModel
    {
        Symptoms = new List<string> { "Жажда", "Сухость во рту", "Повышение аппетита", "Слабость", "Похудание", "Кожный зуд" },
        Diagnisis = "сахарный диабет"
    }
};

    internal static ICollection<SymptomModel> LoadSymptoms(int n)
    {
        switch (n)
        {
            case 1:
                return new List<SymptomModel>
{
    new SymptomModel { Name = "Боли в области сердца" },
    new SymptomModel { Name = "Сильные боли в суставах" },
    new SymptomModel { Name = "Учащенное сердцебиение" },
    new SymptomModel { Name = "Чувство давления и неловкости в облеста шеи" },
    new SymptomModel { Name = "Шейные лимфатические узлы увеличены" },
    new SymptomModel { Name = "Похудание" },
    new SymptomModel { Name = "Утомляемость" }
};
            case 2:
                return new List<SymptomModel>
{
    new SymptomModel { Name = "Бессонница" },
    new SymptomModel { Name = "Боль в области передней поверхности шеи" },
    new SymptomModel { Name = "Боли в суставах и мышцах" },
    new SymptomModel { Name = "Нарушение функции желудочно-кишечного тракта" },
    new SymptomModel { Name = "Повышенная сальность волос" },
    new SymptomModel { Name = "Сильные боли в суставах" },
    new SymptomModel { Name = "Раздражительность" }
};
            case 3:
                return new List<SymptomModel>
{
    new SymptomModel { Name = "Апатия" },
    new SymptomModel { Name = "Вялость" },
    new SymptomModel { Name = "Гиперпигментация кожных покровов лица, шеи, ладонных складок" },
    new SymptomModel { Name = "Дрожание рук" },
    new SymptomModel { Name = "Запоры" },
    new SymptomModel { Name = "Зябкость" },
    new SymptomModel { Name = "Избыточное отложение жира в области лица, шеи, туловища" },
    new SymptomModel { Name = "Кожа сухая, истонченная" },
    new SymptomModel { Name = "Кожный зуд" },
    new SymptomModel { Name = "Мышечная слабость" },
    new SymptomModel { Name = "Нарушение салоотделения" },
    new SymptomModel { Name = "Озноб" },
    new SymptomModel { Name = "Отсутствие аппетита" },
    new SymptomModel { Name = "Повышение аппетита" },
    new SymptomModel { Name = "Понижение аппетита" },
    new SymptomModel { Name = "Поредение волос по всей части головы" },
    new SymptomModel { Name = "Потливость" },
    new SymptomModel { Name = "Слабость" },
    new SymptomModel { Name = "Снижение массы тела" },
    new SymptomModel { Name = "Снижение потоотделения" },
    new SymptomModel { Name = "Сонливость" },
    new SymptomModel { Name = "Сухость во рту" },
    new SymptomModel { Name = "Сухость кожи" },
    new SymptomModel { Name = "Температура" },
    new SymptomModel { Name = "Ухудшение памяти" },
    new SymptomModel { Name = "Шелушение кожи" }
};
            default:
                throw new Exception("!!!!");
        }
    }
}
