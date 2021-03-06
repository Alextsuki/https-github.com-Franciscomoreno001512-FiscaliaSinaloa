﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Aseguramiento_Medios_de_Transporte
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Aseguramiento_Medios_de_TransporteService : IDetalle_Aseguramiento_Medios_de_TransporteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> _Detalle_Aseguramiento_Medios_de_TransporteRepository;
        #endregion

        #region Ctor
        public Detalle_Aseguramiento_Medios_de_TransporteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> Detalle_Aseguramiento_Medios_de_TransporteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Aseguramiento_Medios_de_TransporteRepository = Detalle_Aseguramiento_Medios_de_TransporteRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Aseguramiento_Medios_de_TransporteRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Aseguramiento_Medios_de_TransporteRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Aseguramiento_Medios_de_TransporteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Aseguramiento_Medios_de_TransporteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Aseguramiento_Medios_de_TransporteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_TransportePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Aseguramiento_Medios_de_TransportePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Aseguramiento_Medios_de_TransporteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Aseguramiento_Medios_de_TransporteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte entity, Spartane.Core.Domain.User.GlobalData Detalle_Aseguramiento_Medios_de_TransporteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Aseguramiento_Medios_de_Transporte.Detalle_Aseguramiento_Medios_de_Transporte entity, Spartane.Core.Domain.User.GlobalData Detalle_Aseguramiento_Medios_de_TransporteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

