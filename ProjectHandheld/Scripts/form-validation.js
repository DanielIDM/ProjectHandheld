$(document).ready(function () {
    //Form Change Password
    $("form[name='ChangePassword']").validate({
        wrapper: "div",
        rules: {
            newpassword: {
                required: true,
                minlength: 3
            },
            confirmpassword: {
                equalTo: newpassword
            }
        },

        messages: {
            newpassword: {
                required: "Password tidak boleh kosong",
                minlength: "Password minimal 3 karakter"
            },
            confirmpassword: {
                equalTo: "Password tidak sama dengan password baru"
            }
        },

        submitHandler: function (form) {
            
            //$(".changePassBtn").attr("disabled", true)
            form.submit();
        }
    });


 
});