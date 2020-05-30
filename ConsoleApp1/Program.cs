using System;
using System.IO;
using System.Net.Http;
using Logger;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check;
            do
            {
                LogToConsole.Info("Введите одну из команд, которые описаны в документации: ");
                var command = ReadLine();
                switch (command)
                {
                    case "CreateCatalog":
                        LogToConsole.Info("Введите полный путь, по которому вы хотите создать каталог: ");
                        var dir = ReadLine();
                        TCC.CreateDirectory(dir);
                        ReadKey();
                        break;
                    case "CreateFile":
                        LogToConsole.Info("Введите полное имя файла, который хотите создать: ");
                        var file = ReadLine();
                        TCC.CreateFile(file);
                        ReadKey();
                        break;
                    case "ShowDirectory":
                        LogToConsole.Info("Введите путь до директории, содержимое которой хотите увидеть: ");
                        var path = ReadLine();
                        TCC.ShowCatalog(path);
                        ReadKey();
                        break;
                    case "DeleteFile":
                        LogToConsole.Info("Введите полное имя файла, который вы хотите удалить: ");
                        var delFile = ReadLine();
                        TCC.DeleteFile(delFile);
                        ReadKey();
                        break;
                    case "DeleteDirectory":
                        LogToConsole.Info("Введите полное имя каталога, который вы хотите удалить: ");
                        var delDir = ReadLine();
                        TCC.DeleteDirectory(delDir);
                        ReadKey();
                        break;
                    case "CopyFile":
                        LogToConsole.Info("Введите полное имя файла, который вы хотите скопировать: ");
                        var fileCopy = ReadLine();
                        LogToConsole.Info("Введите полный путь, куда вы хотите скопировать выбранный фаил: ");
                        var fileCopyWay = ReadLine();
                        TCC.CopyFile(fileCopy, fileCopyWay);
                        ReadKey();
                        break;
                    case "CopyDirectory":
                        LogToConsole.Info("Введите полное имя каталога, который вы хотите скопировать: ");
                        var dirCopy = ReadLine();
                        LogToConsole.Info("Введите полный путь, куда вы хотите скопировать выбранный каталог: ");
                        var dirCopyWay = ReadLine();
                        TCC.CopyDir(dirCopy, dirCopyWay);
                        ReadKey();
                        break;
                    default:
                        LogToConsole.Error("Прошу вас быть внимательнее, и правильно вводить команды");
                        break;
                }
                LogToConsole.Info("Если хотите продолжить введите - Y, если хотите закончить сеанс - N");
                var flag = ReadLine();
                check = flag == "Y";
            } while (check);
            LogToConsole.Info("Спасибо, что использовали мой файловый менеджер!");
        }
    }
}
