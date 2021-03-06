﻿

//Begin Declarations for Foreigns fields for Detalle_de_Resultados MultiRow
var Detalle_de_ResultadoscountRowsChecked = 0;





function GetDetalle_de_Resultados_GeneroName(Id) {
    for (var i = 0; i < Detalle_de_Resultados_GeneroItems.length; i++) {
        if (Detalle_de_Resultados_GeneroItems[i].Clave == Id) {
            return Detalle_de_Resultados_GeneroItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_de_Resultados_GeneroDropDown() {
    var Detalle_de_Resultados_GeneroDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Resultados_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Resultados_GeneroDropdown);
    if(Detalle_de_Resultados_GeneroItems != null)
    {
       for (var i = 0; i < Detalle_de_Resultados_GeneroItems.length; i++) {
           $('<option />', { value: Detalle_de_Resultados_GeneroItems[i].Clave, text:    Detalle_de_Resultados_GeneroItems[i].Descripcion }).appendTo(Detalle_de_Resultados_GeneroDropdown);
       }
    }
    return Detalle_de_Resultados_GeneroDropdown;
}
function GetDetalle_de_Resultados_NacionalidadName(Id) {
    for (var i = 0; i < Detalle_de_Resultados_NacionalidadItems.length; i++) {
        if (Detalle_de_Resultados_NacionalidadItems[i].Clave == Id) {
            return Detalle_de_Resultados_NacionalidadItems[i].NacionalidadC;
        }
    }
    return "";
}

function GetDetalle_de_Resultados_NacionalidadDropDown() {
    var Detalle_de_Resultados_NacionalidadDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Resultados_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Resultados_NacionalidadDropdown);

    for (var i = 0; i < Detalle_de_Resultados_NacionalidadItems.length; i++) {
        $('<option />', { value: Detalle_de_Resultados_NacionalidadItems[i].Clave, text: Detalle_de_Resultados_NacionalidadItems[i].NacionalidadC }).appendTo(Detalle_de_Resultados_NacionalidadDropdown);
    }
    return Detalle_de_Resultados_NacionalidadDropdown;
}


function GetInsertDetalle_de_ResultadosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_de_Resultados_Nombre Nombre').attr('id', 'Detalle_de_Resultados_Nombre_' + index).attr('data-field', 'Nombre');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_de_Resultados_Apellido_Paterno Apellido_Paterno').attr('id', 'Detalle_de_Resultados_Apellido_Paterno_' + index).attr('data-field', 'Apellido_Paterno');
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_de_Resultados_Apellido_Materno Apellido_Materno').attr('id', 'Detalle_de_Resultados_Apellido_Materno_' + index).attr('data-field', 'Apellido_Materno');
    columnData[3] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_de_Resultados_Fecha_Nacimiento Fecha_Nacimiento').attr('id', 'Detalle_de_Resultados_Fecha_Nacimiento_' + index).attr('data-field', 'Fecha_Nacimiento');
    columnData[4] = $(GetDetalle_de_Resultados_GeneroDropDown()).addClass('Detalle_de_Resultados_Sexo Sexo').attr('id', 'Detalle_de_Resultados_Sexo_' + index).attr('data-field', 'Sexo').after($.parseHTML(addNew('Detalle_de_Resultados', 'Genero', 'Sexo', 268905)));
    columnData[5] = $($.parseHTML(GetGridAutoComplete(null,'AutoCompleteDetalle_de_Resultados_Nacionalidad'))).addClass('Detalle_de_Resultados_Nacionalidad Nacionalidad').attr('id', 'Detalle_de_Resultados_Nacionalidad_' + index).attr('data-field', 'Nacionalidad').after($.parseHTML(addNew('Detalle_de_Resultados', 'Nacionalidad', 'Nacionalidad', 268906)));


    initiateUIControls();
    return columnData;
}

function Detalle_de_ResultadosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_de_Resultados("Detalle_de_Resultados_", "_" + rowIndex)) {
    var iPage = Detalle_de_ResultadosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_de_Resultados';
    var prevData = Detalle_de_ResultadosTable.fnGetData(rowIndex);
    var data = Detalle_de_ResultadosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false

        ,Nombre:  data.childNodes[counter++].childNodes[0].value
        ,Apellido_Paterno:  data.childNodes[counter++].childNodes[0].value
        ,Apellido_Materno:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_Nacimiento:  data.childNodes[counter++].childNodes[0].value
        ,Sexo:  data.childNodes[counter++].childNodes[0].value
        , NacionalidadNacionalidadC:  $(data.childNodes[counter].childNodes[0]).find('option:selected').text() 
        , Nacionalidad:  data.childNodes[counter++].childNodes[0].value 	

    }
    Detalle_de_ResultadosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_de_ResultadosrowCreationGrid(data, newData, rowIndex);
    Detalle_de_ResultadosTable.fnPageChange(iPage);
    Detalle_de_ResultadoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Resultados("Detalle_de_Resultados_", "_" + rowIndex);
  }
}

