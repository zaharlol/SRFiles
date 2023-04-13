using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Linq.Expressions;
using System.ComponentModel.Design.Serialization;

class Program
{
    static void Main(string[] args)
    {
        DirectoryInfo car = new DirectoryInfo (@"D:/VS/SkillFactory/Новая папка");
        var folders = car.GetDirectories();
        DI(folders); 
    }

public static void DI(DirectoryInfo[] folders)
{
        foreach (var folder in folders)
        {
            try
            {
                Console.WriteLine(folder.Name + $" - {Size(folder)}");
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
}
public static long Size(DirectoryInfo d)
{
    long size = 0;
    FileInfo[] fis = d.GetFiles();
    foreach (FileInfo fi in fis)
    {
        size += fi.Length;
    }
    DirectoryInfo[] dis = d.GetDirectories();
    foreach (DirectoryInfo di in dis)
    {
        size += Size(di);
    }
    return size;
}
}