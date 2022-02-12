using BibliotecasIEI.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebApiServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CATController
    {
        [HttpGet]
        public List<BibliotecaCAT> Get()
        {
            XmlDocument xml = new XmlDocument();
            //xml.Load("Archivos/biblioteques.xml");
            xml.Load("Archivos/demo/CAT.xml");
            XmlNode oXmlNode = xml.LastChild;
            foreach (XmlElement oNode in oXmlNode.ChildNodes)
            {

                var aux = oNode.SelectSingleNode("propietats").InnerText;

                //System.Diagnostics.Debug.WriteLine("hola: " + aux );
                oNode.SelectSingleNode("propietats").InnerText = aux.Replace("<br/>", "; ");
            }

            string catJson = JsonConvert.SerializeXmlNode(xml);

            catJson = catJson.Substring(catJson.IndexOf("row") + 5);
            catJson = catJson.Remove(catJson.Length - 2, 2);


            var catList = JsonConvert.DeserializeObject<List<BibliotecaCAT>>(catJson);
            return catList;
        }
        
    }
}
