﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Aseguramiento_Otros;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Aseguramiento_Otros
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Aseguramiento_OtrosService : IDetalle_Aseguramiento_OtrosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> _Detalle_Aseguramiento_OtrosRepository;
        #endregion

        #region Ctor
        public Detalle_Aseguramiento_OtrosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> Detalle_Aseguramiento_OtrosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Aseguramiento_OtrosRepository = Detalle_Aseguramiento_OtrosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Aseguramiento_OtrosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Aseguramiento_OtrosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Aseguramiento_OtrosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Aseguramiento_OtrosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Aseguramiento_OtrosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_OtrosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Aseguramiento_OtrosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Aseguramiento_OtrosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Aseguramiento_OtrosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros entity, Spartane.Core.Domain.User.GlobalData Detalle_Aseguramiento_OtrosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Aseguramiento_Otros.Detalle_Aseguramiento_Otros entity, Spartane.Core.Domain.User.GlobalData Detalle_Aseguramiento_OtrosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

