using CSharpComposition1.Entities;
using CSharpComposition1.Entities.Enums;
using System.Globalization;

Console.Write("Enter department's name: ");
string deptName = Console.ReadLine();
Console.WriteLine();

Console.WriteLine("Enter worker data:");
Console.WriteLine();

Console.Write("Name: ");
string name = Console.ReadLine();

//instanciacao e conversão de uma string para um enum
Console.Write("Level (Junior/MidLevel/Senior): ");
WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

Console.Write("Base salary: ");
double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
Console.WriteLine();

Console.Write("How many contracts to this worker?: ");
int n = int.Parse(Console.ReadLine());

Department dept = new Department(deptName);
Worker worker = new Worker(name, level, baseSalary, dept);

for(int i = 1; i <= n; i++)
{
    Console.WriteLine($"Enter #{i} contract data:");

    Console.Write("Date (DD/MM/YYYY): ");
    DateTime date = DateTime.Parse(Console.ReadLine());

    Console.Write("Value per hour:  ");
    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Console.Write("Duration (hour): ");
    int hours = int.Parse(Console.ReadLine());

    //Adiciona uma lista de hourcontract com os valores digitados
    HourContract contract = new HourContract(date, valuePerHour, hours);
    worker.AddContract(contract);

    Console.WriteLine();
}

Console.Write("Enter month and year to calculate income (MM/YYYY): ");
string monthAndYear = Console.ReadLine();
Console.WriteLine();

//converte em número o pedaço da string e utiliza como mês
int month = int.Parse(monthAndYear.Substring(0, 2));

//converte em número da posição 3 em diante e utiliza como ano
int year = int.Parse(monthAndYear.Substring(3));

Console.WriteLine("Name: " + worker.Name);

//pega o nome do departamento direto do construtor por causa da associação
Console.WriteLine("Department: " + worker.Department.Name);

//utiliza o método income com os numeros recortados para somar o ganho com cada contrato no período escolhido
Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));