$(document).ready(function () {

    //clock plugin constructor
    $('#myclock').thooClock({
        size: 280,
        showNumerals: true,
        secondHandColor: '#FF8C00',
        brandText: 'Lithiumdenis',
        brandText2: 'Russia',
        onEverySecond: function () {
            //callback that should be fired every second
        }
    });
});