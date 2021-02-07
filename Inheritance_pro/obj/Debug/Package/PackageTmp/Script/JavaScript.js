
function charChange(txt, keycode) {
    var charStr = String.fromCharCode(keycode)
    if (charStr == "ي") {
        txt.value = txt.value + "ی";
        event.preventDefault();
    }
    if (charStr == "ك") {
        txt.value = txt.value + "ک";
        event.preventDefault();
    }
}

//function cancelBack() {
//    if ((event.keyCode == 8 ||
//       (event.keyCode == 37 && event.altKey) ||
//       (event.keyCode == 39 && event.altKey))
//        &&
//       (event.srcElement.form == null || event.srcElement.isTextEdit == false)
//      ) {
//        event.cancelBubble = true;
//        event.returnValue = false;
//    }
//}

//function cancelBack(keycode) {
//    alert('asdasda');
//    if (keyCode == 8)
//        return false;
//}