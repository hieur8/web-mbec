//This method generate an alias from an input text, return empty string if no valid character presents.
function generateAlias(inputText) {
    return generateAlias(inputText, 250, false);
}
function generateAliasNoSpace(inputText) {
    return generateAlias(inputText, 250, true);
}
function generateAlias(inputText, maxLenght, noSpace) {
    //lower chars
    inputText = inputText.replace(/æ|å|ä|à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    inputText = inputText.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    inputText = inputText.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    inputText = inputText.replace(/ø|ö|ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    inputText = inputText.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    inputText = inputText.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    inputText = inputText.replace(/đ/g, "d");
    inputText = inputText.replace(/ñ/g, "n");

    //upper chars
    inputText = inputText.replace(/Æ|Å|Ä|À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    inputText = inputText.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    inputText = inputText.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    inputText = inputText.replace(/Ø|Ö|Ó|Ò|Ỏ|Õ|Ọ|Ô|Ố|Ồ|Ổ|Ỗ|Ộ|Ơ|Ớ|Ờ|Ở|Ỡ|Ợ/g, "O");
    inputText = inputText.replace(/Ú|Ù|Ủ|Ũ|Ụ|Ư|Ứ|Ừ|Ử|Ữ|Ự/g, "U");
    inputText = inputText.replace(/Ý|Ỳ|Ỷ|Ỹ|Ỵ/g, "Y");
    inputText = inputText.replace(/Đ/g, "D");
    inputText = inputText.replace(/Ñ/g, "N");

    inputText = inputText.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, " ");

    // Remove invalid character
    var result = inputText.replace(/(^[^a-zA-Z0-9]+)|([^a-zA-Z0-9\-_\s])/g, "");
    //Replace all space with _
    if (noSpace) result = result.replace(/\s+[\-_]*/g, "-");
    else result = result.replace(/\s+[\-_]*/g, " ");

    result = result.replace(/-+-/g, "-"); //thay thế 2- thành 1-
    result = result.replace(/^\-+|\-+$/g, "");
    // trim space, - and _ of strim
    result = result.replace(/^[\s\-_]+|[\s\-_]+$/g, "");

    return result.substring(0, maxLenght);
}