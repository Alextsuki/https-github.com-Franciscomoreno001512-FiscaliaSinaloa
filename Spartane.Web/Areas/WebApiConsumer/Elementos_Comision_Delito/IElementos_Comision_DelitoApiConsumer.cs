﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Elementos_Comision_Delito
{
    public interface IElementos_Comision_DelitoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_DelitoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Elementos_Comision_DelitoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito entity, Spartane.Core.Domain.User.GlobalData Elementos_Comision_DelitoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito entity, Spartane.Core.Domain.User.GlobalData Elementos_Comision_DelitoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_DelitoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

