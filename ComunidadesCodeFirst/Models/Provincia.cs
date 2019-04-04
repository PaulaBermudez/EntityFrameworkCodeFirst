using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace ComunidadesCodeFirst.Models
{
    [TableName("Provincia")]
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        public String Nombre { get; set; }

        public int IdComunidad { get; set; }
        public virtual Comunidad comunidad { get; set; }
    }
}