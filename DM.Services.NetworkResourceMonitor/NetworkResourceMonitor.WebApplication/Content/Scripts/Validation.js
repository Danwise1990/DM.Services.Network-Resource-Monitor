//<+++++++++++++++++++++++++++++++++++++++++++++++++++++++ Validation Handlers +++++++++++++++++++++++++++++++++++++++++++++++++++++++>

//<-- Initialise All Client Side Validation Rules, calls initialisation functions for each custom client side validation attribute.
function InitialiseValidationAttributes() {

    $.validator.setDefaults({
        ignore: []
    });

    Adddatemustbeequalorlessthancurrentdate();
    Adddatemustbeovertenyearsago();
    Addrequiredif();
    Addrequiredifdictionaryentry();
}

//<-- Adds datemustbeequalorlessthancurrentdate Custom Validation Attribute to Unobtrusive Validation Handler
function Adddatemustbeequalorlessthancurrentdate() {

    $.validator.unobtrusive.adapters.addBool("datemustbeequalorlessthancurrentdate");

    $.validator.addMethod("datemustbeequalorlessthancurrentdate", function (value, element, param) {
        if (value) {
            var TestValue = moment(value, "DD-MM-YYYY");
            var Today = moment()

            if (TestValue.isAfter(Today)) {
                return false;
            } else {
                return true;
            }
        } else {
            return true;
        }
    });
}

//<-- Adds datemustbeovertenyearsago Custom Validation Attribute to Unobtrusive Validation Handler
function Adddatemustbeovertenyearsago() {

    $.validator.unobtrusive.adapters.addBool("datemustbeovertenyearsago");

    $.validator.addMethod("datemustbeovertenyearsago", function (value, element, param) {
        if (value) {
            var TestValue = moment(value, "DD-MM-YYYY");
            var TenYearsAgo = moment().subtract(10, "y");

            if (TestValue.isAfter(TenYearsAgo)) {
                return false;
            } else {
                return true;
            }
        } else {
            return true;
        }
    });
}

//<-- Adds requiredif Custom Validation Attribute to Unobtrusive Validation Handler
function Addrequiredif() {

    $.validator.addMethod('requiredif', function (value, element, parameters) {
        var desiredvalue = parameters.desiredvalue;
        desiredvalue = (desiredvalue == null ? '' : desiredvalue).toString();
        var controlType = $("input[id$='" + parameters.dependentproperty + "']").attr("type");
        var actualvalue = {}
        if (controlType == "checkbox" || controlType == "radio") {
            var control = $("input[id$='" + parameters.dependentproperty + "']:checked");
            actualvalue = control.val();
        } else {
            actualvalue = $("#" + parameters.dependentproperty).val();
        }
        if ($.trim(desiredvalue).toLowerCase() === $.trim(actualvalue).toLocaleLowerCase()) {
            var isValid = $.validator.methods.required.call(this, value, element, parameters);
            return isValid;
        }
        return true;
    });

    $.validator.unobtrusive.adapters.add('requiredif', ['dependentproperty', 'desiredvalue'], function (options) {
        options.rules['requiredif'] = options.params;
        options.messages['requiredif'] = options.message;
    });

}

//<-- Adds requiredif Custom Validation Attribute to Unobtrusive Validation Handler
function Addrequiredifdictionaryentry() {

    $.validator.addMethod('requiredifdictionaryentry', function (value, element, parameters) {
        var desiredvalue = parameters.desiredvalue;
        desiredvalue = (desiredvalue == null ? '' : desiredvalue).toString();
        var controlType = $("input[id$='" + parameters.dependentproperty + "']").attr("type");
        var actualvalue = {}
        if (controlType == "checkbox" || controlType == "radio") {
            var control = $("input[id$='" + parameters.dependentproperty + "']:checked");
            actualvalue = control.val();
        } else {
            actualvalue = $("#" + parameters.dependentproperty).val();
        }
        if ($.trim(desiredvalue).toLowerCase() === $.trim(actualvalue).toLocaleLowerCase()) {
            var isValid = $.validator.methods.required.call(this, value, element, parameters);
            return isValid;
        }
        return true;
    });

    $.validator.unobtrusive.adapters.add('requiredifdictionaryentry', ['dependentproperty', 'desiredvalue'], function (options) {
        options.rules['requiredifdictionaryentry'] = options.params;
        options.messages['requiredifdictionaryentry'] = options.message;
    });

}

//<+++++++++++++++++++++++++++++++++++++++++++++++++++++++ Misc Functions +++++++++++++++++++++++++++++++++++++++++++++++++++++++>