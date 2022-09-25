////"use strict"; var KTBudgetAdd = function () {
////    var e, t, i; return {
////        init: function () {
////            e = document.querySelector("#budget_input_form"),
////                t = document.querySelector("#budget_input_submit"),
////                t.addEventListener("click", (function (n) {
////                    n.preventDefault(),
////                        t.setAttribute("data-kt-indicator", "on"), t.disabled = !0, setTimeout((function () {
////                            t.removeAttribute("data-kt-indicator"), t.disabled = !1
////                            var form = $("#budget_input_form");
////                            var url = form.attr('action');

////                            $.ajax({
////                                type: "POST",
////                                url: url,
////                                data: form.serialize(), // serializes the form's elements.
////                                dataType: 'json',
////                                success: function (data) {

////                                    if (data.status) {

////                                        Swal.fire({ text: "Form Gonderildi", icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam", customClass: { confirmButton: "btn btn-primary" } }).then(function () { window.location.href = '/Home/HospitalReport'; });
////                                    }
////                                    else {
////                                        Swal.fire({ text: "Hata", icon: "error" })
////                                    }

////                                }
////                            });
////                        }))
////                }))
////        }
////    }
////}(); KTUtil.onDOMContentLoaded((function () { KTBudgetAdd.init() }));

"use strict"; var KTBudgetAdd = function () {
    var e, t,g, i; return {
        init: function () {
            e = document.querySelector("#budget_input_form"),
                t = document.querySelector("#budget_input_submit"),
                t.addEventListener("click", (function (n) {
                    n.preventDefault(),
                        t.setAttribute("data-kt-indicator", "on"), t.disabled = !0, setTimeout((function () {
                            t.removeAttribute("data-kt-indicator"), t.disabled = !1
                            var form = $("#budget_input_form");
                            var url = form.attr('action');

                            $.ajax({
                                type: "POST",
                                url: url,
                                data: form.serialize(), // serializes the form's elements.
                                dataType: 'json',
                                success: function (data) {

                                    if (data.status) {

                                        Swal.fire({ text: "Form Gonderildi", icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam", customClass: { confirmButton: "btn btn-primary" } }).then(function () { window.location.href = '/Home/HospitalReport'; });
                                    }
                                    else {
                                        Swal.fire({ text: "Hata", icon: "error" })
                                    }

                                }
                            });
                        }))
                }))

            g = document.querySelector("#budget_input_kaydet"),
                g.addEventListener("click", (function (n) {
                    n.preventDefault(),
                        g.setAttribute("data-kt-indicator", "on"), g.disabled = !0, setTimeout((function () {
                            g.removeAttribute("data-kt-indicator"), g.disabled = !1
                            var form = $("#budget_input_form");
                            $.ajax({
                                type: "POST",
                                url: '/Home/FormKaydet',
                                data: form.serialize(), // serializes the form's elements.
                                dataType: 'json',
                                success: function (data) {

                                    if (data.status) {

                                        Swal.fire({ text: "Form Kaydedildi", icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam", customClass: { confirmButton: "btn btn-primary" } }).then(function () { window.location.href = '/Home/Index'; });
                                    }
                                    else {
                                        Swal.fire({ text: "Hata", icon: "error" })
                                    }

                                }
                            });
                        }))
                }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTBudgetAdd.init() }));


