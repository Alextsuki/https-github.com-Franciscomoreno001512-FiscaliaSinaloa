﻿using System;
using Spartane.Core.Domain.Marca_de_Medio_de_transporte;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Marca_de_Medio_de_transporte
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMarca_de_Medio_de_transporteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transportePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Marca_de_Medio_de_transporte.Marca_de_Medio_de_transporte> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
