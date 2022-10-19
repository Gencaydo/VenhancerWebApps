"use strict";
var f;
var KTuserAddUser = function () {
    const t = document.getElementById("kt_modal_add_user"),
        e = t.querySelector("#kt_modal_add_user_form"),
        n = new bootstrap.Modal(t);
    return {
        init: function () {
            (() => {
                var o = FormValidation.formValidation(e, {
                    fields: {
                        username: {
                            validators: {
                                notEmpty: {
                                    message: "Full name is required"
                                }
                            }
                        },
                        useremail: {
                            validators: {
                                notEmpty: {
                                    message: "Valid email address is required"
                                }
                            }
                        },
                        userpassword: {
                            validators: {
                                notEmpty: {
                                    message: "Password is required"
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
                const i = t.querySelector('[data-kt-user-modal-action="submit"]');
                i.addEventListener("click", (t => {
                    t.preventDefault(), o && o.validate().then((function (t) {
                        console.log("validated!"), "Valid" == t ? (i.setAttribute("data-kt-indicator", "on"), i.disabled = !0, setTimeout((function () {
                            i.removeAttribute("data-kt-indicator"),
                                UserCreate(e.querySelector('[name="username"]').value,
                                    e.querySelector('[name="useremail"]').value,
                                    e.querySelector('[name="userpassword"]').value,
                                    e.querySelector('[name="userrole"]:checked').value, e,n),
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
                })), t.querySelector('[data-kt-user-modal-action="cancel"]').addEventListener("click", (t => {
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
                })), t.querySelector('[data-kt-user-modal-action="close"]').addEventListener("click", (t => {
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
KTUtil.onDOMContentLoaded((function () {
    KTuserAddUser.init()
}));
function UserCreate(username, useremail, userpassword, userrole,e,n) {
    var createUserDto = {
        Username: username,
        Email: useremail,
        Password: userpassword,
        PhoneNumber: ""
    };
    $.ajax({
        url: "/Management/UserCreate",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(createUserDto),
        success: function (response) {
            try {
                if (response.IsSuccessful == false) {
                    MessageBox("error", response.Error.Errors[0])
                }
                else {
                    MessageBox("success", "user  " + username + " Added Successful!");
                    GetAllUser();
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