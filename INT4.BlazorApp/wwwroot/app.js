


window.mostraIstogramma = (frequenze) => {
    const ctx = document.getElementById("dadiChart");

    if (window.barChart !== null && window.barChart !== undefined) {
        window.barChart.destroy();
    }

    const data = {
        labels: ["1", "2", "3", "4", "5", "6"],
        datasets: [
            {
                label: 'Frequenza',
                data: frequenze,
                backgroundColor: '#fff',
                borderWidth: 2,
                borderRadius: 12,
                borderSkipped: false,
            }
        ]
    }

    const config = {
        type: 'bar',
        data: data,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                    display:false
                },
                title: {
                    display: true,
                    text: 'Frequenze dadi'
                }
            },
            scales: {
                y: {
                    ticks: {
                        callback: function (val, index) {
                            return val % 1 === 0 ? this.getLabelForValue(val) : '';
                        },
                        stepSize: 1,
                    }
                }
            }
        }
    };
    window.barChart = new Chart(ctx, config);
}