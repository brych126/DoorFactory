// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.dtDoorTables').DataTable({
        'language': {
            'url': "https://cdn.datatables.net/plug-ins/1.10.20/i18n/Ukrainian.json"
        }
    });
    $('.dataTables_length').addClass('bs-select');

    $("#Home").click(function () {
        $("#homeSubmenu").toggle();
    });

    $("#sidebar").mCustomScrollbar({
        theme: "minimal"
    });

    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
    $('[data-toggle="tooltip"]').tooltip();
});
