﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Submarca_de_medio_de_transporte;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Submarca_de_medio_de_transporte
{
    public class Submarca_de_medio_de_transporteApiConsumer : BaseApiConsumer,ISubmarca_de_medio_de_transporteApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Submarca_de_medio_de_transporteApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Submarca_de_medio_de_transporte";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>(false, null);
            }
        }

        public ApiResponse<Submarca_de_medio_de_transportePagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transportePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Submarca_de_medio_de_transporte.Clave='" + Key.ToString() + "'"
                        + "&Order=Submarca_de_medio_de_transporte.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transportePagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transportePagingModel>(false, new Submarca_de_medio_de_transportePagingModel() { Submarca_de_medio_de_transportes = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Submarca_de_medio_de_transporteInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<short> Insert(Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte entity, Core.Domain.User.GlobalData Submarca_de_medio_de_transporteInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<short> Update(Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte entity, Core.Domain.User.GlobalData Submarca_de_medio_de_transporteInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Clave,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Submarca_de_medio_de_transportePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transportePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transportePagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transportePagingModel>(false, new Submarca_de_medio_de_transportePagingModel() { Submarca_de_medio_de_transportes = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<short> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Submarca_de_medio_de_transporteGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }
		
public ApiResponse<short> Update_Datos_Generales(Submarca_de_medio_de_transporte_Datos_Generales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put_Datos_Generales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<Submarca_de_medio_de_transporte_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Submarca_de_medio_de_transporte.Submarca_de_medio_de_transporte_Datos_Generales>(false, null);
            }
        }


    }
}

