using System.Threading.Channels;

namespace Student 
{
//    Потрібно розробити консольну програму на C#, яка дозволить керувати списком студентів. Кожен студент має ім'я, прізвище, вік та середній бал. Програма повинна мати такі можливості:

//    Додавання нового студента до списку.
//    Видалення студента зі списку за його прізвищем.
//    Пошук студента за його прізвищем.
//    Виведення на екран усіх студентів у відсортованому порядку за прізвищем.
//    Обчислення середнього балу всіх студентів.
//    Завершення роботи програми.

//Використай LINQ to Objects для реалізації цих функцій. Не забудь про меню, яке дозволить користувачу вибирати потрібну опцію.

//Після створення програми, зроби кілька тестових випадків для перевірки її правильності.
    class Program
    {
        static void Main(string[] args)
        { 
            var students = new Dictionary<string, Student>();

            string commands;

            ListOfCommands();

            while (true) 
            {
                Console.Write("Введiть команду:");
                commands = Console.ReadLine();

                if (commands == "Stop")
                {
                    break;
                }
                switch (commands) 
                {
                    case "Add":
                        Console.Write("Введiть iм'я студента:");
                        string studentName = Console.ReadLine();

                        Console.Write("Введiть фамiлiю студента:");
                        string studentSurname = Console.ReadLine();

                        Console.Write("Введiть вiк студента:");
                        int studentAge = int.Parse(Console.ReadLine());

                        Console.Write("Введiть середнiй бал студента:");
                        int studentGPA = int.Parse(Console.ReadLine());

                        students.Add(studentSurname, new Student(studentName, studentSurname, studentAge, studentGPA));
                        break;
                    case "Remove":
                        Console.Write("Введiть фамілію студента котрого ви хочете видалити зі списку:");

                        string deletedStudentSurname = Console.ReadLine();

                        students.Remove(deletedStudentSurname);
                        break;
                    case "Print":
                        Console.Write("Введiть фамiлiю з котрою ви хочите вивести студентів: ");

                        string sortSurname = Console.ReadLine();

                        var sortStudents = from student in students where student.Key == sortSurname select student;

                        foreach (var item in sortStudents)
                        {
                            Console.WriteLine(item.Value.ToString());
                        }

                        break;
                    case "Print all":

                        var printStudents = (from student in students
                                             orderby student.Value.Surname
                                             select student);

                        foreach(var pSt in printStudents)
                            Console.WriteLine(pSt.Value.ToString());

                        break;
                    case"Print GPA":
                        int GPA = 0;
                        int num = 0;

                        foreach (var st in students) {
                            num++;

                            GPA += st.Value.GPA;
                        }

                        GPA /= num;

                        Console.WriteLine(GPA);

                        break;
                    case "Clear":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ви ввели не правильну команду.");

                        ListOfCommands();
                        break;
                }
            }
        }
        static void ListOfCommands()
        { 
            Console.WriteLine("Список команд:");
            Console.WriteLine("Add - додати студента до списку,");
            Console.WriteLine("Remove - видалити студента з списку,");
            Console.WriteLine("Print - вивести усіх студентів за фамілією,");
            Console.WriteLine("Print - вивести усіх студентів,");
            Console.WriteLine("Print GPA - виводить середній бал усіх студентів,");
            Console.WriteLine("Clear - очищує консоль,");
            Console.WriteLine("Stop - зупиняє роботу програми.");
        }
    }
    class Student 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int GPA { get; set; }

        public Student(string name, string surname, int age, int gPA)
        {
            Name = name;
            Surname = surname;
            Age = age;
            GPA = gPA;
        }

        public override string ToString() 
        {
            return $"Name:{Name}, Surname:{Surname}, Age:{Age}, GPA:{GPA}";
        }
    }
}
