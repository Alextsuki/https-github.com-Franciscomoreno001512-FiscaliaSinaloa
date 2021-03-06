﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_del_IndicioModel
    {
        [Required]
        public int Clave { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_de_Indicio { get; set; }
        public string Nombre_del_Indicio { get; set; }
        public string Descripcion_del_Indicio { get; set; }
        public string Motivo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public string Ubicacion_de_Indicio { get; set; }

    }
	
	public class Detalle_del_Indicio_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_de_Indicio { get; set; }
        public string Nombre_del_Indicio { get; set; }
        public string Descripcion_del_Indicio { get; set; }
        public string Motivo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public string Ubicacion_de_Indicio { get; set; }

    }


}

