using System.Net.Http.Headers;

namespace LINQ_gyakorlas
{
    internal class Program
    {
        static void Normal()
        {
            List<int> nums = new List<int>
            {
                4, 12, 7, 25, 10, 18, 3
            };

            List<int> results = new List<int>();

            foreach (var item in nums)
            {
                if (item > 10)
                {
                    results.Add(item);
                }
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        static void LINQ()
        {
            List<int> nums = new List<int>
            {
                4, 12, 7, 25, 10, 18, 3
            };

            List<int> results = nums.Where(item => item > 10).ToList();

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        static void LINQ_MethodSyntax()
        {
            int[] nums = { 8, 3, 12, 5, 20, 7 };

            var result = nums.Where(item => item > 6).ToList().OrderBy(item => item);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void LINQ_OtherSyntax()
        {
            int[] nums = { 8, 3, 12, 5, 20, 7 };

            var result =
                from item in nums
                where item > 6
                orderby item
                select item;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            //LINQ_MethodSyntax(); // Lambda-kifejezések
            //LINQ_OtherSyntax(); // Ritkán használt kifejezés

            List<Student> students = File.ReadAllLines("students.csv")
                .Skip(1)
                .Select(line => line.Split(';'))
                .Select(parts => new Student(parts[0], int.Parse(parts[1]), parts[2], double.Parse(parts[3])))
                .ToList();

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            List<Student> results_1 = students
                .Where(item => item.Age >= 18 && item.Avg >= 4.0f)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("They are 18+ & have an avg. above 4.0: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in results_1)
            {
                Console.WriteLine(item);
            }

            List<Student> results_2 = students
                .Where(item => item.ClassId == "11A" || item.ClassId == "13A")
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("They are in 11A or 13A: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in results_2)
            {
                Console.WriteLine(item);
            }

            List<Student> results_3 = students
                .Where(item => item.ClassId != "12B")
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("They are NOT in 12B: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in results_3)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Get names of the students: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<string> results_4 = students
                .Select(item => item.Name)
                .ToList();

            foreach (var item in results_4)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Get the ages of the students, but doubled: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<int> results_5 = students
                .Select(item => item.Age * 2)
                .ToList();

            foreach (var item in results_5)
            {
                Console.WriteLine(item);
            }

        }
    }
}
