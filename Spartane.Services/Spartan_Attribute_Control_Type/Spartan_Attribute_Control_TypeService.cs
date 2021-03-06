﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Attribute_Control_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Attribute_Control_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Attribute_Control_TypeService : ISpartan_Attribute_Control_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> _Spartan_Attribute_Control_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Attribute_Control_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> Spartan_Attribute_Control_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Attribute_Control_TypeRepository = Spartan_Attribute_Control_TypeRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Attribute_Control_TypePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Attribute_Control_TypeRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_Attribute_Control_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Attribute_Control_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Attribute_Control_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

