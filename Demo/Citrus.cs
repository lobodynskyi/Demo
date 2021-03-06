﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{

    [Serializable]
    public class Citrus : Fruit
    {

        private double? contentOfVitamin_C_IN_G;
        public double? ContentOfVitamin_C_IN_G
        {
            get
            {
                return contentOfVitamin_C_IN_G;
            }
            set
            {
                contentOfVitamin_C_IN_G = value;
            }
        }

        public Citrus(string name, string color, double? contentOfVitamin_C_IN_G) : base(name, color)
        {
            this.contentOfVitamin_C_IN_G = contentOfVitamin_C_IN_G;
        }

        public Citrus(double? contentOfVitamin_C_IN_G)
        {
            this.contentOfVitamin_C_IN_G = contentOfVitamin_C_IN_G;
        }

        public Citrus()
        {
        }

        public override void Input()
        {
            Console.WriteLine("Please enter citrus name");
            Name = Console.ReadLine();

            Console.WriteLine("Please enter citrus color");
            Color = Console.ReadLine();

            Console.WriteLine("Please enter the content Of vitamin C in gram");
            string numberToParse = Console.ReadLine();
            double number;
            if (Double.TryParse(numberToParse, out number))
            {
                contentOfVitamin_C_IN_G = number;
            }
            else
            {
                Console.WriteLine("Unable to parse '{0}'.", numberToParse);
                ContentOfVitamin_C_IN_G = null;
            }
        }

        public override void Input(StreamReader sr)
        {
            String line;
            double number;

            if ((line = sr.ReadLine()) != null)
            {
                string[] tab = line.Split('\t');
                Name = tab[0];

                try
                {
                    Color = tab[1];
                }
                catch (IndexOutOfRangeException e)
                {
                    Color = string.Empty;
                    ContentOfVitamin_C_IN_G = null;
                    Console.WriteLine(e.Message + "\tCitrus without color and number ->" + this);
                }

                try
                {
                    if (Double.TryParse(tab[2], out number))
                    {
                        contentOfVitamin_C_IN_G = number;
                    }
                    else
                    {
                        
                        Console.WriteLine("Unable to parse '{0}'.", tab[2]);
                        ContentOfVitamin_C_IN_G = null;
                    }
                }catch (IndexOutOfRangeException e)
                {
                    ContentOfVitamin_C_IN_G = null;
                    Console.WriteLine(e.Message + "\tCitrus without number ->" + this);
                }
            }


        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        virtual public void Print(StreamWriter sw)
        {
            sw.WriteLine(this);
        }

        public override string ToString()
        {
            return String.Concat(Name + "\t", Color + "\t", ContentOfVitamin_C_IN_G);
        }
    }
}
