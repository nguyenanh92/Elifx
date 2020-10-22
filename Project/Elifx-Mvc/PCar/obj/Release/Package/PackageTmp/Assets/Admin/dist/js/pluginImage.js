function bindRightClick() {
    $('.allImage li').unbind();
    $('.allImage li').bind('contextmenu', function (e) {
        $('#context-menu').css('left', e.pageX + 'px');
        $('#context-menu').css('top', e.pageY + 'px');
        $('#context-menu').show();
        e.preventDefault();
        curentImg = $(this);
        return false;
    });
}
function sapxep() {
    var temp = 0;
    $(".allImage li").each(function () {
        $(this).find('input').each(function () {
            var id = $(this).attr("id");
            var name = $(this).attr("name");
            var abc = name.substring(name.indexOf('[') + 1, name.indexOf(']'));
            //console.log('name: ' + name + ' and : ' + abc);
            var idreplace = id.replace(abc, temp);
            var namereplace = name.replace(abc, temp);
            $(this).attr("id", idreplace);
            $(this).attr("name", namereplace);
        });
        temp++;
    });
    bindRightClick();
}


function loadHtmlForImage(val) {
    if ($('#EGalleryITems_' + val + '__Image').length > 0) {
        return loadHtmlForImage(++val);
    } else {
        //console.log(val);
        var image = '<input id="EGalleryITems_' + val + '__Image" name="EGalleryITems[' + val + '].Image" type="hidden" value="' + $('#img-thumb').val() + '"/>';
        var img = '<img src="' + $('#img-thumb').val() + '" width="100" height="80" />';
        return ('<li>' + image + img + '</li>');
    }
}