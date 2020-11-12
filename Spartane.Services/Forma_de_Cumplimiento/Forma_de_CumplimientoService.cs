﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Forma_de_Cumplimiento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Forma_de_Cumplimiento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Forma_de_CumplimientoService : IForma_de_CumplimientoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> _Forma_de_CumplimientoRepository;
        #endregion

        #region Ctor
        public Forma_de_CumplimientoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> Forma_de_CumplimientoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Forma_de_CumplimientoRepository = Forma_de_CumplimientoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> SelAll(bool ConRelaciones)
        {
            return this._Forma_de_CumplimientoRepository.Table.ToList();
        }

        public IList<Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> SelAllComplete(bool ConRelaciones)
        {
            return this._Forma_de_CumplimientoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Forma_de_CumplimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Forma_de_CumplimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Forma_de_CumplimientoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_CumplimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Forma_de_CumplimientoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Forma_de_CumplimientoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Forma_de_CumplimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento entity, Spartane.Core.Domain.User.GlobalData Forma_de_CumplimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Forma_de_Cumplimiento.Forma_de_Cumplimiento entity, Spartane.Core.Domain.User.GlobalData Forma_de_CumplimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

