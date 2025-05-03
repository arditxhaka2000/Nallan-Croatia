$(document).ready(function () {

    let rootid =  $('#rootid').val();

    $.ajax({
        url: '/' + currentLang +'/Root/Detail4LegalDocPartial?RootId=' + rootid,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { 
            $('#scrolli').html(result)
        },
        error: function (xhr, status) { 
        },
    });

    //$('#sidebarCollapse1').on('click', function () {
    //    $('#sidebar1').toggleClass('active');
    //    if ($("#sidebar1").hasClass("active")) {
    //        $("#sidebarCollapse1").html('Open PDF');
    //    }
    //    else {
    //        $("#sidebarCollapse1").html('Close PDF');


    //    }
    //});
});
