//#region Validaciones dinamicas
function ocultarValidaciones(modal) {
    let inputs = $(modal).find('input');

    for (const input of inputs) {
        if (input.name != '__RequestVerificationToken') {
            $(`${modal} #val-${input.name}`).hide(); // Ocultar el mensaje de error de cada input
            $(input).parent().removeClass('has-error'); // Remover error del div
            $(input).val('');
        }
    }
}
function ocultarValidacionesPantallaCompleta(form) {
    let inputs = $(form).find('input');

    for (const input of inputs) {
        if (input.name != '__RequestVerificationToken') {
            $(`${form} #val-${input.name}`).hide(); // Ocultar el mensaje de error de cada input
            $(input).parent().removeClass('has-error'); // Remover error del div
            $(input).val('');
        }
    }
}

// Esta validacion es solamente para los modales
function camposRequeridos(campos, mensaje) {
    var validacion = true;

    let camposError = new Array();
    let i = 0;
    for (const campo of campos) {
        i++;

        let campoVal = campo.val();
        const campoError = $(campo).parent().find(`#val-${campo[0].name}`); // nombre del campo

        if (campoVal == '') {
            $(campo).parent().addClass('has-error')

            camposError.push(campo);
            campoError.html(mensaje[i - 1])
            campoError.show();
            validacion = false;
            campoError.show();

            campo.on('keyup keypress change blur', function (val) {
                // Obtener valores
                var esteCampo = $(this);
                let valorKeyup = $(this).val();

                if (valorKeyup.trim() == '') {
                    esteCampo.parent().addClass('has-error');
                    esteCampo.parent().addClass('has-error')
                    campoError.show();
                } else {
                    esteCampo.parent().removeClass('has-error');
                    esteCampo.parent().removeClass('has-error')
                    campoError.hide();
                    campo.parent().removeClass('has-error');
                }
            });
        } else {
            campo.parent().removeClass('has-error');
            campoError.hide();
        }
    }

    if (camposError.length > 0) {
        camposError[0].focus();
    }
    return validacion
}

function camposRequeridosPantallaCompleta(campos, mensaje) {
    var validacion = true;

    let camposError = new Array();
    let i = 0;
    for (const campo of campos) {
        i++;

        let campoVal = campo.val();
        const campoError = $(campo).parent().find(`#val-${campo[0].name}`); // nombre del campo

        const label = $(campoError).parent().parent().parent().find('label:first').html()

        if (campoVal == '') {
            $(campo).parent().parent().addClass('has-error')

            camposError.push(campo);
            campoError.html(mensajesError.requerido(label))
            campoError.show();
            validacion = false;
            campoError.show();

            campo.on('keyup keypress change blur', function (val) {
                // Obtener valores
                var esteCampo = $(this);
                let valorKeyup = $(this).val();

                if (valorKeyup.trim() == '') {
                    esteCampo.parent().parent().addClass('has-error');
                    esteCampo.parent().parent().addClass('has-error')
                    campoError.show();
                } else {
                    esteCampo.parent().parent().removeClass('has-error');
                    esteCampo.parent().parent().removeClass('has-error')
                    campoError.hide();
                    campo.parent().parent().removeClass('has-error');
                }
            });

        } else {
            campo.parent().parent().removeClass('has-error');
            campoError.hide();
        }
    }

    if (camposError.length > 0) {
        camposError[0].focus();
    }
    return validacion
}

function imagenRequerida(campo) {
    var validacion = true;
    let campoVal = campo.val();
    const campoError = $(campo).parent().parent().parent().find(`#val-${campo[0].name}`); // nombre del campo

    if (campoVal == '') {
        $(campo).parent().parent().parent().addClass('has-error')

        campoError.html(mensajesError.requerido($(campoError).parent().parent().find('label:first').html()))
        campoError.show();
        validacion = false;
        campoError.show();

        campo.change(function (val) {
            // Obtener valores
            var esteCampo = $(this);
            let valorKeyup = $(this).val();

            if (valorKeyup.trim() == '') {
                esteCampo.parent().parent().parent().addClass('has-error');
                esteCampo.parent().parent().parent().addClass('has-error')
                campoError.show();
            } else {
                esteCampo.parent().parent().parent().removeClass('has-error');
                esteCampo.parent().parent().parent().removeClass('has-error')
                campoError.hide();
                campo.parent().parent().parent().removeClass('has-error');
            }
        });
    } else {
        campo.parent().parent().parent().removeClass('has-error');
        campoError.hide();
    }
    return validacion;
}
//#endregion

function objetoAjaxDataTables(url) {
    return {
        //Hacer la peticion asíncrona y obtener los datos que se mostraran en el datatable
        method: 'GET',
        url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json'
    }
}

