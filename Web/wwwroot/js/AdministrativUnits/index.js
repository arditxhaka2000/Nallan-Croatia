$('#btnSubmitItem').click(function () {
    submitListItemForm();
});

$('#AddNewBtn').click(function () {
    setTextEditOrAdd(true, '.modal-title');
    $('#AdministrativeUnitForms').find('input[name="Id"]').val(0);
});
function submitListItemForm() {
    formValidation('#AdministrativeUnitForms');
    if (!$('#AdministrativeUnitForms').valid()) {
        return;
    }
    //var disabled = $('#AdministrativeUnitForms').find(':input:disabled').removeAttr('disabled');
    var data = $('#AdministrativeUnitForms').serialize();

    //disabled.attr('disabled', 'disabled');
    $('#btnSubmitItem').button('loading');
    var url = $('#AdministrativeUnitForms').attr('action');
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            $('#itemMsg').text(d.msg);
            $('#itemMsg').removeClass('hidden');
            $('#btnSubmitItem').button('reset');
            setTimeout(function () {
                $('#btnSubmitItem').button('reset');
            }, 3000);
        }
    }, 'json');
}

function editListItems(caller) {
    var listid = caller.data('listid');
    var listtransid = caller.data('listtransid');
    var name = caller.data('name');
    var nametransitive = caller.data('nametransitive');
    var listtypeid = caller.data('listtypeid');
    var active = caller.data('active');
    var code = caller.data('code');


    setTextEditOrAdd(false, '.modal-title');


    var isChecked = false;

    if (active === "True") {
        isChecked = true;

    }

    $('#Id').val(listid);
    $('#name').val(name);
    $('#code').val(code);
    $('#nametransitive').val(nametransitive);
    $('#listtypeid').val(listtypeid);

    showHidenCode(listtypeid);

    $('#listtransid').val(listtransid);
    $('#isactive').prop("checked", isChecked);
    $('#addUpdateUnits').modal('show');
}
$('.btnEditItem').click(function () {
    editListItems($(this));
});

$('.close1').click(function () {
    removeClassErorr();
    $('#AdministrativeUnitForms')[0].reset();
});

function submitDeleteArticle(form, id) {
    var data = { id: id };
    var url = $('#DeleteArticle').data('formstr');
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

function removeClassErorr() {
    var elms = document.querySelectorAll('.error');
    for (var i = 0; i < elms.length; i++) {
        elms[i].classList.remove("error");
    }
}





$("#listtypeid").change(function () {
    var currentVal = $(this).val();
    showHidenCode(currentVal);
});

function showHidenCode(typeId) {
    if (typeId == "14") {
        $("#codediv").attr("hidden", false);
        $("#code").prop('disabled', false);
    }
    else {
        $("#codediv").attr("hidden", true);
        $("#code").prop('disabled', true);
    }
}