using System;
using System.ComponentModel.Design;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

string[] students = new string[10];
students[0] = "Alisa";
students[1] = "Leha";
students[2] = "Dina";

string[] groups = new string[5];
groups[0] = "BK-22-1";
groups[1] = "ISTb-22-2";
groups[2] = "Asub-22-1";

string[,] groupAndStudents = new string[students.Length, groups.Length];

while (true)
{
    ShowMenu();

    string choice = Console.ReadLine();
    Console.WriteLine("");

    switch (choice)
    {

        case "1":
            Console.Write("Введите имя студента: ");
            AddStudAndGrup(students, "студент");
            break;

        case "2":
            UniversalWrite(students, "студенты");
            break;
        case "3":
            Console.Write("Введите курс:");
            AddStudAndGrup(groups, "курс") ;
            break;
        case "4":
            UniversalWrite(groups, "группы");
            break;
        case "5":
            WriteStudent();
            break;

        case "6":
            StudentsGroup();
            break;

        case "7":
            RemoveStudents();
            break;

        case "8":
            RemoveGroups();
            break;

        case "9":
            LeaveStudGroup();
            break;
        case "10":
            SearchStudent();
            Console.WriteLine("");

            break;
        case "11":
            return;

        default:
            Console.WriteLine("Ошибка. Введите цифру от 1 до 11");
            break;

    }
}

void ShowMenu(){
    Console.WriteLine("");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("Меню:");
    Console.WriteLine("1.Добавить студента");
    Console.WriteLine("2.Показать всех студентов");
    Console.WriteLine("3.Добавить курс");
    Console.WriteLine("4.Показать курс");
    Console.WriteLine("5.Записать студента на курс");
    Console.WriteLine("6.Показать студентов курса");
    Console.WriteLine("7.Удалить студента");
    Console.WriteLine("8.Удалить курс");
    Console.WriteLine("9.Снятие студента с курса");
    Console.WriteLine("10.Поиск студента по имени");

    Console.WriteLine("11.Выход");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.Write("Выбрать опциию > ");
}

string[] UniversalWrite(string[] array, string entityType)
{
    Console.WriteLine($"{entityType}: ");

    foreach (string Univer in array)
    {
        if (Univer != null)
            Console.WriteLine(Univer);
    }
    return array;
}

string[] AddStudAndGrup(string[] array, string entityType)
{
    string gr = Console.ReadLine();

    for (int i = 0; i < array.Length; i++)
        if (array[i] == null)
        {
            array[i] = gr;
            break;
        }

    Console.WriteLine($"Доблен(а) {entityType}: {gr} ");


    return array;
}

void WriteStudent()
{
    int studentID = GetValidId(students, "Студента");
    if (studentID == -1) return;

    Console.WriteLine("");
    int GroupID = GetValidId(groups, "Курса");
    if (GroupID == -1) return;

    groupAndStudents[studentID, GroupID] = $"{students[studentID]} {groups[GroupID]}";
    Console.WriteLine($"Студент {students[studentID]} записан на курс {groups[GroupID]} ");
}

void StudentsGroup()
{
    Console.WriteLine("Студенты записанные на курс:");
    foreach (string groupAndStudent in groupAndStudents)
    {
        if (groupAndStudent != null)
            Console.WriteLine(groupAndStudent.ToString());

    }
}

void RemoveStudents()
{

    students = RemoveSearch(students, "студента");

}

void RemoveGroups()
{

    groups = RemoveSearch(groups,"группы");

}
// Удаление студентов и курсов
string[] RemoveSearch(string[] array, string entityType)
{
    ShowList(array, entityType);


    Console.Write($"Введите номер {entityType}: ");

    int st = int.Parse(Console.ReadLine());

    st -= 1;
    Console.WriteLine("Удален: " + array[st]);

    string[] newArray = new string[array.Length - 1];

    for (int i = 0, j = 0; i < array.Length; i++)
    {
        if (i != st)
        {
            newArray[j] = array[i];
            j++;
        }
    }
    return newArray;

}

void LeaveStudGroup()
{
    Console.WriteLine("Снятие студента с курса");
    foreach (string groupAndStudent in groupAndStudents)
    {
        if (groupAndStudent != null)
            Console.WriteLine(groupAndStudent.ToString());

    }

    Console.Write("Введите студента:");
    int stGr = int.Parse(Console.ReadLine());
    Console.WriteLine(stGr);
    stGr -= 1;


    string[,] newArray = new string[groupAndStudents.GetLength(0) - 1, 2];

    for (int i = 0, j = 0; i < groupAndStudents.GetLength(0); i++)
    {
        if (i != stGr)
        {
            newArray[j, 0] = groupAndStudents[i, 0];
            newArray[j, 1] = groupAndStudents[i, 1];
            j++;
        }
    };
    groupAndStudents = newArray;
}

void SearchStudent()
{
    Console.WriteLine("Кого найти?");

    string poick = Console.ReadLine();

    foreach (string student in students)
    {
        if (student == poick)
        {
            Console.WriteLine("Найден(a): " + student);
            Console.WriteLine("Участие в курсах:");
            for (int i = 0; i < groupAndStudents.GetLength(0); i++)
            {
                for (int j = 0; j < groupAndStudents.GetLength(1); j++)
                {
                    if (groups != null)
                    {
                        Console.WriteLine(groupAndStudents[i, j]);
                        break;
                    }
                    break;
                }
                break;
            }
        }
        else
        {
            Console.WriteLine("Нет совпадений");
        }
        break;
    }
}

int GetValidId(string[] array,string entityType) 
{
    ShowList(array, entityType);

    Console.Write($"Выберете ID {entityType}:");
    
    if (int.TryParse(Console.ReadLine(), out int id) && id>=0 && id<array.Length && array[id] != null)
    {
        return id;
    }
    Console.WriteLine("Ошибка: id некорректно");
    return -1;
}

void ShowList(string[] array,string entityType)
{
    Console.WriteLine($"Список {entityType}: ");
    foreach(string showlist in array)
    {
        if (showlist != null)
        {
            Console.WriteLine($"{showlist}");

        }
    }
}