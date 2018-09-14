using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            FruitsList introduction = new FruitsList();
            string filePass = "FilesTXT\\Output.txt";
            bool isOverwrite = true;
            introduction.OutputToFile(filePass, isOverwrite);
            Fruit fruit1 = new Fruit("Nazar1", "Black");
            Fruit fruit2 = new Fruit("Nazar2", "Black");
            Fruit fruit3 = new Fruit("Nazar3", "Black");

            //filePass = Path.GetFullPath(filePass);
            //filePass = filePass.Replace("\\bin\\Debug", "");
            //using (StreamWriter sw = new StreamWriter(filePass, isOverwrite, System.Text.Encoding.Default))
            //{
            //    fruit1.Print(sw);
            //    fruit2.Print();
            //    fruit3.Print(sw);
            //}
            //List<Fruit> fruits = new List<Fruit>();
            //string filePass1 = "FilesTXT\\IntputFruits.txt";
            //filePass1 = Path.GetFullPath(filePass1);
            //filePass1 = filePass1.Replace("\\bin\\Debug", "");
            //using (StreamReader sr = new StreamReader(filePass1, System.Text.Encoding.Default))
            //{
            //    try
            //    {
            //        while (sr.EndOfStream != true)
            //        {
            //            Fruit fruit = new Fruit();
            //            fruit.Input(sr);
            //            fruits.Add(fruit);
            //        }
            //    }
            //    catch(ArgumentNullException e)
            //    {
            //        Console.WriteLine(e.ToString());
            //    }
            //}
            //foreach (var item in fruits)
            //{
            //    item.Print();
            //}
            string filePass2 = "FilesTXT\\sertest.xml";
            filePass2 = Path.GetFullPath(filePass2);
            filePass2 = filePass2.Replace("\\bin\\Debug", "");

            XmlSerializer ser = new XmlSerializer(typeof(FruitsList));
            FruitsList fruitsList = new FruitsList();
            fruitsList.FillWithData();
            using (FileStream fs = new FileStream(filePass2, FileMode.Create))
            {
                ser.Serialize(fs, fruitsList);
            }

            Console.ReadKey();
        }
    }
}
