$('document').ready(function () {
    var emailExpression = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
});

$('#PatientRegister').on('click',function () {
    var email = $('#emailId').val();
    var password = $('#password').val();
    if (email =='')
    {
        $('#emailAlert').text('Enter the email');
    }
    else if (!(email.match(emailExpression)))                                      /*Click Event*/ {
        $('#emailAlert').text('Invalid Email Id');
    }
    else if(password =='')
    {
        $('#passwordAlert').text('Enter the Password');
    }
    else
    {
        $.ajax({                                                                /*Ajax call*/
            url: '/Home/PatientSignUp',
            type: 'POST',
            data: { EmailId: email, Password:password },
            success: function (response) {
                $('#emailAlert').html(response)
            }
        });
    }
});


$('#DoctorRegister').on('click', function () {
    var email = $('#emailId').val();
    var password = $('#password').val();
    if (email == '') {
        $('#emailAlert').text('Enter the email');
    }
    else if (!(email.match(emailExpression)))                                      /*Click Event*/ {
        $('#emailAlert').text('Invalid Email Id');
    }
    else if (password == '') {
        $('#passwordAlert').text('Enter the Password');
    }
    else {
        $.ajax({                                                                /*Ajax call*/
            url: '/Home/DoctorSignUp',
            type: 'POST',
            data: { EmailId: email, Password: password },
            success: function (response) {
                $('#emailAlert').html(response)
            }
        });
    }
});


$('#emailId').on('focus',function () {
    $('#serverAlert').text(" ");
});


  