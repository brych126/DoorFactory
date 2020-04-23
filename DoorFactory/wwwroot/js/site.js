// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#dtBasicExample').DataTable({
        'language': {
            'url': "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Ukrainian.json"
        }
    });
    $('.dataTables_length').addClass('bs-select');
});
