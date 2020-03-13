using System;
using System.Collections.Generic;

using System.Xml.Serialization;
using cw2;

namespace Cw2
{
    public class  Calosc
    {
        [XmlAttribute] 
        public string createdAt;
        [XmlAttribute] 
        public string author;

        public HashSet<Student> studentsList;
    }
}
