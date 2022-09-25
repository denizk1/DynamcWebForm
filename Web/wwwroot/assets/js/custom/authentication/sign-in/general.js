"use strict"; var KTSigninGeneral = function () {
    var e, t, i; return {
        init: function () {
            e = document.querySelector("#kt_sign_in_form"),
                t = document.querySelector("#kt_sign_in_submit"),
                i = FormValidation.formValidation(e,
                    {
                        fields:
                        {
                            Username: { validators: { notEmpty: { message: "Username address is required" } } }, Password: {
                                validators: {
                                    notEmpty: { message: "The Password is required" },
                                    callback: {
                                        message: "Please enter valid password",
                                        callback: function (e) { if (e.value.length > 0) return _validatePassword() }
                                    }
                                }
                            }
                        }, plugins: { trigger: new FormValidation.plugins.Trigger, bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) }
                    }),
                t.addEventListener("click", (function (n) {
                    n.preventDefault(),
                        i.validate().then((function (i) {
                            "Valid" == i ?
                                (
                                    t.setAttribute("data-kt-indicator", "on"), t.disabled = !0, setTimeout((function () {
                                        t.removeAttribute("data-kt-indicator"), t.disabled = !1
                                        var form = $("#kt_sign_in_form");
                                        var url = form.attr('action');

                                        $.ajax({
                                            type: "POST",
                                            url: url,
                                            data: form.serialize(), // serializes the form's elements.
                                            dataType: 'json',
                                            success: function (data) {
                                                if (data.status) {
                                                    let timerInterval
                                                    Swal.fire({
                                                        title: 'Basarili',
                                                        icon: 'success',
                                                        html: 'yonlendiriliyor <b></b>',
                                                        timer: 2000,
                                                        timerProgressBar: true,
                                                        didOpen: () => {
                                                            Swal.showLoading()
                                                            const b = Swal.getHtmlContainer().querySelector('b')
                                                            timerInterval = setInterval(() => {
                                                                b.textContent = '...'
                                                            }, 200)
                                                        },
                                                        willClose: () => {
                                                            clearInterval(timerInterval)
                                                        }
                                                    }).then(function () { window.location.href = '/Home/Index'; })

                                                }
                                                else {
                                                    Swal.fire({ text: data.errorMessage, icon: "error" })
                                                }

                                            }
                                        });
                                    }), 2e3)) : Swal.fire({ text: "Bir sorun oluþtu tekrar kontrol edin", icon: "error", buttonsStyling: !1, confirmButtonText: "Tamam", customClass: { confirmButton: "btn btn-primary" } })
                        }))
                }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTSigninGeneral.init() })); //