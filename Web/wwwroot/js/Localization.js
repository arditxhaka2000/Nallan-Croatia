
//$("#SearchLanguages").select2();
//$("#SearchLanguages").chosen();

$('.EditBtn').click(function () {
    editLocalization($(this));
    //setTextEditOrAdd(true, '.modal-title');
});

var LocalizationFormclass = '#LocalizationForm';

$('#AddNewBtn').click(function () {
    LocalizationFormclass = '#LocalizationForm2';
    //setTextEditOrAdd(true, '.modal-title');
    $(LocalizationFormclass).find('input[name="Id"]').val(0);
});

function editLocalization(caller) {
    var id = caller.data('id');
    var keyname = caller.data('keyname');
    var resourcekey = caller.data('resourcekey');
    var languageid = caller.data('languageid');
    var keyvalue = caller.data('keyvalue');
    var description = caller.data('description');

    $('#Id').val(id);
    $('#keyname').val(keyname);
    $('#languageId').val(languageid);
    $('#keyvalue').val(keyvalue);
    $('#resourcekey').val(resourcekey);
    $('#description').val(description);

    $('#AddUpdateLocalization').modal('show');
}
$('#btnSubmitItem').click(function () {
    submitLocalizationForm();
})

$('#btnSubmitItem2').click(function () {
    LocalizationFormclass = '#LocalizationForm2';
    submitLocalizationForm();
})

function submitLocalizationForm() {
    //formValidation(LocalizationFormclass);
    //if (!$(LocalizationFormclass).valid()) {
    //    return;
    //}
    //var disabled = $(LocalizationFormclass).find(':input:disabled').removeAttr('disabled');
    //disabled.attr('disabled', 'disabled');
    var data = $(LocalizationFormclass).serialize();
    //ShowSavingAndDisabledButton(true, "#btnSubmitItem");
    var url = $(LocalizationFormclass).attr('action');
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            //ShowSavingAndDisabledButton(false, "#btnSubmitItem");
            $('#error-msg').text(d.msg);
            $('#error-msg').removeClass('d-none');
            $('#btnSubmit').button('reset');
            setTimeout(function () {
                $('#btnSubmit').button('reset');
            }, 1000);
        }
    }, 'json');
}
//$(LocalizationFormclass)[0].reset();
$(".close").on('click', function () {
    $('#id').val(0);
    ClearForm();


});

$('.close1').click(function () {
    $('#id').val(0);
    ClearForm();
    $(LocalizationFormclass)[0].reset();

    //$('#btnSubmitItem').prop('disabled', false);
    //$("#incomingDocMsg1").attr("hidden", "hidden");

});
function ClearForm() {
    $('#keyname').val('');
    $('#resourcekey').val('');
    $('#languageId').val('');
    $('#keyvalue').val('');
    $('#rezervekey').val('');
    $('#description').val('');
    $('#userMsg').text('');
    $('#error-msg').text('');
    $('#error-msg').addClass('d-none');
};
function formValidation(formId) {
    $.validator.messages.required = '';
    $(formId)
        .validate({
            rules: {
                '.required': {
                    required: true
                }
            },
            messages: {
                '.required': {
                    required: ''
                }
            }
        });
}