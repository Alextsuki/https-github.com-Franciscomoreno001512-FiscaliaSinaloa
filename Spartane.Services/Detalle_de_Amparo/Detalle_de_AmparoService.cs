﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_de_Amparo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Amparo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_AmparoService : IDetalle_de_AmparoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> _Detalle_de_AmparoRepository;
        #endregion

        #region Ctor
        public Detalle_de_AmparoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> Detalle_de_AmparoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_AmparoRepository = Detalle_de_AmparoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> SelAll(bool ConRelaciones)
        {
            return this._Detalle_de_AmparoRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_de_AmparoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_AmparoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_AmparoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_AmparoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_AmparoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_de_AmparoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_AmparoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_de_AmparoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo entity, Spartane.Core.Domain.User.GlobalData Detalle_de_AmparoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_de_Amparo.Detalle_de_Amparo entity, Spartane.Core.Domain.User.GlobalData Detalle_de_AmparoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

