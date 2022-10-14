"use strict";
var KTSigninGeneral = function () {
    var t, e, i;
    return {
        init: function () {
            t = document.querySelector("#kt_sign_in_form"), e = document.querySelector("#kt_sign_in_submit"), i = FormValidation.formValidation(t, {
                fields: {
                    email: {
                        validators: {
                            notEmpty: {
                                message: "Email address is required"
                            },
                            emailAddress: {
                                message: "The value is not a valid email address"
                            }
                        }
                    },
                    password: {
                        validators: {
                            notEmpty: {
                                message: "The password is required"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger,
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: ".fv-row"
                    })
                }
            }), e.addEventListener("click", (function (n) {
                n.preventDefault(), i.validate().then((function (i) {
                    "Valid" == i ?
                        grecaptcha.ready(function () {
                                (e.setAttribute("data-kt-indicator", "on"), e.disabled = !0, setTimeout((function () {
                                    e.removeAttribute("data-kt-indicator"),
                                        UserLogin(t.querySelector('[name="email"]').value, t.querySelector('[name="password"]').value,e).then((function (e) {
                                            e.isConfirmed && (t.querySelector('[name="email"]').value = "", t.querySelector('[name="password"]').value = "")
                                        }))
                                }), 2e3)).then((function (e) {
                                    e.disabled = !1
                                }))
                        }) : MessageBox("error", "Sorry, looks like there are some errors detected, please check login form.");
                }))
            }))
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    KTSigninGeneral.init()
    //setInterval(() => {
    //    MessageBox("error", "BU mesaj 5 saniyede bir görünecek!");
    //},5000);
}));
function UserLogin(loginemail, loginpassword, e) {
    var loginDto = {
        Email: loginemail,
        Password: loginpassword,
    };
    $.ajax({
        url: "/User/UserSignIn",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(loginDto),
        success: function (response) {
            var a = response;
            try {
                if (response.IsSuccessful == false) {
                    MessageBox("error", response.Error.Errors[0])
                }
                else {
                    window.location.href = "Home/Index";
                }
            } catch {
                MessageBox("error", "Login Error.Please Contact with IT Departmant. Error Number : 1003");
            }
        },
        error: function (response) {
            MessageBox("error", "Sorry, Service not working., Please contact with IT department. Error Detail :" + response.message);
        }
    });
    e.disabled = !1;
}
function MessageBox(MessageType, MessageText) {
    Swal.fire({
        text: MessageText,
        icon: MessageType,
        buttonsStyling: !1,
        confirmButtonText: "Ok, got it!",
        customClass: {
            confirmButton: "btn btn-primary"
        }
    })
}
function getFormData(dom_query) {
    var object = $(dom_query).serializeArray().reduce(function (obj, item) {
        var name = item.name.replace("[]", "");
        if (typeof obj[name] !== "undefined") {
            if (!Array.isArray(obj[name])) {
                obj[name] = [obj[name], item.value];
            } else {
                obj[name].push(item.value);
            }
        } else {
            obj[name] = item.value;
        }
        return obj;
    }, {});
    return JSON.stringify(object);
}