function Detalle_de_ResultadosCancelRow(rowIndex) {
    var prevData = Detalle_de_ResultadosTable.fnGetData(rowIndex);
    var data = Detalle_de_ResultadosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_de_ResultadosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_de_ResultadosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_de_ResultadosGrid(Detalle_de_ResultadosTable.fnGetData());
    Detalle_de_ResultadoscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_de_ResultadosFromDataTable() {
    var Detalle_de_ResultadosData = [];
    var gridData = Detalle_de_ResultadosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_de_ResultadosData.push({
                Clave: gridData[i].Clave

                ,Nombre: gridData[i].Nombre
                ,Apellido_Paterno: gridData[i].Apellido_Paterno
                ,Apellido_Materno: gridData[i].Apellido_Materno
                ,Fecha_Nacimiento: gridData[i].Fecha_Nacimiento
                ,Sexo: gridData[i].Sexo
                ,Nacionalidad: gridData[i].Nacionalidad

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_de_ResultadosData.length; i++) {
        if (removedDetalle_de_ResultadosData[i] != null && removedDetalle_de_ResultadosData[i].Clave > 0)
            Detalle_de_ResultadosData.push({
                Clave: removedDetalle_de_ResultadosData[i].Clave

                ,Nombre: removedDetalle_de_ResultadosData[i].Nombre
                ,Apellido_Paterno: removedDetalle_de_ResultadosData[i].Apellido_Paterno
                ,Apellido_Materno: removedDetalle_de_ResultadosData[i].Apellido_Materno
                ,Fecha_Nacimiento: removedDetalle_de_ResultadosData[i].Fecha_Nacimiento
                ,Sexo: removedDetalle_de_ResultadosData[i].Sexo
                ,Nacionalidad: removedDetalle_de_ResultadosData[i].Nacionalidad

                , Removed: true
            });
    }	

    return Detalle_de_ResultadosData;
}

function Detalle_de_ResultadosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_de_ResultadosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_de_ResultadoscountRowsChecked++;
    var Detalle_de_ResultadosRowElement = "Detalle_de_Resultados_" + rowIndex.toString();
    var prevData = Detalle_de_ResultadosTable.fnGetData(rowIndexTable );
    var row = Detalle_de_ResultadosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_de_Resultados_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_de_ResultadosGetUpdateRowControls(prevData, "Detalle_de_Resultados_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_de_ResultadosRowElement + "')){ Detalle_de_ResultadosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_de_ResultadosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_de_ResultadosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_de_ResultadosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_de_ResultadosValidation();
    initiateUIControls();
    $('.Detalle_de_Resultados' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_de_Resultados(nameOfTable, rowIndexFormed);
    }
}

function Detalle_de_ResultadosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_de_ResultadosTable.fnGetData().length;
    Detalle_de_ResultadosfnClickAddRow();
    GetAddDetalle_de_ResultadosPopup(currentRowIndex, 0);
}

function Detalle_de_ResultadosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_de_ResultadosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_de_ResultadosRowElement = "Detalle_de_Resultados_" + rowIndex.toString();
    var prevData = Detalle_de_ResultadosTable.fnGetData(rowIndexTable);
    GetAddDetalle_de_ResultadosPopup(rowIndex, 1, prevData.Clave);

    $('#Detalle_de_ResultadosNombre').val(prevData.Nombre);
    $('#Detalle_de_ResultadosApellido_Paterno').val(prevData.Apellido_Paterno);
    $('#Detalle_de_ResultadosApellido_Materno').val(prevData.Apellido_Materno);
    $('#Detalle_de_ResultadosFecha_Nacimiento').val(prevData.Fecha_Nacimiento);
    $('#Detalle_de_ResultadosSexo').val(prevData.Sexo);
    $('#dvDetalle_de_ResultadosNacionalidad').html($($.parseHTML(GetGridAutoComplete(prevData.Nacionalidad.label,'AutoCompleteNacionalidad'))).addClass('Detalle_de_Resultados_Nacionalidad'));

    initiateUIControls();








}

function Detalle_de_ResultadosAddInsertRow() {
    if (Detalle_de_ResultadosinsertRowCurrentIndex < 1)
    {
        Detalle_de_ResultadosinsertRowCurrentIndex = 1;
    }
    return {
        Clave: null,
        IsInsertRow: true

        ,Nombre: ""
        ,Apellido_Paterno: ""
        ,Apellido_Materno: ""
        ,Fecha_Nacimiento: ""
        ,Sexo: ""
        ,Nacionalidad: ""

    }
}

