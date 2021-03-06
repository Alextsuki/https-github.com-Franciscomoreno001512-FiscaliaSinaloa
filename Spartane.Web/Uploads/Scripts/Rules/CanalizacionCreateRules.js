var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function() {
    //COD-MANI INI OCULTAR BOTONES
    $('#CanalizacionGuardarYNuevo').css('display', 'none');
    $('#CanalizacionGuardarYCopia').css('display', 'none');
    $('#ConfigureSave').css('display', 'none');
    //COD-MANI END OCULTAR BOTONES






    //BusinessRuleId:3557, Attribute:269153, Operation:Field, Event:None
    $("form#CreateCanalizacion").on('change', '#Municipio', function() {
        nameOfTable = '';
        rowIndex = '';
        var valor = $('#' + nameOfTable + 'Unidad' + rowIndex).val();
        $('#' + nameOfTable + 'Unidad' + rowIndex).empty();
        if (!$('#' + nameOfTable + 'Unidad' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option selected />").val("").text(""));
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            var selectData = [];
            selectData.push({ id: "", text: "" });
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { selectData.push({ id: index, text: value }); });
            $('#' + nameOfTable + 'Unidad' + rowIndex).select2({ data: selectData })
        }
        $('#' + nameOfTable + 'Unidad' + rowIndex).val(valor).trigger('change');
    });





    //BusinessRuleId:3557, Attribute:269153, Operation:Field, Event:None

    //NEWBUSINESSRULE_NONE//
});

