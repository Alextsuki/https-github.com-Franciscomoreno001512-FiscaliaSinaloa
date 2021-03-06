﻿using System;
using Spartane.Core.Domain.Sentencia;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Sentencia
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISentenciaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Sentencia.Sentencia> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Sentencia.Sentencia> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Sentencia.Sentencia> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Sentencia.Sentencia GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Sentencia.Sentencia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Sentencia.Sentencia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Sentencia.Sentencia> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Sentencia.Sentencia> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Sentencia.SentenciaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Sentencia.Sentencia> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
