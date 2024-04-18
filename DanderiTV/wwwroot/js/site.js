// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//function changeMode() {
//    var isChecked = document.getElementById("flexSwitchCheckDefault").checked;

//    // Realizar una solicitud AJAX para llamar al método en el controlador
//    $.ajax({
//        url: '/Home/ChangeViewMode',
//        type: 'POST',
//        data: { isChecked: isChecked },
//        success: function (response) {
//            // Manejar la respuesta del controlador si es necesario
//        },
//        error: function (error) {
//            // Manejar el error si ocurre
//        }
//    });
//}

function changeMode() {
    var isChecked = document.getElementById("flexSwitchCheckDefault").checked;

    // Realizar una solicitud AJAX para llamar al método en el controlador
    $.ajax({
        url: '/Home/ChangeViewMode',
        type: 'POST',
        data: { isChecked: isChecked },
        success: function (response) {
            // Obtiene la URL de la respuesta
            var url = response.url;

            // Redirige a la nueva URL
            window.location.href = url;
        },
        error: function (error) {
            // Manejar el error si ocurre
        }
    });
}



