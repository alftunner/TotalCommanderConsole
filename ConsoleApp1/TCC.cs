using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

namespace ConsoleApp1
{
    public delegate void Message(string msg);
    public static class TCC // абревиатура от TotalCommanderConsole
    {
        static readonly System.Collections.Specialized.StringCollection log =
            new System.Collections.Specialized.StringCollection(); // Коллекция строк с ошибками
        public static Message message;
        public static void ShowCatalog(string path)
        {
            var rootDir = new DirectoryInfo(path); // Создаём объект, который содержит каталог диска.
            WalkDirectoryTree(rootDir); // Передаём корневой каталог диска в функцию обхода.
            message?.Invoke("Files with restricted access:"); // распечатываем буфер с ошибками
            foreach (var s in log)
            {
                message?.Invoke(s);
            }
            // удерживаем консоль
            message?.Invoke("Press any key");
        }

        private static void WalkDirectoryTree(DirectoryInfo root) // рекурсивная функция для обхода директории
        {
            FileInfo[] files = null; // Инициализируем массив с файлами
            DirectoryInfo[] subDirs = null; // Инициализируем массив с поддиректориями
            try
            {
                files = root.GetFiles("*.*");  // Получаем все файлы заданной директории и записываем их в массив с файлами
            }
            catch (UnauthorizedAccessException e) // Отлавливаем ошибки отсутствия прав доступа
            {
                log.Add(e.Message);
            }

            catch (DirectoryNotFoundException e) // Отлавливаем ошибки несуществующей директории
            {
                message?.Invoke(e.Message);
            }

            if (files == null) return;
            foreach (var fi in files)
            {
                message?.Invoke(fi.FullName);
            }

            subDirs = root.GetDirectories(); // Получаем все поддиректории данной директории

            foreach (var dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo); // Рекурсивно применяем функцию для каждой директории
            }

        }

        public static void CreateFile(string path)
        {
            using var fileInf1 = File.Create(path);
            message?.Invoke($"{fileInf1.Name} создан!");
        }

        public static void CreateDirectory(string path)
        {
            var dirInf1 = new DirectoryInfo(path);
            dirInf1.Create();
            message?.Invoke($"{dirInf1.FullName} созданa!");
            
        }

        public static void DeleteFile(string path)
        {
            var fileInf2 = new FileInfo(path);
            fileInf2.Delete();
            message?.Invoke($"Фаил будет удалён!");
        }

        public static void DeleteDirectory(string path)
        {
            try
            {
                var dirInfo2 = new DirectoryInfo(path);
                if (!dirInfo2.Exists) return;
                dirInfo2.Delete(true);
                message?.Invoke("Каталог удален");
            }
            catch (UnauthorizedAccessException ex)
            {
                message?.Invoke(ex.Message);
            }
        }

        public static void CopyFile(string path1, string path2)
        {
            var fileInf3 = new FileInfo(path1);
            if (!fileInf3.Exists) return;
            fileInf3.CopyTo(path2, true);
            message?.Invoke("Фаил скопирован");
        }

        public static void CopyDir(string path1, string path2)
        {
            var dirInf3 = new DirectoryInfo(path1);
            if (!dirInf3.Exists || Directory.Exists(path2) != false) return;
            dirInf3.MoveTo(path2);
            message?.Invoke("Каталог перемещён скопирован");
        }
    }
}
