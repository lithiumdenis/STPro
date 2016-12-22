function runRain() {
    var image = document.getElementById('bg');
    image.onload = function () {
        var engine = new RainyDay({
            image: this
        });
        //engine.rain([[1, 2, 10]]); 
        engine.rain([[3, 3, 0.88], [5, 5, 0.9], [6, 2, 1]], 100);
    };
    image.crossOrigin = 'anonymous';
    image.src = '/Content/images/autumn.jpg';
}