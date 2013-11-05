$(document).ready(function () {

    var datepickerParameters = {
        dateFormat: 'dd/mm/yy',
        showOn: "button",
        defaultDate: new Date()
        //buttonImageOnly: false
    };

    $("#PickUp").datepicker(datepickerParameters);
    $("#DropOff").datepicker(datepickerParameters);
});