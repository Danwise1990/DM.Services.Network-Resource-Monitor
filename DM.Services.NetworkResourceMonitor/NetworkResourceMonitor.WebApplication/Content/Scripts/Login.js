//<+++++++++++++++++++++++++++++++++++++++++++++++++++++++ Event Handlers +++++++++++++++++++++++++++++++++++++++++++++++++++++++>
$(document).on("input propertychange paste", "form input", function () {

    $.validator.unobtrusive.parse("#form-login-validate_user");
    $('#form-login-validate_user').validate(true);

    if ($("#form-login-validate_user").valid()) {
        $("#btn-validate_user").prop('disabled', false);
        $("#btn-validate_user i").removeClass("fa-lock").addClass("fa-unlock");
    } else {
        $("#btn-validate_user").prop('disabled', true);
        $("#btn-validate_user i").removeClass("fa-unlock").addClass("fa-lock");
    }
});

$(document).on("click", "#btn-validate_user", function () {    

    $.validator.unobtrusive.parse("#form-login-validate_user");

    if ($("#form-login-validate_user").valid()) {
        $("#btn-validate_user i").toggleClass("fa-lock").toggleClass("fa-spinner").toggleClass("fa-pulse");

    }
});