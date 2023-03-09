using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _09._03._2023HM
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xDocument = XDocument.Load("Phone.xml");

            XElement xElement = xDocument.Root;

            xElement.Add(new XElement("Phone",
                new XAttribute("Name_Phone", "Apple"),
                new XAttribute("Name_Company", "Apple"),
                new XAttribute("Price", "1000$")
                ));
            xDocument.Save("Phone.xml");

            ////////////////поиск
            
            var tom = xDocument.Element("Phone")?   
                .Elements("Name_Company")            
                .FirstOrDefault(p => p.Attribute("name")?.Value == "Apple");

            var Name_P = tom?.Attribute("Name_Phone").Value;
            var Age_P = tom?.Element("Name_Company").Value;
            var Company_P = tom?.Element("Price").Value;
            Console.WriteLine($"Name_Phone: {Name_P}  Name_Company: {Age_P}  Price: {Company_P}");

            ////////////////добавление

            xElement.Add(new XElement("Phone",
               new XAttribute("Name_Phone", "Sumsung"),
               new XAttribute("Name_Company", "Android"),
               new XAttribute("Price", "400$")
               ));
            xDocument.Save("Phone.xml");

            ////////////////удаление

            var rem = xElement.Elements("Phone")
                .FirstOrDefault(P => P.Attribute("Name_Company")?.Value == "Android");
            if (rem!=null)
            {
                rem.Remove();
                xDocument.Save("Phone.xml");
            }

            ////////////////показ на кансоль

            var Print_NAme = tom.Attribute("Name_Phone").Value;
            var Print_Company = tom.Element("Name_Company").Value;
            var Print_Price = tom.Element("Price_Phone").Value;
            Console.WriteLine($"Name_Phone\t{Print_NAme}\nName_Company{Print_Company}\nPrice_Phone{Print_Price}\n");

            ////////////////редактировать

            var edit = xElement.Element("Name_Company")?
                .Elements("Name_Company")
                .FirstOrDefault(p => p.Attribute("Name_Phone")?.Value == "LG");

            if (tom != null)
            {
            
                var name = tom.Attribute("Name_Phone");
                if (name != null) name.Value = "LG";


               
                var Age_P = tom.Element("Name_Company");
                if (Age_P != null) Age_P.Value = "700$";

                xElement.Save("Phone.xml");
            }


        }
    }
}
