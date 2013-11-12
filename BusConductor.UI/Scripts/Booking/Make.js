BusConductor.Booking.Make = function () {

    var initialize = function () {

        var datepickerParameters = {
            dateFormat: 'dd/mm/yy',
            showOn: "button",
            defaultDate: new Date()
        };

        $("#PickUp").datepicker(datepickerParameters);
        $("#DropOff").datepicker(datepickerParameters);

        $("#IsMainDriver").change(function (event) {
            if (this.checked == true) {
                $(".alternate-driver").addClass("hide");
            } else {
                $(".alternate-driver").removeClass("hide");
            }
        });
    };

    return { initialize: initialize };
} ();


$(document).ready(function () {
    BusConductor.Booking.Make.initialize();
});