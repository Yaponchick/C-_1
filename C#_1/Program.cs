using System;
using System.ComponentModel.Design;

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

    string choice = Console.ReadLine();
    Console.WriteLine("");

    switch (choice)
    {

        case "1":
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] == null)
                {
                    students[i] = name;
                    Console.WriteLine("Добавлен(а): " + name);
                    break;
                    
                }
            }
            break;

        case "2":
            Console.WriteLine("Студенты:");
            foreach (string student in students)
            {
                if (student != null)
                    Console.WriteLine(student);
            }
            break;

        case "3":
            Console.Write("Введите курс:");
            string gr = Console.ReadLine();

            for (int i = 0; i < groups.Length; i++)
                if (groups[i] == null)
                {
                    groups[i] = gr;
                    Console.WriteLine("Добавлен курс: " + gr);
                    break;
                }
            break;
        case "4":
            Console.WriteLine("Курсы:");
            foreach (string group in groups)
            {
                if (group != null)
                    Console.WriteLine(group);
            }
            break;
        case "5":
            Console.WriteLine("Студенты:");
            foreach (string student in students)
            {
                if (student != null)
                    Console.WriteLine(student);
                
            }
            Console.WriteLine("");

            Console.Write("Введите студента:");
            int s = int.Parse(Console.ReadLine());
            s -= 1;
            Console.WriteLine("");
            Console.WriteLine("Вы выбрали студента: " + students[s]);
            Console.WriteLine("");

            Console.WriteLine("Группы:");
            foreach (string group in groups)
            {
                if (group != null)
                    Console.WriteLine(group);
                
            }

            Console.Write("Введите группу:");
            int g = int.Parse(Console.ReadLine());
            Console.WriteLine(g);
            g -= 1;
            Console.WriteLine("");
            Console.WriteLine("Вы выбрали группу: " + groups[g]);
            Console.WriteLine("");

            if (students[s] != null && groups[g] != null)
            {
                groupAndStudents[s, g] = $"{students[s]} {groups[g]}";
                Console.WriteLine($"Студент {students[s]} записан на курс { groups[g]} ");
            }
            break;

        case "6":
            Console.WriteLine("Студенты записанные на курс:");
            foreach(string groupAndStudent in groupAndStudents)
            {
                if (groupAndStudent != null)
                    Console.WriteLine(groupAndStudent.ToString());
                
            }
            break;

        case "7":
            Console.WriteLine("Кого отчисляем?");
            foreach (string student in students)
            {
                if (student != null)
                    Console.WriteLine(student);
            }
            Console.Write("Введите студента:");
            int st = int.Parse(Console.ReadLine());
            
            st -= 1;
            Console.WriteLine("Отчислили: " + students[st]);

            string[] newStudents = new string[students.Length - 1];

            for (int i = 0, j = 0; i < students.Length; i++)
            {
                if (i != st)
                {
                    newStudents[j] = students[i];
                    j++;
                }
            }

            students = newStudents;
            break;

        case "8":
            Console.WriteLine("Какой курс удаляем?");
            foreach (string group in groups)
            {
                if (group != null)
                    Console.WriteLine(group);
            }
            Console.Write("Введите группу:");
            int grp = int.Parse(Console.ReadLine());
            
            grp -= 1;

            Console.WriteLine("Удалили: " + groups[grp]);

            string[] newGroups = new string[groups.Length - 1];

            for (int i = 0, j = 0; i < groups.Length; i++)
            {
                if (i != grp)
                {
                    newGroups[j] = groups[i];
                    j++;
                }
            }

            groups = newGroups;
            break;

        case "9":
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
            break;
        case "10":
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
                                Console.Write(groupAndStudents[i, j]);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Нет совпадений");
                }
                break;
            }
            Console.WriteLine("");

            break;
        case "11":
            return;

        default:
            Console.WriteLine("Ошибка. Введите цифру от 1 до 11");
            break;

    }
}