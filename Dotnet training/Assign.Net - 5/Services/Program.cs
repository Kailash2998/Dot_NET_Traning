using Assign.Net___5.Models; // Assuming Student class is in this namespace

namespace Assign.Net___5.Services
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create instance of student repository
            var studentRepository = new StudentRepository();

            // Insert some sample students
            studentRepository.Insert(new Student { Id = 1, Name = "John", Age = 20 });
            studentRepository.Insert(new Student { Id = 2, Name = "Alice", Age = 22 });
            studentRepository.Insert(new Student { Id = 3, Name = "Bob", Age = 21 });

            // Retrieve all students
            Console.WriteLine("All Students:");
            var allStudents = studentRepository.GetAll();
            foreach (var student in allStudents)
            {
                Console.WriteLine(value: $"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }

            // Retrieve student by Id
            Console.WriteLine("\nRetrieve Student by Id:");
            var studentById = studentRepository.GetById(2);
            if (studentById != null)
            {
                Console.WriteLine($"Id: {studentById.Id}, Name: {studentById.Name}, Age: {studentById.Age}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            // Delete a student
            Console.WriteLine("\nDeleting Student with Id 1:");
            studentRepository.Delete(1);
            Console.WriteLine("After deletion:");
            var remainingStudents = studentRepository.GetAll();
            foreach (var student in remainingStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
            }
        }
    }
}
