﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_de_Otro_Nombre;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Otro_Nombre
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Otro_NombreService : IDetalle_de_Otro_NombreService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> _Detalle_de_Otro_NombreRepository;
        #endregion

        #region Ctor
        public Detalle_de_Otro_NombreService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> Detalle_de_Otro_NombreRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Otro_NombreRepository = Detalle_de_Otro_NombreRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> SelAll(bool ConRelaciones)
        {
            return this._Detalle_de_Otro_NombreRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_de_Otro_NombreRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Otro_NombreRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Otro_NombreRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Otro_NombreRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_NombrePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_de_Otro_NombrePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Otro_NombreRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_de_Otro_NombreInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Otro_NombreInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_de_Otro_Nombre.Detalle_de_Otro_Nombre entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Otro_NombreInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

