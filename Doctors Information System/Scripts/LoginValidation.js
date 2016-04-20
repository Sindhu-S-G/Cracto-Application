$('document').ready(function () {
    var emailExpression = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

});
$('#loginUser').click(function () {
    var emailExpression = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var email = $('#usersEmail').val();
    var password = $('#usersPassword').val();
    if (email == '') {
        $('#usersEmailAlert').text('Enter E-mail');
        return false;
    }
    else if (password == '') {
        $('#usersPasswordAlert').text('Enter Password');
        return false;
    }
    else if (!(email.match(emailExpression))) {
        $('#usersEmailAlert').text('Invalid Email Id');
        return false;
    }
});
$('#usersEmail').change(function () {
    $('#usersEmailAlert').text('');
    $('#serverUsersPasswordAlert').text('');

});
$('#usersPassword').change(function () {
    $('#usersPasswordAlert').text('');
    $('#serverUsersPasswordAlert').text('');
});