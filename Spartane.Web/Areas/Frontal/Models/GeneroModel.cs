﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class GeneroModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string sexo { get; set; }
        public string Inicial { get; set; }

    }
	
	public class Genero_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string sexo { get; set; }
        public string Inicial { get; set; }

    }


}

