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

        public void FillWithData()
        {
            fruits.Add(new Fruit("A", "B"));
            fruits.Add(new Citrus("Orange", "E", 65));
            fruits.Add(new Fruit("c", "r"));
            fruits.Add(new Citrus("v", "u", 65));
        }

        public void OutputToFile(string filePass, bool isOverwrite)
        {
            filePass = Path.GetFullPath(filePass);
            filePass = filePass.Replace("\\bin\\Debug", "");
            using (StreamWriter sw = new StreamWriter(filePass, isOverwrite, System.Text.Encoding.Default))
            {
                foreach (var item in fruits)
                {
                    item.Print(sw);
                }
            }
        }


    }
}
