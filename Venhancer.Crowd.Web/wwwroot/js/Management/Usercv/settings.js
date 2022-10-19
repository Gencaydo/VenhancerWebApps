"use strict";
var KTModalCreateCvPersonelInformation = function () {
    var e, t, i, o, r;
    return {
        init: function () {
            o = KTModalCreateCv.getForm(), r = KTModalCreateCv.getStepperObj(), e = KTModalCreateCv.getStepper().querySelector('[data-kt-element="information-next"]'), t = KTModalCreateCv.getStepper().querySelector('[data-kt-element="information-previous"]')
                $(o.querySelector('[name="information_release_date"]')).flatpickr({
                enableTime: !0,
                dateFormat: "d, M Y, H:i"
            }), i = FormValidation.formValidation(o, {
                fields: {
                    cv_name: {
                        validators: {
                            notEmpty: {
                                message: "Cv name is required"
                            }
                        }
                    },
                    information_description: {
                        validators: {
                            notEmpty: {
                                message: "Description is required"
                            }
                        }
                    },
                    information_release_date: {
                        validators: {
                            notEmpty: {
                                message: "Release date is required"
                            }
                        }
                    },
                    "settings_notifications[]": {
                        validators: {
                            notEmpty: {
                                message: "Notifications are required"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger,
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: ".fv-row",
                        eleInvalidClass: "",
                        eleValidClass: ""
                    })
                }
            }), e.addEventListener("click", (function (t) {
                t.preventDefault(), e.disabled = !0, i && i.validate().then((function (t) {
                    console.log("validated!"), "Valid" == t ? (e.setAttribute("data-kt-indicator", "on"), setTimeout((function () {
                        e.removeAttribute("data-kt-indicator"), e.disabled = !1, r.goNext()
                    }), 1500)) : (e.disabled = !1, Swal.fire({
                        text: "Sorry, looks like there are some errors detected, please try again.",
                        icon: "error",
                        buttonsStyling: !1,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    }))
                }))
            })), t.addEventListener("click", (function () {
                r.goPrevious()
            }))
        }
    }
}();
"undefined" != typeof module && void 0 !== module.exports && (window.KTModalCreateCvPersonelInformation = module.exports = KTModalCreateCvPersonelInformation);