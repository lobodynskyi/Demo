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
    class MainClass
    {
        static string GetPath(string path)
        {
            path = Path.GetFullPath(path);
            path = path.Replace("\\bin\\Debug", "\\Files\\");
            return path;
        }

        static void Main(string[] args)
        {

            FruitsList fruitsList = new FruitsList();

            fruitsList.FillWithData();

            Console.WriteLine("\t\t\tFunction Find(string keyColor) with parametr Orange");
            fruitsList.Find("orange");
            Console.WriteLine("\n\n");

            try
            {
                using (StreamReader sr = new StreamReader(GetPath("IntputFruits.txt"), System.Text.Encoding.Default))
                {
                    while (sr.EndOfStream != true)
                    {
                        Fruit fruit = new Fruit();
                        fruit.Input(sr);
                        fruitsList.fruits.Add(fruit);
                    }
                }
            }catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                using (StreamReader sr = new StreamReader(GetPath("IntputCitrus.txt"), System.Text.Encoding.Default))
                {
                    while (sr.EndOfStream != true)
                    {
                        Citrus fruit = new Citrus();
                        fruit.Input(sr);
                        fruitsList.fruits.Add(fruit);
                    }
                }
            }catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            fruitsList.Sort();

            fruitsList.OutputToFile(GetPath("Output.txt"));

            fruitsList.Serialize(fruitsList.fruits, GetPath("Fruits.xml"));

            List<Fruit> fruitsDeserialized = fruitsList.Deserialize(GetPath("Fruits.xml"));

            Console.WriteLine("\n\n\t\tList after deserialization\n\n");

            foreach (var item in fruitsDeserialized)
            {
                item.Print();
            }

            Console.ReadKey();
        }
    }
}
