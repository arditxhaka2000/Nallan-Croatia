$('#btnSubmitItem').click(function () {
    /*tinymce.triggerSave();*/
    submitDocumentForm();
})

//binds to onchange event of your input field
let MaxFileLengthInMB = "";

$(document).ready(function () {
    getMaxFileLengthInMB();
});

$('#File').bind('change', function () {
    CurrentLengthInMB = this.files[0].size;
});
$('#AddNewBtn').click(function () {
    $('#Documentform').find('input[name="Id"]').val(0);
});
function getMaxFileLengthInMB() {
    $.ajax({ type: "GET", url: "/" + currentLang + "/Document/GetConfigurationValue4MaxFileLengthInMB" })
        .done(function (parameterValue) { MaxFileLengthInMB = parseInt(parameterValue["parameter"]); });
}


function submitDocumentForm() {
    formValidation('#Documentform');
    if (!$('#Documentform').valid()) {
        return;
    }

    const CurrentLengthInMB = parseInt(document.getElementById('File').files[0].size) / (1024 * 1024);

    var disabled = $('#Documentform').find(':input:disabled').removeAttr('disabled');
    var form = $('#Documentform')[0];

    if (CurrentLengthInMB > MaxFileLengthInMB) {
        $('#incomingDocMsg1').text(`Nuk lejohet madhesi e file-it me shume se [${MaxFileLengthInMB}MB] `);
        $('#incomingDocMsg1').removeClass('hidden');
        $("#incomingDocMsg1").removeAttr("hidden");
        return;
    }

    var _data = new FormData(form);
    if (_data.entries) {
        var data = new FormData();
        for (var p of _data) {
            if (p[1]) {
                // p[1] is the value of form entry
                data.append(p[0], p[1]);
            }
        } _data = data;
    }
    //disabled.attr('disabled', 'disabled');
    //$('#btnSubmitItem').button('Saving');
    ShowSavingAndDisabledButton(true, "#btnSubmitItem");
    var url = $('#Documentform').attr('action');
    $.ajax({
        url: url,
        type: 'POST',
        contentType: false,
        data: _data,
        processData: false,
        complete: function (result) {
            var d = result.responseJSON;
            if (result.status === 500) {
                $('#incomingDocMsg1').text('Invalid Data Exception');
                $('#incomingDocMsg1').removeClass('hidden');
                $("#incomingDocMsg1").removeAttr("hidden");
                setTimeout(function () {
                    $('#btnSubmitItem').button('reset');
                }, 1000);
            }
            else if (d.success === true) {
                location.reload(true);
            }
            else {
                $('#incomingDocMsg1').text(d.msg);
                $('#incomingDocMsg1').removeClass('hidden');
                setTimeout(function () {
                    $('#btnSubmitItem').button('reset');
                }, 1000);
            }
        }
    });
}

$('.deletedocument').click(function () {
    var id = $(this).data('detailid');
    var data = { id: id };
    var url = $(this).data('formstr');
    $.confirm({
        confirm: function () {
            $.post(url, data, function (d) {
                if (d.success === true) {
                    location.reload(true);
                }
                else {
                    cancelConfirm();
                }
            }, 'json');
        },
        cancel: function () {
            cancelConfirm();
        }
    });
});


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


$(".previewFile").on('click', function () {

    var fileName = $(this).data('filename');
    var filexe = $(this).data('filexe');
    var docName = $(this).data('docname');
    //SetData
    $("#docName").text(docName);
    $("#setIframe").html(setIframeOrEmbedHtml(fileName, filexe));
    $("#FilePreview").modal("show");
});

function setIframeOrEmbedHtml(fileName, fileExe) {

    if (fileExe.toLowerCase() === "doc" || fileExe.toLowerCase() === "docx") {
        return `<iframe src='https://view.officeapps.live.com/op/embed.aspx?src=http://lawdata.online/hr/Document/Download?filename=${fileName}' width='100%' height='100%' frameborder='0'></iframe>`;
    }
    else if (fileExe.toLowerCase() === "pdf") {
        return `<embed id="iframePreviewFile" class="h-100 w-100" src="/Documents/${fileName}" />`;
    }
}