function money(clase, unit, delimiter, separator) {
    VMasker($(`.${clase}`)).maskMoney({ unit, delimiter, separator });
}

// retorna el valor del input mask money en decimal
var toDecimal = (array, field) => array.map((val, i) => {
    if (val.name === field) {
        return {
            ...val,
            value: VMasker.toMoney(val.value, { delimiter: ',', separator: '.' }).replace(/,/g, '')
        }
    }
    return val;
});

// se usa indicando el modal al que pertenece, y el numero de input
function primerCampoFocus(modal, id) {
    setTimeout(() => {
        $(modal).find('input')[id - 1].focus();
    }, 500);
}

//#region Botones
const botonDetalles = '<button type="button" id="btnDetalles" class="btn btn-secondary">Detalles</button>';
const botonEditar = '<button type="button" id="btnEditar" class="btn btn-success">Editar</button>';
const botonEliminar = '<button type="button" id="btnEliminar" class="btn btn-danger">Eliminar</button>';
const botonActivar = '<button type="button" id="btnActivar" class="btn btn-success">Activar</button>';
//#endregion

var traduccion = {
    sProcessing: 'Procesado...',
    sLengthMenu: 'Mostrar _MENU_ registros',
    sZeroRecords: 'No se encontraron resultados',
    sEmptyTable: 'No hay datos para mostrar.',
    sInfo: 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros',
    sInfoEmpty: 'Mostrando registros del 0 al 0 de un total de 0 registros',
    sInfoFiltered: '(filtrado de un total de _MAX_ registros)',
    sInfoPostFix: '',
    sSearch: 'Buscar:',
    sUrl: '',
    sInfoThousands: ',',
    sLoadingRecords: 'Cargando...',
    oPaginate: {
        sFirst: 'Primero',
        sLast: 'Último',
        sNext: 'Siguiente',
        sPrevious: 'Anterior'
    },
    oAria: {
        sSortAscending: ': Activar para ordenar la columna de manera ascendente',
        sSortDescending: ': Activar para ordenar la columna de manera descendente'
    }
}

//#region IziToast
async function success(mensaje) {
    await iziToast.success({
        title: 'Éxito',
        message: mensaje
    });
}

async function error(mensaje) {
    await iziToast.error({
        title: 'Error',
        message: mensaje
    });
}

//#endregion

//#region Peticiones backend Get y Post
async function get(url, datos, err) {
    try {
        await $.get(url, (data) => {
            datos(data);
        });
    } catch (error) {
        err(error);
    }
}

async function post(url, datos, retorno, error) {
    try {
        await $.post(url, datos, (data) => {
            retorno(data);
        });
    } catch (err) {
        error(err);
    }
}
//#endregion

var mensaje = {
    //Insersión
    insertado: '¡El registro se agregó de forma exitosa!',
    falloInsersion: 'No se guardó el registro, contacte al administrador',

    //Inactivación
    inactivado: '¡El registro se inactivó de forma exitosa!',
    falloInactivacion: 'No se inactivó el registro, contacte al administrador',

    //Permisos
    permisos: 'No tienes permisos para realizar esta acción',

    //Activación
    activado: '¡El registro se activó de forma exitosa!',
    falloActivacion: 'No se activó el registro, contacte al administrador',

    //Edición
    editado: '¡El registro se editó de forma exitosa!',
    falloEdicion: 'No se editó el registro, contacte al administrador'
}

var mensajesError = {
    requerido: (campo) => {
        return `El campo ${campo} es obligatorio.`
    }
}

async function submit(form) {
    $(form).submit(ev => false);
}

function disabled(boton, estado) {
    if (estado) {
        boton.disabled = estado
    } else {
        setTimeout(() => boton.disabled = estado, 1000);
    }
}

//#region Constantes

const bien = 'bien',
    activo = `
    ${botonEditar}
    ${botonDetalles}
    ${botonEliminar}
    `,
    inactivo = `
    ${botonEditar}
    ${botonDetalles}
    ${botonActivar}
    `,
    modalEditar = '#ModalEditar',
    modalConfirmarEditar = '#ModalConfirmarEditar',
    modalCrear = '#ModalCrear',
    modalHabilitar = '#Modalhabilitar',
    modalDetalles = '#modalDetalles',
    modalInHabilitar = '#ModalInhabilitar',
    modalConfirmarInHabilitar = '#ModalConfirmarInhabilitar',
    btnCerrarModal = '#btnCerrarModal'
    ;
//#endregion
var table;

async function mostrarModal(modal) {
    await $(modal).modal({
        backdrop: 'static',
        keyboard: false
    });
}

async function ocultarModal(modal) {
    await $(modal).modal('hide');
}
