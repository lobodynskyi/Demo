using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [TestFixture]
    class DemoTests
    {
        [Test]
        public void ToString()
        {
            Fruit fruit = new Fruit("Banana", "Yellow");
            var actual = fruit.ToString();
            var expected = "Banana\tYellow";
            Assert.AreEqual(actual, expected);
        }


        [Test, Order(1)]
        public void Deserialization_Exception_EmptyList()
        {
            FruitsList fruits = new FruitsList();
            var actual = fruits.Deserialize("file.txt");
            var expected = new List<Fruit>();
            CollectionAssert.AreEqual(actual, expected);
        }


        [TestCase("Orange")]
        [TestCase("orange")]
        public void Find_PositiveTest(string keyWordColor)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                FruitsList fruits = new FruitsList();
                fruits.fruits.Add(new Fruit("Orange", "Yellow"));
                fruits.fruits.Add(new Fruit("Orange", "Orange"));
                fruits.Find(keyWordColor);

                string expected = new Fruit("Orange", "Orange").ToString() + "\r\n";
                string actual = sw.ToString();
                sw.Close();

                Assert.AreEqual(actual, expected);
            }
        }

        [TestCase("Black")]
        public void Find_NegativeTest(string keyWordColor)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                FruitsList fruits = new FruitsList();
                fruits.fruits.Add(new Fruit("Orange", "Yellow"));
                fruits.fruits.Add(new Fruit("Orange", "Orange"));
                fruits.Find(keyWordColor);

                string expected = "No fruits with color: " + keyWordColor + "\r\n";
                string actual = sw.ToString();
                sw.Close();

                Assert.AreEqual(actual, expected);
            }
        }

        [Test]
        public void OutputToFile_Exception_NoFileExist()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                FruitsList fruits = new FruitsList();
                fruits.OutputToFile("");

                string expected = "Empty path name is not legal.\r\n";
                string actual = sw.ToString();
                sw.Close();

                Assert.AreEqual(actual, expected);
            }
        }

        [Test]
        public void Deserialize_Exception_NoFileExist()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                FruitsList fruits = new FruitsList();
                fruits.Deserialize("");

                string expected = "Empty path name is not legal.\r\n";
                string actual = sw.ToString();
                sw.Close();

                Assert.AreEqual(actual, expected);
            }
        }

        [TestCase("Orange", "Orange", "0,01")]
        [TestCase("Banana", "Yellow", "0,05")]
        public void CitrusInputPrint(string name, string color, string ContentOfVitamin_C_IN_G)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("{1}{0}{2}{0}{3}{0}",
                        Environment.NewLine, name, color, ContentOfVitamin_C_IN_G)))
                {
                    Console.SetIn(sr);

                    Citrus citrus = new Citrus("", "", 2);
                    citrus.Input();
                    citrus.Print();

                    string expected = "Please enter citrus name\r\nPlease enter citrus color\r\nPlease enter the content Of vitamin C in gram\r\n" + citrus.ToString() + "\r\n";
                    string actual = sw.ToString();
                    sr.Close();

                    Assert.AreEqual(expected, actual);
                }
                sw.Close();
            }
        }

        [TestCase("Banana", "Yellow", "0,05q")]
        public void CitrusInputPrint_Exception(string name, string color, string ContentOfVitamin_C_IN_G)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("{1}{0}{2}{0}{3}{0}",
                        Environment.NewLine, name, color, ContentOfVitamin_C_IN_G)))
                {
                    Console.SetIn(sr);

                    Citrus citrus = new Citrus("", "", 2);
                    citrus.Input();
                    citrus.Print();

                    string expected = "Please enter citrus name\r\nPlease enter citrus color\r\nPlease enter the content Of vitamin C in gram\r\nUnable to parse '" + ContentOfVitamin_C_IN_G + "'.\r\n" + citrus.ToString() + "\r\n";
                    string actual = sw.ToString();
                    sr.Close();

                    Assert.AreEqual(expected, actual);
                }
                sw.Close();
            }
        }
    }

}
