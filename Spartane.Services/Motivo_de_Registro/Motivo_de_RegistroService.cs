﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Motivo_de_Registro;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Motivo_de_Registro
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Motivo_de_RegistroService : IMotivo_de_RegistroService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro> _Motivo_de_RegistroRepository;
        #endregion

        #region Ctor
        public Motivo_de_RegistroService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro> Motivo_de_RegistroRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Motivo_de_RegistroRepository = Motivo_de_RegistroRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro> SelAll(bool ConRelaciones)
        {
            return this._Motivo_de_RegistroRepository.Table.ToList();
        }

        public IList<Core.Domain.Motivo_de_Registro.Motivo_de_Registro> SelAllComplete(bool ConRelaciones)
        {
            return this._Motivo_de_RegistroRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Motivo_de_RegistroRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Motivo_de_RegistroRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Motivo_de_RegistroRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_RegistroPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Motivo_de_RegistroPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Motivo_de_RegistroRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Motivo_de_RegistroInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro entity, Spartane.Core.Domain.User.GlobalData Motivo_de_RegistroInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro entity, Spartane.Core.Domain.User.GlobalData Motivo_de_RegistroInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

