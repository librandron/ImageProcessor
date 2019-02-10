using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor
{
    public class Menu : Methods
    {
       public void drawMenu()
        {
            Console.WriteLine("Choose what you want to do:\n Enter '1' and then press 'Enter' to rename photo by date \n Enter '2' and then press 'Enter' to draw date on image \n Enter '3' and then press 'Enter' to sort images by year");
            var choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                   NewDirectoryForRename();
                    Rename();
                    break;

                case "2":
                    NewDirectoryForPrint();
                    Print();
                    break;
                case "3":
                    NewDirectoryForSort();
                    SortByYear();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        Console.ReadLine();
        }
    }      
}
