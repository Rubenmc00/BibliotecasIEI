﻿using BibliotecasIEI.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Data.SqlClient;
using GMap.NET.WindowsForms;
using System.Net;
using System.Net.Http;

namespace BibliotecasIEI
{
    public partial class CargaDeBibliotecas : Form
    {

        //private static WebDriver driver = null;
        GMapOverlay markers = new GMapOverlay("markers");

        public CargaDeBibliotecas()
        {
            InitializeComponent();

        }



        private void bibliotecaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bibliotecaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.modelDataSet);
        }

        private void CargaDeBibliotecas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet.Provincia' Puede moverla o quitarla según sea necesario.
            this.provinciaTableAdapter.Fill(this.modelDataSet.Provincia);
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet.Localidad' Puede moverla o quitarla según sea necesario.
            this.localidadTableAdapter.Fill(this.modelDataSet.Localidad);
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet.Biblioteca' Puede moverla o quitarla según sea necesario.
            this.bibliotecaTableAdapter.Fill(this.modelDataSet.Biblioteca);



        }

        private async void button1_Click_1(object sender, EventArgs e)
        {


            //System.Diagnostics.Process.Start("https://localhost:44353/");




            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:63554/carga");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                    
                   

                }
                else
                {
                    Console.WriteLine($"response error code: {response.StatusCode}");
                }
            }

                Console.ReadLine();
           
            
            /*
            var eusList = obtenerBibliotecasEUS();

            StreamReader t = new StreamReader("Archivos/AlavaCodes.json");
            string CodesAlava = t.ReadToEnd();
            var AlavaCodes = JsonConvert.DeserializeObject<List<Class1>>(CodesAlava);

            StreamReader y = new StreamReader("Archivos/GipuzkoaCodes.json");
            string CodesGipuzkoa = y.ReadToEnd();
            var GipuzkoaCodes = JsonConvert.DeserializeObject<List<Class1>>(CodesGipuzkoa);

            StreamReader u = new StreamReader("Archivos/VizcayaCodes.json");
            string CodesVizcaya = u.ReadToEnd();
            var VizcayaCodes = JsonConvert.DeserializeObject<List<Class1>>(CodesVizcaya);


            for (int i = 0; i < eusList.Count; i++)
            {
                try
                {
                    var telefono = eusList[i].phone;
                    if (telefono.Equals(""))
                    {
                        telefono = "NO TIENE";

                    }

                    string codigo = "";
                    string municipio = eusList[i].municipality;
                    if (municipio.Equals("Donostia / San Sebastián"))
                    {
                        municipio = "Donostia";
                    }
                    else if (municipio.Equals("Vitoria - Gasteiz"))
                    {
                        municipio = "Vitoria";
                    }


                    Boolean codes = false;

                    for (int z = 0; z < GipuzkoaCodes.Count && codes == false; z++)
                    {
                        String p = GipuzkoaCodes[z].NOMBRE;
                        if (p.Contains(municipio))
                        {

                            codes = true;
                            codigo = GipuzkoaCodes[z].CPRO + GipuzkoaCodes[z].CMUN;
                        }
                    }
                    for (int j = 0; j < AlavaCodes.Count && codes == false; j++)
                    {
                        String x = AlavaCodes[j].NOMBRE;
                        if (x.Contains(municipio))
                        {
                            codes = true;
                            codigo = "0" + AlavaCodes[j].CPRO + "0" + AlavaCodes[j].CMUN;

                        }
                    }

                    for (int k = 0; k < VizcayaCodes.Count && codes == false; k++)
                    {
                        String o = VizcayaCodes[k].NOMBRE;
                        if (o.Contains(municipio))
                        {
                            codes = true;
                            codigo = VizcayaCodes[k].CPRO + VizcayaCodes[k].CMUN;

                        }
                    }


                    this.bibliotecaTableAdapter.Insert(
                       eusList[i].documentName,
                       telefono,
                       eusList[i].email,
                       eusList[i].address,
                       eusList[i].postalcode,
                       eusList[i].lonwgs84,
                       eusList[i].latwgs84,
                       "Publica",
                       eusList[i].documentDescription,
                       codigo
                       );

                    this.localidadTableAdapter.Insert(
                         codigo,
                         eusList[i].municipality,
                         eusList[i].postalcode.Substring(0, 2)
                        );

                    this.provinciaTableAdapter.Insert(
                        eusList[i].postalcode.Substring(0, 2),
                        eusList[i].territory
                        );

                }
                catch (Exception err)
                {

                }
                finally
                {
                    this.bibliotecaTableAdapter.Fill(this.modelDataSet.Biblioteca);
                    this.provinciaTableAdapter.Fill(this.modelDataSet.Provincia);
                    this.localidadTableAdapter.Fill(this.modelDataSet.Localidad);
                }
                System.Diagnostics.Debug.WriteLine("Funciona, hasta luego Manin ");

            }*/
        }
        private void button2_Click(object sender, EventArgs e)
        {

            var catList = obtenerBibliotecasCAT();

            for (int i = 0; i < catList.Count; i++)
            {
                var nombre = catList[i].nom;
                if (catList[i].nom.Length == 0)
                {
                    nombre = catList[i].alies;
                }

                var tipo = "Publica";
                if (catList[i].propietats.Contains("Privada"))
                {
                    tipo = "Privada";
                }

                var descripcion = catList[i].categoria;

                try
                {
                    this.bibliotecaTableAdapter.Insert(
                        nombre,
                        catList[i].telefon1,
                        catList[i].email,
                        catList[i].via,
                        catList[i].cpostal,
                        catList[i].longitud,
                        catList[i].latitud,
                        tipo,
                        descripcion,
                        catList[i].codi_municipi
                        );

                    this.localidadTableAdapter.Insert(
                        catList[i].codi_municipi,
                        catList[i].poblacio,
                        catList[i].cpostal.Substring(0, 2)
                        );

                    this.provinciaTableAdapter.Insert(
                        catList[i].cpostal.Substring(0, 2),
                        catList[i].comarca
                        );
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine("hola error en i: " + i + " - con nombre: " + err.Message);
                }
                finally
                {
                    this.bibliotecaTableAdapter.Fill(this.modelDataSet.Biblioteca);
                    this.provinciaTableAdapter.Fill(this.modelDataSet.Provincia);
                    this.localidadTableAdapter.Fill(this.modelDataSet.Localidad);
                }
            }
        }

        private List<BibliotecaVAL> obtenerBibliotecasVAL()
        {
            StreamReader r = new StreamReader("Archivos/demo/CV.json");
            string CVJson = r.ReadToEnd();
            var CV = JsonConvert.DeserializeObject<List<BibliotecaVAL>>(CVJson);
            return CV;
        }
        private List<BibliotecaCAT> obtenerBibliotecasCAT()
        {
            XmlDocument xml = new XmlDocument();
            //xml.Load("Archivos/biblioteques.xml");
            xml.Load("Archivos/demo/CAT.xml");
            XmlNode oXmlNode = xml.LastChild;
            System.Diagnostics.Debug.WriteLine("el child es: " + oXmlNode.Name);

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

        private List<BibliotecaEUS> obtenerBibliotecasEUS()
        {
            StreamReader r = new StreamReader("Archivos/demo/EUS.json");
            string eusJson = r.ReadToEnd();
            var eusList = JsonConvert.DeserializeObject<List<BibliotecaEUS>>(eusJson);
            return eusList;
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("press any key cont...");
            Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:63554/VAL");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine($"response error code: {response.StatusCode}");
                }
            }

            Console.ReadLine();



            /*var CV = obtenerBibliotecasVAL();

            for (int i = 0; i < CV.Count; i++)
            {
                try
                {
                   String path = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\ºIDE\\geckodriver.exe";
                    System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", path);
                    IWebDriver driver = new ChromeDriver();
                    driver.Url = "https://www.coordenadas-gps.com/";
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless");
                    options.AddArgument("--disable-geolocation");
                    driver.Manage().Window.Maximize();
                    Thread.Sleep(1000);

                    driver.FindElement(By.Id("longitude")).Clear();
                    driver.FindElement(By.Id("latitude")).Clear();
                    Thread.Sleep(1000);

                    driver.FindElement(By.Id("address")).Clear();
                    driver.FindElement(By.Id("address")).SendKeys(CV[i].DIRECCION);

                    driver.FindElement(By.XPath("//button[text()='Obtener Coordenadas GPS']")).Click();

                    Thread.Sleep(2500);

                    Thread.Sleep(1000);
                    String longi = driver.FindElement(By.Id("longitude")).GetAttribute("value");
                    String lat = driver.FindElement(By.Id("latitude")).GetAttribute("value");

                    Thread.Sleep(1000);
                    driver.Quit();

                    System.Diagnostics.Debug.WriteLine(CV[i].COD_MUNICIPIO);

                    String telf = CV[i].TELEFONO.Substring(6);

                   

                    this.bibliotecaTableAdapter.Insert(
                       CV[i].NOMBRE,
                       telf,
                       CV[i].EMAIL,
                       CV[i].DIRECCION,
                       CV[i].CP,
                       longi,
                       lat,
                       CV[i].TIPO,
                       CV[i].DES_CARACTER,
                        CV[i].COD_MUNICIPIO
                       );

                    this.localidadTableAdapter.Insert(
                         CV[i].COD_MUNICIPIO,
                         CV[i].NOM_MUNICIPIO,
                         CV[i].COD_PROVINCIA
                        );

                    this.provinciaTableAdapter.Insert(
                        CV[i].COD_PROVINCIA,
                        CV[i].NOM_PROVINCIA
                        );

                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine("Error de la biblioteca en __i: " + i + " - con nombre: " + err.Message);
                }
                finally
                {
                    this.bibliotecaTableAdapter.Fill(this.modelDataSet.Biblioteca);
                    this.provinciaTableAdapter.Fill(this.modelDataSet.Provincia);
                    this.localidadTableAdapter.Fill(this.modelDataSet.Localidad);
                }
                System.Diagnostics.Debug.WriteLine("Funciona, hasta luego Manin ");
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //no va
            System.Diagnostics.Debug.WriteLine("Borrado inicio ");

            //var conString = "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = C:\\CORENTINE\\VDI\\ALUMNO\\ILESDEB\\Escritorio\\ru\\BibliotecasIEI\\BibliotecasIEI\\bin\\Debug\\BaseDeDatos.mdf; Integrated Security = True";
            var conString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\BaseDeDatos.mdf ; Integrated Security = True; Encrypt=False;TrustServerCertificate=False";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand command1 = new SqlCommand("DELETE FROM biblioteca", con);
            SqlCommand command2 = new SqlCommand("DELETE FROM provincia", con);
            SqlCommand command3 = new SqlCommand("DELETE FROM localidad", con);
            try
            {
                con.Open();
                bibliotecaTableAdapter.Adapter.DeleteCommand = command1;
                bibliotecaTableAdapter.Adapter.DeleteCommand.ExecuteNonQuery();
                bibliotecaTableAdapter.Adapter.DeleteCommand = command2;
                bibliotecaTableAdapter.Adapter.DeleteCommand.ExecuteNonQuery();
                bibliotecaTableAdapter.Adapter.DeleteCommand = command3;
                bibliotecaTableAdapter.Adapter.DeleteCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("Borrado fin ");
                this.bibliotecaTableAdapter.Fill(this.modelDataSet.Biblioteca);
                this.provinciaTableAdapter.Fill(this.modelDataSet.Provincia);
                this.localidadTableAdapter.Fill(this.modelDataSet.Localidad);
            }







        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormularioBusqueda form = new FormularioBusqueda();
            form.Show();
        }
    }
}
