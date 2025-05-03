$('#btnSubmitItem').click(function () {
    submitListItemForm();
});
$('.EditBtn').click(function () {
    editList($(this));
});
function editList(caller) {
    var languageid = caller.data('languageid');
    var name = caller.data('name');
    var active = caller.data('isactive');
    var code = caller.data('code');
    var isChecked = false;
    if (active === "True") {
        isChecked = true;
    }
    $('#id').val(languageid);
    $('#name').val(name);
    $('#code').val(code);
    $('#active').prop("checked", isChecked);
    $("#editList").modal('show');  
}
$('#LanguageListForm')[0].reset();
$(".close").on('click', function () {
    $('#id').val(0);
    $('#name').val('');;
    $('#userMsg').text('');
    $('#userMsg').addClass('hidden');
});
function submitListItemForm() {
    formValidation('#LanguageListForm');
    if (!$('#LanguageListForm').valid()) {
        return;
    }
    var disabled = $('#LanguageListForm').find(':input:disabled').removeAttr('disabled');
    disabled.attr('disabled', 'disabled');
    $('#btnSubmitItem').html('Saving');
    var data = $('#LanguageListForm').serialize();
    var url = $('#LanguageListForm').attr('action');
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            $('#btnSubmitItem').html('Ruaj');
            $('#btnSubmitItem').button('reset');
            $('#btnSubmitItem').text(d.msg);
            $('#userMsg').removeClass('hidden');
        }
    }, 'json');
}
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