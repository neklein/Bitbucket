$(document).ready(function() {
    loadItems();

    var addDollar = 1;
    var addQuarter = .25;
    var addDime = .1;
    var addNickel = .05;

    var total = 0;
    $('#money-in').val(total);
  

    $('#addDollar').on('click', function(event){
        total += addDollar;
        $('#money-in').val(total);
    });

    $('#addQuarter').on('click', function(event){
        total += addQuarter;
        $('#money-in').val(total);        
    });

    $('#addDime').on('click', function(event){
        total += addDime;
        $('#money-in').val(total);        
    });
    $('#addNickel').on('click', function(event){
        total += addNickel;
        $('#money-in').val(total);        
    });

    $('#purchase-button').on('click', function(event){
        var id = $('#item-in').val();
            $.ajax({
                type: 'GET',
                url: 'http://localhost:8080/money/' + total + '/item/' + id,
                success: function(data, status){
                    var change = '';
                    var quarters = 'Quarters: ' + data.quarters;
                    var dimes = 'Dimes: ' + data.dimes;
                    var nickels = 'Nickels: ' + data.nickels;
                    
                    if(data.quarters > 0)
                        change += quarters;
                    if(data.dimes > 0)
                        change += dimes;
                    if(nickels > 0)
                        change += nickels;
                    
                    $('#change-returned').val(change);    
                    $('#message-in').val('Thank you!');
                },
                error: function(data, status){
                    var message = data.responseJSON.message;
                    alert(message);
                }
        });

    });

    $('#change-return').on('click', function(event){
        $('#money-in').val(0);
        $('#change-returned').val('');    
        $('#message-in').val('');
        $('#item-in').val('');
        total = 0;
    });
});

function loadItems(){

    var column = $('#items-to-vend');
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(itemArray){
            $.each(itemArray, function(index, item){
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var row = '<div class = "col-sm-4" style = "text-align: center; background-color: grey"><ul>';
                    row += '<p><a onclick="selectItem(' + id + ')">' + name + '</a></p>';
                    row += '<p>$' + price + '</p>';
                    row += '<p>Quantity Left: ' + quantity + '</p>';
                    row += '</ul></div>';
                    

                column.append(row);

            });
        },
        error: function(){

        }
    })
}

function selectItem(id){
$('#item-in').val(id);
}



