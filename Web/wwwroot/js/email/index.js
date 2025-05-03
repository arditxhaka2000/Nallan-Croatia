
$('.sendEmail').click(function () {
    tinymce.triggerSave();
    let _id = $(this).attr("id");
    let _formid = $(this).data("formid");
    sendEmailFunction(_formid, _id);
});

function sendEmailFunction(formid, btnid) {
    formValidation(`#${formid}`);
    if (!$(`#${formid}`).valid()) {
        return;
    }
    var datas = $(`#${formid}`).serialize();
    var url = $(`#${formid}`).attr('action');
    ShowSavingAndDisabledButton(true, `#${btnid}`);
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'json',
        data: datas,
        beforeSend: function () {
            $('.loading-load').show()
        },
        success: function (res) {
            if (res.success == "true") {
                $('.loading-load').hide()
                msgShow("msgShow", "alert alert-success", res.msg);
                setTimeout(function () {
                    location.reload();
                },  3000);
            }
            else {
                $('.loading-load').hide()
                msgShow("msgShow", "alert alert-danger", res.msg);
                setTimeout(function () {
                    location.reload();
                }, 3000);
            }
        }
    });
}

function toggle(source) {
    var checkboxes = document.querySelectorAll('.select-email');
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i] != source)
            checkboxes[i].checked = source.checked;
    }
}


function msgShow(id, className, text) {
    $(`#${id}`).html(`
       <h4 class="${className}">${text}</h4>
    `);
}



$(".openBody").click(function () {
    let email = $(this).data("email");
    let subject = $(this).data("subject");
    let body = $(this).data("body");

    $("#email").val(email);
    $("#subject").val(subject);
    tinyMCE.get("body").setContent(body);

    $("#sendEmailModal").modal("show");
});