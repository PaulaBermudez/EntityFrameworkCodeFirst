using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace ComunidadesCodeFirst.Models
{
    [TableName("Comunidades")]
    public class Comunidad
    {
        [Key]
        public int IdComunidad { get; set; }
        public String Nombre { get; set; }
        public virtual List<Provincia> Provincias { get; set; }
    }
}