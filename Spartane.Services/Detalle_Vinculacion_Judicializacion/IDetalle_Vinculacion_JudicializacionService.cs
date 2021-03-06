﻿using System;
using Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Vinculacion_Judicializacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Vinculacion_JudicializacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_JudicializacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Vinculacion_Judicializacion.Detalle_Vinculacion_Judicializacion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
