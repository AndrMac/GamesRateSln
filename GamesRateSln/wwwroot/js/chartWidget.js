function chartWidget(labelsArray, dataArray, ctx, legendId) {
    var colors = [
        'rgb(70, 191, 189)',
        'rgb(252, 180, 92)',
        'rgb(247, 70, 74)',
        'rgb(148, 159, 177)',
        'rgb(51, 143, 82)',
        'rgb(77, 83, 96)',
        'rgb(180, 142, 173)',
        'rgb(150, 181, 180)',
        'rgb(235, 203, 138)',
        'rgb(94, 65, 149)',
        /*'rgb(171, 121, 103)',
        'rgb(134, 175, 18)'*/
    ];
    var labels = labelsArray;
    var data = dataArray;
    var bgColor = colors;
    var dataChart = {
        labels: labels,
        datasets: [{
            data: data,
            backgroundColor: bgColor
        }]
    };
    var config = {
        type: 'doughnut',
        data: dataChart,
        options: {
            maintainAspectRatio: false,
            cutoutPercentage: 45,
            legend: {
                display: false
            },
            legendCallback: function (chart) {
                var text = [];
                text.push('<ul class="doughnut-legend">');
                if (chart.data.datasets.length) {
                    for (var i = 0; i < chart.data.datasets[0].data.length; ++i) {
                        text.push('<li><span class="doughnut-legend-icon" style="background-color:' + chart.data.datasets[0].backgroundColor[i] + '"></span>');
                        if (chart.data.labels[i]) {
                            text.push('<span class="doughnut-legend-text">' + chart.data.labels[i] + '</span>');
                        }
                        text.push('</li>');
                    }
                }
                text.push('</ul>');
                return text.join("");
            },
            tooltips: {
                yPadding: 10,
                callbacks: {
                    label: function (tooltipItem, data) {
                        var total = 0;
                        data.datasets[tooltipItem.datasetIndex].data.forEach(function (element /*, index, array*/) {
                            total += element;
                        });
                        var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        var percentTxt = Math.round(value / total * 100);
                        return data.labels[tooltipItem.index] + ': ' + data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index] + ' (' + percentTxt + '%)';
                    }
                }
            }
        }
    };
    var ctx = document.getElementById("doughnutChart").getContext("2d");
    var doughnutChart = new Chart(ctx, config);
}