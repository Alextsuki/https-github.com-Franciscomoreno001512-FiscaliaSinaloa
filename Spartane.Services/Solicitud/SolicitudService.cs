﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Solicitud;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Solicitud
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SolicitudService : ISolicitudService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Solicitud.Solicitud> _SolicitudRepository;
        #endregion

        #region Ctor
        public SolicitudService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Solicitud.Solicitud> SolicitudRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SolicitudRepository = SolicitudRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Solicitud.Solicitud> SelAll(bool ConRelaciones)
        {
            return this._SolicitudRepository.Table.ToList();
        }

        public IList<Core.Domain.Solicitud.Solicitud> SelAllComplete(bool ConRelaciones)
        {
            return this._SolicitudRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Solicitud.Solicitud> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SolicitudRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Solicitud.Solicitud> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._SolicitudRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Solicitud.Solicitud> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SolicitudRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Solicitud.SolicitudPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            SolicitudPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Solicitud.Solicitud> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._SolicitudRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Solicitud.Solicitud GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Solicitud.Solicitud result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData SolicitudInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Solicitud.Solicitud entity, Spartane.Core.Domain.User.GlobalData SolicitudInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Solicitud.Solicitud entity, Spartane.Core.Domain.User.GlobalData SolicitudInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

