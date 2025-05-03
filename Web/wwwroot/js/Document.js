let MaxFileLengthInMB = "";
$(document).ready(function () {
    getMaxFileLengthInMB();
});
function getMaxFileLengthInMB() {
    $.ajax({ type: "GET", url: "/" + currentLang + "/Document/GetConfigurationValue4MaxFileLengthInMB" })
        .done(function (parameterValue) { MaxFileLengthInMB = parseInt(parameterValue["parameter"]); });
}

$('#AddNewBtn').click(function () {
    $('#Documentform').find('input[name="Id"]').val(0);
});

$('#btnSubmitItem').click(function () {
  
    submitDocumentForm();
})

//binds to onchange event of your input field
$('#File').bind('change', function () {
    CurrentLengthInMB = this.files[0].size;
});

function submitDocumentForm() {
    formValidation('#Documentform');
    if (!$('#Documentform').valid()) {
        return;
    }

    const CurrentLengthInMB = parseInt(document.getElementById('File').files[0].size) / (1024 * 1024);

    var disabled = $('#Documentform').find(':input:disabled').removeAttr('disabled');
    var form = $('#Documentform')[0];

    if (CurrentLengthInMB > MaxFileLengthInMB) {
        $('#incomingDocMsg1').text(`Nuk lejohet madhesi e files me shume se [${MaxFileLengthInMB}MB] `);
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

                    //$('#btnSubmitItem').button('reset');
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
                    //$('#btnSubmitItem').button('reset');
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

function submitDeleteArticle(form, id) {
    var data = { id: id };
    var url = $('.deletedocument').data('formstr');

    $.post(url, data, function (d) {
        if (d.success === true) {
            location.reload(true);
        }
        else {
            cancelConfirm();

            $.notifyBar({
                // delay: 5000,
                html: d.msg,
                cssClass: "warning",
                animationSpeed: "speed"
            });
        }
    }, 'json');
}

$(".close").on('click', function () {
    $('#id').val(0);
    $('#name').val('');;
    $('#userMsg').text('');
    $('#userMsg').addClass('hidden');
});
function removeClassErorr() {
    var elms = document.querySelectorAll('.error');
    for (var i = 0; i < elms.length; i++) {
        elms[i].classList.remove("error");
    }
}
$('.close1').click(function () {
    removeClassErorr();
    $('#Documentform')[0].reset();

    $('#btnSubmitItem').prop('disabled', false);
    $("#incomingDocMsg1").attr("hidden", "hidden");

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
        return `<iframe src='https://view.officeapps.live.com/op/embed.aspx?src=http://lawdata.online/sq/Document/Download?filename=${fileName}' width='100%' height='100%' frameborder='0'></iframe>`;
    }
    else if (fileExe.toLowerCase() === "pdf") {
        return `<embed id="iframePreviewFile" class="h-100 w-100" src="/Documents/${fileName}" />`;
    }
}