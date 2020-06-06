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
            TCC.Info += LogToConsole.Info;
            do
            {
                LogToConsole.Info("Введите одну из команд, которые описаны в документации, введите Help для полного списка комманд: ");
                var command = ReadLine();
                string[] cmd = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string cmd1 = cmd[0], cmd2, cmd3;
                switch (cmd1)
                {
                    case "CreateCatalog":
                        cmd2 = cmd[1];
                        TCC.CreateDirectory(cmd2);
                        break;
                    case "CreateFile":
                        cmd2 = cmd[1];
                        TCC.CreateFile(cmd2);
                        break;
                    case "ShowDirectory":
                        cmd2 = cmd[1];
                        TCC.ShowCatalog(cmd2);
                        break;
                    case "DeleteFile":
                        cmd2 = cmd[1];
                        TCC.DeleteFile(cmd2);
                        break;
                    case "DeleteDirectory":
                        cmd2 = cmd[1];
                        TCC.DeleteDirectory(cmd2);
                        break;
                    case "CopyFile":
                        cmd2 = cmd[1];
                        cmd3 = cmd[2];
                        TCC.CopyFile(cmd2, cmd3);
                        break;
                    case "CopyDirectory":
                        cmd2 = cmd[1];
                        cmd3 = cmd[2];
                        TCC.CopyDir(cmd2, cmd3);
                        break;
                    case "Help":
                        TCC.Help();
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
