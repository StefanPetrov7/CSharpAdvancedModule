using System.Text;
using static Practice2024.Miner_2024;

namespace Practice2024
{
    internal class Miner_2024
    {
        static void Main(string[] args)
        {

            Dictionary<string, Contest> contests = new Dictionary<string, Contest>();
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            string input;

            while ((input = Console.ReadLine()).TrimEnd() != "end of contests")
            {
                string[] tokens = input.Split(":");
                string contestName = tokens[0];
                string password = tokens[1];

                Contest contest = new Contest(contestName, password);

                if (contests.ContainsKey(contestName) == false)
                {
                    contests.Add(contestName, contest);
                }
            }


            while ((input = Console.ReadLine()).TrimEnd() != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string contestName = tokens[0];
                string password = tokens[1];
                string studentName = tokens[2];
                int points = int.Parse(tokens[3]);

                Contest contest = new Contest(contestName, password);

                if (contests.ContainsKey(contestName) == false)   // check if contest is valid 
                {
                    continue;
                }

                string contestPassword = contests.FirstOrDefault(x => x.Key == contestName).Value.Password.ToString();

                if (contestPassword != password)  // check if password is valid 
                {
                    continue;
                }

                if (students.ContainsKey(studentName) == false)  // check if the student is existing
                {
                    Student student = new Student(studentName);
                    students.Add(studentName, student);
                }

                Student curStudent = students[studentName];

                if (curStudent.courses.ContainsKey(contestName) == false)   // Checking if the student has taken the same exam before 
                {
                    curStudent.courses.Add(contestName, points);
                }
                else
                {
                    int existingCoursePoints = curStudent.courses[contestName];

                    if (existingCoursePoints >= points)
                    {
                        continue;
                    }

                    curStudent.courses[contestName] = points;

                }
            }

            Student bestStudent = students.OrderByDescending(x => x.Value.TotalPoints).Select(x => x.Value).FirstOrDefault();

            if (bestStudent == null)
            {
                Console.WriteLine("No students");
            }
            else
            {
                Console.WriteLine($"Best candidate is {bestStudent.Name} with total {bestStudent.TotalPoints} points.");
                Console.WriteLine("Ranking:");

                foreach (var student in students.OrderBy(x => x.Key))
                {
                    Console.WriteLine(student.Value.ToString());
                }
            }
        }

        public class Contest
        {

            public Contest(string name, string password)
            {
                this.Name = name;
                this.Password = password;
            }
            public string Name { get; set; }
            public string Password { get; set; }

        }

        public class Student
        {
            public Dictionary<string, int> courses;

            public Student(string name)
            {
                this.Name = name;
                this.courses = new Dictionary<string, int>();
            }

            public string Name { get; set; }

            public int TotalPoints => courses.Sum(x => x.Value);

            public override string ToString()
            {
                StringBuilder print = new StringBuilder();
                print.AppendLine(this.Name);

                foreach (var course in courses.OrderByDescending(x => x.Value))
                {
                    print.AppendLine($"#  {course.Key} -> {course.Value} ");
                }

                return print.ToString().TrimEnd();
            }
        }
    }
}
