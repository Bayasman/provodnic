using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provodnic
{
    internal class FAILMENEDGER1
    {
        public static void Menu()
        {
            Console.CursorVisible = false;
            int choice = 0;

            while (true)
            {
                Console.WriteLine("ВЫБОР ДИСКА. ПЕРЕХОД К ДЕЙСТВИЯМ : F1");
                DriveInfo[] drives = DriveInfo.GetDrives();

                for (int i = 0; i < drives.Length; i++)
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($" {drives[i].Name}" + $"      СВОБОДНОЕ МЕСТО : {drives[i].AvailableFreeSpace / 1024 / 1024 / 1024} ГБ\n" + $"          ОБЩИЙ РАЗИМЕР: {drives[i].TotalSize / 1024 / 1024 / 1024} ГБ ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($" {drives[i].Name}");
                    }
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F1:
                        actions options = new actions();
                        options.Coise();
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice + 1 < drives.Length)
                        {
                            choice++;
                            if (choice == drives.Length)
                            {
                                choice = 0;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (choice > 0)
                        {
                            choice--;
                        }
                        break;
                    case ConsoleKey.Enter:

                        Console.Clear();
                        FileSystemInfo[] infos = drives[choice].RootDirectory.GetFileSystemInfos();
                        string currentDirectory = drives[choice].Name;
                        choice = 0;
                        bool exit = false;
                        while (!exit)
                        {
                            Console.WriteLine("  ПОСЕЩАЯЕМАЯ ДЕРИКТОРИЯ : " + currentDirectory);
                            for (int i = 0; i < infos.Length; i++)
                            {
                                if (i == choice)
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine($"  {infos[i].Name}       Время создания: {infos[i].CreationTime}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine($"  {infos[i].Name}");
                                }
                            }
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.DownArrow:
                                    if (choice + 1 < infos.Length)
                                    {
                                        choice++;
                                        if (choice == infos.Length)
                                        {
                                            choice = 0;
                                        }
                                    }
                                    break;
                                case ConsoleKey.UpArrow:
                                    if (choice > 0)
                                    {
                                        choice--;
                                    }
                                    break;
                                case ConsoleKey.Enter:
                                    {
                                        FileSystemInfo fileSystemInfo = infos[choice];
                                        if (fileSystemInfo is DirectoryInfo directory)
                                        {
                                            currentDirectory = directory.FullName;
                                            infos = directory.GetFileSystemInfos();
                                            choice = 0;
                                        }
                                        else
                                        {
                                            Process.Start(new ProcessStartInfo($"{fileSystemInfo.FullName}") { UseShellExecute = true });
                                        }
                                    }
                                    break;
                                case ConsoleKey.Escape:
                                    {
                                        DirectoryInfo directory = Directory.GetParent(currentDirectory);
                                        if (directory == null)
                                        {
                                            exit = true;
                                        }
                                        else
                                        {
                                            infos = directory.GetFileSystemInfos();
                                            currentDirectory = directory.FullName;
                                        }
                                        choice = 0;
                                    }
                                    break;
                            }
                            Console.Clear();
                        }
                        break;
                }
                Console.Clear();
            }
        }
    }
}
