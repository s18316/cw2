using cw2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
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

            
                dane[0] = args.Length > 0 ? args[0] : @"data.csv" ;
                dane[1] = args.Length > 1 ? args[1] : @"żesult.xml";
                dane[2] = args.Length > 2 ? args[2] : "xml";
             
                try
                {


                    //uzywanie naszego comperatora
                    int ileComp = 0;
                    int ileMedia = 0;
                    var listaStud = new HashSet<Student>(new OwnComparator());
                    var stream = new StreamReader(File.OpenRead(Path.GetFullPath(dane[0])));
                    string line = stream.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {

                        bool czyWypisac = true;

                        string[] student = line.Split(',');

                        //poszukiwanie pusych kollumn
                          var regex = new Regex("$\\s+");
                        for (int i = 0; i < student.Length; i++)
                        {
                            var matches = regex.Matches(student[i]);
                            if (matches.Count > 0)
                            {
                                writer.WriteLine(line);
                                czyWypisac = false;
                            }
                        }

                        if (student.Length == 9 && czyWypisac == true)
                        {
                            //zniczanie ucznow na poszczegolnych kierunkach
                            if (student[2].Equals("New Media Art")) ileMedia++;
                            if (student[2].Equals("Computer Science")) ileComp++;

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

            //         Calosc cal = new Calosc()
            //         {
            //             createdAt = DateTime.Today.ToShortDateString(),
            //             author = "Sasha Rzepkowska",
            //             studentsList = listaStud
            // };
                    //wersja XML
                    if (dane[2] == "xml")
                    {
                        FileStream XML = new FileStream(dane[1], FileMode.Create);
                        XmlSerializer serializer =
                            new XmlSerializer(typeof(HashSet<Student>), new XmlRootAttribute("uczelnia"));
                        serializer.Serialize(XML, listaStud);

                        XML.Close();
                        XML.Dispose();

                    }

                    // wersja JSON

                    if (dane[2] == "json")
                    {
                        FileStream JStream = new FileStream(dane[1], FileMode.Create);
                        StreamWriter Json = new StreamWriter(JStream);
                        {

                            foreach (var stud in listaStud)
                                Json.WriteLine(JsonConvert.SerializeObject(stud));

                        }
                        


                    }





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