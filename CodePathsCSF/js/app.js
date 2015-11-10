$(document).read(function () {
    setBindings();

});

function setBindgings() {
    $(".menuview ul li").click(function (e) {
        alert('hit');
    });
}