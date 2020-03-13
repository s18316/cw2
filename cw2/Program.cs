﻿using cw2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var log = File.Create("łog.txt");

            StreamWriter writer = new StreamWriter(log);
            
            
            
            string[] dane = new string[3];

            if (args.Length >= 1)
                dane[0] = args[0];
            else
                dane[0] = "data.csv";

            if (args.Length >= 2)
                dane[1] = args[1];
            else
                dane[1] = "żesult.xml";

            if (args.Length >= 3)
                dane[2] = args[2];
            else
                dane[2] = "xml";

                try
                {

                    var listaStud = new HashSet<Student>(new OwnComparator());


                    var stream = new StreamReader(File.OpenRead(Path.GetFullPath(dane[0])));

                    string line = stream.ReadLine();


                    while (line != null)
                    {

                        bool wpisywac = true;

                        string[] student = line.Split(',');

                          var regex = new Regex("$\\s+");
                        for (int i = 0; i < student.Length; i++)
                        {
                            var matches = regex.Matches(student[i]);

                            if (matches.Count > 0)
                            {
                                writer.WriteLine(line);
                                wpisywac = false;
                            }
                        }

                        if (student.Length == 9 && wpisywac == true)
                        {
                            var st = new Student
                            {

                                fName = student[0],
                                lName = student[1],
                                sName = student[2],
                                sMode = student[3],
                                index = student[4],
                                birthdate = student[5],
                                email = student[6],
                                mothersName = student[7],
                                fathersName = student[8]



                            };


                            if (!listaStud.Add(st))
                            {
                                writer.WriteLine(line);
                            }


                        }
                        line = stream.ReadLine();

                }

                    FileStream XML = new FileStream(dane[1], FileMode.Create);
                            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Student>), new XmlRootAttribute("uczelnia"));
                            serializer.Serialize(XML, listaStud);

                            XML.Close();
                            XML.Dispose();
                         
                        
                    

                }
                catch (ArgumentException e)
                {
                    string mess = "Podana ścieżka jest niepoprawna";
                    Console.WriteLine(mess);
                    writer.WriteLine(mess);
                }
                catch (FileNotFoundException e)
                {
                    string mess = "nazwa Pliku nie istnieje";
                    Console.WriteLine(mess);
                    writer.WriteLine(mess);
                }
            
                             writer.Close();
                            writer.Dispose();
        }
    }
}