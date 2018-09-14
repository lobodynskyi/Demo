using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Demo
{
    class Program
    {
        static string GetPass(string pass)
        {
            pass = Path.GetFullPath(pass);
            pass = pass.Replace("\\bin\\Debug", "");
            return pass;
        }

        static void Main(string[] args)
        {

            FruitsList fruitsList = new FruitsList();

            string filePass = GetPass("FilesTXT\\Output.txt");
            bool isOverwrite = true;
            fruitsList.OutputToFile(filePass, isOverwrite);


            Fruit fruit1 = new Fruit("Nazar1", "Black");
            Fruit fruit2 = new Fruit("Nazar2", "Black");
            Fruit fruit3 = new Fruit("Nazar3", "Black");

            using (StreamWriter sw = new StreamWriter(filePass, isOverwrite, System.Text.Encoding.Default))
            {
                fruit1.Print(sw);
                fruit2.Print();
                fruit3.Print(sw);
            }


            List<Fruit> fruits = new List<Fruit>();
            string filePass1 = GetPass("FilesTXT\\IntputFruits.txt");

            using (StreamReader sr = new StreamReader(filePass1, System.Text.Encoding.Default))
            {
                try
                {
                    while (sr.EndOfStream != true)
                    {
                        Fruit fruit = new Fruit();
                        fruit.Input(sr);
                        fruits.Add(fruit);
                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            foreach (var item in fruits)
            {
                item.Print();
            }
            string filePass2 = GetPass("FilesTXT\\sertest.xml");


            XmlSerializer ser = new XmlSerializer(typeof(FruitsList));
            fruitsList.FillWithData();
            using (FileStream fs = new FileStream(filePass2, FileMode.Create))
            {
                ser.Serialize(fs, fruitsList);
            }

            //var serializer = new XmlSerializer(typeof(FruitsList));
            //using (var reader = XmlReader.Create(filePass2))
            //{
            //    var list = (FruitsList)serializer.Deserialize(reader);
            //    foreach (var item in list)
            //    {
                    
            //    }
            //}

            Console.ReadKey();
        }
    }
}
