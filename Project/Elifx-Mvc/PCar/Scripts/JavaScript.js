var targetClass = 'TargetAlias';
var aliasClass = 'Alias';

//Convert chuỗi có dấu thành không giấu
function ConvertToUnSign(obj) {
    var str = obj;
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");// tìm và thay thế các kí tự đặc biệt trong chuỗi sang kí tự -
    str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
    str = str.replace(/^\-+|\-+$/g, "");//cắt bỏ ký tự - ở đầu và cuối chuỗi
    return str;
}

//Convert Title thành alias
function AutoAlias(targetClass, aliasClass) {
    if (targetClass === null) {
        targetClass = 'TargetAlias';
    }
    if (aliasClass === null) {
        aliasClass = 'Alias';
    }
    if ($('#' + targetClass).length > 0) {
        $('#' + targetClass).keyup(function () {
            var alias = $(this).val();
            $('#' + aliasClass).val(ConvertToUnSign(alias));
        });
        //
        $('#' + aliasClass).unbind();
        $('#' + aliasClass).change(function () {
            $('#' + aliasClass).val(ConvertToUnSign($(this).val()));
        });
    } else {
        $('.' + targetClass).keyup(function () {
            var alias = $(this).val();
            $('.' + aliasClass).val(ConvertToUnSign(alias));
        });
        //
        $('.' + aliasClass).unbind();
        $('.' + aliasClass).change(function () {
            $('.' + aliasClass).val(ConvertToUnSign($(this).val()));
        });
    }
}


function BindUpload() {
    if (!$('.button-upload').length > 0) {
        var upload;
        var textBox = $('.upload');
        for (var i = 0; i < textBox.length; i++) {
            var uploadText = $(textBox[i]);
            uploadText.css('width', uploadText.width() - 70);
            uploadText.after('<button type="button" for="' + uploadText.attr('id') + '" class="button-upload ui-widget ui-state-default ui-corner-all">Upload</button>');
            $('.button-upload').click(function () {
                upload = $(this);
                // You can use the "CKFinder" class to render CKFinder in a page:
                var finder = new CKFinder();
                finder.selectActionFunction = setFileField;
                finder.popup();
            });
            
        }
    }
    if (!$('.add-percent').length > 0) {
        $('.input-percent').css('width', 40).after('<span class="add-percent">%</span>');
    }
}

 
//Tích hợp ckfunder cho input.upload;

function bindUl() {

    //if (!$('.button-upload').length > 0) {
    var upload;
    var textBox = $('.upload');
    for (var i = 0; i < textBox.length; i++) {
        console.log("Open Ckfinder");
        var uploadText = $(textBox[i]);
        uploadText.css('width', uploadText.width() - 70);
        uploadText.after('<button type="button" for="' + uploadText.attr('id') + '" class="button-upload ui-widget ui-state-default ui-corner-all">Upload</button>');
        $('.button-upload').click(function () {
            upload = $(this);
            // You can use the "CKFinder" class to render CKFinder in a page:
            var finder = new CKFinder();
            finder.basePath = '../files';
            finder.selectActionFunction = setFileField;
            finder.popup();
        });
        function setFileField(fileUrl) {
            $('#' + $(upload).attr('for')).val(fileUrl);
        }
    }
}
