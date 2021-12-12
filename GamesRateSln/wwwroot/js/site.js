// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#main-game-tbl').DataTable({
    ajax: {
        url: 'Home\\GetGamesList',
        dataSrc: ''
    },
    fixedHeader: true,
    columns: [
        {
            data: "title",
            title: "Title",
            float:"left"
        },
        {
            data: "year",
            title: "Year"
        },
    ]
});