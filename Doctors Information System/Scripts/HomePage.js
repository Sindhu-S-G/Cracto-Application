$('document').ready(function () {
   
    $('#city').val("");
    $('#locality').attr('disabled', true);
    $('#specialization').val("");
   
    /**/
   
 });


$('#city').on('click', function (){
    $('.cities').on('click',function () {
        var city = $(this).text();
        $('#city').val(city);
        $('#locality').attr('disabled', false);
        return false;
    });
});

$('#localityMenu').on('mouseover', function () {
    $('.localities').on('click', function () {
        var locality = $(this).text();
        $('#locality').val(locality)
    });
});

$('#locality').on('click', function () {
    var city = $('#city').val();
    $.ajax({
        url: '/Home/ListOfLocalities',
        type: 'POST',
        dataType: 'json',
        data: { CityName: city },
        success: function (data) {
            $('#localityMenu').empty();
            $.each(data, function (index, itemData) {
                $('#localityMenu').append($('<a>', {
                    href: '#',
                    role: 'menuitem',
                    class: 'list-group-item localities',
                    text: itemData.LocalityName
                }))
            });
        }
    });
});

$('#specialization').on('click', function () {
    $('.specialist').on('click', function () {
        var specialization = $(this).text();
        $('#specialization').val(specialization);
        return false;
    });
});

$('#submitData').on('click', function () {
    if ($('#city').val() == '') {
        $('#cityCheck').text("Select City");
        return false;
    }
    else if ($('#specialization').val() == '') {
        $('#specCheck').text("Select Specialization");
        return false;
    }
});

$('#city').mousedown(function () {
    $('#cityCheck').text("");
    return false;
});

$('#specialization').mousedown(function () {
    $('#specCheck').text("");
    return false;
});



