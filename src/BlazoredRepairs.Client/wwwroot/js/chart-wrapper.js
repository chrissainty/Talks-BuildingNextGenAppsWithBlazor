window.blazoredRepairs = {

    buildChart: (element, type, data) => {
        var chart = new Chart(element, {
            type: type,
            data: data,
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true,
                            stepSize: 1
                        }
                    }]
                }
            }
        });
    }

};