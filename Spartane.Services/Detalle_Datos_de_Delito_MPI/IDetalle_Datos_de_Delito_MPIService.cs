﻿using System;
using Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Datos_de_Delito_MPI
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Datos_de_Delito_MPIService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPIPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI.Detalle_Datos_de_Delito_MPI> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
