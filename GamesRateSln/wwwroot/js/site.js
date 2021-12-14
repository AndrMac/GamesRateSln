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
        },
        {
            data: "year",
            title: "Year"
        },
        {
            data: "id",
            render: function (data, type, row) {
                return '<button class="btn btn-primary" onclick="showRateWindow('+data+');">Rate</button>';
            }
        },
    ]
});

var labels = ["label 1", "label 2", "label 3", "label 4", "label 5", "label 6", "label 7", "label 8", "label 9"];
var data = [794, 458, 169, 103, 85, 75, 44, 33, 22];
var ctx = document.getElementById("doughnutChart").getContext("2d");
chartWidget(labels, data, ctx, "legend");


$("#submit-rate").on("click", function () {
    $("#rate-form").submit();
});

function showRateWindow(id) {
        
    $("#modal-data").load("Home\\AddRate\\"+id, function () {
        $("#rate-modal").modal('show');
    });
}