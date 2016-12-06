$(function () {

    $('input[type=date]').each(function(){
        this.type="text";
    });

    $('input[type=time]').each(function () {
        this.type = "text";
    });

    $(".date-picker").datepicker({
    //    showOn: "button",
    //    buttonImage: "http://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
    //    buttonImageOnly: true,

        showOn: "both",
        altFormat: "mm/dd/yyyy",
        //dateFormat: "mm/dd/yyyy",
        buttonImage: "http://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
        buttonImageOnly: true,
        buttonText: "Select date",
        minDate: 0,
        defaultDate: new Date(),
        duration: "slow",
        showButtonPanel: true,
        closeText: 'Clear',
        onClose: function () {
            var event = arguments.callee.caller.caller.arguments[0];
            // If "Clear" gets clicked, then really clear it
            //if ($(event.delegateTarget).hasClass('ui-datepicker-close')) {
            //    $(this).val('');
            //}
        }
    });

    $('.start-time-picker').timepicker({
        timeFormat: 'h:mm p',
        interval: 60,
        minTime: '10',
        maxTime: '11:00pm',
        defaultTime: '10',
        startTime: '6:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });

    $('.end-time-picker').timepicker({
        timeFormat: 'h:mm p',
        interval: 60,
        minTime: '1:00am',
        maxTime: '11:00pm',
        defaultTime: '1:00pm',
        startTime: '6:00am'
    });

});