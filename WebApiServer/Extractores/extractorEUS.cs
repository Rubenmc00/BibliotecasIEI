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
using System.Configuration;
using System.Collections;

namespace WebApiServer.Extractores
{
    public class extractorEUS
    {
        private string codigo;

        
        public async Task<string> cogerCodigoAsyncEUS()
        {

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:63554/EUS");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                   
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

                    List<string> codProvincias = new List<string>();
                    List<string> codMunicipios = new List<string>();
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

                            string ccc = "Publica";

                            SqlConnection sqlConnection1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ruben\\Desktop\\BibliotecasIEI\\BibliotecasIEI\\bin\\Debug\\BaseDeDatos.mdf;Integrated Security=True");

                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.Text;

                            cmd.Connection = sqlConnection1;
                            sqlConnection1.Open();
                            if (i != 0) {

                                if (!codMunicipios.Contains(codigo))
                                {
                                    codMunicipios.Add(codigo);
                                    cmd.CommandText = "INSERT Localidad(codigoMunicipal, municipio, codProvincia)" +
                                      " values ('" + codigo + "', '" + eusList[i].municipality + "', '" + eusList[i].postalcode.Substring(0, 2) + "')";
                                    cmd.ExecuteNonQuery();

                                }
                                if (!codProvincias.Contains(eusList[i].postalcode.Substring(0, 2)))
                                {
                                    codProvincias.Add(eusList[i].postalcode.Substring(0, 2));
                                    cmd.CommandText = "INSERT Provincia(codigo, provincia)" +
                                        " values ('" + eusList[i].postalcode.Substring(0, 2) + "', '" + eusList[i].territory + "')";
                                    cmd.ExecuteNonQuery();
                                }

                            }
                            else
                            {
                                codProvincias.Add(eusList[i].postalcode.Substring(0, 2));
                                codMunicipios.Add(codigo);
                                cmd.CommandText = "INSERT Provincia(codigo, provincia)" +
                                        " values ('" + eusList[i].postalcode.Substring(0, 2) + "', '" + eusList[i].territory + "')";
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = "INSERT Localidad(codigoMunicipal, municipio, codProvincia)" +
                                       " values ('" + codigo + "', '" + eusList[i].municipality + "', '" + eusList[i].postalcode.Substring(0, 2) + "')";
                                cmd.ExecuteNonQuery();
                            }
                            



                            cmd.CommandText = "INSERT Biblioteca(nombre, telefono, email, direccion, codigoPostal, longitud, latitud, tipo, descripcion, codMunicipal)" +
                                " values ('" + eusList[i].documentName + "', '" + eusList[i].phone + "', '" + eusList[i].email + "', '" + eusList[i].address + "', '"
                                             + eusList[i].postalcode + "', '" + eusList[i].lonwgs84 + "', '" + eusList[i].latwgs84 + "', '" + ccc + "', '" + eusList[i].documentDescription+ "', '"+codigo+"')";

                          
                            cmd.ExecuteNonQuery();
                            sqlConnection1.Close();

                         }
                         catch (Exception err)
                        {

                        }
                     }
                    return message;
                         }
                         else
                         {
                             Console.WriteLine($"response error code: {response.StatusCode}");
                         }
                     }

                    return "";
                }
            }
        }


