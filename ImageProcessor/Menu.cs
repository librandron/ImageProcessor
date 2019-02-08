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
            Console.WriteLine("Choose what you want to do:\n Enter '1' and then press 'Enter' to rename photo by date \n Enter '2' and then press 'Enter' to draw date on image");
            var choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                   NewDirectoryForRename();
                    Rename();
                    break;

                case "2":

                    break;


                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        Console.ReadLine();
        }
    }      
}
