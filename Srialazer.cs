using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serialization
{
    internal class Srialazer
    {
        string _desktopPath;
        string _path;
        List<Student> _students;
        public Srialazer()
        {
            _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _path = Path.Combine(_desktopPath, "example.json");

            _students = new List<Student>(3)
            {
                new Student("A", "AA"),
                new Student("B", "BB"),
                new Student("C", "CC")
            };

            _students[0].AddMarks("Math", new int[] { 1, 2, 5, 3 });
            _students[1].AddMarks("Math", new int[] { 2, 3, 4 });
            _students[0].AddMarks("CS", new int[] { 1, 2, 5, 3 });
            _students[0].AddMarks("CS", new int[] { 5, 3, 2, 4 });
        }
        public void Serialize()
        {
            var jsonString = JsonSerializer.Serialize(_students);

            Console.WriteLine(jsonString);
            File.WriteAllText(_path, jsonString);

            _students = null;
        }

        public void Deserialize() {
            Console.WriteLine();
            var jsonString = File.ReadAllText(_path);
            Console.WriteLine(jsonString);

            Student[] students = JsonSerializer.Deserialize<Student[]>(jsonString);
            foreach (var student in students) {
                Console.WriteLine($"{student.Id} {student.Name} has marks: {string.Join(" ", student.Subjects.Select(x => x.FinalMark))}");
            }
        }
        
    }
}
