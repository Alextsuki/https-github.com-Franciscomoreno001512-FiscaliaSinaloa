﻿using System;
using Spartane.Core.Domain.Detalle_de_Persona_Moral;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_de_Persona_Moral
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_Persona_MoralService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_MoralPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_de_Persona_Moral.Detalle_de_Persona_Moral> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
