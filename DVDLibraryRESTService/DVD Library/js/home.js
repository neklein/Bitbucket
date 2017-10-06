$(document).ready(function() {
    loadDvds();

    $('#create-dvd-button').on('click', function(){
        $('#errorMessages').empty();
        
            $('#dvd-display').hide();
            $('#dvd-list').hide();
            $('#createFormDiv').show();
    });        

    $('#create-button').click(function(event){
        $.ajax({
            type: 'POST',
            url: 'http://localhost:8080/dvd',
            data: JSON.stringify({

                title: $('#create-dvd-title').val(),
                realeaseYear: $('#create-release-year').val(),
                director: $('#create-director').val(),
                rating: $('#create-rating').val(),
                notes: $('#create-notes').val()

            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type' : 'application/json'
            },
            'dataType' : 'json',
            success: function(){
                $('#errorMessages').empty();
                $('#create-dvd-title').val('');
                $('#create-release-year').val('');
                $('#create-director').val('');
                $('#create-rating').val('');
                $('#create-notes').val('');
                
                $('#createFormDiv').hide();
                $('#dvd-display').show();
                $('#dvd-list').show();
    
                loadDvds();
            },
            error: function(){
                $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later'))    
                
            }
        })
    });
    $('#search-button').click(function(event){
        $('#errorMessages').empty();
        
            var category = $('#searchCategory').val();
            var term = $('#search-term-input').val();

            
        $.ajax({
            type: 'GET',
            url: 'http://localhost:8080/dvds/' + category + '/' + term,
            headers: {
                        'Accept': 'application/json',
                        'Content-Type' : 'application/json'
            },
            'dataType' : 'json',       
            success: function(dvdArray){     
                
                $.each(dvdArray, function(index, dvd){
                            
                    var contentRows = $('#searchContentRows');
                            
                    var title = dvd.title;
                    var realeaseYear = dvd.realeaseYear;
                    var director = dvd.director;
                    var rating = dvd.rating;
                    var dvdId = dvd.dvdId;

                    var row = '<tr>';
                    row += '<td><a onclick="accessDvd(' + dvdId + ')">' + title + '</a></td>';
                    row += '<td>' + realeaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a></td>';
                    row += '<td><a onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';

                    contentRows.append(row);
        
                })
                $('#dvd-display').hide();
                $('#dvd-list').hide();
                $('#searchFormDiv').show();                
            },
            error: function(){
                $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Please select a valid search category and search term.'))

            }
        })
    });
    
    $('#edit-button').click(function(event){
        $.ajax({
            type: 'PUT',
            url: 'http://localhost:8080/dvd/' + $('#edit-dvd-id').val(),
            data: JSON.stringify({
                dvdId: $('#edit-dvd-id').val(),
                title: $('#edit-dvd-title').val(),
                realeaseYear: $('#edit-release-year').val(),
                director: $('#edit-director').val(),
                rating: $('#edit-rating').val(),
                notes: $('#edit-notes').val()

            }),
            headers: {
                'Accept' : 'application/json',
                'Content-Type' : 'application/json'
            },
            success: function() {
                $('#errorMessages').empty();
                hideEditForm();
            },
            error: function (){
                $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later.'))

            }
        })
    });

});

function hideCreateForm(){
    $('#errorMessages').empty();
    
    $('#create-dvd-title').val('');
    $('#create-release-year').val('');
    $('#create-director').val('');
    $('#create-rating').val('');
    $('#create-notes').val('');
    
    $('#createFormDiv').hide();
    $('#dvd-display').show();
    $('#dvd-list').show();

    loadDvds();
}

function loadDvds(){
    clearDvdTable();
    
    var contentRows = $('#contentRows');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvds',
        success: function(dvdArray){
            $.each(dvdArray, function(index, dvd){
                var title = dvd.title;
                var realeaseYear = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var dvdId = dvd.dvdId

                var row = '<tr>';
                    row += '<td><a onclick="accessDvd(' + dvdId + ')">' + title + '</a></td>';
                    row += '<td>' + realeaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a></td>';
                    row += '<td><a onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';

                contentRows.append(row);
            });
        },
        error: function(){
            $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later'))
        }
    });
}

function accessDvd(dvdId){
    $('#errorMessages').empty();
    
            $.ajax({
                type: 'GET',
                url: 'http://localhost:8080/dvd/' + dvdId,
                success: function(data, status){
                    $('#singleDvdTitle').append(data.title),
                    $('#singleDvdReleaseYear').append(data.realeaseYear),
                    $('#singleDvdDirector').append(data.director),
                    $('#singleDvdRating').append(data.rating),
                    $('#singleDvdNotes').append(data.notes)
                },
                error: function(){
                    $('#errorMessages')
                    .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                    .text('Error calling web service. Please try again later'))
                }
            })
    
            $('#dvd-display').hide();
            $('#dvd-list').hide();
            $('#singleDvd').show();

}

function hideSingleDvd(){
    $('#errorMessages').empty();
    $('#singleDvdTitle').empty();
    $('#singleDvdReleaseYear').empty();
    $('#singleDvdDirector').empty();
    $('#singleDvdRating').empty();
    $('#singleDvdNotes').empty();

    $('#singleDvd').hide();
    $('#dvd-display').show();
    $('#dvd-list').show();

    loadDvds();

}

function showEditForm(dvdId){
    $('#errorMessages').empty();
    
            $.ajax({
                type: 'GET',
                url: 'http://localhost:8080/dvd/' + dvdId,
                success: function(data, status){
                    $('#editDvdHeader').append(data.title),
                    
                    $('#edit-dvd-title').val(data.title),
                    $('#edit-release-year').val(data.realeaseYear),
                    $('#edit-director').val(data.director),
                    $('#edit-rating').val(data.rating),
                    $('#edit-notes').val(data.notes),
                    $('#edit-dvd-id').val(data.dvdId)                
                },
                error: function(){
                    $('#errorMessages')
                    .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                    .text('Error calling web service. Please try again later'))
                }
            })
    
            $('#dvd-display').hide();
            $('#dvd-list').hide();
            $('#editFormDiv').show();
    
}

function hideEditForm(){
    $('#errorMessages').empty();
    $('#editDvdHeader').empty();
    
    $('#edit-dvd-title').val('');
    $('#edit-release-year').val('');
    $('#edit-director').val('');
    $('#edit-rating').val('');
    $('#edit-notes').val('');
    
    $('#editFormDiv').hide();
    $('#dvd-display').show();
    $('#dvd-list').show();

    loadDvds();

}

function deleteDvd(dvdId){
    
    if(confirm("Are you sure you want to delete this dvd?")){
        $.ajax({
            type: 'DELETE',
            url: 'http://localhost:8080/dvd/' + dvdId,
            success: function(){
                loadDvds();
            },
            error: function(){
                $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later'))
    
            }
        });
    };
}

function clearDvdTable(){
    $('#contentRows').empty();
}

function hideSearchDiv(){
    $('#searchContentRows').empty();

    $('#searchFormDiv').hide();                    
    $('#dvd-display').show();
    $('#dvd-list').show();

    loadDvds();

}
