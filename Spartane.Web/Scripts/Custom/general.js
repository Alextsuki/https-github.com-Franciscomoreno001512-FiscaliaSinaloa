﻿
$('.modal').on('hidden.bs.modal', function (e) {

    if ($('.modal').hasClass('in')) {
        $('body').addClass('modal-open');
    }
    if (!$('.modal').is(':visible')) {
        $('body').removeClass('modal-open');
    }

});

var controlDocumentoDynamiSeach = false; 								 
$(function () {

    //$('#datetimepicker1 > input').mask("00-00-0000", { clearIfNotMatch: true });
    // display focus in and out as per validation
    $('.inputclientrequired').blur(function () {
        if ($(this).val() == '') {
            $(this).parent().closest('.form-group').addclass('has-error');
        } else {
            $(this).parent().closest('.form-group').removeclass('has-error');
        }
    });
});

function setDynamicRenderElement() {
    //display focus in and out as per validation
    $('.inputClientRequired').blur(function () {
        if ($(this).val() == '') {
            $(this).addClass('has-error');
        } else {
            $(this).removeClass('showRequired');
        }
    });
}

function setInputEntityAttributes(inpuElementArray, selectorType, elementType) {
    for (var i = 0; i < inpuElementArray.length; i++) {
        var element = $('' + selectorType + inpuElementArray[i].inputId);
        if (element != undefined) {
            //if (element.val() != undefined) {
            if (!inpuElementArray[i].IsVisible) {
                if (elementType == 0) {
                    $('' + selectorType + inpuElementArray[i].inputId + 'Header').hide()
                    element.parent().hide();
                } else {
                    element.parent().closest('.form-group').hide();
                }
            }
            if (inpuElementArray[i].IsRequired) {
                if (element.length > 1) {
                    for (var j = 0; j < element.length; j++) {
                        SetRequiredToControl(element[j].id);
                    }
                }
                else {
                    SetRequiredToControl(element);
                }
            }
            else {
                SetNotRequiredToControl(element);
            }
            if (element.val() != undefined) {
                if (inpuElementArray[i].DefaultValue != '') {
                    switch (inpuElementArray[i].inputType.toString().toLowerCase()) {
                        case 'text':
                            if (element.val() == '') {
                                element.val(inpuElementArray[i].DefaultValue);
                            }
                            break;
                        case 'select':
                            if ($("" + selectorType + inpuElementArray[i].inputId + " option[value='" + inpuElementArray[i].DefaultValue + "']").length > 0) {
                                element.val(inpuElementArray[i].DefaultValue);
                            }
                            break;
                        case 'file':
                            break;
                        case 'checkbox':
                            //element.attr('checked', true);
                            break;
                        default:
                            break;
                    }
                }
            }
            if (inpuElementArray[i].HelpText != '') {
                element.attr('title', inpuElementArray[i].HelpText);
            }
            if (inpuElementArray[i].IsReadOnly) {
                element.attr('disabled', true);
            }
        }
        //}
    }
}

function htmlEncode(html) {
    return document.createElement('a').appendChild(
        document.createTextNode(html)).parentNode.innerHTML;
};

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}

function closeOpenAllNodes(jsTree) {
    jsTree.jstree('open_all');
    jsTree.jstree('close_all');
}

String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }

    return s;
}


String.prototype.endsWith = function (suffix) {
    return (this.substr(this.length - suffix.length) === suffix);
}

String.prototype.startsWith = function (prefix) {
    return (this.substr(0, prefix.length) === prefix);
}

function showMessageRequired(item) {

    //$('#controlsRequerid').show();
    var error = ShowMessageRequired(item.parent().attr("data-field-name"));

    if (item.parent()[0].tagName == "TD") {
        var campo = $(item.closest('table').find('th').eq(item.parent().index()).get(0)).attr("aria-label").trim();
        error = ShowMessageRequired(campo);
    }
    if (item.parent().hasClass('date') || item.hasClass('inputMoney')) {
        var error = ShowMessageRequired(item.parent().parent().attr("data-field-name"));
    }
    if ($('#textRequired').text().indexOf(error) < 0)
        $('#textRequired').append(error + " <br>");

}


