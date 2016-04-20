$('document').ready(function () {
    $('#appointmenttime').hide();
});

$('#appoint').on('click', function () {
   // MorningTime();
    $('#appointmenttime').slideToggle(1000);
});
/*function MorningTime()
{
    var startTiming = prompt("Enter the Start Time ");
    var endTiming = prompt("Enter the End Time");
    startTiming = 0.00+parseFloat(startTiming.replace(":", "."));
     endTiming = 12.00 + parseFloat(endTiming.replace(":", "."));
     for(var counter = startTiming; counter <= endTiming ; counter += 0.15)
     {
         if (counter < 11.00)
         {
             $('#first-left').append($('<span>', {
                 text: (counter).toString()
             }));
             $('#first-left').append('<br/>')
         }
         else if (counter >= 11.00 && counter < 13.00)
         {
             $('#second-left').append($('<span>', {
                 text: (counter).toString()
             }));
             $('#second-left').append('<br/>')
         }
         else if (counter >= 13.00 && counter < 15.00)
         {
             $('#third-left').append($('<span>', {
                 text: (counter).toString()
             }));
             $('#third-left').append('<br/>')
         }

    }
        
}*/



