var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//BusinessRuleId:563, Attribute:264367, Operation:Field, Event:None
$("form#CreateEncuesta1").on('keyup', '#NUAT', function () {
	nameOfTable='';
	rowIndex='';
if( GetValueByControlType($('#' + nameOfTable + 'NUAT' + rowIndex),nameOfTable,rowIndex)!=TryParseInt('null', 'null') && EvaluaQuery("select count(*) from Encuesta1 where NUAT='FLD[NUAT]'",rowIndex, nameOfTable)>=TryParseInt('1', '1') ) { alert(DecodifyText('Este NUAT ya tiene una encuesta relacionada.', rowIndex, nameOfTable));

result=false;} else {}
});


//BusinessRuleId:563, Attribute:264367, Operation:Field, Event:None

//COD-MANI INI OCULTAR BOTONES
$('#Encuesta1GuardarYNuevo').css('display', 'none');
$('#Encuesta1GuardarYCopia').css('display', 'none');
$('#Encuesta1Cancelar').css('display', 'none');
//COD-MANI END OCULTAR BOTONES








//BusinessRuleId:2879, Attribute:264366, Operation:Field, Event:None
$("form#CreateEncuesta1").on('change', '#Numero_de_Preguntas', function () {
	nameOfTable='';
	rowIndex='';
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('2', '2') ) { $('#divPregunta1').css('display', 'block');$('#divPregunta2').css('display', 'block');$('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex)); $('#divPregunta3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));$('#divPregunta4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));$('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));$('#divRespuesta_3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));$('#divRespuesta_4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));$('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));} else {}
});


//BusinessRuleId:2879, Attribute:264366, Operation:Field, Event:None



//BusinessRuleId:2881, Attribute:264366, Operation:Field, Event:None
$("form#CreateEncuesta1").on('change', '#Numero_de_Preguntas', function () {
	nameOfTable='';
	rowIndex='';
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('4', '4') ) { $('#divPregunta1').css('display', 'block');$('#divPregunta2').css('display', 'block');$('#divPregunta3').css('display', 'block');$('#divPregunta4').css('display', 'block');$('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block');$('#divRespuesta_3').css('display', 'block');$('#divRespuesta_4').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex)); $('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));$('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));} else {}
});


//BusinessRuleId:2881, Attribute:264366, Operation:Field, Event:None

//BusinessRuleId:2882, Attribute:264366, Operation:Field, Event:None
$("form#CreateEncuesta1").on('change', '#Numero_de_Preguntas', function () {
	nameOfTable='';
	rowIndex='';
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('5', '5') ) { $('#divPregunta1').css('display', 'block');$('#divPregunta2').css('display', 'block');$('#divPregunta3').css('display', 'block');$('#divPregunta4').css('display', 'block');$('#divPregunta5').css('display', 'block');$('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block');$('#divRespuesta_3').css('display', 'block');$('#divRespuesta_4').css('display', 'block');$('#divRespuesta_5').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));} else {}
});


//BusinessRuleId:2882, Attribute:264366, Operation:Field, Event:None

//BusinessRuleId:2878, Attribute:264366, Operation:Field, Event:None
$("form#CreateEncuesta1").on('change', '#Numero_de_Preguntas', function () {
	nameOfTable='';
	rowIndex='';
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('1', '1') ) { $('#divPregunta1').css('display', 'block');$('#divRespuesta_1').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex)); $('#divPregunta2').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));$('#divPregunta3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));$('#divPregunta4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));$('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));$('#divRespuesta_2').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));$('#divRespuesta_3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));$('#divRespuesta_4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));$('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta1' + rowIndex));} else {}
});


//BusinessRuleId:2878, Attribute:264366, Operation:Field, Event:None



//BusinessRuleId:2880, Attribute:264366, Operation:Field, Event:None
$("form#CreateEncuesta1").on('change', '#Numero_de_Preguntas', function () {
	nameOfTable='';
	rowIndex='';
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('3', '3') ) { $('#divPregunta1').css('display', 'block');$('#divPregunta2').css('display', 'block');$('#divPregunta3').css('display', 'block');$('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block');$('#divRespuesta_3').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex)); $('#divPregunta4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));$('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));$('#divRespuesta_4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));$('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex)); DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_3" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));}} else {}
});

