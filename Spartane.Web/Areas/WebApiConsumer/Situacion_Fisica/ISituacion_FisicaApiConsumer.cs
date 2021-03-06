﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Situacion_Fisica
{
    public interface ISituacion_FisicaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Situacion_Fisica.Situacion_FisicaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Situacion_FisicaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica entity, Spartane.Core.Domain.User.GlobalData Situacion_FisicaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica entity, Spartane.Core.Domain.User.GlobalData Situacion_FisicaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Situacion_Fisica.Situacion_FisicaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Situacion_Fisica.Situacion_Fisica_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

