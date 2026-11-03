using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_gyakorlas
{
    internal class Student
    {
        private string name;
        private int age;
        private string classId;
        private int avg;

        public Student(string name, int age, string classId, int avg)
        {
            Name = name;
            Age = age;
            ClassId = classId;
            Avg = avg;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string ClassId { get => classId; set => classId = value; }
        public int Avg { get => avg; set => avg = value; }
    }
}
