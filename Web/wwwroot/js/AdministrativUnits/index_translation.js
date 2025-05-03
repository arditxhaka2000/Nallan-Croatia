$('#btnSubmitItem').click(function () {
    submitListItemForm();
});

$('#AddNewBtn').click(function () {
    setTextEditOrAdd(true, '.modal-title');
    $('#AdministrativeUnitTransForms').find('input[name="Id"]').val(0);
});
function submitListItemForm() {
    formValidation('#AdministrativeUnitTransForms');
    if (!$('#AdministrativeUnitTransForms').valid()) {
        return;
    }
    var disabled = $('#AdministrativeUnitTransForms').find(':input:disabled').removeAttr('disabled');
    var data = $('#AdministrativeUnitTransForms').serialize();
    disabled.attr('disabled', 'disabled');
    $('#btnSubmitItem').button('loading');
    var url = $('#AdministrativeUnitTransForms').attr('action');
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            $('#itemMsg').text(d.msg);
            $('#itemMsg').prop('hidden', false);
            setTimeout(function () {
                location.reload();
            }, 3000);
        }
    }, 'json');
}

function editListItems(caller) {
    var listtransid = caller.data('listtransid');
    var name = caller.data('name');
    var nametransitive = caller.data('nametransitive');
    var languageid = caller.data('languageid');
    var langname = caller.data('langname');
  
    setTextEditOrAdd(false, '.modal-title');

    if (listtransid > 0) {
        $('#listtransid').val(listtransid);
        $('#dropDownLang').prop("hidden", true);
        var htmlCode = '<h6 class="searchFilterParagraph">Language</h6><input class="form-control form-control-borderless required" type="text" placeholder="' + langname + '" disabled="">';
        $('#LangEdit').prop("hidden", false).html(htmlCode);
    }

    $('#name').val(name);
    $('#nametransitive').val(nametransitive); 
    $('#languageid').val(languageid);
    $('#addUpdateUnitsTrans').modal('show');
}
$('.btnEditItem').click(function () {
    editListItems($(this));
});

$('.close1').click(function () {
    removeClassErorr_1();
    $('#AdministrativeUnitTransForms').find('input[name="Id"]').val(0);
    $('#dropDownLang').prop("hidden", false);
    $('#LangEdit').prop("hidden", true);
    $('#AdministrativeUnitTransForms')[0].reset();
});

$('.DeleteListTrans').click(function () {
    var form = $(this).data('formstr');
    var id = $(this).data('detailid');
    $.confirm({
        confirm: function () {
            submitDeleteTranslationList(form, id);
        },
        cancel: function () {
            cancelConfirm();
        }
    });
});

function cancelConfirm() {
    $('.confirm').prop('disabled', false);
    $('.confirm').html('Yes');
}

function submitDeleteTranslationList(form, id) {
    var data = { id: id };
    var url = $('#DeleteListTrans').data('formstr');
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            cancelConfirm();
            $.notifyBar({
                delay: 5000,
                html: d.msg,
                cssClass: "error"
            });
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

function removeClassErorr_1() {
    var elms = document.querySelectorAll('.error');
    for (var i = 0; i < elms.length; i++) {
        elms[i].classList.remove("error");
    }
}