function Detalle_de_ResultadosfnClickAddRow() {
    Detalle_de_ResultadoscountRowsChecked++;
    Detalle_de_ResultadosTable.fnAddData(Detalle_de_ResultadosAddInsertRow(), true);
    Detalle_de_ResultadosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_de_ResultadosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_de_ResultadosGrid tbody tr:nth-of-type(' + (Detalle_de_ResultadosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_de_Resultados("Detalle_de_Resultados_", "_" + Detalle_de_ResultadosinsertRowCurrentIndex);
}

function Detalle_de_ResultadosClearGridData() {
    Detalle_de_ResultadosData = [];
    Detalle_de_ResultadosdeletedItem = [];
    Detalle_de_ResultadosDataMain = [];
    Detalle_de_ResultadosDataMainPages = [];
    Detalle_de_ResultadosnewItemCount = 0;
    Detalle_de_ResultadosmaxItemIndex = 0;
    $("#Detalle_de_ResultadosGrid").DataTable().clear();
    $("#Detalle_de_ResultadosGrid").DataTable().destroy();
}

//Used to Get Consulta de Mandamientos Judiciales Information
function GetDetalle_de_Resultados() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_de_ResultadosData.length; i++) {
        form_data.append('[' + i + '].Clave', Detalle_de_ResultadosData[i].Clave);

        form_data.append('[' + i + '].Nombre', Detalle_de_ResultadosData[i].Nombre);
        form_data.append('[' + i + '].Apellido_Paterno', Detalle_de_ResultadosData[i].Apellido_Paterno);
        form_data.append('[' + i + '].Apellido_Materno', Detalle_de_ResultadosData[i].Apellido_Materno);
        form_data.append('[' + i + '].Fecha_Nacimiento', Detalle_de_ResultadosData[i].Fecha_Nacimiento);
        form_data.append('[' + i + '].Sexo', Detalle_de_ResultadosData[i].Sexo);
        form_data.append('[' + i + '].Nacionalidad', Detalle_de_ResultadosData[i].Nacionalidad);

        form_data.append('[' + i + '].Removed', Detalle_de_ResultadosData[i].Removed);
    }
    return form_data;
}
function Detalle_de_ResultadosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_de_Resultados("Detalle_de_ResultadosTable", rowIndex)) {
    var prevData = Detalle_de_ResultadosTable.fnGetData(rowIndex);
    var data = Detalle_de_ResultadosTable.fnGetNodes(rowIndex);
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false

        ,Nombre: $('#Detalle_de_ResultadosNombre').val()
        ,Apellido_Paterno: $('#Detalle_de_ResultadosApellido_Paterno').val()
        ,Apellido_Materno: $('#Detalle_de_ResultadosApellido_Materno').val()
        ,Fecha_Nacimiento: $('#Detalle_de_ResultadosFecha_Nacimiento').val()
        ,Sexo: $('#Detalle_de_ResultadosSexo').val()
        ,Nacionalidad: $('#Detalle_de_ResultadosNacionalidad').val()

    }

    Detalle_de_ResultadosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_de_ResultadosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_de_Resultados-form').modal({ show: false });
    $('#AddDetalle_de_Resultados-form').modal('hide');
    Detalle_de_ResultadosEditRow(rowIndex);
    Detalle_de_ResultadosInsertRow(rowIndex);
    //}
}
function Detalle_de_ResultadosRemoveAddRow(rowIndex) {
    Detalle_de_ResultadosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_de_Resultados MultiRow


$(function () {
    function Detalle_de_ResultadosinitializeMainArray(totalCount) {
        if (Detalle_de_ResultadosDataMain.length != totalCount && !Detalle_de_ResultadosDataMainInitialized) {
            Detalle_de_ResultadosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_de_ResultadosDataMain[i] = null;
            }
        }
    }
    function Detalle_de_ResultadosremoveFromMainArray() {
        for (var j = 0; j < Detalle_de_ResultadosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_de_ResultadosDataMain.length; i++) {
                if (Detalle_de_ResultadosDataMain[i] != null && Detalle_de_ResultadosDataMain[i].Id == Detalle_de_ResultadosdeletedItem[j]) {
                    hDetalle_de_ResultadosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_de_ResultadoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_de_ResultadosDataMain.length; i++) {
            data[i] = Detalle_de_ResultadosDataMain[i];

        }
        return data;
    }
    function Detalle_de_ResultadosgetNewResult() {
        var newData = copyMainDetalle_de_ResultadosArray();

        for (var i = 0; i < Detalle_de_ResultadosData.length; i++) {
            if (Detalle_de_ResultadosData[i].Removed == null || Detalle_de_ResultadosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_de_ResultadosData[i]);
            }
        }
        return newData;
    }
    function Detalle_de_ResultadospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_de_ResultadosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_de_ResultadosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

var AutoCompleteNacionalidadData = [];
function GetAutoCompleteConsulta_de_Mandamientos_Judiciales_Nacionalidad_NacionalidadData(data) {
	AutoCompleteNacionalidadData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteNacionalidadData.push({
            id: data[i].Clave,
            text: data[i].NacionalidadC
        });
    }
    return AutoCompleteNacionalidadData;
}
//Grid GetAutocomplete
var AutoCompleteNacionalidadData = [];
function GetAutoCompleteDetalle_de_Resultados_Nacionalidad_NacionalidadData(data) {
	AutoCompleteNacionalidadData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteNacionalidadData.push({
            id: data[i].Clave,
            text: data[i].NacionalidadC
        });
    }
    return AutoCompleteNacionalidadData;
}



