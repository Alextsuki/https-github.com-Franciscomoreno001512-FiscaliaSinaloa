﻿using System;
using Spartane.Core.Domain.Indicios_MP;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Indicios_MP
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IIndicios_MPService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Indicios_MP.Indicios_MP> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Indicios_MP.Indicios_MP> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Indicios_MP.Indicios_MP> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Indicios_MP.Indicios_MP GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Indicios_MP.Indicios_MP entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Indicios_MP.Indicios_MP entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Indicios_MP.Indicios_MP> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Indicios_MP.Indicios_MP> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Indicios_MP.Indicios_MPPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Indicios_MP.Indicios_MP> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
