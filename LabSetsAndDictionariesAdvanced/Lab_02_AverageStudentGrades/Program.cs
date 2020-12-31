using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_02_AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>(n);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (students.ContainsKey(name) == false)
                {
                    students.Add(name, new List<decimal>());
                }
                students[name].Add(grade);
            }

            foreach (var student in students)
            {
                StringBuilder grades = new StringBuilder();

                for (int i = 0; i < student.Value.Count; i++)
                {
                    grades.Append($"{student.Value[i]:f2}" + " ");
                }
                Console.WriteLine($"{student.Key} -> {grades}(avg: {student.Value.Average():f2})");
            }
        }
    }
}
