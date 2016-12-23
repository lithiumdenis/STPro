function runRain() {
    var image = document.getElementById('bg');
    image.onload = function () {
        var engine = new RainyDay({
            image: this
        });
        //engine.rain([[0, 2, 200], [3, 3, 1]], 100);
        engine.rain([[3, 3, 0.1]], 33);
    };
    image.crossOrigin = 'anonymous';
    image.src = '/Content/images/autumn.jpg';
}