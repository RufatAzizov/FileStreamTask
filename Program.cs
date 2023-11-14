namespace FileStreamTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            manager.LoadFromFile();

            Student student1 = new Student { Name = "Rufat", Surname = "Azizov", Code = "12345" };
            manager.AddStudent(student1);

            Student student2 = new Student { Name = "Adil", Surname = "Helilov", Code = "67890" };
            manager.AddStudent(student2);

            Console.WriteLine("All Students:");
            foreach (var student in manager.GetAllStudents())
            {
                Console.WriteLine($"Name: {student.Name}, Surname: {student.Surname}, Code: {student.Code}");
            }

            
            Student editedStudent = new Student { Name = "Edited", Surname = "Student", Code = "12345" };
            manager.EditStudent("12345", editedStudent);

            Console.WriteLine("\nAfter Editing:");

            foreach (var student in manager.GetAllStudents())
            {
                Console.WriteLine($"Name: {student.Name}, Surname: {student.Surname}, Code: {student.Code}");
            }

            manager.RemoveStudent("67890");

            Console.WriteLine("\nAfter Removing:");

            foreach (var student in manager.GetAllStudents())
            {
                Console.WriteLine($"Name: {student.Name}, Surname: {student.Surname}, Code: {student.Code}");
            }
        }
    }
}