function checkClientValidate(formSelector) {

    $('#textRequired').empty();
    var elementValid = true;
    $('.' + formSelector + ' .inputClientRequired').each(function () {
        if (this.nodeName.toString().toLowerCase() == 'select') {
            if ($(this).val() == '') {
                $(this).parent().closest('.form-group').addClass('has-error');
                showMessageRequired($(this));
                elementValid = false;
            } else {
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
        else if (this.nodeName.toString().toLowerCase() == 'textarea' && $(this).data('type') == 'ckEditor') {
            if (CKEDITOR.instances[this.name].getData() == '') {
                $(this).parent().closest('.form-group').addClass('has-error');
                showMessageRequired($(this));
                elementValid = false;
            } else {
                $("textarea#" + this.name).val(htmlEncode(CKEDITOR.instances[this.name].getData()));
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
        else if (this.nodeName.toString().toLowerCase() == 'input' && $(this).prop("type") == 'file') {
            if ($(this).val() == '' || $(this).val() == null) {
                var hndFile = '#hdnAttached' + this.name.replace('File', '');
                var hndFileRemoved = '#hdnRemove' + this.name.replace('File', '');
                if ($(hndFile).val() == undefined || $(hndFile).val() == '' || $(hndFileRemoved).val() == '1') {
                    $(this).parent().closest('.form-group').addClass('has-error');
                    showMessageRequired($(this));
                    elementValid = false;
                }
                else {
                    $(this).parent().closest('.form-group').removeClass('has-error');
                }
            }
            else {
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }

        else {
            if ($(this).val() == '' || $(this).val() == null) {
                $(this).parent().closest('.form-group').addClass('has-error');
                showMessageRequired($(this));
                elementValid = false;
            } else {
                //$(this).removeClass('showRequired');
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
    });
    if (elementValid === true)
        $('#controlsRequerid').hide();
    else
        //$('#controlsRequerid').show();

        if (elementValid === true)
            $('#controlsRequerid').hide();
        else
            $('#controlsRequerid').show();

    $('html,body').animate({
        scrollTop: $('#viewmodeledit').offset().top
    }, '4000');
    return elementValid;
}
function dynamicFieldValidation(formSelector) {
    var elementValid = true;
    $('.' + formSelector + ' .inputClientRequired').each(function () {
        if ($(this).css('display') != 'none') {
            if (this.nodeName.toString().toLowerCase() == 'select') {
                if ($(this).val() == '' || $(this).val() == $(this).next().val()) {
                    $(this).addClass('showRequired');
                    $(this).focus();
                    elementValid = false;
                } else {
                    $(this).removeClass('showRequired');
                }
            } else {
                if ($(this).val() == '') {
                    $(this).addClass('showRequired');
                    $(this).focus();
                    elementValid = false;
                } else {
                    $(this).removeClass('showRequired');
                }
            }
        }
    });

    setDynamicRenderElement();
    return elementValid;
}

$('body').on('keydown', '.inputNumber', function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl+A, Command+A
        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right, down, up
        (e.keyCode >= 35 && e.keyCode <= 40)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

function ajaxindicatorstart(text) {
    if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {
        jQuery('body').append('<div id="resultLoading" class="pace pace-active"><div class="bg"><div class="loading-spinner"><div class="sk-spinner sk-spinner-chasing-dots"><div class="sk-dot1"></div><div class="sk-dot2"></div></div></div></div></div>');
    }
    jQuery('#resultLoading').css({
        'width': '100%',
        'height': '100%',
        'position': 'fixed',
        'z-index': '10000000',
        'top': '0',
        'left': '0',
        'right': '0',
        'bottom': '0',
        'margin': 'auto',
        'padding-top': '100'
    });
    jQuery('#resultLoading .bg').css({
        'background': 'rgba(0, 0, 0, .7) none repeat scroll 0 0',
        'width': '100%',
        'height': '100%',
        'position': 'absolute',
        'top': '0',
        'padding-top': '100'
    });
    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeIn(300);
    jQuery('body').css('cursor', 'wait');
}

function ajaxindicatorstop() {
    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeOut(300);
    jQuery('body').css('cursor', 'default');
}

//LOADING
//jQuery(document).ajaxStart(function () {
//    ajaxindicatorstart('loading data.. please wait..');
//}).ajaxStop(function () {
//    //hide ajax indicator
//    ajaxindicatorstop();
//});


function ReplaceFLD(text, rowIndex, nameOfTable) {
    // debugger;
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLD\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        valueOfVar = '';
        nameOfVar = nameOfTable + matches[1] + rowIndex;



        if ($('#' + nameOfVar).is('input:checkbox')) {
            valueOfVar = $('#' + nameOfVar).is(':checked');
        }
        if ($('#' + nameOfVar).is('input:text') || $('#' + nameOfVar).is('input:password') || $('#' + nameOfVar).is('textarea')) {
            valueOfVar = $('#' + nameOfVar).val();
        }
        if ($('#' + nameOfVar).is('select')) {
            valueOfVar = $('#' + nameOfVar).val();
        }
        if ($('#' + nameOfVar).is('input:text') && $('#' + nameOfVar).parent().id == 'datetimepicker1') {
            valueOfVar = $('#' + nameOfVar).datepicker({ dateFormat: 'dd-mm-yy' }).val();
        }
        if ($.trim(valueOfVar) == '' || valueOfVar == undefined) {
            valueOfVar = null;
        }
        if ($('#' + nameOfVar)[0] != null) {
            if ($($('#' + nameOfVar)[0]).hasClass('inputMoney')) {
                if (valueOfVar === null || valueOfVar == "null" || valueOfVar == "") //fjmore inicio
                {
                    valueOfVar = 0;
                }
                else {
                    valueOfVar = valueOfVar.replace(/,/g, '')
                    // valueOfVar = valueOfVar.replace(',', '');
                } //fjmore fin
            }
        }
        text = text.replace(matches[0], valueOfVar);
        text = text.replace("\'null\'", '');
        text = text.replace("\'null\'", "\'\'");
        if (text.indexOf("(,") > 0) {
            text = text.replace('(,', '(');
        }
        matches = regExp.exec(text);
    }
    return text;
}


function ReplaceFLDP(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLDP\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = $('#' + nameOfVar).val();
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceFLDD(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLDD\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = nameOfTable + matches[1] + rowIndex;
        valueOfVar = $.trim($('#' + nameOfVar).text());
        if ($('#' + nameOfVar).is('select')) {
            valueOfVar = $('#' + nameOfVar + ' option:selected').text();
        }
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

//For HTML field
function ReplaceFLDH(text) {
    var regExp = /FLDH\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = CKEDITOR.instances[nameOfVar].getData();
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceGLOBAL(text) {
    var nameOfVar;
    var valueOfVar;
    var regExp = /GLOBAL\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = GetSessionValue(nameOfVar);
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function EvaluaQuery(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQuery",
        type: 'POST',
        cache: false,
        dataType: "json",
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    //return res;
    return TryParseInt(res, res);
}


function DecodifyText(text, rowIndex, nameOfTable) {
    text = ReplaceFLD(text, rowIndex, nameOfTable);
    text = ReplaceFLDD(text, rowIndex, nameOfTable);
    text = ReplaceGLOBAL(text);
    return text;
}


function GetSessionValue(name) {
    var res = '';
    $.ajax({
        url: url_content + "Frontal/General/GetSessionVar?name=" + name,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error buscando variable", "error");
        }
    });
    return res;
}
//fjmore
function ResetSessionValue(valor) {
    var res = '';
    $.ajax({
        url: url_content + "Frontal/General/ResetSessionVar?val=" + valor,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error buscando variable", "error");
        }
    });
    return res;
}

function CreateSessionVar(name, value) {
    value = ReplaceFLD(value);
    value = ReplaceFLDD(value);
    value = ReplaceFLDH(value);

    $.ajax({
        url: url_content + "Frontal/General/AddSessionVar?name=" + name + "&val=" + value,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            return result;
        },
        error: function (result) {
            showNotification("Error creando variable", "error");
        }
    });
}

//TextBox(Texto, Fecha, Hora)
function ShowHideTextbox(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableTextbox(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueTextbox(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).val(result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).val(val);
    }
}

//DropDown
function ShowHideDropdown(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableDropdown(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueDropdown(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).val(result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).val(val);
    }
}
//HTML Editor
function ShowHideHTMLEditor(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableHTMLEditor(idField, trueOrFalse) {
    CKEDITOR.instances['JobDescription'].config.readOnly = !trueOrFalse;
}
function DefaultValueHTMLEditor(idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            CKEDITOR.instances[idField].insertText(result);
        });
    }
    else {
        CKEDITOR.instances[idField].insertText(val);
    }
}
//CheckBox
function ShowHideCheckbox(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableCheckbox(idForm, idField, trueOrFalse) {
    $("form#" + idForm + " #" + idField).prop('disabled', trueOrFalse);
}
function DefaultValueCheckbox(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).prop('checked', result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).prop('checked', val);
    }
}
//AutoComplete
function ShowHideAutocomplete(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableAutocomplete(idForm, idField, trueOrFalse) {
    $("form#" + idForm + " #" + idField).prop('disabled', !trueOrFalse);
}
function DefaultValueAutocomplete(idForm, idField, valId, text/*Aqui deberia ir la query*/, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).append($('<option>', {
                value: valId,
                text: result
            }));
            $("form#" + idForm + " #" + idField).val(valId).trigger("change");
        });
    }
    else {
        $("form#" + idForm + " #" + idField).append($('<option>', {
            value: valId,
            text: text
        }));
        $("form#" + idForm + " #" + idField).val(valId).trigger("change");
    }
}
//RadioButton
function ShowHideRadiobutton(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableRadiobutton(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueRadiobutton(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).filter('[value="' + result + '"]').attr('checked', true);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).filter('[value="' + val + '"]').attr('checked', true);
    }
}

//FileUpload
function ShowHideFileupload(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableFileupload(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField + "File").prop('disabled', disabledOrEmpty);
}
function DefaultValueFileupload(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            getFileNameById(result, function (name) {
                $("form#" + idForm + " #DefaultName" + idField).text('Default: ' + name);
            });
            $("form#" + idForm + " #Default" + idField).val(result);
        });
    }
    else {
        getFileNameById(val, function (name) {
            $("form#" + idForm + " #DefaultName" + idField).text('Default: ' + name);
        });
        $("form#" + idForm + " #Default" + idField).val(val);
    }
}

