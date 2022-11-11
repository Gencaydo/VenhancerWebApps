"use strict";
var KTModalCreateCvPersonelInformation = function () {
    var e, t, i, o, r;
    return {
        init: function () {
            o = KTModalCreateCv.getForm(),
                r = KTModalCreateCv.getStepperObj(),
                e = KTModalCreateCv.getStepper().querySelector('[data-kt-element="information-next"]'),
                t = KTModalCreateCv.getStepper().querySelector('[data-kt-element="information-previous"]')
                $(o.querySelector('[name="dateofbirth"]')).flatpickr({
                    enableTime: !0,
                    dateFormat: "d, M Y, H:i"
                }),
                i = FormValidation.formValidation(o, {
                    fields: {
                        cvname: {
                            validators: {
                                notEmpty: {
                                    message: "Cv name is required"
                                }
                            }
                        },
                        firstname: {
                            validators: {
                                notEmpty: {
                                    message: "First Name is required"
                                }
                            }
                        },
                        lastname: {
                            validators: {
                                notEmpty: {
                                    message: "Last Name is required"
                                }
                            }
                        },
                        dateofbirth: {
                            validators: {
                                notEmpty: {
                                    message: "Date of birth is required"
                                }
                            }
                        },
                        homeaddress: {
                            validators: {
                                notEmpty: {
                                    message: "Description is required"
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
var KTExperienceAdd = function () {
    const t = document.getElementById("kt_modal_add_experience"),
        e = t.querySelector("#kt_modal_add_experience_form"),
        n = new bootstrap.Modal(t);
    return {
        init: function () {
            (() => {
                $(e.querySelector('[name="experiencedateofstart"]')).flatpickr({
                    enableTime: !0,
                    dateFormat: "d, M Y, H:i"
                })
                $(e.querySelector('[name="experiencedateofend"]')).flatpickr({
                    enableTime: !0,
                    dateFormat: "d, M Y, H:i"
                })
                var o = FormValidation.formValidation(e, {
                    fields: {
                        experiencecompanyname: {
                            validators: {
                                notEmpty: {
                                    message: "Company name is required"
                                }
                            }
                        },
                        experiencedateofstart: {
                            validators: {
                                notEmpty: {
                                    message: "Experience start date is required"
                                }
                            }
                        },
                        experiencedateofend: {
                            validators: {
                                notEmpty: {
                                    message: "Experience end date is required"
                                }
                            }
                        },
                        experiencedescription: {
                            validators: {
                                notEmpty: {
                                    message: "Description is required"
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
                });
                const i = t.querySelector('[data-kt-experience-modal-action="submit"]');
                i.addEventListener("click", (t => {
                    t.preventDefault(), o && o.validate().then((function (t) {
                        console.log("validated!"), "Valid" == t ? (i.setAttribute("data-kt-indicator", "on"), i.disabled = !0, setTimeout((function () {
                            i.removeAttribute("data-kt-indicator"),
                                AddUserCV(e.querySelector('[name="experiencecompanyname"]').value,
                                    e.querySelector('[name="experiencedateofstart"]').value,
                                    e.querySelector('[name="experiencedateofend"]').value,
                                    e.querySelector('[name="experiencedescription"]').value, e, n),
                                i.disabled = !1
                        }), 2e3)) : Swal.fire({
                            text: "Sorry, looks like there are some errors detected, please try again.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                })), t.querySelector('[data-kt-experience-modal-action="cancel"]').addEventListener("click", (t => {
                    t.preventDefault(), Swal.fire({
                        text: "Are you sure you would like to cancel?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Yes, cancel it!",
                        cancelButtonText: "No, return",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "Your form has not been cancelled!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                })), t.querySelector('[data-kt-experience-modal-action="close"]').addEventListener("click", (t => {
                    t.preventDefault(), Swal.fire({
                        text: "Are you sure you would like to cancel?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Yes, cancel it!",
                        cancelButtonText: "No, return",
                        customClass: {
                            confirmButton: "btn btn-primary",
                            cancelButton: "btn btn-active-light"
                        }
                    }).then((function (t) {
                        t.value ? (e.reset(), n.hide()) : "cancel" === t.dismiss && Swal.fire({
                            text: "Your form has not been cancelled!.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        })
                    }))
                }))
            })()
        }
    }
}();
"undefined" != typeof module && void 0 !== module.exports && (window.KTExperienceAdd = module.exports = KTExperienceAdd);
function AddUserCV(companyname, dateofstart, dateofend, description, e, n) {
    var createUserCVDto = {
        CvType: {
            "Id": "123468",
            "Name": "Gencay"
        },
        Experiences: [
            { "CompanyName": companyname }
        ],
    };
    $.ajax({
        url: "/Management/CreateUserCV",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(createUserCVDto),
        success: function (response) {
            try {
                if (response.IsSuccessful == false) {
                    MessageBox("error", response.Error.Errors[0])
                }
                else {
                    MessageBox("success", "Experience Added Successful!");
                    //GetAllUser();
                    e.reset();
                    n.hide();
                }
            } catch (e) {
                MessageBox("error", "Add user Error.Please Contact with IT Departmant. Error Number : 1002");
            }
        },
        error: function (response) {
            MessageBox("error", "Sorry, Service not working., Please contact with IT department. Error Detail :" + response.message);
        }
    });
}