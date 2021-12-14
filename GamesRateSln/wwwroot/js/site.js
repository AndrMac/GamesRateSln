// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function refreshDashboards() {
    $.get("Home\\GetRatesSummary", function (result) {
        var labels = [];
        var data = [];
        $.each(result, function (i, field) {
            labels.push(field.rate);
            data.push(field.ratesCount);
        });
        chartWidget(labels, data);
    });

    topGames("top-high-game-tbl", false)
    topGames("top-low-game-tbl", true)
}

function showListArea() {
    $("#results-area").hide();
    $("#main-game-tbl-area").show();
}

$(function () {
    $("#main-game-tbl-area").hide();
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
                data: "avrRate",
                title: "Average Rating"
            },
            {
                data: "id",
                render: function (data, type, row) {
                    return '<a class="btn btn-primary" href="Home\\AddRate\\' + data + '">Rate</button>';
                }
            },
        ]
    });

    $('#recent-rates-tbl').DataTable({
        bSort: false,
        paging: false,
        searching: false,
        ajax: {
            url: 'Home\\GetTop20RecentRatesList',
            dataSrc: ''
        },
        fixedHeader: true,
        columns: [
            {
                data: "gameTitle",
                title: "Game Title",
            },
            {
                data: "personName",
                title: "Name"
            },
            {
                data: "personEmail",
                title: "Email"
            },
            {
                data: "comment",
                title: "Comment"
            },
            {
                data: "value",
                title: "Rate"
            }
        ]
    });

    refreshDashboards();

    $("#list-btn").on("click", function () {
        showListArea();
    });

});