function EjecutarValidacionesAlComienzo() {






    //BusinessRuleId:3553, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'New') {
        $('#divClave').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Clave' + rowIndex));
        $('#divExpediente_MP').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_MP' + rowIndex));
        $('#divExpediente_AT').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_AT' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_MP' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_AT' + rowIndex));


    }
    //BusinessRuleId:3553, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3553, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Update') {
        $('#divClave').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Clave' + rowIndex));
        $('#divExpediente_MP').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_MP' + rowIndex));
        $('#divExpediente_AT').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_AT' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_MP' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_AT' + rowIndex));


    }
    //BusinessRuleId:3553, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3553, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Consult') {
        $('#divClave').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Clave' + rowIndex));
        $('#divExpediente_MP').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_MP' + rowIndex));
        $('#divExpediente_AT').css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_AT' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_MP' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Expediente_AT' + rowIndex));


    }
    //BusinessRuleId:3553, Attribute:0, Operation:Object, Event:SCREENOPENING



    //BusinessRuleId:3554, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'New') {
        AsignarValor($('#' + nameOfTable + 'Fecha_de_Canalizacion' + rowIndex), EvaluaQuery("select convert(nvarchar(11), getdate(), 105)", rowIndex, nameOfTable));
        AsignarValor($('#' + nameOfTable + 'Hora_de_Canalizacion' + rowIndex), EvaluaQuery("select convert(nvarchar(11), getdate(), 108)", rowIndex, nameOfTable));
        AsignarValor($('#' + nameOfTable + 'Usuario_que_Canaliza' + rowIndex), EvaluaQuery("SELECT NAME FROM SPARTAN_USER WHERE ID_USER = GLOBAL[USERID]", rowIndex, nameOfTable));


    }
    //BusinessRuleId:3554, Attribute:0, Operation:Object, Event:SCREENOPENING







    //BusinessRuleId:3555, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'New') {
        DisabledControl($("#" + nameOfTable + "Usuario_que_Canaliza" + rowIndex), ("true" == "true"));
        if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Usuario_que_Canaliza' + rowIndex)); }


    }
    //BusinessRuleId:3555, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3555, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Update') {
        DisabledControl($("#" + nameOfTable + "Usuario_que_Canaliza" + rowIndex), ("true" == "true"));
        if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Usuario_que_Canaliza' + rowIndex)); }


    }
    //BusinessRuleId:3555, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3555, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Consult') {
        DisabledControl($("#" + nameOfTable + "Usuario_que_Canaliza" + rowIndex), ("true" == "true"));
        if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Usuario_que_Canaliza' + rowIndex)); }


    }
    //BusinessRuleId:3555, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3556, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Municipio' + rowIndex).val();
        $('#' + nameOfTable + 'Municipio' + rowIndex).empty();
        if (!$('#' + nameOfTable + 'Municipio' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Municipio' + rowIndex).append($("<option selected />").val("").text(""));
            $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE FROM MUNICIPIO WHERE ESTADO = 25", rowIndex, nameOfTable), function(index, value) { $('#' + nameOfTable + 'Municipio' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            var selectData = [];
            selectData.push({ id: "", text: "" });
            $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE FROM MUNICIPIO WHERE ESTADO = 25", rowIndex, nameOfTable), function(index, value) { selectData.push({ id: index, text: value }); });
            $('#' + nameOfTable + 'Municipio' + rowIndex).select2({ data: selectData })
        }
        $('#' + nameOfTable + 'Municipio' + rowIndex).val(valor).trigger('change');


    }
    //BusinessRuleId:3556, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3556, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Municipio' + rowIndex).val();
        $('#' + nameOfTable + 'Municipio' + rowIndex).empty();
        if (!$('#' + nameOfTable + 'Municipio' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Municipio' + rowIndex).append($("<option selected />").val("").text(""));
            $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE FROM MUNICIPIO WHERE ESTADO = 25", rowIndex, nameOfTable), function(index, value) { $('#' + nameOfTable + 'Municipio' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            var selectData = [];
            selectData.push({ id: "", text: "" });
            $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE FROM MUNICIPIO WHERE ESTADO = 25", rowIndex, nameOfTable), function(index, value) { selectData.push({ id: index, text: value }); });
            $('#' + nameOfTable + 'Municipio' + rowIndex).select2({ data: selectData })
        }
        $('#' + nameOfTable + 'Municipio' + rowIndex).val(valor).trigger('change');


    }
    //BusinessRuleId:3556, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3556, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Consult') {
        var valor = $('#' + nameOfTable + 'Municipio' + rowIndex).val();
        $('#' + nameOfTable + 'Municipio' + rowIndex).empty();
        if (!$('#' + nameOfTable + 'Municipio' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Municipio' + rowIndex).append($("<option selected />").val("").text(""));
            $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE FROM MUNICIPIO WHERE ESTADO = 25", rowIndex, nameOfTable), function(index, value) { $('#' + nameOfTable + 'Municipio' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            var selectData = [];
            selectData.push({ id: "", text: "" });
            $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE FROM MUNICIPIO WHERE ESTADO = 25", rowIndex, nameOfTable), function(index, value) { selectData.push({ id: index, text: value }); });
            $('#' + nameOfTable + 'Municipio' + rowIndex).select2({ data: selectData })
        }
        $('#' + nameOfTable + 'Municipio' + rowIndex).val(valor).trigger('change');


    }
    //BusinessRuleId:3556, Attribute:0, Operation:Object, Event:SCREENOPENING



    //BusinessRuleId:3559, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Unidad' + rowIndex).val();
        $('#' + nameOfTable + 'Unidad' + rowIndex).empty();
        if (!$('#' + nameOfTable + 'Unidad' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option selected />").val("").text(""));
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            var selectData = [];
            selectData.push({ id: "", text: "" });
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { selectData.push({ id: index, text: value }); });
            $('#' + nameOfTable + 'Unidad' + rowIndex).select2({ data: selectData })
        }
        $('#' + nameOfTable + 'Unidad' + rowIndex).val(valor).trigger('change');


    }
    //BusinessRuleId:3559, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3559, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Unidad' + rowIndex).val();
        $('#' + nameOfTable + 'Unidad' + rowIndex).empty();
        if (!$('#' + nameOfTable + 'Unidad' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option selected />").val("").text(""));
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            var selectData = [];
            selectData.push({ id: "", text: "" });
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { selectData.push({ id: index, text: value }); });
            $('#' + nameOfTable + 'Unidad' + rowIndex).select2({ data: selectData })
        }
        $('#' + nameOfTable + 'Unidad' + rowIndex).val(valor).trigger('change');


    }
    //BusinessRuleId:3559, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3559, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Consult') {
        var valor = $('#' + nameOfTable + 'Unidad' + rowIndex).val();
        $('#' + nameOfTable + 'Unidad' + rowIndex).empty();
        if (!$('#' + nameOfTable + 'Unidad' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option selected />").val("").text(""));
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { $('#' + nameOfTable + 'Unidad' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            var selectData = [];
            selectData.push({ id: "", text: "" });
            $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION FROM UNIDAD WHERE CLAVE_DE_MUNICIPIO = FLD[Municipio]", rowIndex, nameOfTable), function(index, value) { selectData.push({ id: index, text: value }); });
            $('#' + nameOfTable + 'Unidad' + rowIndex).select2({ data: selectData })
        }
        $('#' + nameOfTable + 'Unidad' + rowIndex).val(valor).trigger('change');


    }
    //BusinessRuleId:3559, Attribute:0, Operation:Object, Event:SCREENOPENING





    //BusinessRuleId:3558, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'New') {
        $("a[href='#tabResolucion']").css('display', 'none');
        SetNotRequiredToControl($('#' + nameOfTable + 'Fecha_de_Resolucion' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Hora_de_Resolucion' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Nueva_Relacion' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'ResolucionId' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Resolucion' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Detalle_de_la_Resolucion' + rowIndex));
        SetNotRequiredToControl($('#' + nameOfTable + 'Observaciones' + rowIndex));


    }
    //BusinessRuleId:3558, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3560, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Update') {
        if (GetValueByControlType($('#' + nameOfTable + 'ResolucionId' + rowIndex), nameOfTable, rowIndex) != TryParseInt('NULL', 'NULL') && GetValueByControlType($('#' + nameOfTable + 'ResolucionId' + rowIndex), nameOfTable, rowIndex) > TryParseInt('0', '0')) {
            $("a[href='#tabResolucion']").css('display', 'block');
            DisabledControl($("#" + nameOfTable + "Fecha_de_Resolucion" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Fecha_de_Resolucion' + rowIndex)); }
            DisabledControl($("#" + nameOfTable + "Hora_de_Resolucion" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Hora_de_Resolucion' + rowIndex)); }
            DisabledControl($("#" + nameOfTable + "Hubo_modificacion_en_la_relacion" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Hubo_modificacion_en_la_relacion' + rowIndex)); }
            DisabledControl($("#" + nameOfTable + "Nueva_Relacion" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Nueva_Relacion' + rowIndex)); }
            DisabledControl($("#" + nameOfTable + "ResolucionId" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'ResolucionId' + rowIndex)); }
            DisabledControl($("#" + nameOfTable + "Resolucion" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Resolucion' + rowIndex)); }
            DisabledControl($("#" + nameOfTable + "Detalle_de_la_Resolucion" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Detalle_de_la_Resolucion' + rowIndex)); }
            DisabledControl($("#" + nameOfTable + "Observaciones" + rowIndex), ("true" == "true"));
            if ('true' == 'true') { SetNotRequiredToControl($('#' + nameOfTable + 'Observaciones' + rowIndex)); }
        } else {}


    }
    //BusinessRuleId:3560, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:3562, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Fecha_de_Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_de_Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_de_Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hubo_modificacion_en_la_relacion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hubo_modificacion_en_la_relacion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Nueva_Relacion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Nueva_Relacion' + rowIndex));}DisabledControl($("#" + nameOfTable + "ResolucionId" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'ResolucionId' + rowIndex));}DisabledControl($("#" + nameOfTable + "Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Detalle_de_la_Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Detalle_de_la_Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Observaciones" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Observaciones' + rowIndex));}

}
//BusinessRuleId:3562, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3562, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Fecha_de_Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_de_Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_de_Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hubo_modificacion_en_la_relacion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hubo_modificacion_en_la_relacion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Nueva_Relacion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Nueva_Relacion' + rowIndex));}DisabledControl($("#" + nameOfTable + "ResolucionId" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'ResolucionId' + rowIndex));}DisabledControl($("#" + nameOfTable + "Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Detalle_de_la_Resolucion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Detalle_de_la_Resolucion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Observaciones" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Observaciones' + rowIndex));}

}
//BusinessRuleId:3562, Attribute:0, Operation:Object, Event:SCREENOPENING















//BusinessRuleId:3566, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('2', '2') ) { var valor = $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val();   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3566, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3566, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('2', '2') ) { var valor = $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val();   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3566, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3566, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('2', '2') ) { var valor = $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val();   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3566, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3565, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('3', '3') ) { var valor = $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val();   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Expediente_MP = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Expediente_MP = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3565, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3565, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('3', '3') ) { var valor = $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val();   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Expediente_MP = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Expediente_MP = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3565, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3565, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('3', '3') ) { var valor = $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val();   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Expediente_MP = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM Detalle_de_Relaciones where Expediente_MP = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Relacion_a_Canalizar' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3565, Attribute:0, Operation:Object, Event:SCREENOPENING













//BusinessRuleId:3564, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('3', '3') ) { var valor = $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val();   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Canalizar_a' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2)", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2)", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Canalizar_a' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3564, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3564, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('3', '3') ) { var valor = $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val();   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Canalizar_a' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2)", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2)", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Canalizar_a' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3564, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3586, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('2', '2') ) { var valor = $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val();   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Canalizar_a' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2,6)	", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2,6)	", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Canalizar_a' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3586, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3586, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('2', '2') ) { var valor = $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val();   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Canalizar_a' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2,6)	", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Canalizar_a' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT Clave, Descripcion FROM dbo.Estatus_Orientador WHERE Clave IN (2,6)	", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Canalizar_a' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Canalizar_a' + rowIndex).val(valor).trigger('change');} else {}

}
//BusinessRuleId:3586, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}

function EjecutarValidacionesAntesDeGuardar() {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVING//
    return result;
}

function EjecutarValidacionesDespuesDeGuardar() {
    //BusinessRuleId:3567, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('3', '3') ) { EvaluaQuery(" update Canalizacion set Expediente_MP = GLOBAL[SpartanOperationId] where Clave = GLOBAL[keyvalueinserted]", rowIndex, nameOfTable);} else {}

}
//BusinessRuleId:3567, Attribute:2, Operation:Object, Event:AFTERSAVING

//BusinessRuleId:3568, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('2', '2') ) { EvaluaQuery(" update Canalizacion set Expediente_AT = GLOBAL[SpartanOperationId] where Clave = GLOBAL[keyvalueinserted]", rowIndex, nameOfTable);} else {}

}
//BusinessRuleId:3568, Attribute:2, Operation:Object, Event:AFTERSAVING



//BusinessRuleId:3570, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[idTablero]'), ReplaceGLOBAL('GLOBAL[idTablero]'))==TryParseInt('2', '2') && GetValueByControlType($('#' + nameOfTable + 'Canalizar_a' + rowIndex),nameOfTable,rowIndex)==TryParseInt('2', '2') ) { EvaluaQuery("exec uspCanalizarAT_a_MASC GLOBAL[SpartanOperationId], FLD[Relacion_a_Canalizar]", rowIndex, nameOfTable);} else {}

}
//BusinessRuleId:3570, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_Diligencias_Canalizacion(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Diligencias_Canalizacion//
    return result;
}

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Diligencias_Canalizacion(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Diligencias_Canalizacion//
}

function EjecutarValidacionesAlEliminarMRDetalle_Diligencias_Canalizacion(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Diligencias_Canalizacion//
    return result;
}

function EjecutarValidacionesNewRowMRDetalle_Diligencias_Canalizacion(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Diligencias_Canalizacion//
    return result;
}

function EjecutarValidacionesEditRowMRDetalle_Diligencias_Canalizacion(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Diligencias_Canalizacion//
    return result;
}