function getFileNameById(id, callbak) {
    $.ajax({
        url: url_content + "Frontal/General/GetFileNameById?id=" + id,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            return callbak(result);
        },
        error: function (result) {
            showNotification("Error buscando file", "error");
        }
    });
}

//GRID RULES

//Show/Hide es el mismo metodo para cualquier columna
function ShowHideGridColumn(idForm, idField, blockOrNone) {
    $("#" + idForm + " ." + idField + 'Header').css('display', blockOrNone);
}

//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridTextbox(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridCheckbox(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridDropdown(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridAutomcomplete(idForm, idField, trueOrFalse) {
    $("#" + idForm + " ." + idField).prop('disabled', !trueOrFalse);
}

function SetRequiredToControl(element) {
    element = jQuery.type(element) == "string" ? $('#' + element) : element;

    var aterisk = "<i class='fa fa-asterisk fa-asterisk-req' aria-hidden='true'></i>";
    if ($(element.selector + "File").is('input:file'))
        element = $(element.selector + "File");

    element.addClass('inputClientRequired');
    if (element.parent().prev().children('i').length == 0 && element.parent().is("div"))
        element.parent().prev().append(aterisk);

    if ((element.parent().hasClass('date') || element.hasClass('inputMoney')) && !element.parent().is("td"))
        element.parent().parent().prev().append(aterisk);

    if (element.parent().is("td") && element.parent().children('.fa-asterisk').length == 0) {
        element.parent().append(aterisk);
        element.parent().parent().removeClass('nowrap');
        //  element.parent().parent().addClass('nowrap');
    }

}