function getDropdown(elementKey) {
    var labelSelect = $("#Consulta_de_Mandamientos_Judiciales_cmbLabelSelect").val();
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">' + labelSelect + '</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' >";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control'  data-autoclose='true'>";
}
function GetGridTextArea() {
    return "<textarea rows='2'></textarea>";
}
function GetGridCheckBox() {
    return " <input type='checkbox' class='fullWidth'> ";
}
function GetFileUploader() {
    return "<input type='file' class='fullWidth'>";
}

function GetGridAutoComplete(data,field, id) {
    
    var dataMain = data == null ? "Select" : data;
    id ==  (id==null   || id==undefined)? "":id;
    
     return "<select class='AutoComplete fullWidth select2-dropDown " + field + " form-control' data-val='true'  ><option value='" + id +"'>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceClave").val("0");
    $('#CreateConsulta_de_Mandamientos_Judiciales')[0].reset();
    ClearFormControls();
    $("#ClaveId").val("0");
    $('#Nacionalidad').empty();
    $("#Nacionalidad").append('<option value=""></option>');
    $('#Nacionalidad').val('0').trigger('change');
                Detalle_de_ResultadosClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateConsulta_de_Mandamientos_Judiciales').trigger('reset');
    $('#CreateConsulta_de_Mandamientos_Judiciales').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
				for (instance in CKEDITOR.instances) {
                    CKEDITOR.instances[instance].updateElement();
                    CKEDITOR.instances[instance].setData('');
                }
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateConsulta_de_Mandamientos_Judiciales');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_de_ResultadoscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_de_Resultados();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblClave").text("0");
}
$(document).ready(function () {
    $("form#CreateConsulta_de_Mandamientos_Judiciales").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateConsulta_de_Mandamientos_Judiciales").on('click', '#Consulta_de_Mandamientos_JudicialesCancelar', function () {
	  if (!isPartial) {
        Consulta_de_Mandamientos_JudicialesBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateConsulta_de_Mandamientos_Judiciales").on('click', '#Consulta_de_Mandamientos_JudicialesGuardar', function () {
		$('#Consulta_de_Mandamientos_JudicialesGuardar').attr('disabled', true);
		$('#Consulta_de_Mandamientos_JudicialesGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendConsulta_de_Mandamientos_JudicialesData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial  && !viewInEframe)
						Consulta_de_Mandamientos_JudicialesBackToGrid();
					else if (viewInEframe) 
                    {
                        $('#Consulta_de_Mandamientos_JudicialesGuardar').removeAttr('disabled');
                        $('#Consulta_de_Mandamientos_JudicialesGuardar').bind()
                    }
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Consulta_de_Mandamientos_Judiciales', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Consulta_de_Mandamientos_JudicialesItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Consulta_de_Mandamientos_JudicialesDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Consulta_de_Mandamientos_JudicialesGuardar').removeAttr('disabled');
					$('#Consulta_de_Mandamientos_JudicialesGuardar').bind()
				}
		}
		else {
			$('#Consulta_de_Mandamientos_JudicialesGuardar').removeAttr('disabled');
			$('#Consulta_de_Mandamientos_JudicialesGuardar').bind()
		}
    });
	$("form#CreateConsulta_de_Mandamientos_Judiciales").on('click', '#Consulta_de_Mandamientos_JudicialesGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendConsulta_de_Mandamientos_JudicialesData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_de_ResultadosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Consulta_de_Mandamientos_Judiciales', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Consulta_de_Mandamientos_JudicialesItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Consulta_de_Mandamientos_JudicialesDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateConsulta_de_Mandamientos_Judiciales").on('click', '#Consulta_de_Mandamientos_JudicialesGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendConsulta_de_Mandamientos_JudicialesData(function (currentId) {
					$("#ClaveId").val("0");
	    $('#Nacionalidad').empty();
    $("#Nacionalidad").append('<option value=""></option>');
    $('#Nacionalidad').val('0').trigger('change');
                Detalle_de_ResultadosClearGridData();

					ResetClaveLabel();
					$("#ReferenceClave").val(currentId);
	                getDetalle_de_ResultadosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Consulta_de_Mandamientos_Judiciales',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Consulta_de_Mandamientos_JudicialesItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Consulta_de_Mandamientos_JudicialesDropDown().get(0)').innerHTML);                          
					    }	
					}						
			setIsNew();
				});
		}
    });
});

