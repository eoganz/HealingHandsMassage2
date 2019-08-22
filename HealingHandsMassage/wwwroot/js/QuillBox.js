
function OpenEditor() {
    editor.enable();
    editor.focus();
}

function FinishUp() {
    editor.disable();
    var boxText = editor.getText();

    $.ajax({
        type: "POST",
        url: '/Home/CreateCarouselItem',
        dataType: "text",
        data: { boxText },
        traditional: true,
        success: function (data) {
            console.log(data);
        },
        error: console.log("it did not work"),
    });

}

var config = {
    readOnly: true
};

var editor = new Quill('.editText', config);
var delta = editor.getContents();
var json = JSON.stringify(delta);