function SetNotRequiredToControl(element) {
    element = jQuery.type(element) == "string" ? $('#' + element) : element;

    if ($(element.selector + "File").is('input:file'))
        element = $(element.selector + "File");

    if (element.parent().hasClass('date') || element.hasClass('inputMoney'))
        element.parent().parent().prev().children('.fa-asterisk').remove();

    element.removeClass('inputClientRequired');
    element.parent().prev().children('.fa-asterisk').remove();
    element.parent().children('.fa-asterisk').remove();
}


function SendEmail(to, subject, body) {
    to = ReplaceGLOBAL(to);
    subject = ReplaceFLD(subject);
    subject = ReplaceFLDD(subject);
    body = ReplaceFLD(body);
    body = ReplaceFLDD(body);
    body = ReplaceFLDH(body);

    var data = {
        to: to,
        subject: subject,
        body: body
    };
    $.ajax({
        //   url: '/Frontal/Empleados/PostJobHistory?empleadoId=' + employeeId + "&referenceId=" + $("#ReferenceClave").val(),
        url: url_content + "Frontal/General/SendEmail",
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        async: true,
        success: function (result) {

        },
        error: function (result) {
            showNotification("Error enviando correo", "error");
        },
        cache: false,
        contentType: 'application/json; charset=utf-8',
        processData: false
    });
}

function SendEmailQuery(subject, to, body, rowIndex, nameOfTable) {

    subject = ReplaceFLD(subject, rowIndex, nameOfTable);
    subject = ReplaceFLDD(subject, rowIndex, nameOfTable);
    body = ReplaceFLD(body, rowIndex, nameOfTable);
    body = ReplaceFLDD(body, rowIndex, nameOfTable);
    body = ReplaceFLDH(body);
    body = ReplaceGLOBAL(body);

    var data = {
        to: to,
        subject: subject,
        body: body
    };
    $.ajax({
        //   url: '/Frontal/Empleados/PostJobHistory?empleadoId=' + employeeId + "&referenceId=" + $("#ReferenceClave").val(),
        url: url_content + "Frontal/General/SendEmail",
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        async: true,
        success: function (result) {

        },
        error: function (result) {
            showNotification("Error enviando correo", "error");
        },
        cache: false,
        contentType: 'application/json; charset=utf-8',
        processData: false
    });
}


function fillMRFromQuery(nameOfTable, query) {
    var res = '';
    query = ReplaceFLD(query, '', '');
    query = ReplaceFLDD(query, '', '');
    query = ReplaceGLOBAL(query);
    var data = {
        query: query
    }

    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryTable",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            var jsonObj = $.parseJSON(result);
            var table = nameOfTable + 'Table';
            var data = eval(table);
            data.fnClearTable();
            $.each(jsonObj, function (index, element) {
                data.fnAddData(element, true);
                jQuery.globalEval(nameOfTable + 'EditRow(' + index + ', null, false)');
                jQuery.globalEval(nameOfTable + 'InsertRow(' + index + ')');
            });
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}


