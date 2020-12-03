﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Aseguramientos;
using Spartane.Core.Domain.Tipo_de_Equipo_Tactico;
using Spartane.Core.Domain.Marca_de_Equipo_Tactico;
using Spartane.Core.Domain.Modelo_de_equipo_tactico;
using Spartane.Core.Domain.Unidad_de_Medida_de_Equipo_Tactico;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Aseguramiento_Otros_Aseguramientos
{
    /// <summary>
    /// Detalle_Aseguramiento_Otros_Aseguramientos table
    /// </summary>
    public class Detalle_Aseguramiento_Otros_Aseguramientos: BaseEntity
    {
        public int Clave { get; set; }
        public int? Aseguramiento { get; set; }
        public short? Tipo { get; set; }
        public short? Marca { get; set; }
        public short? Modelo { get; set; }
        public string Inventario { get; set; }
        public string Serie { get; set; }
        public short? Unidad_de_Medida { get; set; }
        public decimal? Cantidad { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("Aseguramiento")]
        public virtual Spartane.Core.Domain.Aseguramientos.Aseguramientos Aseguramiento_Aseguramientos { get; set; }
        [ForeignKey("Tipo")]
        public virtual Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico Tipo_Tipo_de_Equipo_Tactico { get; set; }
        [ForeignKey("Marca")]
        public virtual Spartane.Core.Domain.Marca_de_Equipo_Tactico.Marca_de_Equipo_Tactico Marca_Marca_de_Equipo_Tactico { get; set; }
        [ForeignKey("Modelo")]
        public virtual Spartane.Core.Domain.Modelo_de_equipo_tactico.Modelo_de_equipo_tactico Modelo_Modelo_de_equipo_tactico { get; set; }
        [ForeignKey("Unidad_de_Medida")]
        public virtual Spartane.Core.Domain.Unidad_de_Medida_de_Equipo_Tactico.Unidad_de_Medida_de_Equipo_Tactico Unidad_de_Medida_Unidad_de_Medida_de_Equipo_Tactico { get; set; }

    }
	
	public class Detalle_Aseguramiento_Otros_Aseguramientos_Datos_Generales
    {
                public int Clave { get; set; }
        public int? Aseguramiento { get; set; }
        public short? Tipo { get; set; }
        public short? Marca { get; set; }
        public short? Modelo { get; set; }
        public string Inventario { get; set; }
        public string Serie { get; set; }
        public short? Unidad_de_Medida { get; set; }
        public decimal? Cantidad { get; set; }
        public string Observaciones { get; set; }

		        [ForeignKey("Aseguramiento")]
        public virtual Spartane.Core.Domain.Aseguramientos.Aseguramientos Aseguramiento_Aseguramientos { get; set; }
        [ForeignKey("Tipo")]
        public virtual Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico Tipo_Tipo_de_Equipo_Tactico { get; set; }
        [ForeignKey("Marca")]
        public virtual Spartane.Core.Domain.Marca_de_Equipo_Tactico.Marca_de_Equipo_Tactico Marca_Marca_de_Equipo_Tactico { get; set; }
        [ForeignKey("Modelo")]
        public virtual Spartane.Core.Domain.Modelo_de_equipo_tactico.Modelo_de_equipo_tactico Modelo_Modelo_de_equipo_tactico { get; set; }
        [ForeignKey("Unidad_de_Medida")]
        public virtual Spartane.Core.Domain.Unidad_de_Medida_de_Equipo_Tactico.Unidad_de_Medida_de_Equipo_Tactico Unidad_de_Medida_Unidad_de_Medida_de_Equipo_Tactico { get; set; }

    }


}

