var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//CONVERTIR A MAYUSCULAS AL BLUR
$('input[type="text"],textarea').blur(function() {
	this.value = this.value.toUpperCase();
	});
//END CONVERTIR A MAYUSCULAS AL BLUR

//BusinessRuleId:2495, Attribute:263253, Operation:Field, Event:None
$("form#CreateDetalle_de_Servicio_de_Apoyo").on('change', '#Requiere_Traductor', function () {
	nameOfTable='';
	rowIndex='';
if( GetValueByControlType($('#' + nameOfTable + 'Requiere_Traductor' + rowIndex),nameOfTable,rowIndex)==TryParseInt('true', 'true') ) { $('#divLengua_Originaria').css('display', 'block');$('#divIdioma').css('display', 'block');} else { $('#divLengua_Originaria').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lengua_Originaria' + rowIndex));$('#divIdioma').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Idioma' + rowIndex));}
});


//BusinessRuleId:2495, Attribute:263253, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:1719, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divModulo_de_Atencion_Inicial').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo_de_Atencion_Inicial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo_de_Atencion_Inicial' + rowIndex));


}
//BusinessRuleId:1719, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1737, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Modulo_de_Atencion_Inicial" + rowIndex), ("true" == "true"));


}
//BusinessRuleId:1737, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1753, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));


}
//BusinessRuleId:1753, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1753, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));


}
//BusinessRuleId:1753, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1753, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));


}
//BusinessRuleId:1753, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1983, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Servicio' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Dictamen' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Responsable' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Compareciente' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Requiere_Traductor' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Lengua_Originaria' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Idioma' + rowIndex));


}
//BusinessRuleId:1983, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1983, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Servicio' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Dictamen' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Responsable' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Compareciente' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Requiere_Traductor' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Lengua_Originaria' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Idioma' + rowIndex));


}
//BusinessRuleId:1983, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1983, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Servicio' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Dictamen' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Responsable' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Compareciente' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Requiere_Traductor' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Lengua_Originaria' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Idioma' + rowIndex));


}
//BusinessRuleId:1983, Attribute:0, Operation:Object, Event:SCREENOPENING



//BusinessRuleId:2232, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Modulo_de_Atencion_Inicial' + rowIndex),EvaluaQuery("SELECT NUAT FROM Modulo_Atencion_Inicial WHERE Clave = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable));


}
//BusinessRuleId:2232, Attribute:0, Operation:Object, Event:SCREENOPENING













//BusinessRuleId:2496, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divLengua_Originaria').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lengua_Originaria' + rowIndex));$('#divIdioma').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Idioma' + rowIndex));


}
//BusinessRuleId:2496, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2496, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divLengua_Originaria').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lengua_Originaria' + rowIndex));$('#divIdioma').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Idioma' + rowIndex));


}
//BusinessRuleId:2496, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2496, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 $('#divLengua_Originaria').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lengua_Originaria' + rowIndex));$('#divIdioma').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Idioma' + rowIndex));


}
//BusinessRuleId:2496, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//BusinessRuleId:1728, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
 EvaluaQuery(" update Detalle_de_Servicio_de_Apoyo"
+" 	set Modulo_de_Atencion_Inicial	 = GLOBAL[SpartanOperationId]"
+" 	where Clave=GLOBAL[keyvalueinserted]", rowIndex, nameOfTable);


}
//BusinessRuleId:1728, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}


