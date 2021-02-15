using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private const string ADDED_STUDENT = "Added student {0} {1}";
        private const string NO_SEATS_CLASSROOM = "No seats in the classroom";
        private const string DISMISSED_STUDENT = "Dismissed student {0} {1}";
        private const string STUDENT_NOT_FOUND = "Student not found";
        private const string NO_SUCH_SUBJECT = "No students enrolled for the subject";

        private HashSet<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            students = new HashSet<Student>();
        }

        public int Capacity { get; set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                return string.Format(ADDED_STUDENT, student.FirstName, student.LastName);
            }
            else
            {
                return NO_SEATS_CLASSROOM;
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student studentToRemove = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (studentToRemove!= null)
            {
                this.students.Remove(studentToRemove);
                return string.Format(DISMISSED_STUDENT, firstName, lastName);
            }
            else
            {
                return STUDENT_NOT_FOUND;
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            if (students.Any(s => s.Subject == subject))
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in this.students.Where(s => s.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return NO_SUCH_SUBJECT;
            }
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            return student;
        }
    }
}
