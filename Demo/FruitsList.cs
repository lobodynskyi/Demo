using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo
{
    
    [Serializable]
    public class FruitsList
    {

        [XmlArray("fruits"), XmlArrayItem(typeof(Fruit))]
        public List<Fruit> fruits;

        public FruitsList()
        {
            fruits = new List<Fruit>();
        }

        public FruitsList(List<Fruit> fruits)
        {
            this.fruits = fruits;
        }


        /// <summary>
        /// Fill list with data
        /// </summary>
        public void FillWithData()
        {
            fruits.Add(new Fruit("Apple", "Red"));
            fruits.Add(new Fruit("Banana", "Yellow"));
            fruits.Add(new Fruit("Strawberry", "Red"));
            fruits.Add(new Fruit("Pomelo", "Green"));
            fruits.Add(new Fruit("Dragonfruit", "Red"));

            fruits.Add(new Citrus("Orange", "Orange", 0.25));
            fruits.Add(new Citrus("Sudachi", "Green", 0.05));
            fruits.Add(new Citrus("Tangelo", "Orange", null));
            fruits.Add(new Citrus("Tangerine", "Orange", 0.06));
            fruits.Add(new Citrus("Tangor", "Orange", 0.1));
        }


        /// <summary>
        /// Write all list data to file
        /// </summary>
        /// <param name="filePath"> Path to file</param>
        public void OutputToFile(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    foreach (var item in fruits)
                    {
                        item.Print(sw);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Sort()
        {
            fruits.Sort();
        }

        /// <summary>
        ///Return fruits with color wich been set in parameter
        /// </summary>
        /// <param name="keyWordColor"></param>
        public void Find(string keyWordColor)
        {
            bool flag = true;
            foreach (var item in fruits)
            {
                if(string.Equals(item.Color, keyWordColor, StringComparison.OrdinalIgnoreCase))
                {
                    item.Print();
                    flag = false;
                }
            }
            if(flag == true)
            {
                Console.WriteLine("No fruits with color: " + keyWordColor);
            }
        }

        public void Serialize(List<Fruit> fruits, string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Fruit>));
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, fruits);
                    Console.WriteLine("\n\n\t\tFruits was serialize");
                }
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Fruit> Deserialize(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Fruit>));
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open ))
                {
                    Console.WriteLine("\n\n\t\tFruits was deserialize");
                    return formatter.Deserialize(fs) as List<Fruit>;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new List<Fruit>();
        }

    }
}
