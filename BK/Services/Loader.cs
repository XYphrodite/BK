using BK.Model;

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

    public static ICollection<SymptomModel> LoadSymptoms(int n)
    {
        switch (n)
        {
            case 3:
                return new List<SymptomModel>
{
    new SymptomModel("Боли в области сердца","Мышечная слабость","Учащенное сердцебиение"),//
    new SymptomModel ("Чувство давления и неловкости в облеста шеи", "Боль в области передней поверхности шеи","Шейные лимфатические узлы увеличены" ),//
    new SymptomModel ("Утомляемость","Апатия", "Учащенное сердцебиение"),//
    new SymptomModel ("Нарушение салоотделения","Поредение волос по всей части головы","Апатия"),
    new SymptomModel ("Нарушение функции желудочно-кишечного тракта", "Запоры","Снижение массы тела"),//
    new SymptomModel ("Боли в суставах и мышцах", "Сильные боли в суставах","Мышечная слабость"), //
};
            case 2:
                return new List<SymptomModel>
{
    new SymptomModel ("Боль в области передней поверхности шеи", "Избыточное отложение жира в области лица, шеи, туловища","Гиперпигментация кожных покровов лица, шеи, ладонных складок"),//
    new SymptomModel ("Раздражительность","Ухудшение памяти", "Кожный зуд"),//
    new SymptomModel ("Снижение массы тела", "Понижение аппетита","Похудание"),//
    new SymptomModel ("Озноб", "Потливость","Температура"), //
    new SymptomModel ("Мышечная слабость","Слабость","Вялость" ), //
    new SymptomModel ("Апатия","Вялость","Ухудшение памяти"),//
    new SymptomModel ("Снижение потоотделения", "Сухость кожи","Зябкость" ),//
};
            case 1:
                return new List<SymptomModel>
{
                        new SymptomModel ("Учащенное сердцебиение"),
    new SymptomModel ("Сильные боли в суставах"),
    new SymptomModel ("Шейные лимфатические узлы увеличены"),
    new SymptomModel ("Повышенная сальность волос"),
    new SymptomModel ("Отсутствие аппетита"),
    new SymptomModel ("Ухудшение памяти"),
    new SymptomModel ("Вялость"),
    new SymptomModel ("Гиперпигментация кожных покровов лица, шеи, ладонных складок")   ,
    new SymptomModel ("Дрожание рук"),
    new SymptomModel ("Запоры"),
    new SymptomModel ("Зябкость"),
    new SymptomModel ("Избыточное отложение жира в области лица, шеи, туловища"),
    new SymptomModel ("Кожа сухая, истонченная"),
    new SymptomModel ("Кожный зуд"),
    new SymptomModel ("Повышение аппетита"),
    new SymptomModel ("Понижение аппетита"),
    new SymptomModel ("Поредение волос по всей части головы"),
    new SymptomModel ("Потливость"),
    new SymptomModel ("Слабость")   ,
    new SymptomModel ("Сонливость"),
    new SymptomModel ("Сухость во рту"),
    new SymptomModel ("Сухость кожи"),
    new SymptomModel ("Температура"),
    new SymptomModel ("Бессонница"),
    new SymptomModel ("Шелушение кожи"),
    new SymptomModel ("Похудание"),
};
            default:
                throw new Exception("!!!!");
        }
    }
}
