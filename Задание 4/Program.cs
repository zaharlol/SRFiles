using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;


class Program
{
    static void Main(string[] args)
    {
        const string SettingsFileName = @"D:/VS/Новая папка/Students.bin";

        if (File.Exists(SettingsFileName))
        {
            string StringValue;
            using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
            {
                StringValue = reader.ReadString();
            }
            Console.WriteLine("Из файла считано: {0}", StringValue);
        }

        Directory.CreateDirectory("C:/Users/denma/Desktop/Students");
        string Di = ("C:/Users/denma/Desktop/Students");
        string[] txtList = Directory.GetFiles(SettingsFileName, @"C:/D:/VS/Новая папка/Students.bin");
        foreach (string f in txtList)
        {
            string fName = f.Substring(SettingsFileName.Length + 1);

            try
            {
                File.Copy(Path.Combine(SettingsFileName, fName), Path.Combine(Di, fName));
            }

            catch (IOException copyError)
            {
                Console.WriteLine(copyError.Message);
            }
        }
    }
}
[Serializable]
class Contact
{
    public string Name { get; set; }
    public string Group { get; set; }
    public int DateOfBirth { get; set; }

    public Contact(string name, string group, int dateofbirth)
    {
        Name = name;
        Group = group;
        DateOfBirth = dateofbirth;
    }
}