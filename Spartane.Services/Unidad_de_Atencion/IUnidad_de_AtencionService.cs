﻿using System;
using Spartane.Core.Domain.Unidad_de_Atencion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Unidad_de_Atencion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IUnidad_de_AtencionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_AtencionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Unidad_de_Atencion.Unidad_de_Atencion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
