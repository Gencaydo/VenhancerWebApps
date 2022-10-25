"use strict";
var KTModalCreateCv = function () {
    var e, t, o, f;
    return {
        init: function () {
                e = document.querySelector("#kt_modal_create_cv_stepper"),
                o = document.querySelector("#kt_modal_create_cv_form"),
                f = document.querySelector("#kt_modal_add_experience_form"), t = new KTStepper(e)
        },
        getStepperObj: function () {
            return t
        },
        getStepper: function () {
            return e
        },
        getForm: function () {
            return f
        },
        getForm: function () {
            return o
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    document.querySelector("#kt_modal_create_cv") && document.querySelector("#kt_modal_add_experience") && (KTModalCreateCv.init(),
        KTModalCreateCvType.init(),
        KTModalCreateCvPersonelInformation.init(),
        KTModalCreateExrepienceInformation.init(),
        KTExperienceAdd.init(),
        KTModalCreateProjectTeam.init(),
        KTModalCreateProjectTargets.init(),
        KTModalCreateProjectFiles.init(),
        KTModalCreateProjectComplete.init())
})), "undefined" != typeof module && void 0 !== module.exports && (window.KTModalCreateCv = module.exports = KTModalCreateCv);