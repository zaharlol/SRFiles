class Program
{
    static void Main(string[] args)
    {
        string NewFolder = @"D:/VS/SkillFactory/Новая папка";
        if (Directory.Exists(NewFolder))
        {
            string[] dirs = Directory.GetDirectories(NewFolder);
            foreach (string d in dirs)
                Console.WriteLine(d);
            Console.WriteLine();
            Console.WriteLine("Файлы:");
            string[] files = Directory.GetFiles(NewFolder);

            foreach (string s in files)   
                Console.WriteLine(s);
        }

        try
        {
                TimeSpan interval = TimeSpan.FromMinutes(30);
                DirectoryInfo FI = new DirectoryInfo("D:/VS/SkillFactory/Новая папка");
                foreach (FileInfo f in FI.GetFiles())
                {
                    f.Delete();
                }
                foreach (DirectoryInfo f in FI.GetDirectories())
                {
                    f.Delete();
                }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}