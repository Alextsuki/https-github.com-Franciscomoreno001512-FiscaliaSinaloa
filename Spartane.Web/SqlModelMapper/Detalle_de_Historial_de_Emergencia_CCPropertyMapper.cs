﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_de_Historial_de_Emergencia_CC;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_de_Historial_de_Emergencia_CCPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Detalle_de_Historial_de_Emergencia_CC.Clave";
                case "Fecha":
                    return "Detalle_de_Historial_de_Emergencia_CC.Fecha";
                case "Hora":
                    return "Detalle_de_Historial_de_Emergencia_CC.Hora";
                case "Latitud":
                    return "Detalle_de_Historial_de_Emergencia_CC.Latitud";
                case "Longitud":
                    return "Detalle_de_Historial_de_Emergencia_CC.Longitud";
                case "Estatus":
                    return "Detalle_de_Historial_de_Emergencia_CC.Estatus";
                case "Comentarios":
                    return "Detalle_de_Historial_de_Emergencia_CC.Comentarios";
                case "Usuario_que_registra":
                    return "Detalle_de_Historial_de_Emergencia_CC.Usuario_que_registra";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_de_Historial_de_Emergencia_CC).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }


            var operatorCondition = GetOperationType(columnName);
            columnName = GetPropertyName(columnName);

            switch (operatorCondition)
            {
                case SqlOperationType.Contains:
                    return string.IsNullOrEmpty(Convert.ToString(value)) ? "" : columnName + " LIKE '%" + value + "%'";
                case SqlOperationType.Equals:
                    return Convert.ToString(value) == "0" || Convert.ToString(value) == "" ? "" : columnName + "='" + value + "'";

            }
            return null;
        }
    }
}