//BusinessRuleId:2880, Attribute:264366, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {






















//BusinessRuleId:523, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('6', '6') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta7' + rowIndex)); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:523, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:523, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('6', '6') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta7' + rowIndex)); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:523, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:524, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('7', '7') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:524, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:524, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('7', '7') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:524, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:525, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('8', '8') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'block'); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:525, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:525, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('8', '8') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'block'); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:525, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:526, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('9', '9') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'block'); $('#divPregunta9').css('display', 'block'); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:526, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:526, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('9', '9') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'block'); $('#divPregunta9').css('display', 'block'); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex));} else {}


}
//BusinessRuleId:526, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:527, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('10', '10') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'block'); $('#divPregunta9').css('display', 'block'); $('#divPregunta10').css('display', 'block');} else {}


}
//BusinessRuleId:527, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:527, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[varpreguntas]'",rowIndex, nameOfTable)==TryParseInt('10', '10') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'block'); $('#divPregunta7').css('display', 'block'); $('#divPregunta8').css('display', 'block'); $('#divPregunta9').css('display', 'block'); $('#divPregunta10').css('display', 'block');} else {}


}
//BusinessRuleId:527, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2540, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));


}
//BusinessRuleId:2540, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2540, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));


}
//BusinessRuleId:2540, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2540, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));


}
//BusinessRuleId:2540, Attribute:0, Operation:Object, Event:SCREENOPENING































//BusinessRuleId:531, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Pregunta6' + rowIndex),EvaluaQuery(" SELECT Pregunta_6 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:531, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:531, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Pregunta6' + rowIndex),EvaluaQuery(" SELECT Pregunta_6 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:531, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:531, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 AsignarValor($('#' + nameOfTable + 'Pregunta6' + rowIndex),EvaluaQuery(" SELECT Pregunta_6 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:531, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:532, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Pregunta7' + rowIndex),EvaluaQuery(" SELECT Pregunta_7 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:532, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:532, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Pregunta7' + rowIndex),EvaluaQuery(" SELECT Pregunta_7 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:532, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:532, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 AsignarValor($('#' + nameOfTable + 'Pregunta7' + rowIndex),EvaluaQuery(" SELECT Pregunta_7 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:532, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:534, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Pregunta8' + rowIndex),EvaluaQuery(" SELECT Pregunta_8 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:534, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:534, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Pregunta8' + rowIndex),EvaluaQuery(" SELECT Pregunta_8 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:534, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:534, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 AsignarValor($('#' + nameOfTable + 'Pregunta8' + rowIndex),EvaluaQuery(" SELECT Pregunta_8 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:534, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:535, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Pregunta9' + rowIndex),EvaluaQuery(" SELECT Pregunta_9 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:535, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:535, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Pregunta9' + rowIndex),EvaluaQuery(" SELECT Pregunta_9 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:535, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:535, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 AsignarValor($('#' + nameOfTable + 'Pregunta9' + rowIndex),EvaluaQuery(" SELECT Pregunta_9 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:535, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:536, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Pregunta9' + rowIndex),EvaluaQuery("SELECT Pregunta_9 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:536, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:536, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Pregunta9' + rowIndex),EvaluaQuery("SELECT Pregunta_9 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:536, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:536, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 AsignarValor($('#' + nameOfTable + 'Pregunta9' + rowIndex),EvaluaQuery("SELECT Pregunta_9 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:536, Attribute:0, Operation:Object, Event:SCREENOPENING







//BusinessRuleId:537, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Pregunta10' + rowIndex),EvaluaQuery(" SELECT Pregunta_10 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:537, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:537, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Pregunta10' + rowIndex),EvaluaQuery(" SELECT Pregunta_10 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:537, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:537, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 AsignarValor($('#' + nameOfTable + 'Pregunta10' + rowIndex),EvaluaQuery(" SELECT Pregunta_10 FROM Encuesta WHERE Clave = 1", rowIndex, nameOfTable));


}
//BusinessRuleId:537, Attribute:0, Operation:Object, Event:SCREENOPENING





































