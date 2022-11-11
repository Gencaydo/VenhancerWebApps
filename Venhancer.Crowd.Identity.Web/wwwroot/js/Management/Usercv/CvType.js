"use strict";
var KTModalCreateCvType = function () {
    var e, t, o, r;
    return {
        init: function () {
            o = KTModalCreateCv.getForm(), r = KTModalCreateCv.getStepperObj(), e = KTModalCreateCv.getStepper().querySelector('[data-kt-element="type-next"]'), t = FormValidation.formValidation(o, {
                fields: {
                    cvtype: {
                        validators: {
                            notEmpty: {
                                message: "Cv type is required"
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
            }), e.addEventListener("click", (function (o) {
                o.preventDefault(), e.disabled = !0, t && t.validate().then((function (t) {
                    console.log("validated!"), o.preventDefault(), "Valid" == t ? (e.setAttribute("data-kt-indicator", "on"), setTimeout((function () {
                        e.removeAttribute("data-kt-indicator"), e.disabled = !1, r.goNext()
                    }), 1e3)) : (e.disabled = !1, Swal.fire({
                        text: "Sorry, looks like there are some errors detected, please try again.",
                        icon: "error",
                        buttonsStyling: !1,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    }))
                }))
            }))
        }
    }
}();
"undefined" != typeof module && void 0 !== module.exports && (window.KTModalCreateCvType = module.exports = KTModalCreateCvType);