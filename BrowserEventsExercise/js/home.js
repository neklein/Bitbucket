$(document).ready(function () {
    $('#akronInfoDiv').css('display', 'none');
    $('#minneapolisInfoDiv').css('display', 'none');
    $('#louisvilleInfoDiv').css('display', 'none');

    $('#mainButton').on('click', function(){
        $('#akronInfoDiv').hide();
        $('#minneapolisInfoDiv').hide();
        $('#louisvilleInfoDiv').hide();
        $('#mainInfoDiv').css('display', 'block');
    });

    $('#akronButton').on('click', function(){
        $('#mainInfoDiv').hide();
        $('#minneapolisInfoDiv').hide();
        $('#louisvilleInfoDiv').hide();
        $('#akronInfoDiv').css('display', 'block');
        $('#akronWeather').hide();

        $('#akronWeatherButton').on('click', function(){
            $('#akronWeather').toggle('slow');
        });
    });
   
    $('#minneapolisButton').on('click', function(){
        $('#mainInfoDiv').hide();
        $('#akronInfoDiv').hide();
        $('#louisvilleInfoDiv').hide();
        $('#minneapolisInfoDiv').css('display', 'block');
        $('#minneapolisWeather').hide();
        
        $('#minneapolisWeatherButton').on('click', function(){
            $('#minneapolisWeather').toggle('slow');
        });
    });

    $('#louisvilleButton').on('click', function(){
        $('#mainInfoDiv').hide();
        $('#minneapolisInfoDiv').hide();
        $('#akronInfoDiv').hide();
        $('#louisvilleInfoDiv').css('display', 'block');
        $('#louisvilleWeather').hide();
        
        $('#louisvilleWeatherButton').on('click', function(){
            $('#louisvilleWeather').toggle('slow');
        });
    });

    $('td').hover(
        function(){
            $(this).css('background-color', 'WhiteSmoke');
    },
        function(){
            $(this).css('background-color', '');
    })
});