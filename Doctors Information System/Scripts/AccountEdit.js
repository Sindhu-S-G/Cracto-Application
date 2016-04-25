$('document').ready(function () {
    $('#state').val("Select State");
    $('#cityList').val("Select City");
    $('#cityList').attr('disabled', true);
    $('#datePick').datepicker({ dateFormat: 'mm/dd/yy' });
    var gender, dateOfBirth, Bloodgroup, locality, cityid, state;
    $.ajax({
        url: '/Profile/GetDetails',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $('#emailLink').empty();
            $('#cityList').empty();
            $.each(data, function (index, itemData) {
                $('#userName').val(itemData.FullName),
                $('#userName').attr('value', itemData.FullName),
                 Bdate = GetActualDate(itemData.DateOfBirth),
                $('#datePick').val(Bdate),
                $('#emailLink').prepend($('<span/>',{
                    text: itemData.EmailId
                })),
                $('#bloodGroup').val(itemData.BloodGroup),
                $('#phNumber').val(itemData.PhoneNumber)
            });
        }
    });
    if( $('#userName').val() == "" || $('#phNumber').val() == "")
    {
        $('#CancelLink').attr('href', '#');
    }
    gender = $('input[type=radio]:checked').val();
    dateOfBirth = $('#datePick').val();
    Bloodgroup = $('#bloodGroup').val();
    locality = $('#location').val();
    cityid = $('#cityList').val();
});

$('input[type=radio]').on('change', function () {
    gender = $('input[type=radio]:checked').val();
});                                                      /*Gender Selection*/

$('#datePick').on('change', function () {
    dateOfBirth = $('#datePick').val();
});                                                              /*Picking Date of birth*/

$('#BloodGroup').on('change', function () {
    Bloodgroup = $('#bloodGroup').val();
});                                                            /*Blood Group*/

$('#location').on('change', function () {
    locality = $('#location').val();
});                                                              /*Taking the location field value*/

$('#state').on('change', function () {
    var stateId = $('#state').val();
    if (stateId != null)
    {
        $('#cityList').val("Select City");
        Cityname = $('#cityList').val();
    }
});

$('#state').on('blur', function () {
    var stateId = $('#state').val();
    $('#cityList').attr('disabled', false);
        $('#cityList').val("Select City");
        if (stateId != null) {
            $.ajax({
                url: '/Profile/ListCities',
                type: 'POST',
                dataType: 'json',
                data: { StateId: stateId },
                success: function (data) {
                    $('#cityList').empty();
                    $.each(data, function (index, itemData) {
                        $('#cityList').append($('<option/>', {
                            value: itemData.CityId,
                            text: itemData.CityName
                        }))
                    });
                }
            });
        }
});

/*Submit Events*/

$('#UpdateChanges').on('click', function () {
    var NameExpr = /^[A-Za-z ]+$/;
    var ContactNumberExpr = /^(\+91)?[0]?[91]?[789]+[0-9]+$/;
    var name = $('#userName').val(); 
    var Phonenumber = $('#phNumber').val();
    dateOfBirth = $('#datePick').val();
    if(name == "")
    {
        $('#nameAlert').text('Name is Mandatory');
        return false;
    }
    else if (!(name.match(NameExpr)))
    {
        $('#nameAlert').text('Unidentified Data');
        return false;
    }
    else if(Phonenumber == "")
    {
        $('#phNumberAlert').text('Phone Number is Mandatory');
        return false;
    }
    else if(!(Phonenumber.match(ContactNumberExpr)))
    {
        $('#phNumberAlert').text('Unidentified Contact Number');
        return false;
    }
    else if(dateOfBirth == "")
    {
        $('#dboAlert').text("Enter Your Birth Date");
        return false;
    }
    else
    {
        $.ajax({
            url: '/Profile/UdateAccount',
            type: 'POST',
            data: {
                FullName: name,
                PhoneNumber: Phonenumber,
                DateOfBirth: dateOfBirth,
                Gender: gender,
                BloodGroup: Bloodgroup
            },
            success:function(response){
               response
        }
        });
    }
});
function GetActualDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth()+1)+"/"+dt.getDate()+"/"+dt.getFullYear();
}




