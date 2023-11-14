using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileStreamTask
{
    public class StudentManager
    {
        private List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            SaveToFile();
        }

        public void RemoveStudent(string code)
        {
            Student studentToRemove = students.Find(s => s.Code == code);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                SaveToFile();
            }
        }

        public void EditStudent(string code, Student newStudent)
        {
            Student existingStudent = students.Find(s => s.Code == code);
            if (existingStudent != null)
            {
                existingStudent.Name = newStudent.Name;
                existingStudent.Surname = newStudent.Surname;
                existingStudent.Code = newStudent.Code;
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(students);
            File.WriteAllText("students.json", json);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public void LoadFromFile()
        {
            if (File.Exists("students.json"))
            {
                string json = File.ReadAllText("students.json");
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }
        }
    }
}
