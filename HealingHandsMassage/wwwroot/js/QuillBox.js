
function OpenEditor() {
    editor.enable();
    editor.focus();
}

function FinishUp() {
    editor.disable();
    var boxText = editor.getText();

    document.getElementById(editText).innerHTML = boxText;

}

var config = {
    readOnly: true
};

var editor = new Quill('.editText', config);
var delta = editor.getContents();
var json = JSON.stringify(delta);