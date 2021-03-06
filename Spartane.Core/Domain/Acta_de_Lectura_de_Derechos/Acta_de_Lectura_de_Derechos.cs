﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Acta_de_Lectura_de_Derechos
{
    /// <summary>
    /// Acta_de_Lectura_de_Derechos table
    /// </summary>
    public class Acta_de_Lectura_de_Derechos: BaseEntity
    {
        public int Clave { get; set; }
        public string NUC { get; set; }
        public string NIC { get; set; }
        public string Folio { get; set; }
        public string Ubicacion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Hora { get; set; }
        public string Agente_de_la_PM { get; set; }
        public string Plaza_de_Adscripcion { get; set; }
        public string Domicilio_de_la_Comandancia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }


    }
	
	public class Acta_de_Lectura_de_Derechos_Datos_Generales
    {
                public int Clave { get; set; }
        public string NUC { get; set; }
        public string NIC { get; set; }
        public string Folio { get; set; }
        public string Ubicacion { get; set; }
        public DateTime? Fecha { get; set; }
        public string Hora { get; set; }
        public string Agente_de_la_PM { get; set; }
        public string Plaza_de_Adscripcion { get; set; }
        public string Domicilio_de_la_Comandancia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }

		
    }


}

