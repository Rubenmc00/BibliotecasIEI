using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecasIEI.Modelos
{
    class BibliotecaCAT
    {
        public String @_id { get; set; }
        public String @_uuid { get; set; }
        public String @_position { get; set; }
        public String @_address { get; set; }
        public String idequipament { get; set; }
        public String alies { get; set; }
        public String nom { get; set; }
        public String categoria { get; set; }
        public String via { get; set; }
        public String cpostal { get; set; }
        public String poblacio { get; set; }
        public String codi_municipi { get; set; }
        public String comarca { get; set; }
        public String telefon1 { get; set; }
        public String utmx { get; set; }
        public String utmy { get; set; }
        public String longitud { get; set; }
        public String latitud { get; set; }
        public String email { get; set; }
        public Dictionary<String,String> web { get; set; }
        public String data_modificacio { get; set; }        
        public String propietats { get; set; }
        public String localitzacio { get; set; }
        }
}