//BusinessRuleId:499, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Numero_de_Preguntas" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));} CreateSessionVar('varpreguntas', EvaluaQuery(" SELECT FLD[Numero_de_Preguntas]", rowIndex, nameOfTable));


}
//BusinessRuleId:499, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:503, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('1', '1') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex)); $('#divPregunta3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex)); $('#divPregunta4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex)); $('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex)); $('#divPregunta6').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta6' + rowIndex)); $('#divPregunta7').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta7' + rowIndex)); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex)); $('#divRespuesta_1').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex)); DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));} $('#divRespuesta_2').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));$('#divRespuesta_3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));$('#divRespuesta_4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));$('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));} else {}


}
//BusinessRuleId:503, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:519, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('2', '2') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex)); $('#divPregunta4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex)); $('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex)); $('#divPregunta6').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta6' + rowIndex)); $('#divPregunta7').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta7' + rowIndex)); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex)); $('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex)); DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));} $('#divRespuesta_3').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));$('#divRespuesta_4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));$('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));} else {}


}
//BusinessRuleId:519, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:520, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('3', '3') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex)); $('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex)); $('#divPregunta6').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta6' + rowIndex)); $('#divPregunta7').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta7' + rowIndex)); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex)); $('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block');$('#divRespuesta_3').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex)); DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_3" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));} $('#divRespuesta_4').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));$('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));} else {}


}
//BusinessRuleId:520, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:521, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('4', '4') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex)); $('#divPregunta6').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta6' + rowIndex)); $('#divPregunta7').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta7' + rowIndex)); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex)); $('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block');$('#divRespuesta_3').css('display', 'block');$('#divRespuesta_4').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex)); DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_3" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_4" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));} $('#divRespuesta_5').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));} else {}


}
//BusinessRuleId:521, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:522, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( GetValueByControlType($('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex),nameOfTable,rowIndex)==TryParseInt('5', '5') ) { $('#divPregunta1').css('display', 'block'); $('#divPregunta2').css('display', 'block'); $('#divPregunta3').css('display', 'block'); $('#divPregunta4').css('display', 'block'); $('#divPregunta5').css('display', 'block'); $('#divPregunta6').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta6' + rowIndex)); $('#divPregunta7').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta7' + rowIndex)); $('#divPregunta8').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta8' + rowIndex)); $('#divPregunta9').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta9' + rowIndex)); $('#divPregunta10').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta10' + rowIndex)); $('#divRespuesta_1').css('display', 'block');$('#divRespuesta_2').css('display', 'block');$('#divRespuesta_3').css('display', 'block');$('#divRespuesta_4').css('display', 'block');$('#divRespuesta_5').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex)); DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_3" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_4" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_5" + rowIndex), ("false" == "true"));if ('false'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));}} else {}


}
//BusinessRuleId:522, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2884, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('106', '106') ) { $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));$('#divNumero_de_Preguntas').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));$('#divNUAT').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));$('#divModulo').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));$('#divFecha_Enviado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));$('#divHora_Enviado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));$('#divFecha_Respuesta').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));$('#divHora_Respuesta').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));$('#divEstatus').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));$('#divTipo_Encuesta').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Encuesta' + rowIndex));} else {}

}
//BusinessRuleId:2884, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2884, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('106', '106') ) { $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));$('#divNumero_de_Preguntas').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));$('#divNUAT').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));$('#divModulo').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));$('#divFecha_Enviado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));$('#divHora_Enviado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));$('#divFecha_Respuesta').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));$('#divHora_Respuesta').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));$('#divEstatus').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));$('#divTipo_Encuesta').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Encuesta' + rowIndex));} else {}

}
//BusinessRuleId:2884, Attribute:0, Operation:Object, Event:SCREENOPENING







