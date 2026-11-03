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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Get a new List of names and classIds (class list method): ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var results_6 = students
                .Select(item => new { item.Name, item.ClassId })
                .ToList();

            foreach (var item in results_6)
            {
                Console.WriteLine($"{item.Name} | {item.ClassId}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Get a new List of names and classIds (string list method): ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<string> results_7 = students
                .Select(item => $"{item.Name} | {item.ClassId}")
                .ToList();

            foreach (var item in results_7)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Get the names of students with an avg. above 4.0: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<string> results_8 = students
                .Where(item => item.Avg >= 4.0)
                .Select(item => item.Name)
                .ToList();

            foreach (var item in results_8)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Students ordered by age: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Student> results_9 = students
                .OrderBy(item => item.Age)
                .ToList();

            foreach (var item in results_9)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Students ordered by reverse avg.: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Student> results_10 = students
                .OrderByDescending(item => item.Avg)
                .ToList();

            foreach (var item in results_10)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Students ordered by classIds, then reverse ordered by avg.: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Student> results_11 = students
                .OrderBy(item => item.ClassId)
                .ThenByDescending(item => item.Avg)
                // Az első OrderBy után Then-t használunk
                .ToList();

            foreach (var item in results_11)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Top 3 students ordered by avg.: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Student> results_13 = students
                .OrderByDescending(item => item.Avg)
                .Take(3)
                .ToList();

            foreach (var item in results_13)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Exclude top 3 students ordered by avg.: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            List<Student> results_14 = students
                .OrderByDescending(item => item.Avg)
                .Skip(3)
                .ToList();

            foreach (var item in results_14)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("First student: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Student results_15 = students
                .First();
                // Inkább használjuk a FirstOrDefault-ot

            Console.WriteLine(results_15);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Find student named 'Ferenc': ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Student? results_16 = students
                .FirstOrDefault(item => item.Name == "Ferenc");

            Console.WriteLine(results_16);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("First student with an avg. above 4.5: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Student? results_17 = students
                .Where(item => item.Avg >= 4.5f)
                .FirstOrDefault();

            Console.WriteLine(results_17);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Last student: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Student? results_18 = students
                .LastOrDefault();

            Console.WriteLine(results_18);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Is there a student with an avg. above 4.5: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            bool results_19 = students
                .Any(item => item.Avg >= 4.5f);

            Console.WriteLine(results_19 ? "Yes, there is :)" : "No, there is not :(");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Are all the students 18+: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            bool results_20 = students
                .All(item => item.Avg >= 4.5f);

            Console.WriteLine(results_20 ? "Yes, they are :)" : "No, they are not :(");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Average age of all students: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            double results_21 = students
                .Average(item => item.Age);

            Console.WriteLine(results_21);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The worst avg.: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            double results_22 = students
                .Min(item => item.Avg);

            Console.WriteLine(results_22);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The oldest student's age: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            double results_23 = students
                .Max(item => item.Age);

            Console.WriteLine(results_23);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("List of classIds: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var results_24 = students
                .Select(item => item.ClassId)
                .Distinct();

            foreach (var item in results_24)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ClassIds and students: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var results_25 = students
                .GroupBy(item => item.ClassId);

            foreach (var item in results_25)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var subItem in item)
                {
                    Console.WriteLine($" {subItem}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ClassIds and student counts: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var results_26 = students
                .GroupBy(item => item.ClassId)
                .Select(item => new
                {
                    ClassId = item.Key,
                    People = item.Count()
                });

            foreach (var item in results_26)
            {
                Console.WriteLine($"{item.ClassId}: {item.People}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Added 'Zoltán' later to the list: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var results_27 = students
                .Where(item => item.Avg >= 4.0);

            students.Add(new Student("Zoltán", 18, "13A", 4.5f));

            foreach (var item in results_27)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Mennyi az osztályátlag az egyes osztályokban? ");
            Console.ForegroundColor = ConsoleColor.Gray;
            var task_1 = students
                .GroupBy(item => item.ClassId)
                .Select(item => new
                {
                    ClassId = item.Key,
                    Average = item.Average(subItem => subItem.Avg)
                });

            foreach (var item in task_1)
            {
                Console.WriteLine($"{item.ClassId}: {Math.Round(item.Average, 1)}");
            }
        }
    }
}
