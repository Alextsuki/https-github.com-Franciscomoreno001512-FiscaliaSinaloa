﻿using System;
using Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Registro_de_Tiempo_por_Estatus
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegistro_de_Tiempo_por_EstatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_EstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Registro_de_Tiempo_por_Estatus.Registro_de_Tiempo_por_Estatus> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