//BusinessRuleId:2883, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Numero_de_Preguntas" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));}DisabledControl($("#" + nameOfTable + "NUAT" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta1" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta2" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta3" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta4" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta5" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));}DisabledControl($("#" + nameOfTable + "Modulo" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));}DisabledControl($("#" + nameOfTable + "Fecha_Enviado" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_Enviado" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));}DisabledControl($("#" + nameOfTable + "Fecha_Respuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_Respuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));}DisabledControl($("#" + nameOfTable + "Estatus" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));}DisabledControl($("#" + nameOfTable + "Folio" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex));} DisabledControl($("#" + nameOfTable + "Tipo_Encuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Encuesta' + rowIndex));}

}
//BusinessRuleId:2883, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2883, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Numero_de_Preguntas" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));}DisabledControl($("#" + nameOfTable + "NUAT" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta1" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta2" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta3" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta4" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta5" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));}DisabledControl($("#" + nameOfTable + "Modulo" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));}DisabledControl($("#" + nameOfTable + "Fecha_Enviado" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_Enviado" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));}DisabledControl($("#" + nameOfTable + "Fecha_Respuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_Respuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));}DisabledControl($("#" + nameOfTable + "Estatus" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));}DisabledControl($("#" + nameOfTable + "Folio" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex));} DisabledControl($("#" + nameOfTable + "Tipo_Encuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Encuesta' + rowIndex));}

}
//BusinessRuleId:2883, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2883, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta1' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));SetRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Numero_de_Preguntas" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Preguntas' + rowIndex));}DisabledControl($("#" + nameOfTable + "NUAT" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'NUAT' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta1" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta2" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta3" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta4" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta4' + rowIndex));}DisabledControl($("#" + nameOfTable + "Pregunta5" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Pregunta5' + rowIndex));}DisabledControl($("#" + nameOfTable + "Modulo" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo' + rowIndex));}DisabledControl($("#" + nameOfTable + "Fecha_Enviado" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Enviado' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_Enviado" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Enviado' + rowIndex));}DisabledControl($("#" + nameOfTable + "Fecha_Respuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_Respuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_Respuesta' + rowIndex));}DisabledControl($("#" + nameOfTable + "Estatus" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));}DisabledControl($("#" + nameOfTable + "Folio" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex));} DisabledControl($("#" + nameOfTable + "Tipo_Encuesta" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Encuesta' + rowIndex));}

}
//BusinessRuleId:2883, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3115, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( GetValueByControlType($('#' + nameOfTable + 'Estatus' + rowIndex),nameOfTable,rowIndex)==TryParseInt('2', '2') ) { DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_3" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_4" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_5" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));}} else {}

}
//BusinessRuleId:3115, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3115, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( GetValueByControlType($('#' + nameOfTable + 'Estatus' + rowIndex),nameOfTable,rowIndex)==TryParseInt('2', '2') ) { DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_3" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_4" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_5" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));}} else {}

}
//BusinessRuleId:3115, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:3115, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( GetValueByControlType($('#' + nameOfTable + 'Estatus' + rowIndex),nameOfTable,rowIndex)==TryParseInt('2', '2') ) { DisabledControl($("#" + nameOfTable + "Respuesta_1" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_1' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_2" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_2' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_3" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_3' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_4" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_4' + rowIndex));}DisabledControl($("#" + nameOfTable + "Respuesta_5" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Respuesta_5' + rowIndex));}} else {}

}
//BusinessRuleId:3115, Attribute:0, Operation:Object, Event:SCREENOPENING

//INI COD-MAN PARA OCULTAR BOTON DE GUARDAR SI EL ESTATUS  = 2 CONTESTADA
if(operation == 'Update' || operation == 'New' || operation == 'Consult'){
	if( GetValueByControlType($('#' + nameOfTable + 'Estatus' + rowIndex),nameOfTable,rowIndex)==TryParseInt('2', '2') ) 
	{ 
		$('#Encuesta1Guardar').css('display', 'none');
	}
}
//END COD-MAN PARA OCULTAR BOTON DE GUARDAR SI EL ESTATUS  = 2 CONTESTADA

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;




//BusinessRuleId:2885, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'Update'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('106', '106') ) { AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),'2'); AsignarValor($('#' + nameOfTable + 'Fecha_Respuesta' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_Respuesta' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable));} else {}


}
//BusinessRuleId:2885, Attribute:2, Operation:Object, Event:BEFORESAVING

//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}


