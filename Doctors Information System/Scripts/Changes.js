
$('#SaveEmail').on('click', function () {
    var emailExpression = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var email = $('#newEmail').val();
    var password = $('#userPassword').val();
    if (email =='')
    {
        $('#newEmailAlert').text('Enter the email');
    }
    else if (!(email.match(emailExpression)))                                      /*Click Event*/ {
        $('#newEmailAlert').text('Invalid Email Id');
    }
    else if(password =='')
    {
        $('#userPasswordAlert').text('Enter the Password');
    }
    else
    {
        $.ajax({                                                                /*Ajax call*/
            url: '/Profile/ChangeEmailId',
            type: 'POST',
            data: { EmailId: email,
                    Password: password},
            success: function (response) {
                 $('#newEmailAlert').html(response);
            }
        });
    }
});
$('#newEmail').on('change',function () {
    $('#newEmailAlert').text('');
    $('#serverEmailAlert').text('');

});
$('#userPassword').on('change',function () {
    $('#userPasswordAlert').text('');
    $('#serverPasswordAlert').text('');
});


/*Change Password*/
$('#SavePassword').on('click',function () {
    var currentPassword = $('#currentPassword').val();
    var newPassword = $('#newPassword').val();
    var confirmPassword = $('#confirmPassword').val();
    if(currentPassword == '')
    {
        $('#currentPasswordAlert').text('Enter the current Password');
        return false;
    }
    else if(newPassword == '')
    {
        $('#newPasswordAlert').text('Enter the new Password');
        return false;
    }
    else if (confirmPassword == '')
    {
        $('#confirmPasswordAlert').text('Re-Enter the Password');
        return false;
    }
    else if(confirmPassword != newPassword)
    {
        $('#confirmPasswordAlert').text('Password entered does not match');
        return false;
    }
    else
    {
        $.ajax({
            url: '/Profile/ChangeUserPassword',
            type: 'POST',
            data: {CurrentPassword: currentPassword,
                NewPassword: newPassword
            },
            succcess: function (response) {
                $('#SavePassword').unbind('click');
            }

        });
    }
});

$('#currentPassword').on('change', function () {
    $('#currentPasswordAlert').text('');
    $('#serverPasswordAlert').text('');
});
$('#newPassword').on('change', function () {
    $('#newPasswordAlert').text('');
});
$('#confirmPassword').on('change', function () {
    $('#confirmPasswordAlert').text('');
});



/*For Doctor's Profile*/
$('#SaveDoctorEmail').on('click', function () {
    var emailExpression = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var email = $('#newEmail').val();
    var password = $('#userPassword').val();
    if (email == '') {
        $('#newEmailAlert').text('Enter the email');
    }
    else if (!(email.match(emailExpression)))                                      /*Click Event*/ {
        $('#newEmailAlert').text('Invalid Email Id');
    }
    else if (password == '') {
        $('#userPasswordAlert').text('Enter the Password');
    }
    else {
        $.ajax({                                                                /*Ajax call*/
            url: '/Profile/ChangeEmailId',
            type: 'POST',
            data: {
                EmailId: email,
                Password: password
            },
            success: function (response) {
                $('#newEmailAlert').html(response);
            }
        });
    }
});

