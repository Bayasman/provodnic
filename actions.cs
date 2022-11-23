using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace provodnic
{
    internal class actions
    {
        ConsoleKey Key_Pressed;
        public string path;
        public string path1;
        public string File_Name;
        public string Directory_Name;
        public void Coise()
        {

            Console.Clear();
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ДОПОЛНИТЕЛЬНЫЕ ДЕЙСТВИЯ.\n  ЧТОБЫ ВЫЙТИ -- НАЖАТЬ Escape\n ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  СОЗДАНИЕ ФАЙЛОВ (-_-) - F2");
            Console.WriteLine("  УДАЛЕНИЕ ФАЙЛОВ (-_-) - F3");
            Console.WriteLine("  СОЗДАНИЕ ДИРЕКТОРИЙ:) - F4");
            Console.WriteLine("  УДАЛЕНИЕ ДИРЕКТОРИЙ:(  - F5");
            Console.WriteLine("  ЛУЧШЕ БЫТЬ ОКУРАТНЫМ И НЕ УДАЛИТЬ ВАЖНЫЕ ДАНЫЕ :)");
            Console.ResetColor();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                
                if (key.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.WriteLine("ВВЕДИТЕ ПУТЬ ГДЕ БУДЕТ ХРАНИТСЯ ФАЙЛ: ");
                    path = Console.ReadLine();
                    Console.WriteLine("НАЗВАНИЯ ФАЙЛА : ");
                    File_Name = Console.ReadLine();

                    File.Create(path + @"\" + File_Name);
                    
                    Console.WriteLine("ФАЙЛ БЫЛ СОЗДАН ВАМИ УСПЕШНО ");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.WriteLine("ВВЕДИТЕ ПУТЬ КАКОЙ  ФАЙЛ ХОТИТЕ УДАЛИТЬ: ");
                    path = Console.ReadLine();

                    File.Delete(path);
                 
                    Console.WriteLine("ФАЙЛ ВЫБРАНЫМ ВАМИ УСПЕШНО УДАЛЕН ");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                
                else if (key.Key == ConsoleKey.F4)
                {
                    Console.Clear();
                    Console.WriteLine("ВВЕДИТЕ ПУТЬ В КАКТОРОМ ХОТИТЕ СОЗДАВЙТЬ СВОЙ ФАЙЛ: ");
                    path = Console.ReadLine();
                    Console.WriteLine("ВВЕДИТЕ НАЗВАНИЕ ПАПКИ: ");
                    Directory_Name = Console.ReadLine();

                    Directory.CreateDirectory(path + @"\" + Directory_Name);
                 
                    Console.WriteLine("ПАПКА БЫЛА СОЗДАНА ");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                
                else if (key.Key == ConsoleKey.F5)
                {
                    Console.Clear();
                    Console.WriteLine("ВВЕДИТЕ ПУТЬ В КАТОРОМ ХОТИТЕ УДАЛИТЬ ПАПКИ: ");
                    path = Console.ReadLine();

                    
                    Directory.Delete(path, true);
                  
                    Console.WriteLine("ПАПКА БЫЛА УДАЛЕНА");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;

                }

                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
