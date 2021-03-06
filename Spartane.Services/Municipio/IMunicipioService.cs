﻿using System;
using Spartane.Core.Domain.Municipio;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Municipio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMunicipioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Municipio.Municipio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Municipio.Municipio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Municipio.Municipio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Municipio.Municipio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Municipio.Municipio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Municipio.Municipio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Municipio.Municipio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Municipio.Municipio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Municipio.MunicipioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Municipio.Municipio> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
