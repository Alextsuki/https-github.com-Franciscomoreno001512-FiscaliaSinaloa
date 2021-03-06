﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Presentation_View
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_Presentation_ViewService : ISpartan_Report_Presentation_ViewService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> _Spartan_Report_Presentation_ViewRepository;
        #endregion

        #region Ctor
        public Spartan_Report_Presentation_ViewService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> Spartan_Report_Presentation_ViewRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_Presentation_ViewRepository = Spartan_Report_Presentation_ViewRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Report_Presentation_ViewPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_Presentation_ViewRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

