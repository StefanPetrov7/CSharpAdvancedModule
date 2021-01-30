using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> topStudent = new List<Student>();

            for (int i = 0; i < 30; i++)
            {
                topStudent.Add(new Student());
            }

            //topStudent = topStudent.OrderBy(x => x.Grade).ToList();

            int minIndex = 0;
            IComparer<Student> comparer = new StudentComparer();
            for (int i = 0; i < topStudent.Count; i++)
            {
                for (int j = i; j < topStudent.Count; j++)
                {
                    if (comparer.Compare(topStudent[minIndex], topStudent[j]) > 0) // ascending
                    {
                        minIndex = j;
                    }
                }

                Student temp = topStudent[minIndex];
                topStudent[minIndex] = topStudent[i];
                topStudent[i] = temp;
            }

            //topStudent.Sort(new StudentComparer());

            foreach (var student in topStudent)
            {
                Console.WriteLine($"{student.Name}--{student.Grade}");
            }
        }
    }
}
