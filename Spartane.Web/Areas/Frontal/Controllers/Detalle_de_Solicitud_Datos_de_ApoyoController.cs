﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_de_Solicitud_Datos_de_Apoyo;
using Spartane.Core.Domain.Solicitud;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_de_Servicio_de_Apoyo;
using Spartane.Core.Domain.Detalle_de_Solicitud_Solicitante;
using Spartane.Core.Domain.Idioma;
using Spartane.Core.Domain.Dialecto;
using Spartane.Core.Domain.Detalle_de_documentos;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_de_Solicitud_Datos_de_Apoyo;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Solicitud_Datos_de_Apoyo;
using Spartane.Web.Areas.WebApiConsumer.Solicitud;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Servicio_de_Apoyo;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Solicitud_Solicitante;
using Spartane.Web.Areas.WebApiConsumer.Idioma;
using Spartane.Web.Areas.WebApiConsumer.Dialecto;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_documentos;

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
    public class Detalle_de_Solicitud_Datos_de_ApoyoController : Controller
    {
        #region "variable declaration"

        private IDetalle_de_Solicitud_Datos_de_ApoyoService service = null;
        private IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer;
        private ISolicitudApiConsumer _ISolicitudApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITipo_de_Servicio_de_ApoyoApiConsumer _ITipo_de_Servicio_de_ApoyoApiConsumer;
        private IDetalle_de_Solicitud_SolicitanteApiConsumer _IDetalle_de_Solicitud_SolicitanteApiConsumer;
        private IIdiomaApiConsumer _IIdiomaApiConsumer;
        private IDialectoApiConsumer _IDialectoApiConsumer;
        private IDetalle_de_documentosApiConsumer _IDetalle_de_documentosApiConsumer;

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

        
        public Detalle_de_Solicitud_Datos_de_ApoyoController(IDetalle_de_Solicitud_Datos_de_ApoyoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer Detalle_de_Solicitud_Datos_de_ApoyoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISolicitudApiConsumer SolicitudApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ITipo_de_Servicio_de_ApoyoApiConsumer Tipo_de_Servicio_de_ApoyoApiConsumer , IDetalle_de_Solicitud_SolicitanteApiConsumer Detalle_de_Solicitud_SolicitanteApiConsumer , IIdiomaApiConsumer IdiomaApiConsumer , IDialectoApiConsumer DialectoApiConsumer , IDetalle_de_documentosApiConsumer Detalle_de_documentosApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer = Detalle_de_Solicitud_Datos_de_ApoyoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._ISolicitudApiConsumer = SolicitudApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ITipo_de_Servicio_de_ApoyoApiConsumer = Tipo_de_Servicio_de_ApoyoApiConsumer;
            this._IDetalle_de_Solicitud_SolicitanteApiConsumer = Detalle_de_Solicitud_SolicitanteApiConsumer;
            this._IIdiomaApiConsumer = IdiomaApiConsumer;
            this._IDialectoApiConsumer = DialectoApiConsumer;
            this._IDetalle_de_documentosApiConsumer = Detalle_de_documentosApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_de_Solicitud_Datos_de_Apoyo
        [ObjectAuth(ObjectId = (ModuleObjectId)45044, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45044, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Detalle_de_Solicitud_Datos_de_Apoyo/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)45044, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45044, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varDetalle_de_Solicitud_Datos_de_Apoyo = new Detalle_de_Solicitud_Datos_de_ApoyoModel();
			varDetalle_de_Solicitud_Datos_de_Apoyo.Clave = Id;
			
            ViewBag.ObjectId = "45044";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_de_Solicitud_Datos_de_ApoyosData = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.ListaSelAll(0, 1000, "Detalle_de_Solicitud_Datos_de_Apoyo.Clave=" + Id, "").Resource.Detalle_de_Solicitud_Datos_de_Apoyos;
				
				if (Detalle_de_Solicitud_Datos_de_ApoyosData != null && Detalle_de_Solicitud_Datos_de_ApoyosData.Count > 0)
                {
					var Detalle_de_Solicitud_Datos_de_ApoyoData = Detalle_de_Solicitud_Datos_de_ApoyosData.First();
					varDetalle_de_Solicitud_Datos_de_Apoyo= new Detalle_de_Solicitud_Datos_de_ApoyoModel
					{
						Clave  = Detalle_de_Solicitud_Datos_de_ApoyoData.Clave 
	                    ,Solicitud = Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitud
                    ,SolicitudNumero_de_Folio = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitud), "Solicitud") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitud_Solicitud.Numero_de_Folio
                    ,Fecha_de_Registro = (Detalle_de_Solicitud_Datos_de_ApoyoData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Detalle_de_Solicitud_Datos_de_ApoyoData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Detalle_de_Solicitud_Datos_de_ApoyoData.Hora_de_Registro
                    ,Usuario_que_registra = Detalle_de_Solicitud_Datos_de_ApoyoData.Usuario_que_registra
                    ,Usuario_que_registraName = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Usuario_que_registra), "Spartan_User") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Usuario_que_registra_Spartan_User.Name
                    ,Tipo_de_Servicio = Detalle_de_Solicitud_Datos_de_ApoyoData.Tipo_de_Servicio
                    ,Tipo_de_ServicioServicio = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Tipo_de_Servicio), "Tipo_de_Servicio_de_Apoyo") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Servicio
                    ,Dictamen = Detalle_de_Solicitud_Datos_de_ApoyoData.Dictamen
                    ,Solicitante = Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitante
                    ,SolicitanteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitante), "Detalle_de_Solicitud_Solicitante") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitante_Detalle_de_Solicitud_Solicitante.Nombre_Completo
                    ,Responsable = Detalle_de_Solicitud_Datos_de_ApoyoData.Responsable
                    ,Idioma = Detalle_de_Solicitud_Datos_de_ApoyoData.Idioma
                    ,IdiomaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Idioma), "Idioma") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Idioma_Idioma.Descripcion
                    ,Lengua_Originaria = Detalle_de_Solicitud_Datos_de_ApoyoData.Lengua_Originaria
                    ,Lengua_OriginariaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Lengua_Originaria), "Dialecto") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Lengua_Originaria_Dialecto.Descripcion
                    ,Diligencia_a_Enviar = Detalle_de_Solicitud_Datos_de_ApoyoData.Diligencia_a_Enviar
                    ,Diligencia_a_EnviarDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Diligencia_a_Enviar), "Detalle_de_documentos") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Diligencia_a_Enviar_Detalle_de_documentos.Descripcion
                    ,Archivo_Adjunto = Detalle_de_Solicitud_Datos_de_ApoyoData.Archivo_Adjunto

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_AdjuntoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto).Resource;

				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Servicio_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = _ITipo_de_Servicio_de_ApoyoApiConsumer.SelAll(true);
            if (Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio != null && Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource != null)
                ViewBag.Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource.Where(m => m.Servicio != null).OrderBy(m => m.Servicio).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Servicio_de_Apoyo", "Servicio") ?? m.Servicio.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IIdiomaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Idiomas_Idioma = _IIdiomaApiConsumer.SelAll(true);
            if (Idiomas_Idioma != null && Idiomas_Idioma.Resource != null)
                ViewBag.Idiomas_Idioma = Idiomas_Idioma.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Idioma", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDialectoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dialectos_Lengua_Originaria = _IDialectoApiConsumer.SelAll(true);
            if (Dialectos_Lengua_Originaria != null && Dialectos_Lengua_Originaria.Resource != null)
                ViewBag.Dialectos_Lengua_Originaria = Dialectos_Lengua_Originaria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dialecto", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varDetalle_de_Solicitud_Datos_de_Apoyo);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_de_Solicitud_Datos_de_Apoyo(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45044);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_de_Solicitud_Datos_de_ApoyoModel varDetalle_de_Solicitud_Datos_de_Apoyo= new Detalle_de_Solicitud_Datos_de_ApoyoModel();


            if (id.ToString() != "0")
            {
                var Detalle_de_Solicitud_Datos_de_ApoyosData = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.ListaSelAll(0, 1000, "Detalle_de_Solicitud_Datos_de_Apoyo.Clave=" + id, "").Resource.Detalle_de_Solicitud_Datos_de_Apoyos;
				
				if (Detalle_de_Solicitud_Datos_de_ApoyosData != null && Detalle_de_Solicitud_Datos_de_ApoyosData.Count > 0)
                {
					var Detalle_de_Solicitud_Datos_de_ApoyoData = Detalle_de_Solicitud_Datos_de_ApoyosData.First();
					varDetalle_de_Solicitud_Datos_de_Apoyo= new Detalle_de_Solicitud_Datos_de_ApoyoModel
					{
						Clave  = Detalle_de_Solicitud_Datos_de_ApoyoData.Clave 
	                    ,Solicitud = Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitud
                    ,SolicitudNumero_de_Folio = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitud), "Solicitud") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitud_Solicitud.Numero_de_Folio
                    ,Fecha_de_Registro = (Detalle_de_Solicitud_Datos_de_ApoyoData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Detalle_de_Solicitud_Datos_de_ApoyoData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Detalle_de_Solicitud_Datos_de_ApoyoData.Hora_de_Registro
                    ,Usuario_que_registra = Detalle_de_Solicitud_Datos_de_ApoyoData.Usuario_que_registra
                    ,Usuario_que_registraName = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Usuario_que_registra), "Spartan_User") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Usuario_que_registra_Spartan_User.Name
                    ,Tipo_de_Servicio = Detalle_de_Solicitud_Datos_de_ApoyoData.Tipo_de_Servicio
                    ,Tipo_de_ServicioServicio = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Tipo_de_Servicio), "Tipo_de_Servicio_de_Apoyo") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Servicio
                    ,Dictamen = Detalle_de_Solicitud_Datos_de_ApoyoData.Dictamen
                    ,Solicitante = Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitante
                    ,SolicitanteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitante), "Detalle_de_Solicitud_Solicitante") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Solicitante_Detalle_de_Solicitud_Solicitante.Nombre_Completo
                    ,Responsable = Detalle_de_Solicitud_Datos_de_ApoyoData.Responsable
                    ,Idioma = Detalle_de_Solicitud_Datos_de_ApoyoData.Idioma
                    ,IdiomaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Idioma), "Idioma") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Idioma_Idioma.Descripcion
                    ,Lengua_Originaria = Detalle_de_Solicitud_Datos_de_ApoyoData.Lengua_Originaria
                    ,Lengua_OriginariaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Lengua_Originaria), "Dialecto") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Lengua_Originaria_Dialecto.Descripcion
                    ,Diligencia_a_Enviar = Detalle_de_Solicitud_Datos_de_ApoyoData.Diligencia_a_Enviar
                    ,Diligencia_a_EnviarDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Solicitud_Datos_de_ApoyoData.Diligencia_a_Enviar), "Detalle_de_documentos") ??  (string)Detalle_de_Solicitud_Datos_de_ApoyoData.Diligencia_a_Enviar_Detalle_de_documentos.Descripcion
                    ,Archivo_Adjunto = Detalle_de_Solicitud_Datos_de_ApoyoData.Archivo_Adjunto

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Archivo_AdjuntoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Servicio_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = _ITipo_de_Servicio_de_ApoyoApiConsumer.SelAll(true);
            if (Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio != null && Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource != null)
                ViewBag.Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource.Where(m => m.Servicio != null).OrderBy(m => m.Servicio).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Servicio_de_Apoyo", "Servicio") ?? m.Servicio.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IIdiomaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Idiomas_Idioma = _IIdiomaApiConsumer.SelAll(true);
            if (Idiomas_Idioma != null && Idiomas_Idioma.Resource != null)
                ViewBag.Idiomas_Idioma = Idiomas_Idioma.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Idioma", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDialectoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dialectos_Lengua_Originaria = _IDialectoApiConsumer.SelAll(true);
            if (Dialectos_Lengua_Originaria != null && Dialectos_Lengua_Originaria.Resource != null)
                ViewBag.Dialectos_Lengua_Originaria = Dialectos_Lengua_Originaria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dialecto", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_de_Solicitud_Datos_de_Apoyo", varDetalle_de_Solicitud_Datos_de_Apoyo);
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
        public ActionResult GetSolicitudAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitudApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISolicitudApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Numero_de_Folio).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Solicitud", "Numero_de_Folio")?? m.Numero_de_Folio,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetSpartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name")?? m.Name,
                    Value = Convert.ToString(m.Id_User)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_de_Servicio_de_ApoyoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Servicio_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Servicio_de_ApoyoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Servicio).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Servicio_de_Apoyo", "Servicio")?? m.Servicio,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetDetalle_de_Solicitud_SolicitanteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_Solicitud_SolicitanteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_de_Solicitud_SolicitanteApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Detalle_de_Solicitud_Solicitante", "Nombre_Completo")?? m.Nombre_Completo,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetIdiomaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIdiomaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIdiomaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Idioma", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDialectoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDialectoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDialectoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dialecto", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetDetalle_de_documentosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_documentosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_de_documentosApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Detalle_de_documentos", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel model, int idFilter = -1)
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

            _ITipo_de_Servicio_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = _ITipo_de_Servicio_de_ApoyoApiConsumer.SelAll(true);
            if (Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio != null && Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource != null)
                ViewBag.Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource.Where(m => m.Servicio != null).OrderBy(m => m.Servicio).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Servicio_de_Apoyo", "Servicio") ?? m.Servicio.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IIdiomaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Idiomas_Idioma = _IIdiomaApiConsumer.SelAll(true);
            if (Idiomas_Idioma != null && Idiomas_Idioma.Resource != null)
                ViewBag.Idiomas_Idioma = Idiomas_Idioma.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Idioma", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDialectoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dialectos_Lengua_Originaria = _IDialectoApiConsumer.SelAll(true);
            if (Dialectos_Lengua_Originaria != null && Dialectos_Lengua_Originaria.Resource != null)
                ViewBag.Dialectos_Lengua_Originaria = Dialectos_Lengua_Originaria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dialecto", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Servicio_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = _ITipo_de_Servicio_de_ApoyoApiConsumer.SelAll(true);
            if (Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio != null && Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource != null)
                ViewBag.Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio = Tipo_de_Servicio_de_Apoyos_Tipo_de_Servicio.Resource.Where(m => m.Servicio != null).OrderBy(m => m.Servicio).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Servicio_de_Apoyo", "Servicio") ?? m.Servicio.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IIdiomaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Idiomas_Idioma = _IIdiomaApiConsumer.SelAll(true);
            if (Idiomas_Idioma != null && Idiomas_Idioma.Resource != null)
                ViewBag.Idiomas_Idioma = Idiomas_Idioma.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Idioma", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDialectoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dialectos_Lengua_Originaria = _IDialectoApiConsumer.SelAll(true);
            if (Dialectos_Lengua_Originaria != null && Dialectos_Lengua_Originaria.Resource != null)
                ViewBag.Dialectos_Lengua_Originaria = Dialectos_Lengua_Originaria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Dialecto", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Solicitud_Datos_de_Apoyos == null)
                result.Detalle_de_Solicitud_Datos_de_Apoyos = new List<Detalle_de_Solicitud_Datos_de_Apoyo>();

            return Json(new
            {
                data = result.Detalle_de_Solicitud_Datos_de_Apoyos.Select(m => new Detalle_de_Solicitud_Datos_de_ApoyoGridModel
                    {
                    Clave = m.Clave
                        ,SolicitudNumero_de_Folio = CultureHelper.GetTraduction(m.Solicitud_Solicitud.Clave.ToString(), "Solicitud") ?? (string)m.Solicitud_Solicitud.Numero_de_Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_registraName = CultureHelper.GetTraduction(m.Usuario_que_registra_Spartan_User.Id_User.ToString(), "Spartan_User") ?? (string)m.Usuario_que_registra_Spartan_User.Name
                        ,Tipo_de_ServicioServicio = CultureHelper.GetTraduction(m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Clave.ToString(), "Servicio") ?? (string)m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Servicio
			,Dictamen = m.Dictamen
                        ,SolicitanteNombre_Completo = CultureHelper.GetTraduction(m.Solicitante_Detalle_de_Solicitud_Solicitante.Clave.ToString(), "Detalle_de_Solicitud_Solicitante") ?? (string)m.Solicitante_Detalle_de_Solicitud_Solicitante.Nombre_Completo
			,Responsable = m.Responsable
                        ,IdiomaDescripcion = CultureHelper.GetTraduction(m.Idioma_Idioma.Clave.ToString(), "Descripcion") ?? (string)m.Idioma_Idioma.Descripcion
                        ,Lengua_OriginariaDescripcion = CultureHelper.GetTraduction(m.Lengua_Originaria_Dialecto.Clave.ToString(), "Descripcion") ?? (string)m.Lengua_Originaria_Dialecto.Descripcion
                        ,Diligencia_a_EnviarDescripcion = CultureHelper.GetTraduction(m.Diligencia_a_Enviar_Detalle_de_documentos.Clave.ToString(), "Detalle_de_documentos") ?? (string)m.Diligencia_a_Enviar_Detalle_de_documentos.Descripcion
			,Archivo_Adjunto = m.Archivo_Adjunto

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetDetalle_de_Solicitud_Datos_de_ApoyoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Clave), "Detalle_de_Solicitud_Datos_de_Apoyo", m.),
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
        /// Get List of Detalle_de_Solicitud_Datos_de_Apoyo from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Detalle_de_Solicitud_Datos_de_Apoyo Entity</returns>
        public ActionResult GetDetalle_de_Solicitud_Datos_de_ApoyoList(UrlParametersModel param)
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
            _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel))
                {
					var advanceFilter =
                    (Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper oDetalle_de_Solicitud_Datos_de_ApoyoPropertyMapper = new Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oDetalle_de_Solicitud_Datos_de_ApoyoPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Solicitud_Datos_de_Apoyos == null)
                result.Detalle_de_Solicitud_Datos_de_Apoyos = new List<Detalle_de_Solicitud_Datos_de_Apoyo>();

            return Json(new
            {
                aaData = result.Detalle_de_Solicitud_Datos_de_Apoyos.Select(m => new Detalle_de_Solicitud_Datos_de_ApoyoGridModel
            {
                    Clave = m.Clave
                        ,SolicitudNumero_de_Folio = CultureHelper.GetTraduction(m.Solicitud_Solicitud.Clave.ToString(), "Solicitud") ?? (string)m.Solicitud_Solicitud.Numero_de_Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_registraName = CultureHelper.GetTraduction(m.Usuario_que_registra_Spartan_User.Id_User.ToString(), "Spartan_User") ?? (string)m.Usuario_que_registra_Spartan_User.Name
                        ,Tipo_de_ServicioServicio = CultureHelper.GetTraduction(m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Clave.ToString(), "Servicio") ?? (string)m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Servicio
			,Dictamen = m.Dictamen
                        ,SolicitanteNombre_Completo = CultureHelper.GetTraduction(m.Solicitante_Detalle_de_Solicitud_Solicitante.Clave.ToString(), "Detalle_de_Solicitud_Solicitante") ?? (string)m.Solicitante_Detalle_de_Solicitud_Solicitante.Nombre_Completo
			,Responsable = m.Responsable
                        ,IdiomaDescripcion = CultureHelper.GetTraduction(m.Idioma_Idioma.Clave.ToString(), "Descripcion") ?? (string)m.Idioma_Idioma.Descripcion
                        ,Lengua_OriginariaDescripcion = CultureHelper.GetTraduction(m.Lengua_Originaria_Dialecto.Clave.ToString(), "Descripcion") ?? (string)m.Lengua_Originaria_Dialecto.Descripcion
                        ,Diligencia_a_EnviarDescripcion = CultureHelper.GetTraduction(m.Diligencia_a_Enviar_Detalle_de_documentos.Clave.ToString(), "Detalle_de_documentos") ?? (string)m.Diligencia_a_Enviar_Detalle_de_documentos.Descripcion
			,Archivo_Adjunto = m.Archivo_Adjunto

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetalle_de_Solicitud_Datos_de_Apoyo_Solicitud_Solicitud(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitudApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Solicitud.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Solicitud.Numero_de_Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _ISolicitudApiConsumer.ListaSelAll(1, 20,elWhere , " Solicitud.Numero_de_Folio ASC ").Resource;
               
                foreach (var item in result.Solicituds)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Solicitud", "Numero_de_Folio");
                    item.Numero_de_Folio =trans ??item.Numero_de_Folio;
                }
                return Json(result.Solicituds.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDetalle_de_Solicitud_Datos_de_Apoyo_Usuario_que_registra_Spartan_User(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Spartan_User.Id_User as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Spartan_User.Name as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _ISpartan_UserApiConsumer.ListaSelAll(1, 20,elWhere , " Spartan_User.Name ASC ").Resource;
               
                foreach (var item in result.Spartan_Users)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Id_User), "Spartan_User", "Name");
                    item.Name =trans ??item.Name;
                }
                return Json(result.Spartan_Users.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDetalle_de_Solicitud_Datos_de_Apoyo_Solicitante_Detalle_de_Solicitud_Solicitante(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_Solicitud_SolicitanteApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Detalle_de_Solicitud_Solicitante.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Detalle_de_Solicitud_Solicitante.Nombre_Completo as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IDetalle_de_Solicitud_SolicitanteApiConsumer.ListaSelAll(1, 20,elWhere , " Detalle_de_Solicitud_Solicitante.Nombre_Completo ASC ").Resource;
               
                foreach (var item in result.Detalle_de_Solicitud_Solicitantes)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Detalle_de_Solicitud_Solicitante", "Nombre_Completo");
                    item.Nombre_Completo =trans ??item.Nombre_Completo;
                }
                return Json(result.Detalle_de_Solicitud_Solicitantes.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDetalle_de_Solicitud_Datos_de_Apoyo_Diligencia_a_Enviar_Detalle_de_documentos(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_documentosApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Detalle_de_documentos.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Detalle_de_documentos.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IDetalle_de_documentosApiConsumer.ListaSelAll(1, 20,elWhere , " Detalle_de_documentos.Descripcion ASC ").Resource;
               
                foreach (var item in result.Detalle_de_documentoss)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Detalle_de_documentos", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Detalle_de_documentoss.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





        [NonAction]
        public string GetAdvanceFilter(Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSolicitud))
            {
                switch (filter.SolicitudFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Solicitud.Numero_de_Folio LIKE '" + filter.AdvanceSolicitud + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Solicitud.Numero_de_Folio LIKE '%" + filter.AdvanceSolicitud + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Solicitud.Numero_de_Folio = '" + filter.AdvanceSolicitud + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Solicitud.Numero_de_Folio LIKE '%" + filter.AdvanceSolicitud + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSolicitudMultiple != null && filter.AdvanceSolicitudMultiple.Count() > 0)
            {
                var SolicitudIds = string.Join(",", filter.AdvanceSolicitudMultiple);

                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Solicitud In (" + SolicitudIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Detalle_de_Solicitud_Datos_de_Apoyo.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Detalle_de_Solicitud_Datos_de_Apoyo.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_registra))
            {
                switch (filter.Usuario_que_registraFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_registra + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_registra + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_registra + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_registra + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_registraMultiple != null && filter.AdvanceUsuario_que_registraMultiple.Count() > 0)
            {
                var Usuario_que_registraIds = string.Join(",", filter.AdvanceUsuario_que_registraMultiple);

                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Usuario_que_registra In (" + Usuario_que_registraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Servicio))
            {
                switch (filter.Tipo_de_ServicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Servicio_de_Apoyo.Servicio LIKE '" + filter.AdvanceTipo_de_Servicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Servicio_de_Apoyo.Servicio LIKE '%" + filter.AdvanceTipo_de_Servicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Servicio_de_Apoyo.Servicio = '" + filter.AdvanceTipo_de_Servicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Servicio_de_Apoyo.Servicio LIKE '%" + filter.AdvanceTipo_de_Servicio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_ServicioMultiple != null && filter.AdvanceTipo_de_ServicioMultiple.Count() > 0)
            {
                var Tipo_de_ServicioIds = string.Join(",", filter.AdvanceTipo_de_ServicioMultiple);

                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Tipo_de_Servicio In (" + Tipo_de_ServicioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Dictamen))
            {
                switch (filter.DictamenFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Dictamen LIKE '" + filter.Dictamen + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Dictamen LIKE '%" + filter.Dictamen + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Dictamen = '" + filter.Dictamen + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Dictamen LIKE '%" + filter.Dictamen + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSolicitante))
            {
                switch (filter.SolicitanteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_de_Solicitud_Solicitante.Nombre_Completo LIKE '" + filter.AdvanceSolicitante + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_de_Solicitud_Solicitante.Nombre_Completo LIKE '%" + filter.AdvanceSolicitante + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_de_Solicitud_Solicitante.Nombre_Completo = '" + filter.AdvanceSolicitante + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_de_Solicitud_Solicitante.Nombre_Completo LIKE '%" + filter.AdvanceSolicitante + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSolicitanteMultiple != null && filter.AdvanceSolicitanteMultiple.Count() > 0)
            {
                var SolicitanteIds = string.Join(",", filter.AdvanceSolicitanteMultiple);

                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Solicitante In (" + SolicitanteIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Responsable))
            {
                switch (filter.ResponsableFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Responsable LIKE '" + filter.Responsable + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Responsable LIKE '%" + filter.Responsable + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Responsable = '" + filter.Responsable + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Responsable LIKE '%" + filter.Responsable + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceIdioma))
            {
                switch (filter.IdiomaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Idioma.Descripcion LIKE '" + filter.AdvanceIdioma + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Idioma.Descripcion LIKE '%" + filter.AdvanceIdioma + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Idioma.Descripcion = '" + filter.AdvanceIdioma + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Idioma.Descripcion LIKE '%" + filter.AdvanceIdioma + "%'";
                        break;
                }
            }
            else if (filter.AdvanceIdiomaMultiple != null && filter.AdvanceIdiomaMultiple.Count() > 0)
            {
                var IdiomaIds = string.Join(",", filter.AdvanceIdiomaMultiple);

                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Idioma In (" + IdiomaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceLengua_Originaria))
            {
                switch (filter.Lengua_OriginariaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Dialecto.Descripcion LIKE '" + filter.AdvanceLengua_Originaria + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Dialecto.Descripcion LIKE '%" + filter.AdvanceLengua_Originaria + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Dialecto.Descripcion = '" + filter.AdvanceLengua_Originaria + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Dialecto.Descripcion LIKE '%" + filter.AdvanceLengua_Originaria + "%'";
                        break;
                }
            }
            else if (filter.AdvanceLengua_OriginariaMultiple != null && filter.AdvanceLengua_OriginariaMultiple.Count() > 0)
            {
                var Lengua_OriginariaIds = string.Join(",", filter.AdvanceLengua_OriginariaMultiple);

                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Lengua_Originaria In (" + Lengua_OriginariaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceDiligencia_a_Enviar))
            {
                switch (filter.Diligencia_a_EnviarFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_de_documentos.Descripcion LIKE '" + filter.AdvanceDiligencia_a_Enviar + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_de_documentos.Descripcion LIKE '%" + filter.AdvanceDiligencia_a_Enviar + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_de_documentos.Descripcion = '" + filter.AdvanceDiligencia_a_Enviar + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_de_documentos.Descripcion LIKE '%" + filter.AdvanceDiligencia_a_Enviar + "%'";
                        break;
                }
            }
            else if (filter.AdvanceDiligencia_a_EnviarMultiple != null && filter.AdvanceDiligencia_a_EnviarMultiple.Count() > 0)
            {
                var Diligencia_a_EnviarIds = string.Join(",", filter.AdvanceDiligencia_a_EnviarMultiple);

                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Diligencia_a_Enviar In (" + Diligencia_a_EnviarIds + ")";
            }

            if (filter.Archivo_Adjunto != RadioOptions.NoApply)
                where += " AND Detalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto " + (filter.Archivo_Adjunto == RadioOptions.Yes ? ">" : "==") + " 0";


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
                _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_de_Solicitud_Datos_de_Apoyo varDetalle_de_Solicitud_Datos_de_Apoyo = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_de_Solicitud_Datos_de_ApoyoModel varDetalle_de_Solicitud_Datos_de_Apoyo)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoRemoveAttachment != 0 && varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile == null)
                    {
                        varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto = 0;
                    }

                    if (varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Detalle_de_Solicitud_Datos_de_ApoyoInfo = new Detalle_de_Solicitud_Datos_de_Apoyo
                    {
                        Clave = varDetalle_de_Solicitud_Datos_de_Apoyo.Clave
                        ,Solicitud = varDetalle_de_Solicitud_Datos_de_Apoyo.Solicitud
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varDetalle_de_Solicitud_Datos_de_Apoyo.Fecha_de_Registro)) ? DateTime.ParseExact(varDetalle_de_Solicitud_Datos_de_Apoyo.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varDetalle_de_Solicitud_Datos_de_Apoyo.Hora_de_Registro
                        ,Usuario_que_registra = varDetalle_de_Solicitud_Datos_de_Apoyo.Usuario_que_registra
                        ,Tipo_de_Servicio = varDetalle_de_Solicitud_Datos_de_Apoyo.Tipo_de_Servicio
                        ,Dictamen = varDetalle_de_Solicitud_Datos_de_Apoyo.Dictamen
                        ,Solicitante = varDetalle_de_Solicitud_Datos_de_Apoyo.Solicitante
                        ,Responsable = varDetalle_de_Solicitud_Datos_de_Apoyo.Responsable
                        ,Idioma = varDetalle_de_Solicitud_Datos_de_Apoyo.Idioma
                        ,Lengua_Originaria = varDetalle_de_Solicitud_Datos_de_Apoyo.Lengua_Originaria
                        ,Diligencia_a_Enviar = varDetalle_de_Solicitud_Datos_de_Apoyo.Diligencia_a_Enviar
                        ,Archivo_Adjunto = (varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto.HasValue && varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto != 0) ? ((int?)Convert.ToInt32(varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto.Value)) : null


                    };

                    result = !IsNew ?
                        _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.Update(Detalle_de_Solicitud_Datos_de_ApoyoInfo, null, null).Resource.ToString() :
                         _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.Insert(Detalle_de_Solicitud_Datos_de_ApoyoInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Detalle_de_Solicitud_Datos_de_Apoyo script
        /// </summary>
        /// <param name="oDetalle_de_Solicitud_Datos_de_ApoyoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList)
        {
            for (int i = 0; i < Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strDetalle_de_Solicitud_Datos_de_ApoyoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Solicitud_Datos_de_Apoyo.js")))
            {
                strDetalle_de_Solicitud_Datos_de_ApoyoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_de_Solicitud_Datos_de_Apoyo element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_de_Solicitud_Datos_de_ApoyoScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_de_Solicitud_Datos_de_ApoyoScript.Substring(indexOfArray, strDetalle_de_Solicitud_Datos_de_ApoyoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_de_Solicitud_Datos_de_ApoyoScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strDetalle_de_Solicitud_Datos_de_ApoyoScript.Substring(indexOfArrayHistory, strDetalle_de_Solicitud_Datos_de_ApoyoScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strDetalle_de_Solicitud_Datos_de_ApoyoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_de_Solicitud_Datos_de_ApoyoScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_de_Solicitud_Datos_de_ApoyoScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Detalle_de_Solicitud_Datos_de_ApoyoModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_de_Solicitud_Datos_de_Apoyo.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_de_Solicitud_Datos_de_Apoyo.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Solicitud_Datos_de_Apoyo.js")))
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
        public ActionResult Detalle_de_Solicitud_Datos_de_ApoyoPropertyBag()
        {
            return PartialView("Detalle_de_Solicitud_Datos_de_ApoyoPropertyBag", "Detalle_de_Solicitud_Datos_de_Apoyo");
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
                var whereClauseFormat = "Object = 45044 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Detalle_de_Solicitud_Datos_de_Apoyo.Clave= " + RecordId;
                            var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper());
			
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
                    (Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper oDetalle_de_Solicitud_Datos_de_ApoyoPropertyMapper = new Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oDetalle_de_Solicitud_Datos_de_ApoyoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Solicitud_Datos_de_Apoyos == null)
                result.Detalle_de_Solicitud_Datos_de_Apoyos = new List<Detalle_de_Solicitud_Datos_de_Apoyo>();

            var data = result.Detalle_de_Solicitud_Datos_de_Apoyos.Select(m => new Detalle_de_Solicitud_Datos_de_ApoyoGridModel
            {
                Clave = m.Clave
                        ,SolicitudNumero_de_Folio = CultureHelper.GetTraduction(m.Solicitud_Solicitud.Clave.ToString(), "Solicitud") ?? (string)m.Solicitud_Solicitud.Numero_de_Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_registraName = CultureHelper.GetTraduction(m.Usuario_que_registra_Spartan_User.Id_User.ToString(), "Spartan_User") ?? (string)m.Usuario_que_registra_Spartan_User.Name
                        ,Tipo_de_ServicioServicio = CultureHelper.GetTraduction(m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Clave.ToString(), "Servicio") ?? (string)m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Servicio
			,Dictamen = m.Dictamen
                        ,SolicitanteNombre_Completo = CultureHelper.GetTraduction(m.Solicitante_Detalle_de_Solicitud_Solicitante.Clave.ToString(), "Detalle_de_Solicitud_Solicitante") ?? (string)m.Solicitante_Detalle_de_Solicitud_Solicitante.Nombre_Completo
			,Responsable = m.Responsable
                        ,IdiomaDescripcion = CultureHelper.GetTraduction(m.Idioma_Idioma.Clave.ToString(), "Descripcion") ?? (string)m.Idioma_Idioma.Descripcion
                        ,Lengua_OriginariaDescripcion = CultureHelper.GetTraduction(m.Lengua_Originaria_Dialecto.Clave.ToString(), "Descripcion") ?? (string)m.Lengua_Originaria_Dialecto.Descripcion
                        ,Diligencia_a_EnviarDescripcion = CultureHelper.GetTraduction(m.Diligencia_a_Enviar_Detalle_de_documentos.Clave.ToString(), "Detalle_de_documentos") ?? (string)m.Diligencia_a_Enviar_Detalle_de_documentos.Descripcion
			,Archivo_Adjunto = m.Archivo_Adjunto

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(45044, arrayColumnsVisible), "Detalle_de_Solicitud_Datos_de_ApoyoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(45044, arrayColumnsVisible), "Detalle_de_Solicitud_Datos_de_ApoyoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(45044, arrayColumnsVisible), "Detalle_de_Solicitud_Datos_de_ApoyoList_" + DateTime.Now.ToString());
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

            _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Detalle_de_Solicitud_Datos_de_ApoyoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper oDetalle_de_Solicitud_Datos_de_ApoyoPropertyMapper = new Detalle_de_Solicitud_Datos_de_ApoyoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oDetalle_de_Solicitud_Datos_de_ApoyoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Solicitud_Datos_de_Apoyos == null)
                result.Detalle_de_Solicitud_Datos_de_Apoyos = new List<Detalle_de_Solicitud_Datos_de_Apoyo>();

            var data = result.Detalle_de_Solicitud_Datos_de_Apoyos.Select(m => new Detalle_de_Solicitud_Datos_de_ApoyoGridModel
            {
                Clave = m.Clave
                        ,SolicitudNumero_de_Folio = CultureHelper.GetTraduction(m.Solicitud_Solicitud.Clave.ToString(), "Solicitud") ?? (string)m.Solicitud_Solicitud.Numero_de_Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_registraName = CultureHelper.GetTraduction(m.Usuario_que_registra_Spartan_User.Id_User.ToString(), "Spartan_User") ?? (string)m.Usuario_que_registra_Spartan_User.Name
                        ,Tipo_de_ServicioServicio = CultureHelper.GetTraduction(m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Clave.ToString(), "Servicio") ?? (string)m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Servicio
			,Dictamen = m.Dictamen
                        ,SolicitanteNombre_Completo = CultureHelper.GetTraduction(m.Solicitante_Detalle_de_Solicitud_Solicitante.Clave.ToString(), "Detalle_de_Solicitud_Solicitante") ?? (string)m.Solicitante_Detalle_de_Solicitud_Solicitante.Nombre_Completo
			,Responsable = m.Responsable
                        ,IdiomaDescripcion = CultureHelper.GetTraduction(m.Idioma_Idioma.Clave.ToString(), "Descripcion") ?? (string)m.Idioma_Idioma.Descripcion
                        ,Lengua_OriginariaDescripcion = CultureHelper.GetTraduction(m.Lengua_Originaria_Dialecto.Clave.ToString(), "Descripcion") ?? (string)m.Lengua_Originaria_Dialecto.Descripcion
                        ,Diligencia_a_EnviarDescripcion = CultureHelper.GetTraduction(m.Diligencia_a_Enviar_Detalle_de_documentos.Clave.ToString(), "Detalle_de_documentos") ?? (string)m.Diligencia_a_Enviar_Detalle_de_documentos.Descripcion
			,Archivo_Adjunto = m.Archivo_Adjunto

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
                _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Detalle_de_Solicitud_Datos_de_Apoyo_Datos_GeneralesModel varDetalle_de_Solicitud_Datos_de_Apoyo)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoRemoveAttachment != 0 && varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile == null)
                    {
                        varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto = 0;
                    }

                    if (varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_AdjuntoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Detalle_de_Solicitud_Datos_de_Apoyo_Datos_GeneralesInfo = new Detalle_de_Solicitud_Datos_de_Apoyo_Datos_Generales
                {
                    Clave = varDetalle_de_Solicitud_Datos_de_Apoyo.Clave
                                            ,Solicitud = varDetalle_de_Solicitud_Datos_de_Apoyo.Solicitud
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varDetalle_de_Solicitud_Datos_de_Apoyo.Fecha_de_Registro)) ? DateTime.ParseExact(varDetalle_de_Solicitud_Datos_de_Apoyo.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varDetalle_de_Solicitud_Datos_de_Apoyo.Hora_de_Registro
                        ,Usuario_que_registra = varDetalle_de_Solicitud_Datos_de_Apoyo.Usuario_que_registra
                        ,Tipo_de_Servicio = varDetalle_de_Solicitud_Datos_de_Apoyo.Tipo_de_Servicio
                        ,Dictamen = varDetalle_de_Solicitud_Datos_de_Apoyo.Dictamen
                        ,Solicitante = varDetalle_de_Solicitud_Datos_de_Apoyo.Solicitante
                        ,Responsable = varDetalle_de_Solicitud_Datos_de_Apoyo.Responsable
                        ,Idioma = varDetalle_de_Solicitud_Datos_de_Apoyo.Idioma
                        ,Lengua_Originaria = varDetalle_de_Solicitud_Datos_de_Apoyo.Lengua_Originaria
                        ,Diligencia_a_Enviar = varDetalle_de_Solicitud_Datos_de_Apoyo.Diligencia_a_Enviar
                        ,Archivo_Adjunto = (varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto.HasValue && varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto != 0) ? ((int?)Convert.ToInt32(varDetalle_de_Solicitud_Datos_de_Apoyo.Archivo_Adjunto.Value)) : null

                    
                };

                result = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.Update_Datos_Generales(Detalle_de_Solicitud_Datos_de_Apoyo_Datos_GeneralesInfo).Resource.ToString();
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
                _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IDetalle_de_Solicitud_Datos_de_ApoyoApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Detalle_de_Solicitud_Datos_de_Apoyo_Datos_GeneralesModel
                {
                    Clave = m.Clave
                        ,Solicitud = m.Solicitud
                        ,SolicitudNumero_de_Folio = CultureHelper.GetTraduction(m.Solicitud_Solicitud.Clave.ToString(), "Solicitud") ?? (string)m.Solicitud_Solicitud.Numero_de_Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_registra = m.Usuario_que_registra
                        ,Usuario_que_registraName = CultureHelper.GetTraduction(m.Usuario_que_registra_Spartan_User.Id_User.ToString(), "Spartan_User") ?? (string)m.Usuario_que_registra_Spartan_User.Name
                        ,Tipo_de_Servicio = m.Tipo_de_Servicio
                        ,Tipo_de_ServicioServicio = CultureHelper.GetTraduction(m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Clave.ToString(), "Servicio") ?? (string)m.Tipo_de_Servicio_Tipo_de_Servicio_de_Apoyo.Servicio
			,Dictamen = m.Dictamen
                        ,Solicitante = m.Solicitante
                        ,SolicitanteNombre_Completo = CultureHelper.GetTraduction(m.Solicitante_Detalle_de_Solicitud_Solicitante.Clave.ToString(), "Detalle_de_Solicitud_Solicitante") ?? (string)m.Solicitante_Detalle_de_Solicitud_Solicitante.Nombre_Completo
			,Responsable = m.Responsable
                        ,Idioma = m.Idioma
                        ,IdiomaDescripcion = CultureHelper.GetTraduction(m.Idioma_Idioma.Clave.ToString(), "Descripcion") ?? (string)m.Idioma_Idioma.Descripcion
                        ,Lengua_Originaria = m.Lengua_Originaria
                        ,Lengua_OriginariaDescripcion = CultureHelper.GetTraduction(m.Lengua_Originaria_Dialecto.Clave.ToString(), "Descripcion") ?? (string)m.Lengua_Originaria_Dialecto.Descripcion
                        ,Diligencia_a_Enviar = m.Diligencia_a_Enviar
                        ,Diligencia_a_EnviarDescripcion = CultureHelper.GetTraduction(m.Diligencia_a_Enviar_Detalle_de_documentos.Clave.ToString(), "Detalle_de_documentos") ?? (string)m.Diligencia_a_Enviar_Detalle_de_documentos.Descripcion
			,Archivo_Adjunto = m.Archivo_Adjunto

                    
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

