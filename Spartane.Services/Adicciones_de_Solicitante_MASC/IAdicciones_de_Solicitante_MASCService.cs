﻿using System;
using Spartane.Core.Domain.Adicciones_de_Solicitante_MASC;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Adicciones_de_Solicitante_MASC
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IAdicciones_de_Solicitante_MASCService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASCPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Adicciones_de_Solicitante_MASC.Adicciones_de_Solicitante_MASC> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
