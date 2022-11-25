"use strict";
var userDataSet;
var KTUserList = function () {
    var e, t, n, r, k, o = document.getElementById("kt_user_table"),
        c = () => {
            o.querySelectorAll('[data-kt-user-table-filter="delete_row"]').forEach((t => {
                t.addEventListener("click", (function (t) {
                    t.preventDefault();
                    const n = t.target.closest("tr"),
                        r = n.querySelectorAll("td")[2].innerText;
                        k = n.querySelectorAll("td")[1].innerText;
                    Swal.fire({
                        text: "Are you sure you want to delete " + r + "?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Yes, delete!",
                        cancelButtonText: "No, cancel",
                        customClass: {
                            confirmButton: "btn fw-bold btn-danger",
                            cancelButton: "btn fw-bold btn-active-light-primary"
                        }
                    }).then((function (t) {
                        t.value ? Swal.fire({
                            text: "You have deleted " + r + "!.",
                            icon: "success",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn fw-bold btn-primary"
                            }
                        }).then((function () {
                            RemoveUser(k);
                            e.row($(n)).remove().draw()
                        })).then((function () {
                            a()
                        })) : "cancel" === t.dismiss && Swal.fire({
                            text: customerName + " was not deleted.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Ok, got it!",
                            customClass: {
                                confirmButton: "btn fw-bold btn-primary"
                            }
                        })
                    }))
                }))
            }))
        },
        l = () => {
            const c = o.querySelectorAll('[type="checkbox"]');
            t = document.querySelector('[data-kt-user-table-toolbar="base"]'), n = document.querySelector('[data-kt-user-table-toolbar="selected"]'), r = document.querySelector('[data-kt-user-table-select="selected_count"]');
            const s = document.querySelector('[data-kt-user-table-select="delete_selected"]');
            c.forEach((e => {
                e.addEventListener("click", (function () {
                    setTimeout((function () {
                        a()
                    }), 50)
                }))
            })), s.addEventListener("click", (function () {
                Swal.fire({
                    text: "Are you sure you want to delete selected customers?",
                    icon: "warning",
                    showCancelButton: !0,
                    buttonsStyling: !1,
                    confirmButtonText: "Yes, delete!",
                    cancelButtonText: "No, cancel",
                    customClass: {
                        confirmButton: "btn fw-bold btn-danger",
                        cancelButton: "btn fw-bold btn-active-light-primary"
                    }
                }).then((function (t) {
                    t.value ? Swal.fire({
                        text: "You have deleted all selected customers!.",
                        icon: "success",
                        buttonsStyling: !1,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn fw-bold btn-primary"
                        }
                    }).then((function () {
                        c.forEach((t => {
                            t.checked && e.row($(t.closest("tbody tr"))).remove().draw()
                        }));
                        o.querySelectorAll('[type="checkbox"]')[0].checked = !1
                    })).then((function () {
                        a(), l()
                    })) : "cancel" === t.dismiss && Swal.fire({
                        text: "Selected customers was not deleted.",
                        icon: "error",
                        buttonsStyling: !1,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn fw-bold btn-primary"
                        }
                    })
                }))
            }))
        };
    const a = () => {
        const e = o.querySelectorAll('tbody [type="checkbox"]');
        let c = !1,
            l = 0;
        e.forEach((e => {
            e.checked && (c = !0, l++)
        })), c ? (r.innerHTML = l, t.classList.add("d-none"), n.classList.remove("d-none")) : (t.classList.remove("d-none"), n.classList.add("d-none"))
    };
    return {
        init: function () {
            try {
                o && (o.querySelectorAll("tbody tr"),
                    (e = $(o).DataTable({
                        info: !1,
                        order: [],
                        data: userDataSet,
                        destroy: true,
                        processing: 'Please wait...',
                        columnDefs: [{
                            orderable: !1,
                            targets: 0,
                            'render': function (data, type, full, meta) {
                                return "<div class='form-check form-check-sm form-check-custom form-check-solid'>" +
                                    "<input class='form-check-input' type='checkbox' value='1' />" +
                                    "</div>"
                            }
                        },
                        {
                            targets: 1,
                            data: "Id"
                        },
                        {
                            targets: 2,
                            data: "UserName"
                        },
                        {
                            targets: 3,
                            data: "Email"
                        },
                        {
                            targets: 4,
                            data: "PhoneNumber"
                        },
                        {
                            targets: 5,
                            'render': function (data, type, full, meta) {
                                return "<a href='#' class='btn btn-sm btn-light btn-active-light-primary' data-kt-menu-trigger='click' data-kt-menu-placement='bottom-end'>Actions" +
                                    "<span class='svg-icon svg-icon-5 m-0'>" +
                                    "<svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'>" +
                                    "<path d='M11.4343 12.7344L7.25 8.55005C6.83579 8.13583 6.16421 8.13584 5.75 8.55005C5.33579 8.96426 5.33579 9.63583 5.75 10.05L11.2929 15.5929C11.6834 15.9835 12.3166 15.9835 12.7071 15.5929L18.25 10.05C18.6642 9.63584 18.6642 8.96426 18.25 8.55005C17.8358 8.13584 17.1642 8.13584 16.75 8.55005L12.5657 12.7344C12.2533 13.0468 11.7467 13.0468 11.4343 12.7344Z' fill='black' />" +
                                    "</svg>" +
                                    "</span>" +
                                    "</a>" +
                                    "<div class='menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold fs-7 w-125px py-4' data-kt-menu='true'>" +
                                    "<div class='menu-item px-3'>" +
                                    "<a href='#' class='menu-link px-3' data-kt-user-table-filter='delete_row'>Delete</a>" +
                                    "</div>" +
                                    "<div class='menu-item px-3'>" +
                                    "<a href='#' class='menu-link px-3' data-bs-toggle='modal' data-bs-target='#kt_modal_update_user' data-kt-game-table-filter='update_row'>Update</a>"
                                "</div>" +
                                    "</div>"
                            }
                        }]
                    })).on("draw", (function () {
                        l(), c(), a()
                    })), l(), document.querySelector('[data-kt-user-table-filter="search"]').addEventListener("keyup", (function (t) {
                        e.search(t.target.value).draw()
                        KTMenu.createInstances();
                    })), document.querySelector('[data-kt-user-table-filter="reset"]').addEventListener("click", (function () {
                        document.querySelector('[data-kt-user-table-filter="form"]').querySelectorAll("select").forEach((e => {
                            $(e).val("").trigger("change")
                        })), e.search("").draw()
                        KTMenu.createInstances();
                    })), c(), (() => {
                        const t = document.querySelector('[data-kt-user-table-filter="form"]'),
                            n = t.querySelector('[data-kt-user-table-filter="filter"]'),
                            r = t.querySelectorAll("select");
                        n.addEventListener("click", (function () {
                            var t = "";
                            r.forEach(((e, n) => {
                                e.value && "" !== e.value && (0 !== n && (t += " "), t += e.value)
                            })), e.search(t).draw()
                        }))
                    KTMenu.createInstances();
                    })())
            } catch (e) {
                MessageBox("error", e.Message);
            }
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    GetAllUser();
}));
function GetAllUser() {
    $.ajax({
        type: "GET",
        url: "/User/GetAllUser",
        success: function (response) {
            if (response != null) {
                userDataSet = response.Data;
                KTUserList.init();
            } else {
                MessageBox("error", "User Data not found please contact with IT!");
            }
        },
        failure: function (response) {
            MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
        },
        error: function (response) {
            MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
        }
    });
}
function RemoveUser(userid) {
    var userAppDto = {
        Id: userid
    };
    $.ajax({
        type: "POST",
        url: "/Management/UserRemove",
        contentType: 'application/json',
        data: JSON.stringify(userAppDto),
        success: function (response) {
            if (response != null) {
                userDataSet = response.Data;
                KTUserList.init();
            } else {
                MessageBox("error", "User Data not found please contact with IT!");
            }
        },
        failure: function (response) {
            MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
        },
        error: function (response) {
            MessageBox("error", "User Data not found please contact with IT! Error Detail : " + response.responseText);
        }
    });
}