function setIsNew() {
    $('#hdnIsNew').val("True");
	$('#Operation').val("New");
	operation = "New";
}



var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}

function getElementTable(elementNumber, table) {

    for (var j = 0; j < childElementObject.length; j++) {
        if (childElementObject[j].table == table) {
            return childElementObject[j].elements[elementNumber];
            break;
        }
    }
}

function setRequired(elementNumber, element, elementType, table) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        getElementTable(elementNumber, table).IsRequired = (getElementTable(elementNumber, table).IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!getElementTable(elementNumber, table).IsVisible && getElementTable(elementNumber, table).IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (getElementTable(elementNumber, table).IsReadOnly && getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && getElementTable(elementNumber, table).IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsVisible = (getElementTable(elementNumber, table).IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    }
}
function setReadOnly(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ?GetTraduction('Disabled') : GetTraduction('Enabled')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && !getElementTable(elementNumber, table).IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsReadOnly = (getElementTable(elementNumber, table).IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsReadOnly == true ? GetTraduction('Disabled') : GetTraduction('Enabled')));
    }
}
function setDefaultValue(elementNumber, element, elementType, table) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('DefaultValue'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType, table) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('HelpText'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue(table) {
    debugger;
    if ($('#hdnElementType').val() == "1") {
        if ($('#hdnAttributType').val() == "1") {
            mainElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue));
        } else if ($('#hdnAttributType').val() == "2") {
            mainElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    } else {
        if ($('#hdnAttributType').val() == "1") {
            getElementTable($('#hdnAttributNumber').val(), table).DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            getElementTable($('#hdnAttributNumber').val(), table).HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(element, table, number) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (element.IsRequired == true ? GetTraduction("Required") : GetTraduction("NotRequired")) + '" onclick="setRequired(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (element.IsVisible == true ? GetTraduction("Visible") : GetTraduction("InVisible")) + '" onclick="setVisible(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (element.IsReadOnly == true ?GetTraduction("Disabled") :GetTraduction("Enabled")) + '" onclick="setReadOnly(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + number.toString() + '" class="defaultValueClick" title="' + (element.DefaultValue) + '" onclick="setDefaultValue(' + number.toString() + ', this, 2,  "' + table + '")"><img src="' + $('#hdnApplicationDirectory').val() + (element.DefaultValue != '' && element.DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + number.toString() + '" class="helpTextClick" title="' + (element.HelpText) + '" onclick="setHelpText(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.HelpText != '' && element.HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}



var Consulta_de_Mandamientos_JudicialesisdisplayBusinessPropery = false;
Consulta_de_Mandamientos_JudicialesDisplayBusinessRuleButtons(Consulta_de_Mandamientos_JudicialesisdisplayBusinessPropery);
function Consulta_de_Mandamientos_JudicialesDisplayBusinessRule() {
    if (!Consulta_de_Mandamientos_JudicialesisdisplayBusinessPropery) {
        $('#CreateConsulta_de_Mandamientos_Judiciales').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Consulta_de_Mandamientos_JudicialesdisplayBusinessPropery"><button onclick="Consulta_de_Mandamientos_JudicialesGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Consulta_de_Mandamientos_JudicialesBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Consulta_de_Mandamientos_JudicialesdisplayBusinessPropery').remove();
    }
    Consulta_de_Mandamientos_JudicialesDisplayBusinessRuleButtons(!Consulta_de_Mandamientos_JudicialesisdisplayBusinessPropery);
    Consulta_de_Mandamientos_JudicialesisdisplayBusinessPropery = (Consulta_de_Mandamientos_JudicialesisdisplayBusinessPropery ? false : true);
}
function Consulta_de_Mandamientos_JudicialesDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

