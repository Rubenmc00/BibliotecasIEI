using BibliotecasIEI.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiServer.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace WebApiServer.Extractores
{
    public class extractorEUS
    {
        private string codigo;

        
        public async Task<string> cogerCodigoAsync()
        {

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:63554/EUS");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(message);
                   
                    var eusList = JsonConvert.DeserializeObject<List<BibliotecaEUS>>(message);
                    


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

                            string ccc = "Pública";
                            
                           /* SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ruben\\Desktop\\BibliotecasIEI\\BibliotecasIEI\\BaseDeDatos.mdf;Integrated Security=True;Connect Timeout=30");
                            
                            SqlCommand cmd = new SqlCommand();
                            System.Diagnostics.Debug.WriteLine("------------------------------------------------------");
                            cmd.CommandType = CommandType.Text;
                            sqlConnection1.Open();
                            System.Diagnostics.Debug.WriteLine("*************************************************");
                            cmd.Connection = sqlConnection1;
                            
                            cmd.CommandText = "INSERT Biblioteca (nombre, telefono, email, direccion, codigoPostal, longitud, latitud, tipo, descripcion, codMunicipal)" +
                                " VALUES ('" + eusList[i].documentName + "', '" + eusList[i].phone + "', '" + eusList[i].email + "', '" + eusList[i].address + "', '"
                                             + eusList[i].postalcode + "', '" + eusList[i].lonwgs84 + "', '" + eusList[i].latwgs84 + "', '" + ccc + "', '" + eusList[i].documentDescription+"')";
                           

                            System.Diagnostics.Debug.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                            
                            cmd.ExecuteNonQuery();
                            sqlConnection1.Close();

                            */

                        }
                         catch (Exception err)
                        {

                        }
                     }  
                         }
                         else
                         {
                             Console.WriteLine($"response error code: {response.StatusCode}");
                         }
                     }

                     
                    /*
                     for (int i = 0; i < eusList.Count; i++)
                     {
                        try
                         {
                             var telefono = eusList[i].phone;
                             if (telefono.Equals(""))
                             {
                                 telefono = "NO TIENE";

                             }


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
                         }
                         catch (Exception err)
                        {

                        }
                     }     */
                    return codigo;
                }
            }
        }


