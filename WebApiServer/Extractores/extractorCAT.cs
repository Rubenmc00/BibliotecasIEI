using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BibliotecasIEI.Modelos;
using System.Data;

namespace WebApiServer.Extractores
{
    public class extractorCAT
    {
        public async Task<string> cogerCodigoAsyncCAT()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:63554/CAT");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    var catList = JsonConvert.DeserializeObject<List<BibliotecaCAT>>(message);

                    List<string> codProvincias = new List<string>();
                    List<string> codMunicipios = new List<string>();
                   

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

                        string provincia = "";

                        switch(catList[i].cpostal.Substring(0, 2))
                        {
                            case "08":
                                provincia = "Barcelona";
                                break;
                            case "17":
                                provincia = "Girona";
                                break;
                            case "25":
                                provincia = "Lleida";
                                break;
                            case "43":
                                provincia = "Tarragona";
                                break;

                        }


                        SqlConnection sqlConnection1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ruben\\Desktop\\BibliotecasIEI\\BibliotecasIEI\\bin\\Debug\\BaseDeDatos.mdf;Integrated Security=True");

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        
                        cmd.Connection = sqlConnection1;
                        sqlConnection1.Open();
                        if (i != 0)
                        {

                            if (!codMunicipios.Contains(catList[i].codi_municipi))
                            {

                                codMunicipios.Add(catList[i].codi_municipi);
                                cmd.CommandText = "INSERT Localidad(codigoMunicipal, municipio, codProvincia)" +
                            " values ('" + catList[i].codi_municipi + "', '" + catList[i].poblacio + "', '" + catList[i].cpostal.Substring(0, 2) + "')";
                                cmd.ExecuteNonQuery();

                            }
                            if (!codProvincias.Contains(catList[i].cpostal.Substring(0, 2)))
                            {
                                codProvincias.Add(catList[i].cpostal.Substring(0, 2));
                                cmd.CommandText = "INSERT Provincia(codigo, provincia)" +
                            " values ('" + catList[i].cpostal.Substring(0, 2) + "', '" + provincia + "')";
                                cmd.ExecuteNonQuery();
                            }

                        }
                        else
                        {
                            codProvincias.Add(catList[i].cpostal.Substring(0, 2));
                            codMunicipios.Add(catList[i].codi_municipi);
                            cmd.CommandText = "INSERT Localidad(codigoMunicipal, municipio, codProvincia)" +
                           " values ('" + catList[i].codi_municipi + "', '" + catList[i].poblacio + "', '" + catList[i].cpostal.Substring(0, 2) + "')";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "INSERT Provincia(codigo, provincia)" +
                            " values ('" + catList[i].cpostal.Substring(0, 2) + "', '" + provincia + "')";
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandText = "INSERT Biblioteca(nombre, telefono, email, direccion, codigoPostal, longitud, latitud, tipo, descripcion, codMunicipal)" +
                            " values ('" + nombre + "', '" + catList[i].telefon1 + "', '" + catList[i].email + "', '" + catList[i].via + "', '"
                                         + catList[i].cpostal + "', '" + catList[i].longitud + "', '" + catList[i].latitud + "', '" + tipo + "', '" + descripcion + "', '" + catList[i].codi_municipi + "')";

                        cmd.ExecuteNonQuery();
                        sqlConnection1.Close();


                    }
                    return message;
                }
                return "";
            }
        }
    }
}
