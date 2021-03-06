﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Control_de_Detencion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Control_de_Detencion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Control_de_DetencionService : IControl_de_DetencionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion> _Control_de_DetencionRepository;
        #endregion

        #region Ctor
        public Control_de_DetencionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion> Control_de_DetencionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Control_de_DetencionRepository = Control_de_DetencionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion> SelAll(bool ConRelaciones)
        {
            return this._Control_de_DetencionRepository.Table.ToList();
        }

        public IList<Core.Domain.Control_de_Detencion.Control_de_Detencion> SelAllComplete(bool ConRelaciones)
        {
            return this._Control_de_DetencionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Control_de_DetencionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Control_de_DetencionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Control_de_DetencionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Control_de_Detencion.Control_de_DetencionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Control_de_DetencionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Control_de_DetencionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Control_de_DetencionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion entity, Spartane.Core.Domain.User.GlobalData Control_de_DetencionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Control_de_Detencion.Control_de_Detencion entity, Spartane.Core.Domain.User.GlobalData Control_de_DetencionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

