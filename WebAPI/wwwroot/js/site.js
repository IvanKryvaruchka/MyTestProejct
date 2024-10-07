$(document).ready(function () {
    $("form").each(function () {
        $(this).validate({
            errorClass: "text-danger",
            validClass: "text-success",
            errorElement: "span",
            highlight: function (element, errorClass, validClass) {
                $(element).addClass(errorClass).removeClass(validClass);
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).removeClass(errorClass).addClass(validClass);
            }
        });
    });
});
