$(document).ready(function () {
    $('h1').addClass('text-center');
    $('h2').addClass('text-center');
    $('.page-header').replaceAll('.myBannerHeading');
    $('#yellowHeading').text(function(){
        return $(this).text().replace('The Squad','Yellow Team');
    });

    $('#orangeTeamList').css('background-color', 'orange' );
    $('#blueTeamList').css('background-color', 'blue');
    $('#redTeamList').css('background-color', 'red');
    $('#yellowTeamList').css('background-color', 'yellow');

    $('#yellowTeamList').append('<li>Joseph Banks</li> ' + '<li>Simon Jones</li>');

    $('#oops').hide('slow');

    $('#footerPlaceholder').remove();

    $('.footer').append('<p>Nate Klein | natek21@gmail.com</p>')
    .css({'font-family': 'Courier new', 'font-size': '24px'});
});