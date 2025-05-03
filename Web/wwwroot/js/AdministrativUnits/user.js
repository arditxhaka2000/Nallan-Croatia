$('#btnSubmitItem').click(function () {
    submitListItemForm();
});

function formValidation(formId) {

    $.validator.messages.required = '';

    $(formId).validate({
        rules: {
            '.required': { reqired: true }
        },
        messages: {
            '.required': { required: '' }
        }
    });
}

function submitListItemForm() {
    var disabled = $('#AdministrativeUnitForms').find(':input:disabled').removeAttr('disabled');
    var data = $('#AdministrativeUnitForms').serialize();
    var currentAction = $('#formOperation').val();
    var url = $('#AdministrativeUnitForms').data(currentAction);
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            $('#itemMsg').text(d.msg);
            $('#itemMsg').prop('hidden', false);
            setTimeout(function () {
                //location.reload(true);
                $('#itemMsg').text('');
                $('#itemMsg').prop('hidden', true);
            }, 3000);
        }
    }, 'json');
}

//Edit User

function editUser(caller) {
 
    var username = caller.data('username');
    var Firstname = caller.data('firstname');
    var Lastname = caller.data('lastname');
    var email = caller.data('email');
    var jobtitle = caller.data('jobtitle');
    var roleid = caller.data('roleid');
    var defaultlangid = caller.data('defaultlangid');
    var active = caller.data('active');
    roleid = roleid.toUpperCase();
    var municipalities = caller.data('municipalities');
    var RoleElement = $('input.roles-checks[id="' + roleid + '"]');
    $('#Username').val(username);
    $('#Email').val(email);
    $('#JobTitle').val(jobtitle);
    RoleElement.prop('checked', true);
    $('#DefaultLanguageId').val(defaultlangid);
    $('#Firstname').val(Firstname);
    $('#LastName').val(Lastname);
    if (active === 'True') {
        $('#active').prop('checked', true);
    }
    $('#formOperation').val('update');

     $("#SearchMunicipalities").val(municipalities).trigger("change")

    $("#UserPasswordDiv").prop("hidden", true);
    $('#createUser').modal('show');
    $('#pass').hide();

}

$('.edit-user').click(function () {
    editUser($(this));
});

$('.close').click(function () {
    $('#pass').show();
    $('#AdministrativeUnitForms')[0].reset();
    $('#createUser').hide();
    $("#UserPasswordDiv").prop("hidden", false);
});

$('.close1').click(function () {
    $('#createUser').modal('hide');
    var disabled = $('#AdministrativeUnitForms').find(':input:disabled').removeAttr('disabled');
    $('#pass').show();
    $('#AdministrativeUnitForms')[0].reset();
    $("#UserPasswordDiv").prop("hidden", false);
});

//reset pw
function changeUserPass(caller) {
    var UserName = caller.data('username');
    $('#UserName2').attr('disabled', true).val(UserName);
    $('#hiddenUsername').val(UserName);
    $('#changePassModal').modal('show');
}

$('.resetUserPass').click(function () {
    changeUserPass($(this));
});

$('#btnSubmitChangePass').click(function () {
    $('#btnSubmitChangePass').html('Duke u ruajtur');
    $('#btnSubmitChangePass').prop('disabled', true);
    submitUserPassChange();
});

function submitUserPassChange() {
    var data = $('#changePassForm').serialize();
    var url = $('#changePassForm').data("reset");
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);

        }
        else {
            $('#btnSubmitChangePass').html('Ruaj');
            $('#btnSubmitChangePass').prop('disabled', false);
            $('#passwordMsg').text(d.msg);
            $('#passwordMsg').removeClass('hidden');

        }
    }, 'json');
}
