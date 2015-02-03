function ValidateSpecialCharacter() {
    var code;
    if (document.all) { //判断是否是IE浏览器
        code = window.event.keyCode;
    } else {
        code = arguments.callee.caller.arguments[0].which;
    }
    var character = String.fromCharCode(code);
    //var txt = new RegExp("[ ,\\`,\\~,\\!,\\@,\#,\\$,\\%,\\^,\\+,\\*,\\&,\\\\,\\/,\\?,\\|,\\:,\\.,\\<,\\>,\\{,\\},\\(,\\),\\'',\\;,\\=,\"]");
    var txt = new RegExp("[\\\\,\\/,\\|,\\<,\\>,,\\(,\\),\\'']");
    //特殊字符正则表达式 
    if (txt.test(character)) {
        if (document.all) {
            window.event.returnValue = false;
        } else {
            arguments.callee.caller.arguments[0].preventDefault();
        }
    }
}