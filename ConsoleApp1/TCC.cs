using System;
using System.IO;
using Logger;

namespace ConsoleApp1
{
    public delegate void Message(string msg);
    public static class TCC // абревиатура от TotalCommanderConsole
    {
        static readonly System.Collections.Specialized.StringCollection log =
            new System.Collections.Specialized.StringCollection(); // Коллекция строк с ошибками
        //public static Message message;
        public static event Message Error;
        public static event Message Info;
        
        public static void ShowCatalog(string path)
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            var rootDir = new DirectoryInfo(path); // Создаём объект, который содержит каталог диска.
            WalkDirectoryTree(rootDir); // Передаём корневой каталог диска в функцию обхода.
            Info?.Invoke("Files with restricted access:"); // распечатываем буфер с ошибками
            foreach (var s in log)
            {
                Error?.Invoke(s);
            }
        }

        private static void WalkDirectoryTree(DirectoryInfo root) // рекурсивная функция для обхода директории
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            FileInfo[] files = null; // Инициализируем массив с файлами
            DirectoryInfo[] subDirs = null; // Инициализируем массив с поддиректориями
            try
            {
                files = root.GetFiles("*.*");  // Получаем все файлы заданной директории и записываем их в массив с файлами
            }
            catch (UnauthorizedAccessException) // Отлавливаем ошибки отсутствия прав доступа
            {
                Error?.Invoke("Ошибка доступа");
            }

            catch (DirectoryNotFoundException e) // Отлавливаем ошибки несуществующей директории
            {
                Error?.Invoke(e.Message);
            }

            if (files == null) return;
            foreach (var fi in files)
            {
                Info?.Invoke(fi.FullName);
            }

            subDirs = root.GetDirectories(); // Получаем все поддиректории данной директории

            foreach (var dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo); // Рекурсивно применяем функцию для каждой директории
            }

        }

        public static void CreateFile(string path)
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            using var fileInf1 = File.Create(path);
            Info?.Invoke($"{fileInf1.Name} создан!");
        }

        public static void CreateDirectory(string path)
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            var dirInf1 = new DirectoryInfo(path);
            dirInf1.Create();
            Info?.Invoke($"{dirInf1.FullName} созданa!");
        }

        public static void DeleteFile(string path)
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            var fileInf2 = new FileInfo(path);
            fileInf2.Delete();
            Info?.Invoke($"Фаил будет удалён!");
        }

        public static void DeleteDirectory(string path)
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            try
            {
                var dirInfo2 = new DirectoryInfo(path);
                if (!dirInfo2.Exists) return;
                dirInfo2.Delete(true);
                Info?.Invoke("Каталог удален");
            }
            catch (UnauthorizedAccessException ex)
            {
                Error?.Invoke(ex.Message);
            }
        }

        public static void CopyFile(string path1, string path2)
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            var fileInf3 = new FileInfo(path1);
            if (!fileInf3.Exists) return;
            fileInf3.CopyTo(path2, true);
            Info?.Invoke("Фаил скопирован");
        }

        public static void CopyDir(string path1, string path2)
        {
            var logger = new LogToFile(); 
            Error += LogToConsole.Error;
            Error += logger.Error;
            Info += LogToConsole.Info;
            Info += logger.Info;
            
            var dirInf3 = new DirectoryInfo(path1);
            if (!dirInf3.Exists || Directory.Exists(path2) != false) return;
            dirInf3.MoveTo(path2);
            Error?.Invoke("Каталог перемещён скопирован");
        }
    }
}