function EvaluaQueryDictionary(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryDictionary",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}


function EvaluaQueryEnumerable(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryEnumerable",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}
function ReplaceQuery(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);

    return query;
    //return TryParseInt(res, res);
}


function sortSelect(selElem) {

    var valor = selElem.val();
    var my_options = $(selElem.selector + "  option");

    my_options.sort(function (a, b) {
        if (a.text > b.text) return 1;
        if (a.text < b.text) return -1;
        return 0
    })
    selElem.empty().append(my_options);
    selElem.val(valor);
}



function TryParseInt(str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
        if (str.length > 0) {
            if (!isNaN(str)) {
                if (retValue.indexOf('.') >= 0)
                    retValue = parseFloat(str);
                else
                    retValue = parseInt(str);
            }
        }
    }
    if (retValue == "null") {
        retValue = "";
    }
    return retValue;
}

function GetListOfColumns(query) {
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryTable",
        type: 'POST',
        cache: false,
        dataType: "json",
        async: false,
        data: data,
        success: function (result) {
            var jsonObj = $.parseJSON(result);
            res = jsonObj['Root']['Data'];
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}

function RemoveRequiredElementsIntoTab(divName) {
    var selects = $('#tab' + divName).find('select');
    var inputs = $('#tab' + divName).find('input');
    var textareas = $('#tab' + divName).find('textarea');
    selects.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
    inputs.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
    textareas.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
}

function AddRequiredElementsIntoTab(divName) {
    var selects = $('#tab' + divName).find('select');
    var inputs = $('#tab' + divName).find('input');
    var textareas = $('#tab' + divName).find('textarea');
    selects.each(function () {
        if ($(this).hasClass('inputClientRequired-hide')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
    inputs.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
    textareas.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
}

function GetValueByControlType(control, nameOfTable, rowIndex) {
    var valueOfVar = '';
    if (control.is('input:checkbox')) {
        valueOfVar = control.is(':checked');
    }
    if (control.is('input:text') || control.is('textarea')) {
        valueOfVar = control.val();
    }
    if (control.is('select')) {
        valueOfVar = control.val();

    }
    if (control.is('input:text') && control.parent().id == 'datetimepicker1') {
        valueOfVar = control.datepicker({ dateFormat: 'dd-mm-yy' }).val();
    }
    if (control.is('td')) {
        var controlName = control[0].id.replace(nameOfTable, '').replace(rowIndex, '');
        rowIndex = rowIndex.replace('_', '');
        nameOfTable = nameOfTable.slice(0, -1) + 'Table';
        var data = eval(nameOfTable);
        valueOfVar = data.fnGetData(rowIndex)[controlName];
    }
    else if ($(control.selector + "File").is('input:file')) {
        valueOfVar = $(control.selector + "File").val();
    }

    if (control[0] != undefined && $(control[0]).hasClass('inputMoney')) {
        valueOfVar = valueOfVar.replace(',', '');

    }
    var originalName = control.selector.replace('#', '');
    var name = 'hdnAttached' + originalName;
    control = $('#' + name);
    if (control.is('input:hidden')) {
        valueOfVar = control.val();
        if (valueOfVar == '' || valueOfVar == null) {
            control = $('#' + originalName + 'File');
            valueOfVar = control.val();
        }
    }
    //hdnAttachedContrato_Firmado

    return valueOfVar = valueOfVar == null ? null : valueOfVar.toString();
}

function SetDefectValue(control, val) {
    var c = nameOfTable + control + rowIndex;
    if ($('#' + c).is('input:checkbox')) {
        $('#' + c).prop('checked', val == 'true');
    }
    else {
        $('#' + c).val(val);
    }
}

function GetFile(id) {
    var res = {
        id: 0,
        name: '',
        url: ''
    };
    $.ajax({
        url: url_content + "Frontal/General/GetSpartanFile?id=" + id,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            var description = result.Description;
            var id = result.File_Id;
            var url = url_content + 'Frontal/Client_Registration/GetFile?id=' + id;
            res.id = id;
            res.name = description;
            res.url = url;
        },
        error: function (result) {
            showNotification("Error obteniendo File", "error");
        }
    });
    return res;
}

function AsignarValor(nameOfControl, val) {
    var control = jQuery.type(nameOfControl) == "string" ? $('#' + nameOfControl) : nameOfControl;
    nameOfControl = jQuery.type(nameOfControl) == "string" ? nameOfControl : control.selector;

    var controlFile = $(nameOfControl + "File")
    if (controlFile.length) {
        var file = GetFile(val)
        if ($('#' + nameOfControl).length) {
            $('#' + nameOfControl).val(587);
        }
        else {
            controlFile.parent().append('<input type="hidden" id="' + nameOfControl + '" name="' + nameOfControl + '" value="' + file.id + '" />')
        }
        controlFile.parent().append('<a href="' + file.url + '">' + file.name + '</a>');
    }
    else {
        if (control.is('input:checkbox')) {
            var arrayTrue = ["true", "si", "yes", "1", "verdadero"]; var value = val.toString().toLowerCase().replace('"', ''); control.prop('checked', arrayTrue.indexOf(value) > -1).trigger('change');
        }
        if (control.is('input:text') || control.is('textarea')) {
            control.val(val);
        }
        if (control.is('select') && !control.hasClass('AutoComplete')) {
            control.val(val).trigger('change');
        }
        if (control.hasClass('AutoComplete')) {

            control.select2('open');
            $('.select2-search__field').val(val).trigger('keyup');
            control.select2('close');
            var data = eval('AutoComplete' + control.selector.replace(nameOfTable, '').replace(rowIndex, '').replace('#', '') + 'Data');
            control.select2({ data: data });
            setTimeout(function () {
                var data = eval('AutoComplete' + control.selector.replace('#', '') + 'Data');
                control.select2({ data: data });
                $.each(data, function (key, value) {
                    if (value.text == val)
                        control.val(value.id).trigger('change');
                });
            }, 2000);
			/*control.select2('open');
			 $('.select2-search__field').val('Ad').trigger('keyup');	
			 control.select2('close'); 
			
			 setTimeout(function () {
						   var data = eval('AutoComplete' + control.selector.replace(nameOfTable, '').replace(rowIndex, '').replace('#', '') + 'Data');		
					
						control.select2({ data: data });
						 $.each( data, function( key, value ) {
						 if (value.text == val) 
						control.val(value.id).trigger('change');
						 });		
				
				
                }, 2000);*/

        }
    }
}

function AsignarValor2(nameOfControl, val) {
    var control = jQuery.type(nameOfControl) == "string" ? $('#' + nameOfControl) : nameOfControl;
    nameOfControl = jQuery.type(nameOfControl) == "string" ? nameOfControl : control.selector;

    var controlFile = $(nameOfControl + "File")
    if (controlFile.length) {
        var file = GetFile(val)
        if ($('#' + nameOfControl).length) {
            $('#' + nameOfControl).val(587);
        }
        else {
            controlFile.parent().append('<input type="hidden" id="' + nameOfControl + '" name="' + nameOfControl + '" value="' + file.id + '" />')
        }
        controlFile.parent().append('<a href="' + file.url + '">' + file.name + '</a>');
    }
    else {
        if (control.is('input:checkbox')) {
            var arrayTrue = ["true", "si", "yes", "1", "verdadero"]; var value = val.toString().toLowerCase().replace('"', ''); control.prop('checked', arrayTrue.indexOf(value) > -1).trigger('change');
        }
        if (control.is('input:text') || control.is('textarea')) {
            control.val(val);
        }
        if (control.is('select') && !control.hasClass('AutoComplete')) {
            control.val(val).trigger('change');
        }
        if (control.hasClass('AutoComplete')) {

            control.select2('open');
            $('.select2-search__field').val(val).trigger('keyup');
            control.select2('close');
            var data =  eval("AutoCompleteusuario_que_realiza_observacionData");
            control.select2({ data: data });
            setTimeout(function () {
                var data = eval("AutoCompleteusuario_que_realiza_observacionData");
                control.select2({ data: data });
                $.each(data, function (key, value) {
                    if (value.text == val)
                        control.val(value.id).trigger('change');
                });
            }, 2000);
			/*control.select2('open');
			 $('.select2-search__field').val('Ad').trigger('keyup');	
			 control.select2('close'); 
			
			 setTimeout(function () {
						   var data = eval('AutoComplete' + control.selector.replace(nameOfTable, '').replace(rowIndex, '').replace('#', '') + 'Data');		
					
						control.select2({ data: data });
						 $.each( data, function( key, value ) {
						 if (value.text == val) 
						control.val(value.id).trigger('change');
						 });		
				
				
                }, 2000);*/

        }
    }
}



function EvaluaOperatorIn(parameter1, parameter2) {
    debugger;
    var arr = parameter2.split(',');
    var result = false;
    for (var i = 0; i < arr.length; i++) {
        if (TryParseInt(parameter1, parameter1) === TryParseInt(arr[i], arr[i])) {
            result = true;
            break;
        }
    }
    return result;
}


function formatAmmount(Ammount) {
    return Ammount != null && Ammount != undefined ? Ammount.toString().replace('$', '').replace(',', '') : 0;
}


//This will sort your array
function SortByName(a, b) {
    var aName = a.name.toLowerCase();
    var bName = b.name.toLowerCase();
    return ((aName < bName) ? -1 : ((aName > bName) ? 1 : 0));
}


function DisabledControl(Control, disabled) {
    var controlFile = Control.selector + "File";
    if ($(controlFile).length > 0) {
        Control = controlFile;
    }

    if ($(this).data('type') == 'ckEditor') {
        CKEDITOR.instances['TEXTAREA_NAME'].setReadOnly(disabled);
        return;
    }
    disabled ? $(Control).prop("disabled", "disabled") : $(Control).removeAttr("disabled");
}



function filterCombo(control, dictionary) {
    var isMultiseleccion = false;

    if ($("#ddl" + control.selector.replace("#", "") + "Mult") != 'undefined' && $("#ddl" + control.selector.replace("#", "") + "Mult").is('select')) {
        control = $("#ddl" + control.selector.replace("#", "") + "Mult");
        isMultiseleccion = true;
    }
    var valor = $(control).val();
    $(control).empty();
    if (!$(control).hasClass('AutoComplete')) {
        $(control).append($("<option selected />").val("").text(""));
        $.each(dictionary, function (index, value) {
            $(control).append($("<option />").val(value.Clave).text(value.Description));
        });
        $(control).val(valor);
    }
    else {
        var selectData = []; selectData.push({ id: "", text: "" });
        $.each(dictionary, function (index, value) {
            selectData.push({ id: value.Clave, text: value.Description });
        });
        $(control).select2({ data: selectData })
        $(control).val(valor).trigger('change');
    }
    if (isMultiseleccion) {
        $(control).trigger('chosen:updated');
    }
}


function addItemsToSelect(control, items) {
    control.empty();
    $(control).append($('<option />', { value: '', text: '' }));
    $.each(items, function (i, item) {
        $(control).append($('<option>', {
            value: item.Value,
            text: item.Text
        }));
    });
}

function addNew(nameMR, catalog, nameAttr, objectId) {
    /*if (objectId && GetRoleObjectPermision(objectId)) {
        return "<div class='abm-icons' style='display:inline-block; padding-left:10px;'>" +
                       "<a id='Estado_New' onclick='GetCatalogPopup(\"" + catalog + "\",  \"" + nameAttr + "\", true,  \"" + nameMR + "\");' href='#'><i class='glyphicon glyphicon-plus'></i></a>" +
                     "</div>";
    } else {*/
    return "";
    //}
}



function GetRoleObjectPermision(objectId) {
    var res = false;
    $.ajax({
        url: url_content + "Frontal/General/GetRoleObjectPermision?objectId=" + objectId,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ", "error");
        }
    });
    return res;
}

function isInt(n) {
    return +n === n && !(n % 1);
}

function resizeIframe(obj) {
    obj.style.height = obj.contentWindow.document.documentElement.scrollHeight + 'px';
}

function showObject(label, objetoUrl, value) {

    $(".tabs-container ul").append("<li><a data-toggle='tab' href='#tab" + objetoUrl + "' >" + label + "</a></li>");

    $('.tab-content').append('<div class="tab-pane" id="tab' + objetoUrl + '"><div class="panel-body-' + objetoUrl + '"></div>');


    $(".panel-body-" + objetoUrl).html("<iframe width='850' height='800' style='background: #FFFFFF !important;' resizeIframe(this) frameborder='0' scrolling='no' marginheight='0' marginwidth='0' src='" + location.origin + url_content + "/Frontal/" + objetoUrl + "/Create?Id=" + value + "&viewInEframe=True&nameAttribute=" + objetoUrl + "'><iframe>");

}



//fjmore
var ObjectIdTemp;
var RolUsuarioTemp;
var DocumentoIdTemp;
var iseditTemp;
var ObjectIdFilterTemp;
function OpenPrintFormats(ObjectId, RolUsuario, query, isedit, ObjectIdFilter, formatoID) {
    debugger;
    ResetSessionValue("");
    var DocumentoId = EvaluaQuery(query);
    iseditTemp = isedit;
    ObjectIdTemp = ObjectId == "" ? "0" : ObjectId;
    DocumentoIdTemp = DocumentoId;
    RolUsuarioTemp = RolUsuario;
    ObjectIdFilterTemp = ObjectIdFilter;

    if (isedit) {
        var url = url_content + "Frontal/Control_de_Documentos/Create?id=" + ObjectId + "&Module_Id=1&isPartial=true&nameAttribute=AttributoNombre"; // "@Url.Action("Create", "Catalog", new { Module_Id = "1", isPartial = true, nameAttribute = "AttributoNombre" })";
        var params = [
            'height=' + screen.height,
            'width=' + screen.width,
            'fullscreen=yes' // only works in IE, but here for completeness
        ].join(',');
        timerInterval1 = setInterval('ReadSesionVar()', 1000);
        window.open(url, '_blank', params);

    }
    else {
        var guid = GetHtmlAsString(formatoID, ObjectIdTemp);
        GetCatalogPopupTest(guid, iseditTemp, ObjectIdTemp);
    }


}



var timerInterval1;
function GetCatalogPopupTest(guid, isedit, ObjectIdTemp) {
    debugger;
    var url = "";
    if (!isedit) {
        url = url_content + "Frontal/Control_de_Documentos/Create?Module_Id=1&isPartial=true&nameAttribute=AttributoNombre&guid=" + guid + "&isCallFromCatalogoPopupTest=TRUE"; // "@Url.Action("Create", "Catalog", new { Module_Id = "1", isPartial = true, nameAttribute = "AttributoNombre" })";

    }
    else {
        url = url_content + "Frontal/Control_de_Documentos/Create?id=" + ObjectIdTemp + "&Module_Id=1&isPartial=true&nameAttribute=AttributoNombre&guid=" + guid + "&isCallFromCatalogoPopupTest=TRUE"; // "@Url.Action("Create", "Catalog", new { Module_Id = "1", isPartial = true, nameAttribute = "AttributoNombre" })";

    }

    var params = [
        'height=' + screen.height,
        'width=' + screen.width,
        'fullscreen=yes' // only works in IE, but here for completeness
    ].join(',');

    timerInterval1 = setInterval('ReadSesionVar()', 1000);

    window.open(url, '_blank', params);
}

function utf8_to_b64(str) {
    return window.btoa(unescape(encodeURIComponent(str)));
}

function ReadSesionVar() {
   


    var data = localStorage.getItem('controlDocumentoDynamiSeach');
    if (data != "true" ) {
        controlDocumentoDynamiSeach = false; 
        localStorage.setItem('controlDocumentoDynamiSeach', "");
    }
  
    var FolioControlDocumentos = GetSessionValue("KeyValueInserted");
    if (FolioControlDocumentos != "-1" && FolioControlDocumentos != "") {

        clearInterval(timerInterval1);
        permitirCerrar = true;
        GeneratePDFFromControlDocumentos(FolioControlDocumentos);
    }
}


function GetHtmlAsString(idFormat, RecordId) {
    debugger;
    var res;
    $.ajax({
        url: url_content + "Frontal/Spartan_Format/GetHtmlAsString?idFormat=" + idFormat + "&RecordId=" + RecordId,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            res = result;
        },
        error: function (result) {
            debugger;
            showNotification("Error GetHtmlAsString", "error");
        }
    });
    //return res;
    return res;
}

function ShowMessageRequired(field) {

    if (typeof (field) != "undefined") {
        return "El campo " + field + " es requerido";
    }
    else {
        return "";
    }
}

function GeneratePDFFromControlDocumentos(FolioControlDocumentos) {
    debugger;
    var res;
    $.ajax({
        url: url_content + "Frontal/Spartan_Format/GeneratePDFFromControlDocumentos?FolioControlDocumentos=" + FolioControlDocumentos,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {

            res = result;
            var spartanfileId = "";
            var FolioControlDocumentos = "";
            var spl = res.split('*');
            if (spl != null && spl[2] != null && spl[2] != "") {

                var dileid = spl[2].split('=');
                if (dileid != null && dileid[1] != null && dileid[1] != "") {
                    //spartanfileId = dileid[0];
                    FolioControlDocumentos = dileid[1];
                    $("#Archivo").val(FolioControlDocumentos);
                    $("#Archivo_VerDocto").removeClass("hidden");

                    var upd = EvaluaQuery("update detalle_de_documentos set Archivo = " + FolioControlDocumentos + " where clave=" + $("#ReferenceClave").text());
                }


            }
        },
        error: function (result) {
            debugger;
            showNotification(result, "error");
        }
    });
    //return res;
    return res;
}

function HasValidaPersmisoX(objSelected, role, function_Id) {

    var resulttado = EvaluaQueryDictionary(" usp_ValidaPersmiso  '" + objSelected + "'," + role + "," + function_Id);

    if (Object.keys(resulttado).length > 0) {
        return true;
    }
    else {
        return false;
    }


}
//fjmore
function GetSpartanFileAndPost(SpartanFileId) {
    debugger;
    var res = -1;
    $.ajax({
        url: url_content + "Frontal/General/GetSpartanFileAndPost?SpartanFileId=" + SpartanFileId,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            var sp = result.split('_');
            if (sp != null && sp[1] != null) {
                res = parseInt(sp[1]);
            }
           
        },
        error: function (result) {
            debugger;
            showNotification("Error obteniendo File", "error");
        }
    });
    return res;
}
function GetAllTableSQL( query) {
    var res = null;
    query = ReplaceFLD(query, '', '');
    query = ReplaceFLDD(query, '', '');
    query = ReplaceGLOBAL(query);
    var data = {
        query: query
    };

    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryTable",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
           
            var jsonObj = $.parseJSON(result);
            
            res = jsonObj;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}
$(".glyphicon-new-window").parent().hide();