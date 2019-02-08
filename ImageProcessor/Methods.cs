using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;



namespace ImageProcessor
{
   public  class Methods
    {
        public  string workingDirectory;
        public  string newDirectory;
        const int TIMEOFCREATE = 0x0132;//from metadate

        public  void NewDirectoryForRename()
        {
            Console.WriteLine("Enter full working directory");
            workingDirectory = Console.ReadLine();

            DirectoryInfo dInformation = new DirectoryInfo(workingDirectory);
            newDirectory = dInformation.Name + "_Rename_By_Date";
           if (dInformation.Exists)
            {
                newDirectory = dInformation.CreateSubdirectory(newDirectory).FullName; //create sub directory with command name
            }
        }

        public void NewDirectoryForPrint()
        {
            Console.WriteLine("Enter full working directory");
            workingDirectory = Console.ReadLine();

            DirectoryInfo dInformation = new DirectoryInfo(workingDirectory);
            newDirectory = dInformation.Name + "_PrintOnImage";
            if (dInformation.Exists)
            {
                newDirectory = dInformation.CreateSubdirectory(newDirectory).FullName;
            }
        }

        public void Rename() //rename by date
        {
            FileInfo[] images = GetImages();
            foreach (var image in images)
            {
                Image imageInDir = Image.FromFile(image.FullName);
                var property = GetProperty(imageInDir,TIMEOFCREATE);
                var pr1 = property.TrimEnd('\0').Replace(':', '-'); //delete spec symb \0 at the end // replaice ':' to '-'
                
                //Console.WriteLine(pr2);
                imageInDir.Save($@"{newDirectory}\{pr1}{image.Extension}"); //saving image in new directory with new name
            }
        }

        public void Print() // printing date on image
        {
            FileInfo[] images = GetImages();
            foreach (var image in images)
            {
                Image imageInDir = new Bitmap(image.FullName);
                var property = GetProperty(imageInDir, TIMEOFCREATE);
                var pr1 = property.TrimEnd('\0').Replace(':', '-');
                Graphics drawing = Graphics.FromImage(imageInDir);
                drawing.DrawString(pr1, new Font("Times New Roman", 20), new SolidBrush(Color.Black), 100, 100, new StringFormat());
                imageInDir.Save($@"{newDirectory}\{pr1}{image.Extension}");
            }
        }

        public FileInfo[] GetImages() // getting files in array from directory
        {
            DirectoryInfo dInformation = new DirectoryInfo(workingDirectory);
            return dInformation.GetFiles();
        }

        public string GetProperty(Image image, int prop) // get property and encoding it from metadate
        {
            var getValue = image.GetPropertyItem(prop).Value;
            var encoding = new System.Text.ASCIIEncoding();
            var encResult = encoding.GetString(getValue);
            return encResult;
          
        }
    }
}

