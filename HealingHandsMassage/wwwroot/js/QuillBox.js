
function OpenEditor() {
    editor.enable();
    editor.focus();
}

function FinishUp() {
    editor.disable();
    var boxText = editor.getText();

    var model = new Object();
    model.TextInJson = boxText;
    model.ImagePath = "";

    jQuery.ajax({
        type: "POST",
        url: '/home/CreateCarouselItem',
        dataType: "text",
        contentType: "application/json; cahrset=utf-8",
        data: JSON.stringify({ Item: model }),
        success: function (data) {
            alert(data);
        },
        failure: function (errMsg) {
            alert(errMsg);
        }
    });


    return model;
}

var config = {
    readOnly: true
};

var editor = new Quill('.editText', config);
var delta = editor.getContents();
var json = JSON.stringify(delta);