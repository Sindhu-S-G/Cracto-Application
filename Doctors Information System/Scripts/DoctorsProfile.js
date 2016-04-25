$('document').ready(function () {
    $('.editPart').hide();
    $('.EditQual').hide();
    $('#EditedQual').hide();
    $('#selectOption').hide();
    //$('.SetTimings').hide();
});
$('#EditingInfo').on('click', function () {
    $('.info-part').hide();
    $('.editPart').show();
});
$('#SaveChanges').on('click', function () {
    $('.editPart').hide();
    $('.info-part').show();
});
$('#CancelChanges').on('click', function () {
    $('.editPart').hide();
    $('.info-part').show();
});

/*Qualification*/

$('#EditingQual').on('click', function () {
    $('#EduQual').slideUp();
    $('#EditedQual').slideDown();
});
$('#SaveQual').on('click', function () {
    $('#EditedQual').slideUp();
    $('#EduQual').slideDown();
});
$('#CancelQual').on('click', function () {
    $('#EditedQual').slideUp();
    $('#EduQual').slideDown();
});
$('#QualAdd').on('click', function () {
    $('#inputQual').append($('<input>',{
        class : 'form-control TextStyles',
        placeholder : 'Qualifications',
        id : 'qual'
    }))
});

/*Specialization*/

$('#EditingSpzl').on('click', function () {
    $('#spzDetails').slideUp();
    $('#spzEdit').slideDown();
});
$('#SaveSpzl').on('click', function () {
    $('#spzEdit').slideUp();
    $('#spzDetails').slideDown();
    $('#selectOption').text("(Specialization)");
});
$('#CancelSpzl').on('click', function () {
    $('#spzEdit').slideUp();
    $('#spzDetails').slideDown();
});
$('#SpzlAdd').on('click', function () {
    $('#SpzlAdd').hide();
    $('#inputSpzl').append($('<select>', {
        class: 'form-control TextStyles ',
        placeholder: 'Specializations',
        id: 'selectOption'
    }))
        $.ajax({
            url: '/DoctorsProfile/SpecializationList',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $.each(data, function (index, itemData) {
                    $('#selectOption').append($('<option/>', {
                        value: itemData.SpecializationId,
                        text: itemData.SpecializationName
                    }))
                });
            }
        });
        $('#selectOption').on('change', function () {
            var specialization = $('#selectOption').val();
            if (specialization != "")
            {
                $.ajax({
                    url: '/DoctorsProfile/GetSpecialization',
                    type: 'POST',
                    data: { SpecializationId: specialization },
                    success: function (data) {
                        $.each(data, function (index, itemData) {
                            $('#inputSpzl').append($('<span/>', {
                                class:'hidden-span',
                                text: itemData.SpecializationName
                            }))

                            $('#spzDetails').append($('<span/>', {
                                class: 'hidden-span',
                                text: itemData.SpecializationName
                            }))
                        });
                     }
                });
                
                $('#selectOption').remove();
                $('#SpzlAdd').show();
            }
        });
});

/*Time Settings*/
$('#EditingTiming').on('click', function () {
    $('.SetTimings').slideDown();
    $('#timeDetails').slideUp();
});

$('#SaveTime').on('click', function () {
    $('.SetTimings').slideUp();
    $('#timeDetails').slideDown();
});

$('#CancelTime').on('click', function () {
    $('.SetTimings').slideUp();
    $('#timeDetails').slideDown();
});

