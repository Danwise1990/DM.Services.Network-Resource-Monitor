var SessionTimer;

//<+++++++++++++++++++++++++++++++++++++++++++++++++++++++ Page Load Handlers +++++++++++++++++++++++++++++++++++++++++++++++++++++++>
$(document).ready(function () {
    InitialiseValidationAttributes();
});

//<+++++++++++++++++++++++++++++++++++++++++++++++++++++++ Button Handlers +++++++++++++++++++++++++++++++++++++++++++++++++++++++>

//<-- Interface Sidebar Button Handler, on button click, displays a UI block loading control -->
$(document).on("click", ".block-ui", function () {
    $.blockUI({
        message: "<div class='alert alert-styled-info block-ui-alert text-center'><i class='fa fa-spinner fa-pulse fa-5x'></i><br /></div>",
        baseZ: 1060
    });
});

//<-- Dropdown Item Select Handler, on selection of an item from a dropdown menu, populate the attached input with the dropdown item value -->
$(document).on("click", ".dropdown-menu li", function () {
    var parentdiv = $(this).parent().parent().parent();
    var input = $(parentdiv).find("input");
    var value = $(this).find("a").html();

    $(input).val(value);
});

//<+++++++++++++++++++++++++++++++++++++++++++++++++++++++ AJAX Handler +++++++++++++++++++++++++++++++++++++++++++++++++++++++>

//<-- Universal Dynamic AJAX function, provides single-point-of-entry AJAX functionality to facilitate generic client-server communication -->
function DynamicAJAX(Parameters, ControllerName, FunctionName, SuccessCallback, FailureCallback) {
    $.ajax({
        type: "POST",
        url: webroot + ControllerName + "/" + FunctionName + "/",
        data: Parameters,
        success: function (response) {
            window[SuccessCallback](response, Parameters);
            SessionTimer.reset();
        }, failure: function (jqXHR, textStatus, errorThrown) {
            window[FailureCallback](errorThrown, Parameters);
        }, error: function (event, jqXHR, ajaxSettings, thrownError) {
            window[FailureCallback](event, jqXHR, ajaxSettings, thrownError, Parameters);
        }, complete: function () {
            $.unblockUI();
        }
    });
}

//<-- Universal Dynamic AJAX function, this version specifies that the content of the request is of type Json, otherwise the controller layer does not pick up the parameters -->
function DynamicAJAXJSON(Parameters, ControllerName, FunctionName, SuccessCallback, FailureCallback) {
    $.ajax({
        type: "POST",
        contentType: 'application/json',
        url: webroot + ControllerName + "/" + FunctionName + "/",
        data: Parameters,
        success: function (response) {
            window[SuccessCallback](response, Parameters);
            $(".btn-toggle-loading-state").find(".fa").removeClass("fa-spinner").removeClass("fa-pulse").addClass($(".btn-toggle-loading-state").find(".fa").attr("data-default-icon"));
            SessionTimer.reset();
        }, failure: function (jqXHR, textStatus, errorThrown) {
            window[FailureCallback](errorThrown, Parameters);
        }, error: function (event, jqXHR, ajaxSettings, thrownError) {
            window[FailureCallback](event, jqXHR, ajaxSettings, thrownError, Parameters);
        }, complete: function () {
        }
    });
}

//<-- Universal AJAX Failure or Error Callback, in the event of an error or failure event within the AJAX query, this function can be called to display a standard error to the user. -->
function AJAXFailure(event, jqXHR, ajaxSettings, thrownError, Parameters) {

    $.unblockUI();

    if (event.status === 401) {
        SessionTimeoutHandler()
    } else {
        $.get(webroot + "Resources/Templates/Server Error.html").done(function (Template) {
            if (!($(".modal-dialog").length)) {
                bootbox.dialog({
                    closeButton: false,
                    message: "BLANK MESSAGE",
                    title: "",
                    buttons: {
                        Close: {
                            label: "Close <i class='fa fa-times'></i>",
                            className: "btn-danger"
                        }
                    }
                });
            }

            $(".modal-content").html(Template);

        });
    }
}

//<+++++++++++++++++++++++++++++++++++++++++++++++++++++++ Misc Handlers +++++++++++++++++++++++++++++++++++++++++++++++++++++++>

//<-- Popover Dismiss on Lose Focus Handler, manually dismiss a displayed popover on detection of a click action not within the popover -->
$(document).mousedown(function (e) {
    var Popover = $(".popover-manually-dismiss");

    if (!Popover.is(e.target) // if the target of the click isn't the container...
        && Popover.has(e.target).length === 0) // ... nor a descendant of the container
    {
        $(".btn-popover-close").click();
    }
});

//<-- Dropdown Item Select Handler, on selection of an item from a dropdown menu, populate the attached input with the dropdown item value -->
function SessionTimeoutHandler() {
    $(".has-popover").popover('destroy');

    $.get(webroot + "Authentication/SessionExpired").done(function (Template) {
        if (!($(".modal-dialog").length)) {
            bootbox.dialog({
                closeButton: false,
                message: "BLANK MESSAGE",
                title: "",
                buttons: {
                    Close: {
                        label: "Close <i class='fa fa-times'></i>",
                        className: "btn-danger"
                    }
                }
            });
        }

        $(".modal-content").html(Template);

    });
}

function InitialiseSessionTimer() {
    SessionTimer = new Counter({
        seconds: 1800,
        // callback function for each second
        onUpdateStatus: function (second) {
            // change the UI that displays the seconds remaining in the timeout

            var minutes = Math.floor(second / 60);
            var seconds = second - minutes * 60;

            $(".badge-session-countdown").html(str_pad_left(minutes, '0', 2) + ':' + str_pad_left(seconds, '0', 2));

            if (minutes <= 1) {
                if (minutes <= 0) {
                    $(".lbl-username").removeClass("label-styled-warning").addClass("label-styled-danger");
                } else {
                    $(".lbl-username").removeClass("label-styled-primary").addClass("label-styled-warning");
                }
            } else {
                $(".lbl-username").removeClass("label-styled-warning label-styled-danger").addClass("label-styled-primary");
            }

            function str_pad_left(string, pad, length) {
                return (new Array(length + 1).join(pad) + string).slice(-length);
            }
        },

        // callback function for final action after countdown
        onCounterEnd: function () {
            // show message that session is over, perhaps redirect or log out
            SessionTimeoutHandler();
        }
    });

    SessionTimer.start();
}