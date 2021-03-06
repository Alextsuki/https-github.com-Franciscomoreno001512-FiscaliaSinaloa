﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class SentenciaModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Descr { get; set; }
        [Range(0, 9999999999)]
        public short? iddatos { get; set; }
        public string CveSentencia { get; set; }

    }
	
	public class Sentencia_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Descr { get; set; }
        [Range(0, 9999999999)]
        public short? iddatos { get; set; }
        public string CveSentencia { get; set; }

    }


}

