$(document).ready(function () {
    $("#selectedFile").change(function () {
        var files = this.files;
        var fileName = "";
        for (var i = 0; i < this.files.length; i++) {
            fileName = fileName + "/" + this.files[i].name;
        }
        $("#file-path").val(fileName);

    });

    $('#message-form').validate({
        errorPlacement: function (error, element) {
            return true;
        },
        rules: {
            message: {
                required: true
            }
        }
    });

    
});

function fillData(msgId, msg, page, topicId) {
    $("#editMessageId").val(msgId);
    $("#editMessageText").val(msg);
    $("#editPageNumber").val(page);
    $("#editTopicId").val(topicId);
}