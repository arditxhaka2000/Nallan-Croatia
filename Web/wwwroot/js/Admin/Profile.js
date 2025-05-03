

$('#updateProfile').click(function () {
    if (!$('#updateProfileForm').valid()) {
        return;
    }
    var data = $('#updateProfileForm').serialize();
    var lang = $("#langActive").val();
    var url = "/" + lang + "/Administration/UpdateProfile";
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            $('.oldpassword').show();
            $('#incorrectLbl').text(d.msg);
        }
    }, 'json');
});

$('.close').click(function () {
    $('#updateProfileModal').hide();
    $('#DefaultLanguageId').val(0);
});
$('#close').click(function () {
    $('#updateProfileModal').hide();
    $('#DefaultLanguageId').val(0);
});


$('#updateProfileForm').validate({
    rules: {
        DefaultLanguageId: 'required'
    },
    messages: {
        DefaultLanguageId: "The field is required!"
    }
});

