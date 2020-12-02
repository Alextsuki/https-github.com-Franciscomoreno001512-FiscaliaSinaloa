﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Calibre_de_Arma
{
    public interface ICalibre_de_ArmaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_ArmaPagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Calibre_de_ArmaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma entity, Spartane.Core.Domain.User.GlobalData Calibre_de_ArmaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma entity, Spartane.Core.Domain.User.GlobalData Calibre_de_ArmaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_ArmaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<short> GenerateID();
		ApiResponse<short> Update_Datos_Generales(Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Calibre_de_Arma.Calibre_de_Arma_Datos_Generales> Get_Datos_Generales(string Key);


    }
}
