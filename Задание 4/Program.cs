using System.Collections;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"D:/VS/Новая папка/Students.dat";

            string path = "C:/Users/denma/Desktop/Students";
            Directory.CreateDirectory(path);

            BinaryFormatter bin = new BinaryFormatter();
            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                Student[] students = (Student[])bin.Deserialize(fs);

                for(int i = 0; i < students.Length; i++)
                {
                    string groupFilePath = path + "/" + students[i].Group + ".txt";

                    using (FileStream fileStream = new FileStream(groupFilePath, FileMode.Append))
                    {
                        using (StreamWriter sw = new StreamWriter(fileStream))
                        {
                            sw.WriteLine($"{students[i].Name}, {students[i].DateOfBirth}");
                        }
                    }
                }
            }

        }
    }
        [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string name, string group, DateTime dateofbirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
        }
    }
}