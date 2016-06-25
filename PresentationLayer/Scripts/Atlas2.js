/// Variable global para cargar la Oficina
var g_game;

function routeDir(path) {
    return configuration.siteUrl + g_game + "/" + path;
}

//funcion para los botones SI/NO
$('.btn-toggle').click(function () {
    $(this).find('.btn').toggleClass('active');
    if ($(this).find('.btn-primary').size() > 0) {
        $(this).find('.btn').toggleClass('btn-primary');
    }
    if ($(this).find('.btn-danger').size() > 0) {
        $(this).find('.btn').toggleClass('btn-danger');
    }
    if ($(this).find('.btn-success').size() > 0) {
        $(this).find('.btn').toggleClass('btn-success');
    }
    if ($(this).find('.btn-info').size() > 0) {
        $(this).find('.btn').toggleClass('btn-info');
    }
    $(this).find('.btn').toggleClass('btn-default');
});

function EspecificacionActivo() {

    var estadoanterior = $('#btnActive .active').attr('data-value');
    if (estadoanterior == 'true') {
        $('#b_Active').val('false');
        console.log('b_Active false');


    } else {
        $('#b_Active').val('true');
        console.log('b_Active true');

    }
};

//Obtiene el valor de un parametro en una url
function getQueryVariable(variable) {
    if (variable == null || variable == undefined)
        return (false);

    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == null)
            continue;
        if (pair[0].toUpperCase() == variable.toUpperCase()) { return pair[1]; }
    }
    return (false);
}

/// Selecciona una opción de un "select" sin tener en cuenta mayúsculas/minúsculas.
function SelectComboOption(comboId, option) {
    if (option == null || option == undefined)
        return;
    option = option.toUpperCase();
    $("#" + comboId).find("option").each(function (index, element) {
        if ($(element).val() != null) {
            if ($(element).val().toUpperCase() == option) {
                $(element).prop("selected", true);
                return false;
            }
        }
    });
}