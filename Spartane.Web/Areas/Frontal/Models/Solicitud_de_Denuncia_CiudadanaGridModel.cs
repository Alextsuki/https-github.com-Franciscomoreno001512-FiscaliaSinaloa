﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Solicitud_de_Denuncia_CiudadanaGridModel
    {
        public int Clave { get; set; }
        public string Folio { get; set; }
        public string Contrasena { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public int? Tipo_de_Solicitud { get; set; }
        public string Tipo_de_SolicitudDescripcion { get; set; }
        public int? Estatus_de_Solicitud { get; set; }
        public string Estatus_de_SolicitudDescripcion { get; set; }
        public int? Canalizar_a { get; set; }
        public string Canalizar_aDescripcion { get; set; }
        public int? Unidad_canaliza { get; set; }
        public string Unidad_canalizaDescripcion { get; set; }
        
    }
}

