using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo
{
    [XmlInclude(typeof(Citrus))]
    [Serializable]
    public class Fruit : IComparable<Fruit>
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;   
            }
        }

        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        virtual public void Input()
        {
            Console.WriteLine("Please enter fruit name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter fruit color");
            Color = Console.ReadLine();
        }

        virtual public void Input(StreamReader sr)
        {
            String line;
            if ((line = sr.ReadLine()) != null)
            {
                string[] tab = line.Split('\t');
                Name = tab[0];
                Color = tab[1];
            }else
            {
                throw new ArgumentNullException();
            }

        }

        virtual public void Print()
        {
            Console.WriteLine(ToString());
        }

        virtual public void Print(StreamWriter sw)
        {
            sw.WriteLine(ToString());
        }

        public Fruit(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public Fruit()
        {
            Name = string.Empty;
            Color = string.Empty;
        }

        public override string ToString()
        {
            return String.Concat(Name + "\t", Color);
        }



        public int CompareTo(Fruit fruit)
        {
            return this.Name.CompareTo(fruit.Name);
        }
    }
}
