using System;
using System.Collections.Generic;
using System.IO;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = @"C:\Users\s18316\Desktop\dane.csv";
                var lines = File.ReadLines(path);
                //TODO stworzenie pliku łog.txt do ktorego beda wpisywane bledy

                var today = DateTime.Now;

                string tmp;
                string[] tab;

               //TODO var hs = new HashSet<Student>(new OwnComparator);




                //dateType - konwertowac
                foreach (var line in lines)
                {
                    tmp = line;
                    tab = tmp.Split(",");
                    if (tab.Length == 9)
                    {
                        //hs.Add(tab);

                    }
                    // Console.WriteLine(line);

                }

                //  TODO foreach(Student in )



                /*to co pan napisal
                 * dos.Add(students);
                 * var studentInfo = new XElement("student", new XAttribute( new
                 * new XElement("fname","Jan
                 * 
                 * students.add(studInfo);
                 * 
                 * doc.Save(@"output.xml");
                 */

            } catch (ArgumentException e)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
                //TODO wpisywanie do pliku
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Plik nazwa nie istnieje");
                //TODO wpisywanie do pliku
            }
        }

    }
}
