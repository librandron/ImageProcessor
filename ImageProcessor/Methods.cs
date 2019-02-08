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
                newDirectory = dInformation.CreateSubdirectory(newDirectory).FullName;
            }
        }

        public void Rename()
        {
            FileInfo[] images = GetImages();
            foreach (var image in images)
            {
                Image imageInDir = Image.FromFile(image.FullName);
                var property = GetProperty(imageInDir,TIMEOFCREATE);
                var pr1 = property.TrimEnd('\0');
                var pr2 = pr1.Replace(':','-'); 
                Console.WriteLine(pr2);
                imageInDir.Save($@"{newDirectory}\{pr2}{image.Extension}");
            }
        }

       

        public FileInfo[] GetImages()
        {
            DirectoryInfo dInformation = new DirectoryInfo(workingDirectory);
            return dInformation.GetFiles();
        }

        public string GetProperty(Image image, int prop)
        {
            var getValue = image.GetPropertyItem(prop).Value;
            var encoding = new System.Text.ASCIIEncoding();
            var encResult = encoding.GetString(getValue);
            return encResult;
          
        }
    }
}

