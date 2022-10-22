"use strict";
var KTModalCreateExrepienceInformation = function () {
    var e, t, a, r, o;
    return {
        init: function () {
            r = KTModalCreateCv.getForm(),
                o = KTModalCreateCv.getStepperObj(),
                e = KTModalCreateCv.getStepper().querySelector('[data-kt-element="experience-next"]'),
                t = KTModalCreateCv.getStepper().querySelector('[data-kt-element="experience-previous"]'),
                $(r.querySelector('[name="dateofbirth"]')).flatpickr({
                    enableTime: !0,
                    dateFormat: "d, M Y, H:i"
                }),
                a = FormValidation.formValidation(r, {
                fields: {
                    budget_setup: {
                        validators: {
                            notEmpty: {
                                message: "Budget amount is required"
                            },
                            callback: {
                                message: "The budget amount must be greater than $100",
                                callback: function (e) {
                                    var t = e.value;
                                    if (t = t.replace(/[$,]+/g, ""), parseFloat(t) < 100) return !1
                                }
                            }
                        }
                    },
                    budget_usage: {
                        validators: {
                            notEmpty: {
                                message: "Budget usage type is required"
                            }
                        }
                    },
                    budget_allow: {
                        validators: {
                            notEmpty: {
                                message: "Allowing budget is required"
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
                t.preventDefault(), e.disabled = !0, a && a.validate().then((function (t) {
                    console.log("validated!"), "Valid" == t ? (e.setAttribute("data-kt-indicator", "on"), setTimeout((function () {
                        e.removeAttribute("data-kt-indicator"), e.disabled = !1, o.goNext()
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
                o.goPrevious()
            }))
        }
    }
}();
"undefined" != typeof module && void 0 !== module.exports && (window.KTModalCreateExrepienceInformation = module.exports = KTModalCreateExrepienceInformation);