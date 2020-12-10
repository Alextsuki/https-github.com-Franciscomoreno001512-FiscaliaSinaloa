﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class UnidadModel
    {
        [Required]
        public int Clave { get; set; }
        [Range(0, 9999999999)]
        public int? Clave_Unica_Municipio { get; set; }
        public int? Clave_de_Municipio { get; set; }
        public string Clave_de_MunicipioNombre { get; set; }
        public int? Clave_de_Region { get; set; }
        public string Clave_de_RegionDescripcion { get; set; }
        public string Abreviacion { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion_Corta { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadDescripcion { get; set; }
        public int? Vigencia { get; set; }
        public string VigenciaAbreviacion { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public int? Supervisor { get; set; }
        public string SupervisorName { get; set; }
        [Range(0, 9999999999)]
        public int? Consecutivo_CDI { get; set; }
        public int? Tipo_de_Asignacion_de_MP { get; set; }
        public string Tipo_de_Asignacion_de_MPDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? cod_pais { get; set; }
        [Range(0, 9999999999)]
        public int? cod_edo { get; set; }
        [Range(0, 9999999999)]
        public int? cod_agencia { get; set; }
        public string FTIPO { get; set; }
        public string fcreada { get; set; }
        public string fbaja { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? ULTAVREGIS { get; set; }
        public string FUBICACION { get; set; }
        [Range(0, 9999999999)]
        public int? vr_agen { get; set; }
        public string Especial { get; set; }
        [Range(0, 9999999999)]
        public int? AgenAV { get; set; }
        public string AgenUni_NSJP { get; set; }
        public string Nomenclatura { get; set; }
        public string Alcance { get; set; }
        public bool ReceptorDeclinaciones { get; set; }

    }
	
	public class Unidad_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        [Range(0, 9999999999)]
        public int? Clave_Unica_Municipio { get; set; }
        public int? Clave_de_Municipio { get; set; }
        public string Clave_de_MunicipioNombre { get; set; }
        public int? Clave_de_Region { get; set; }
        public string Clave_de_RegionDescripcion { get; set; }
        public string Abreviacion { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion_Corta { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadDescripcion { get; set; }
        public int? Vigencia { get; set; }
        public string VigenciaAbreviacion { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public int? Supervisor { get; set; }
        public string SupervisorName { get; set; }
        [Range(0, 9999999999)]
        public int? Consecutivo_CDI { get; set; }
        public int? Tipo_de_Asignacion_de_MP { get; set; }
        public string Tipo_de_Asignacion_de_MPDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? cod_pais { get; set; }
        [Range(0, 9999999999)]
        public int? cod_edo { get; set; }
        [Range(0, 9999999999)]
        public int? cod_agencia { get; set; }
        public string FTIPO { get; set; }
        public string fcreada { get; set; }
        public string fbaja { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? ULTAVREGIS { get; set; }
        public string FUBICACION { get; set; }
        [Range(0, 9999999999)]
        public int? vr_agen { get; set; }
        public string Especial { get; set; }
        [Range(0, 9999999999)]
        public int? AgenAV { get; set; }
        public string AgenUni_NSJP { get; set; }
        public string Nomenclatura { get; set; }
        public string Alcance { get; set; }
        public bool? ReceptorDeclinaciones { get; set; }

    }


}

