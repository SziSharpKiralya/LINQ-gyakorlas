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
        private double avg;

        public Student(string name, int age, string classId, double avg)
        {
            Name = name;
            Age = age;
            ClassId = classId;
            Avg = avg;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string ClassId { get => classId; set => classId = value; }
        public double Avg { get => avg; set => avg = value; }

        public override string ToString()
        {
            return $"{Name} - {Age} | Class:{ClassId} Avg:{Avg}";
        }
    }
}
