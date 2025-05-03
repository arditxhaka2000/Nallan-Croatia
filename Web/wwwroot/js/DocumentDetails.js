
//$("#RelatedLegalDocId").chosen();
$('.searchjs-choice').chosen({ single_text: "Select one option", no_results_text: "Oops, nothing found!" });

var $disabledResults = $(".js-example-disabled-results");
$disabledResults.select2(
    {
        placeholder: "Select a law",
        dropdownParent: $('#addRelatedLegalDocs')
    });
//$disabledResults2.select2(
//    {
//        dropdownParent: $('#ByLawaddRelatedLegalDocs')
//    });
let _relatedlegaldocid = '0';
$('#AddNewBtn,#AddNewBtn2').click(function () {
    setTextEditOrAdd(true, '.modal-title');
    $('#RelatedLegalDocsForm').find('input[name="RowId"]').val(0);
    $('#ByLawRelatedLegalDocsForm').find('input[name="RowId"]').val(0);

});

$('#btnSubmitItemRelatedLegalDocs').click(function () {

    submitRelatedLegalDocsForm();
});
$('#btnSubmitItemByLawRelatedLegalDocs').click(function () {

    submitRelatedLegalDocsForm('ByLaw');

});

function submitRelatedLegalDocsForm(lawType = '') {
    const formName = `#${lawType}RelatedLegalDocsForm`;
    formValidation(formName);
    if (!$(formName).valid()) {
        return;
    }

    var data = $(formName).serialize();
    ShowSavingAndDisabledButton(true, "#btnSubmitItemRelatedLegalDocs");
    ShowSavingAndDisabledButton(true, "#btnSubmitItemByLawRelatedLegalDocs");

    var url = $(formName).find('input[Id="Ids"]').val() === '0' ? $(formName).attr('action') : $(formName).data('actionupdate');
    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            $('#itemMsg').text(d.msg);
            $('#itemMsg').prop('hidden', false);
            setTimeout(function () {
                //    location.reload(true);
                $('#itemMsg').text('');
                $('#itemMsg').prop('hidden', true);
                ShowSavingAndDisabledButton(false, "#btnSubmitItemRelatedLegalDocs");
                ShowSavingAndDisabledButton(false, "#btnSubmitItemByLawRelatedLegalDocs");
            }, 3000);
        }
    }, 'json');
}

$('#RelatedLegalTypeId').change(function () {
    var abolishedType = $(this).val();
    if (abolishedType == 34) {
        $('.Abolished-Date').show();
    }
    else {
        $('.Abolished-Date').hide();
    }
});

$('#___RelatedLegalTypeId').change(function () {
    var RLTypeId = $(this).val()

    formValidation('#RelatedLegalDocsForm');
    if (!$('#RelatedLegalDocsForm').valid()) {
        return;
    }

    if ($(this).val() === '0') {
        RLTypeId = '0';
        $('.searchjs-choice').empty();
        $(".searchjs-choice").val([]).trigger("chosen:updated");
        return;
    }

    var RootId = $("#LegalDocId").val();

    $('.searchjs-choice').empty();

    $(".searchjs-choice").val([]).trigger("chosen:updated");

    $.get(`/${currentLang}/Root/GetAllWithOutCurrentRootId?RootId=${RootId}&RootTypeId=${RLTypeId}`, function (res) {
        $(".searchjs-choice").val([]).trigger("chosen:updated");
        if (res.success === true) {
            $.each(res.data, function (id, obj) {
                var newOption = $(`<option value=${obj.id}>${obj.name}</option>`);
                $('.searchjs-choice').append(newOption);
            });
            $('.searchjs-choice').val(_relatedlegaldocid)
            $('.searchjs-choice').trigger("chosen:updated");
        }
        else {
            $('.searchjs-choice').empty();
            $(".searchjs-choice").val([]).trigger("chosen:updated");
        }
    });
});

$('.btnEditItem').click(function () {
    $('.Abolished-Date').hide();
    editRelatedLegalDocs($(this));
});

$('.btnDeleteItem').click(function () {
    var id = $(this).data('id');
    $('#_RelatedLegalDocId').val(id);
    $(`#confirmDelete`).modal('show');
});


$(".deleteModal").click(function () {
    ShowSavingAndDisabledButton(true, "#deleteBtnModal");
    $("#deleteSubmitForm").submit();
});

$('.btnEditByLawItem').click(function () {
    editRelatedLegalDocs($(this), 'ByLaw');
});

function editRelatedLegalDocs(caller, lawType = '') {
    const formName = `#${lawType}RelatedLegalDocsForm`;
    var id = caller.data('id');
    var relatedlegaldocid = _relatedlegaldocid = caller.data('relatedlegaldocid');
    var relatedlegaltypeid = caller.data('relatedlegaltypeid');

    setTextEditOrAdd(false, '.modal-title');


    //$('#Ids').val(id);
    $(formName).find('input[Id="Ids"]').val(id);
    $('#RelatedLegalTypeId').val(relatedlegaltypeid);
    // $(formName).find('input[Id="RelatedLegalTypeId"]').trigger("change"); 

    if (lawType == 'ByLaw') {
        $(`.${lawType}RelatedLegalDocId`).val(relatedlegaldocid).trigger("chosen:updated");
    }
    else {
        $(`.${lawType}RelatedLegalDocId`).val(relatedlegaldocid);
        $(`.${lawType}RelatedLegalDocId`).trigger("change");
    }
    $(`#${lawType}addRelatedLegalDocs`).modal('show');
}

$('.close1').click(function () {
    _relatedlegaldocid = '0';

    $('.Abolished-Date').hide();

    $('#RelatedLegalDocsForm').find('input[name="RowId"]').val(0);
    $('#ByLawRelatedLegalDocsForm').find('input[name="RowId"]').val(0);
    $('#RelatedLegalDocsForm')[0].reset();
    $('#ByLawRelatedLegalDocsForm')[0].reset();
    $('.chosen-select')
        .find('option:selected').prop('selected', false)
        .end().trigger('chosen:updated');


    const elms = document.querySelectorAll('[class$="error"]');  // id ends with Error
    for (var i = 0; i < elms.length; i++) {

        elms[i].classList.remove("error");
    }


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