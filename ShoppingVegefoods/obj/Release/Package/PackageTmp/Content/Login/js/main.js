
(function ($) {
    "use strict";


    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false) {
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }

    $("#email,#username").blur(function (e) {
        if (validate(e.currentTarget) == false) {
            showValidate(e.currentTarget);
            return;
        }

        var url = $(e.currentTarget).attr('name') === 'email' ? URL.CHECKEMAIL : URL.CHECKUSERNAME;
        var errorText = $(e.currentTarget).attr('name') === 'email' ? ERROR.EMAIL : ERROR.USERNAME;

        var dataSet = e.currentTarget.dataset;
        if (dataSet && dataSet.forgot === "1") {
            errorText = $(e.currentTarget).attr('name') === 'email' ? ERROR.EMAIL_FORGOT : ERROR.UERNAME_FORGOT;
        }

        
        
        var $loading = $("#loading");

        $loading.show()
        $.ajax({
            type: "POST",
            url: url,
            data: { data: e.currentTarget.value },
            success: function(data) {
                $loading.hide();
                if (dataSet.forgot === "1" && !data || !dataSet.forgot && data) {
                    displayError(errorText);
                } else {
                    displayError("",false);
                }
            },
            error: function (error) {
                $loading.hide()
                console.log(error);
            }
        });
    });

    $("#confirm-password,input[name='passwordNew']").blur(function (e) {
        var password1 = $('input[name="passwordNew"]').val();
        var password2 = $("#confirm-password").val();
        
        if (password1 !== password2) {
            displayError(ERROR.PASSWORDNOTMATCH)
        } else {
            displayError("",false)
        }
    });

    function displayError(message, isDisplay = true) {
        var $errorInfo = $(".error-info");
        if (isDisplay) {
            $errorInfo.css("display", "block");
            $errorInfo.text(message);
        } else {
            $errorInfo.css("display", "none");
            $errorInfo.text(message);
        }
    }

})(jQuery);