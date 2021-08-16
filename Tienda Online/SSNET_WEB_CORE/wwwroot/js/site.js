function ShowWaitAlert(msg_title, msg_body) {
    Swal.fire({
        title: msg_title,
        html: msg_body,
        allowEscapeKey: false,
        allowOutsideClick: false,
        didOpen: () => {
            Swal.showLoading()
        }
    });
}

function ShowErrorAlert(msg_title, msg_body, msg_footer) {
    Swal.fire({
        icon: 'error',
        title: msg_title,
        text: msg_body,
        footer: msg_footer
    })
}

function ShowSuccesAlert(msg_title, msg_body, msg_footer, show_buton) {
    Swal.fire({
        icon: 'success',
        title: msg_title,
        text: msg_body,
        footer: msg_footer,
        showConfirmButton: show_buton,
    })
}

function add_item(id_modelo) {
    ShowWaitAlert('Por favor espere...', 'Agregando objeto a carrito');
    $.ajax({
        url: '/Main/AgregarProductoToCarrito?Id_Model=' + id_modelo,
        type: 'POST',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (data) {
            ShowErrorAlert('¡Error!', 'Ha ocurrido un error. Avisar a Sistemas.', '');
        },
        success: function (data) {
            var cant_act = parseInt($('.cantidad-' + id_modelo).val());
            $('.cantidad-' + id_modelo).val(cant_act + 1);
            $('.total').text("$"+data.total);
        }
    });
    swal.close();
}

function remove_item(id_modelo) {
    var cant_act = parseInt($('.cantidad-' + id_modelo).val());
    if (cant_act > 0) {
        ShowWaitAlert('Por favor espere...', 'Quitando objeto de carrito');
        $.ajax({
            url: '/Main/RemoveProductoFromCarrito?Id_Model=' + id_modelo,
            type: 'POST',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            error: function (data) {
                ShowErrorAlert('¡Error!', 'Ha ocurrido un error. Avisar a Sistemas.', '');
            },
            success: function (data) {
                $('.cantidad-' + id_modelo).val(cant_act - 1);
                $('.total').text("$" + data.total);
            }
        });
        swal.close();
    }
}

function remove_from_cart(id_item) {
    ShowWaitAlert('Por favor espere...', 'Quitando objeto de carrito');
    $.ajax({
        url: "/Main/DeleteFromCarrito?Id_Model=" + id_item,
        type: 'POST',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        error: function (data) {
            ShowErrorAlert('¡Error!', 'Ha ocurrido un error. Avisar a Sistemas.', '');
        },
        success: function (data) {
            $('.product-' + id_item).hide(750);
            $('.product-' + id_item).remove();
        }
    });
    swal.close();
}