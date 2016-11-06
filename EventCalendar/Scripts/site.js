$(function () {

    $('input[type=date]').each(function(){
        this.type="text";
    });

    $(".date-picker").datepicker({
    //    showOn: "button",
    //    buttonImage: "http://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
    //    buttonImageOnly: true,

    showOn: "both",
    altFormat: "mm/dd/yyyy",
    buttonImage: "http://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
    buttonImageOnly: true,
    buttonText: "Select date",
    minDate : 0,
    showButtonPanel: true,
    closeText: 'Clear',
    onClose: function () {
        var event = arguments.callee.caller.caller.arguments[0];
        // If "Clear" gets clicked, then really clear it
        if ($(event.delegateTarget).hasClass('ui-datepicker-close')) {
            $(this).val('');
        }
    }
    });

});