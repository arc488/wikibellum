$(document).ready(function () {
    rangeSlider();
    setMonth();
});

$(".range-slider__range").on("input", function () {
    setMonthAndYearSelect();
});

$("select").change(function () {
    setMonth();
    setSliderValue();
});

var setMonth = function () {
    var months = $("#months").val();
    var years = $("#years").val();
    var month = parseInt(years) * 12 + parseInt(months);
    $("#monthValue").val(month);
};


var setMonthAndYearSelect = function () {
    var months = $(".range-slider__range").val();
    $("#monthValue").val(months);
    var year = Math.floor((parseInt(months)) / 12);
    var month = months % 12;
    $("#years").val(year);
    $("#months").val(month);
};



var setSliderValue = function () {
    $(".range-slider__range").val($("#monthValue").val());
};

var rangeSlider = function () {
    var slider = $(".range-slider"),
        range = $(".range-slider__range"),
        value = $(".range-slider__value");

    slider.each(function () {
        value.each(function () {
            var value = $(this).prev().attr("value");
            $(this).html(value);
        });

        range.on("input", function () {
            $(this).next(value).html(this.value);
        });
    });
};
