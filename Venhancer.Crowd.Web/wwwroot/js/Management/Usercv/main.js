"use strict";
var KTModalCreateCv = function () {
    var e, t, o;
    return {
        init: function () {
            e = document.querySelector("#kt_modal_create_cv_stepper"), o = document.querySelector("#kt_modal_create_cv_form"), t = new KTStepper(e)
        },
        getStepperObj: function () {
            return t
        },
        getStepper: function () {
            return e
        },
        getForm: function () {
            return o
        }
    }
}();
KTUtil.onDOMContentLoaded((function () {
    document.querySelector("#kt_modal_create_cv") && (KTModalCreateCv.init(),
        KTModalCreateCvType.init(),
        KTModalCreateCvPersonelInformation.init(),
        KTModalCreateProjectBudget.init(),       
        KTModalCreateProjectTeam.init(),
        KTModalCreateProjectTargets.init(),
        KTModalCreateProjectFiles.init(),
        KTModalCreateProjectComplete.init())
})), "undefined" != typeof module && void 0 !== module.exports && (window.KTModalCreateCv = module.exports = KTModalCreateCv);