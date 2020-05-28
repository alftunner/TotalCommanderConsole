using System;
using System.IO;
using System.Net.Http;
using static System.Console;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            TCC.message = Show;
            string command;
            bool check;
            do
            {
                Write("Введите одну из команд, которые описаны в документации: ");
                command = ReadLine();
                switch (command)
                {
                    case "CreateCatalog":
                        Write("Введите полный путь, по которому вы хотите создать каталог: ");
                        var dir = ReadLine();
                        TCC.CreateDirectory(dir);
                        ReadKey();
                        break;
                    case "CreateFile":
                        Write("Введите полное имя файла, который хотите создать: ");
                        var file = ReadLine();
                        TCC.CreateFile(file);
                        ReadKey();
                        break;
                    case "ShowDirectory":
                        Write("Введите путь до директории, содержимое которой хотите увидеть: ");
                        var path = ReadLine();
                        TCC.ShowCatalog(path);
                        ReadKey();
                        break;
                    case "DeleteFile":
                        Write("Введите полное имя файла, который вы хотите удалить: ");
                        var delFile = ReadLine();
                        TCC.DeleteFile(delFile);
                        ReadKey();
                        break;
                    case "DeleteDirectory":
                        Write("Введите полное имя каталога, который вы хотите удалить: ");
                        var delDir = ReadLine();
                        TCC.DeleteDirectory(delDir);
                        ReadKey();
                        break;
                    case "CopyFile":
                        Write("Введите полное имя файла, который вы хотите скопировать: ");
                        var fileCopy = ReadLine();
                        Write("Введите полный путь, куда вы хотите скопировать выбранный фаил: ");
                        var fileCopyWay = ReadLine();
                        TCC.CopyFile(fileCopy, fileCopyWay);
                        ReadKey();
                        break;
                    case "CopyDirectory":
                        Write("Введите полное имя каталога, который вы хотите скопировать: ");
                        var dirCopy = ReadLine();
                        Write("Введите полный путь, куда вы хотите скопировать выбранный каталог: ");
                        var dirCopyWay = ReadLine();
                        TCC.CopyDir(dirCopy, dirCopyWay);
                        ReadKey();
                        break;
                    default:
                        WriteLine("Прошу вас быть внимательнее, и правильно вводить команды");
                        break;
                }
                WriteLine("Если хотите продолжить введите - Y, если хотите закончить сеанс - N");
                string flag = ReadLine();
                if(flag == "Y")
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            } while (check);
            WriteLine("Спасибо, что использовали мой файловый менеджер!");
            

            

            

            

            

            

            
        }

        static void Show(string msg)
        {
            WriteLine(msg);
        }
    }
}
