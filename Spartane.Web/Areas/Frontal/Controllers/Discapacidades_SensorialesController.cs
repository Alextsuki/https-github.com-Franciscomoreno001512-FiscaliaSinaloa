﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Discapacidades_Sensoriales;
using Spartane.Core.Domain.Vigencia;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Discapacidades_Sensoriales;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Discapacidades_Sensoriales;
using Spartane.Web.Areas.WebApiConsumer.Vigencia;

using Spartane.Web.AuthFilters;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format;
using iTextSharp.text.pdf;


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Discapacidades_SensorialesController : Controller
    {
        #region "variable declaration"

        private IDiscapacidades_SensorialesService service = null;
        private IDiscapacidades_SensorialesApiConsumer _IDiscapacidades_SensorialesApiConsumer;
        private IVigenciaApiConsumer _IVigenciaApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
		private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Discapacidades_SensorialesController(IDiscapacidades_SensorialesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDiscapacidades_SensorialesApiConsumer Discapacidades_SensorialesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , IVigenciaApiConsumer VigenciaApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDiscapacidades_SensorialesApiConsumer = Discapacidades_SensorialesApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._IVigenciaApiConsumer = VigenciaApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Discapacidades_Sensoriales
        [ObjectAuth(ObjectId = (ModuleObjectId)45282, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			if (Session["AdvanceReportFilter"] != null)
            {
                Session["AdvanceReportFilter"] = null;
                Session["AdvanceSearch"] = null;
            }
			if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/");
                }
            }
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45282, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Discapacidades_Sensoriales/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)45282, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45282, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varDiscapacidades_Sensoriales = new Discapacidades_SensorialesModel();
			varDiscapacidades_Sensoriales.Clave = Id;
			
            ViewBag.ObjectId = "45282";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Discapacidades_SensorialessData = _IDiscapacidades_SensorialesApiConsumer.ListaSelAll(0, 1000, "Discapacidades_Sensoriales.Clave=" + Id, "").Resource.Discapacidades_Sensorialess;
				
				if (Discapacidades_SensorialessData != null && Discapacidades_SensorialessData.Count > 0)
                {
					var Discapacidades_SensorialesData = Discapacidades_SensorialessData.First();
					varDiscapacidades_Sensoriales= new Discapacidades_SensorialesModel
					{
						Clave  = Discapacidades_SensorialesData.Clave 
	                    ,Descripcion = Discapacidades_SensorialesData.Descripcion
                    ,Vigencia = Discapacidades_SensorialesData.Vigencia
                    ,VigenciaAbreviacion = CultureHelper.GetTraduction(Convert.ToString(Discapacidades_SensorialesData.Vigencia), "Vigencia") ??  (string)Discapacidades_SensorialesData.Vigencia_Vigencia.Abreviacion
                    ,Observaciones = Discapacidades_SensorialesData.Observaciones

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IVigenciaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Vigencias_Vigencia = _IVigenciaApiConsumer.SelAll(true);
            if (Vigencias_Vigencia != null && Vigencias_Vigencia.Resource != null)
                ViewBag.Vigencias_Vigencia = Vigencias_Vigencia.Resource.Where(m => m.Abreviacion != null).OrderBy(m => m.Abreviacion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Vigencia", "Abreviacion") ?? m.Abreviacion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var viewInEframe = false;
			var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

	        if (Request.QueryString["isPartial"]!= null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();
				
			if (Request.QueryString["viewInEframe"] != null)
                viewInEframe = Convert.ToBoolean(Request.QueryString["viewInEframe"]);	
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;
			ViewBag.viewInEframe = viewInEframe;

				
            return View(varDiscapacidades_Sensoriales);
        }
		
	[HttpGet]
        public ActionResult AddDiscapacidades_Sensoriales(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45282);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);
			Discapacidades_SensorialesModel varDiscapacidades_Sensoriales= new Discapacidades_SensorialesModel();


            if (id.ToString() != "0")
            {
                var Discapacidades_SensorialessData = _IDiscapacidades_SensorialesApiConsumer.ListaSelAll(0, 1000, "Discapacidades_Sensoriales.Clave=" + id, "").Resource.Discapacidades_Sensorialess;
				
				if (Discapacidades_SensorialessData != null && Discapacidades_SensorialessData.Count > 0)
                {
					var Discapacidades_SensorialesData = Discapacidades_SensorialessData.First();
					varDiscapacidades_Sensoriales= new Discapacidades_SensorialesModel
					{
						Clave  = Discapacidades_SensorialesData.Clave 
	                    ,Descripcion = Discapacidades_SensorialesData.Descripcion
                    ,Vigencia = Discapacidades_SensorialesData.Vigencia
                    ,VigenciaAbreviacion = CultureHelper.GetTraduction(Convert.ToString(Discapacidades_SensorialesData.Vigencia), "Vigencia") ??  (string)Discapacidades_SensorialesData.Vigencia_Vigencia.Abreviacion
                    ,Observaciones = Discapacidades_SensorialesData.Observaciones

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IVigenciaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Vigencias_Vigencia = _IVigenciaApiConsumer.SelAll(true);
            if (Vigencias_Vigencia != null && Vigencias_Vigencia.Resource != null)
                ViewBag.Vigencias_Vigencia = Vigencias_Vigencia.Resource.Where(m => m.Abreviacion != null).OrderBy(m => m.Abreviacion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Vigencia", "Abreviacion") ?? m.Abreviacion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDiscapacidades_Sensoriales", varDiscapacidades_Sensoriales);
        }


        [HttpGet]
        public FileResult GetFile(int id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(id).Resource;
            if (fileInfo == null)
                return null;
            return File(fileInfo.File, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Description);
        }

        [HttpGet]
        public ActionResult GetVigenciaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVigenciaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IVigenciaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Abreviacion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Vigencia", "Abreviacion")?? m.Abreviacion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Discapacidades_SensorialesAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
				if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return RedirectToAction("Index", "Report", new { id = idFilter });
                }
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IVigenciaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Vigencias_Vigencia = _IVigenciaApiConsumer.SelAll(true);
            if (Vigencias_Vigencia != null && Vigencias_Vigencia.Resource != null)
                ViewBag.Vigencias_Vigencia = Vigencias_Vigencia.Resource.Where(m => m.Abreviacion != null).OrderBy(m => m.Abreviacion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Vigencia", "Abreviacion") ?? m.Abreviacion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IVigenciaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Vigencias_Vigencia = _IVigenciaApiConsumer.SelAll(true);
            if (Vigencias_Vigencia != null && Vigencias_Vigencia.Resource != null)
                ViewBag.Vigencias_Vigencia = Vigencias_Vigencia.Resource.Where(m => m.Abreviacion != null).OrderBy(m => m.Abreviacion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Vigencia", "Abreviacion") ?? m.Abreviacion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Discapacidades_SensorialesAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Discapacidades_SensorialesAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Discapacidades_SensorialesAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Discapacidades_SensorialesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDiscapacidades_SensorialesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Discapacidades_Sensorialess == null)
                result.Discapacidades_Sensorialess = new List<Discapacidades_Sensoriales>();

            return Json(new
            {
                data = result.Discapacidades_Sensorialess.Select(m => new Discapacidades_SensorialesGridModel
                    {
                    Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,VigenciaAbreviacion = CultureHelper.GetTraduction(m.Vigencia_Vigencia.Clave.ToString(), "Abreviacion") ?? (string)m.Vigencia_Vigencia.Abreviacion
			,Observaciones = m.Observaciones

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetDiscapacidades_SensorialesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDiscapacidades_SensorialesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Clave), "Discapacidades_Sensoriales", m.),
                     Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
*/
        /// <summary>
        /// Get List of Discapacidades_Sensoriales from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Discapacidades_Sensoriales Entity</returns>
        public ActionResult GetDiscapacidades_SensorialesList(UrlParametersModel param)
        {
			 int sEcho = param.sEcho;
            int iDisplayStart = param.iDisplayStart;
            int iDisplayLength = param.iDisplayLength;
            string where = param.where;
            string order = param.order;

            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (param.sortColumn != null)
            {
                sortColumn = int.Parse(param.sortColumn);
            }
            if (param.sortDirection != null)
            {
                sortDirection = param.sortDirection;
            }


            if (!_tokenManager.GenerateToken())
                return null;
            _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Discapacidades_SensorialesPropertyMapper());
				
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (param.AdvanceSearch != null && param.AdvanceSearch == true && Session["AdvanceSearch"] != null)            
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Discapacidades_SensorialesAdvanceSearchModel))
                {
					var advanceFilter =
                    (Discapacidades_SensorialesAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Discapacidades_SensorialesPropertyMapper oDiscapacidades_SensorialesPropertyMapper = new Discapacidades_SensorialesPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oDiscapacidades_SensorialesPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IDiscapacidades_SensorialesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Discapacidades_Sensorialess == null)
                result.Discapacidades_Sensorialess = new List<Discapacidades_Sensoriales>();

            return Json(new
            {
                aaData = result.Discapacidades_Sensorialess.Select(m => new Discapacidades_SensorialesGridModel
            {
                    Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,VigenciaAbreviacion = CultureHelper.GetTraduction(m.Vigencia_Vigencia.Clave.ToString(), "Abreviacion") ?? (string)m.Vigencia_Vigencia.Abreviacion
			,Observaciones = m.Observaciones

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Discapacidades_SensorialesAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Discapacidades_Sensoriales.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Discapacidades_Sensoriales.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                switch (filter.DescripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Discapacidades_Sensoriales.Descripcion LIKE '" + filter.Descripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Discapacidades_Sensoriales.Descripcion LIKE '%" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Discapacidades_Sensoriales.Descripcion = '" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Discapacidades_Sensoriales.Descripcion LIKE '%" + filter.Descripcion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceVigencia))
            {
                switch (filter.VigenciaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vigencia.Abreviacion LIKE '" + filter.AdvanceVigencia + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vigencia.Abreviacion LIKE '%" + filter.AdvanceVigencia + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vigencia.Abreviacion = '" + filter.AdvanceVigencia + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vigencia.Abreviacion LIKE '%" + filter.AdvanceVigencia + "%'";
                        break;
                }
            }
            else if (filter.AdvanceVigenciaMultiple != null && filter.AdvanceVigenciaMultiple.Count() > 0)
            {
                var VigenciaIds = string.Join(",", filter.AdvanceVigenciaMultiple);

                where += " AND Discapacidades_Sensoriales.Vigencia In (" + VigenciaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Observaciones))
            {
                switch (filter.ObservacionesFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Discapacidades_Sensoriales.Observaciones LIKE '" + filter.Observaciones + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Discapacidades_Sensoriales.Observaciones LIKE '%" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Discapacidades_Sensoriales.Observaciones = '" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Discapacidades_Sensoriales.Observaciones LIKE '%" + filter.Observaciones + "%'";
                        break;
                }
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Discapacidades_Sensoriales varDiscapacidades_Sensoriales = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDiscapacidades_SensorialesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Discapacidades_SensorialesModel varDiscapacidades_Sensoriales)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Discapacidades_SensorialesInfo = new Discapacidades_Sensoriales
                    {
                        Clave = varDiscapacidades_Sensoriales.Clave
                        ,Descripcion = varDiscapacidades_Sensoriales.Descripcion
                        ,Vigencia = varDiscapacidades_Sensoriales.Vigencia
                        ,Observaciones = varDiscapacidades_Sensoriales.Observaciones

                    };

                    result = !IsNew ?
                        _IDiscapacidades_SensorialesApiConsumer.Update(Discapacidades_SensorialesInfo, null, null).Resource.ToString() :
                         _IDiscapacidades_SensorialesApiConsumer.Insert(Discapacidades_SensorialesInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    return Json(result, JsonRequestBehavior.AllowGet);
				//}
				//return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Discapacidades_Sensoriales script
        /// </summary>
        /// <param name="oDiscapacidades_SensorialesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Discapacidades_SensorialesModuleAttributeList)
        {
            for (int i = 0; i < Discapacidades_SensorialesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Discapacidades_SensorialesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Discapacidades_SensorialesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Discapacidades_SensorialesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Discapacidades_SensorialesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strDiscapacidades_SensorialesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Discapacidades_Sensoriales.js")))
            {
                strDiscapacidades_SensorialesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Discapacidades_Sensoriales element attributes
            string userChangeJson = jsSerialize.Serialize(Discapacidades_SensorialesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDiscapacidades_SensorialesScript.IndexOf("inpuElementArray");
            string splittedString = strDiscapacidades_SensorialesScript.Substring(indexOfArray, strDiscapacidades_SensorialesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDiscapacidades_SensorialesScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strDiscapacidades_SensorialesScript.Substring(indexOfArrayHistory, strDiscapacidades_SensorialesScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strDiscapacidades_SensorialesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDiscapacidades_SensorialesScript.Substring(endIndexOfMainElement + indexOfArray, strDiscapacidades_SensorialesScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Discapacidades_SensorialesModuleAttributeList.ChildModuleAttributeList)
                {
				if (item!= null && item.elements != null  && item.elements.Count>0)
                    ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                    " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                    "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                    "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) +  "\n\r";
            finalResponse += ResponseChild;
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Discapacidades_Sensoriales.js")))
            {
                w.WriteLine(finalResponse);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ReadScriptSettings()
        {
            string strCustomScript = string.Empty;
            
            CustomElementAttribute oCustomElementAttribute = new CustomElementAttribute();

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Discapacidades_Sensoriales.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Discapacidades_Sensoriales.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("function set");
                string childJsonArray = "[";
                if (indexOfChildArray != -1)
                {
                    string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);

                    var funcionsValidations = splittedChildString.Split(new string[] { "function" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var str in funcionsValidations)
                    {
                        var tabla = str.Substring(0, str.IndexOf('('));
                        tabla = tabla.Trim().Replace("set", string.Empty).Replace("Validation", string.Empty);
                        childJsonArray += "{ \"table\": \"" + tabla + "\", \"elements\":";
                        int indexOfChildElement = str.IndexOf('[');
                        int endIndexOfChildElement = str.IndexOf(']') + 1;
                        childJsonArray += str.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement) + "},";
                    }
                }
                childJsonArray = childJsonArray.TrimEnd(',') + "]";
                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();

                if (indexOfChildArray != -1)
                {
                    oCustomElementAttribute.ChildElement = ChildElementList.ToString();
                }
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Discapacidades_SensorialesPropertyBag()
        {
            return PartialView("Discapacidades_SensorialesPropertyBag", "Discapacidades_Sensoriales");
        }
		
		public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            }
            else
            {
                List<Spartan_Business_Rule> partialResult = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Spartan_Business_Rules;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.BusinessRuleId, "").Resource;
                        if (Attribute == 0 && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 1).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 2) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 2 || x.Process_Event == 3).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 3) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 4 || x.Process_Event == 5).Count() > 0)
                        {
                            result.Add(item);
                        }
                        //TODO Faltan en la base de datos cuando creas una row de grilla
                    }
                }
            }
            return result;
        }



        #endregion "Controller Methods"

        #region "Custom methods"
		
		[HttpGet]
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

            MemoryStream ms = new MemoryStream();
           
            //Buscar los Formatos Relacionados
            var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + idFormat, "").Resource.Spartan_Format_Relateds.OrderBy(r => r.Order).ToList();
            if (relacionados.Count > 0)
            {
                var outputDocument = new iTextSharp.text.Document();
                var writer = new PdfCopy(outputDocument, ms);
                outputDocument.Open();
                foreach (var spartan_Format_Related in relacionados)
                {
                    var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(Convert.ToInt32(spartan_Format_Related.FormatId_Related), RecordId).Resource;
                    var reader = new PdfReader(bytePdf);
                    for (var j = 1; j <= reader.NumberOfPages; j++)
                    {
                        writer.AddPage(writer.GetImportedPage(reader, j));
                    }
                    writer.FreeReader(reader);
                    reader.Close();
                }
                writer.Close();
                outputDocument.Close();
                var allPagesContent = ms.GetBuffer();
                ms.Flush();
            }
            else {
                var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);
                ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);           
            }
                
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }
		
		
		
		[HttpGet]
        public ActionResult GetFormats(string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            var formatList = new List<SelectListItem>();

            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
           _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions.Permission_Type = 1 AND Apply=1 ";
            var formatsPermisions = _ISpartan_Format_PermissionsApiConsumer.ListaSelAll(0, 500, whereClause, string.Empty).Resource;
            if (formatsPermisions.RowCount > 0)
            {
                var formats = string.Join(",", formatsPermisions.Spartan_Format_Permissionss.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 45282 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Discapacidades_Sensoriales.Clave= " + RecordId;
                            var result = _IDiscapacidades_SensorialesApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir, string where, string order, dynamic columnsVisible)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);
										  
			string[] arrayColumnsVisible = null;

			 where = HttpUtility.UrlEncode(where);
            if (!_tokenManager.GenerateToken())
                return;

            _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Discapacidades_SensorialesPropertyMapper());
			
			 if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Discapacidades_SensorialesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Discapacidades_SensorialesPropertyMapper oDiscapacidades_SensorialesPropertyMapper = new Discapacidades_SensorialesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oDiscapacidades_SensorialesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDiscapacidades_SensorialesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Discapacidades_Sensorialess == null)
                result.Discapacidades_Sensorialess = new List<Discapacidades_Sensoriales>();

            var data = result.Discapacidades_Sensorialess.Select(m => new Discapacidades_SensorialesGridModel
            {
                Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,VigenciaAbreviacion = CultureHelper.GetTraduction(m.Vigencia_Vigencia.Clave.ToString(), "Abreviacion") ?? (string)m.Vigencia_Vigencia.Abreviacion
			,Observaciones = m.Observaciones

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(45282, arrayColumnsVisible), "Discapacidades_SensorialesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(45282, arrayColumnsVisible), "Discapacidades_SensorialesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(45282, arrayColumnsVisible), "Discapacidades_SensorialesList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir,string where, string order)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

			where = HttpUtility.UrlEncode(where);
										   
            if (!_tokenManager.GenerateToken())
                return null;

            _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Discapacidades_SensorialesPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Discapacidades_SensorialesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Discapacidades_SensorialesPropertyMapper oDiscapacidades_SensorialesPropertyMapper = new Discapacidades_SensorialesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oDiscapacidades_SensorialesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDiscapacidades_SensorialesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Discapacidades_Sensorialess == null)
                result.Discapacidades_Sensorialess = new List<Discapacidades_Sensoriales>();

            var data = result.Discapacidades_Sensorialess.Select(m => new Discapacidades_SensorialesGridModel
            {
                Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,VigenciaAbreviacion = CultureHelper.GetTraduction(m.Vigencia_Vigencia.Clave.ToString(), "Abreviacion") ?? (string)m.Vigencia_Vigencia.Abreviacion
			,Observaciones = m.Observaciones

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
		
		[HttpGet]
        public JsonResult CreateID()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDiscapacidades_SensorialesApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Discapacidades_Sensoriales_Datos_GeneralesModel varDiscapacidades_Sensoriales)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Discapacidades_Sensoriales_Datos_GeneralesInfo = new Discapacidades_Sensoriales_Datos_Generales
                {
                    Clave = varDiscapacidades_Sensoriales.Clave
                                            ,Descripcion = varDiscapacidades_Sensoriales.Descripcion
                        ,Vigencia = varDiscapacidades_Sensoriales.Vigencia
                        ,Observaciones = varDiscapacidades_Sensoriales.Observaciones
                    
                };

                result = _IDiscapacidades_SensorialesApiConsumer.Update_Datos_Generales(Discapacidades_Sensoriales_Datos_GeneralesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Generales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDiscapacidades_SensorialesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IDiscapacidades_SensorialesApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Discapacidades_Sensoriales_Datos_GeneralesModel
                {
                    Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,Vigencia = m.Vigencia
                        ,VigenciaAbreviacion = CultureHelper.GetTraduction(m.Vigencia_Vigencia.Clave.ToString(), "Abreviacion") ?? (string)m.Vigencia_Vigencia.Abreviacion
			,Observaciones = m.Observaciones

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

