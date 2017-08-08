var SignupPopupWidth = 550;
var SignupPopupHeight = 370;

var SigninPopupWidth = 370;
var SigninPopupHeight = 365;

var FancyBox =
{
    width: null,
    height: null,
    href: null,
    closeBtn: true,
    padding: 0,
    selector: null,
    content: null,
    OverlayLocked: false,

    onCancel: null,
    beforeLoad: null,
    afterLoad: null,
    beforeShow: null,
    afterShow: null,
    beforeClose: null,
    afterClose: null,
    onUpdate: null,
    onPlayStart: null,
    onPlayEnd: null
};

FancyBox.Init = function (options) {

    FancyBox.width = options.width;
    FancyBox.height = options.height;
    FancyBox.href = options.href;
    FancyBox.closeBtn = options.closeBtn == undefined ? FancyBox.closeBtn : options.closeBtn;
    FancyBox.padding = options.padding == undefined ? FancyBox.padding : options.padding;
    FancyBox.selector = options.selector == undefined ? FancyBox.selector : options.selector;
    FancyBox.content = options.content == undefined ? FancyBox.content : options.content;
    FancyBox.OverlayLocked = options.OverlayLocked == undefined ? FancyBox.OverlayLocked : options.OverlayLocked;

    FancyBox.onCancel = options.onCancel == undefined ? FancyBox.onCancel : options.onCancel;
    FancyBox.beforeLoad = options.beforeLoad == undefined ? FancyBox.beforeLoad : options.beforeLoad;
    FancyBox.afterLoad = options.afterLoad == undefined ? FancyBox.afterLoad : options.afterLoad;
    FancyBox.beforeShow = options.beforeShow == undefined ? FancyBox.beforeShow : options.beforeShow;
    FancyBox.afterShow = options.afterShow == undefined ? FancyBox.afterShow : options.afterShow;
    FancyBox.beforeClose = options.beforeClose == undefined ? FancyBox.beforeClose : options.beforeClose;
    FancyBox.afterClose = options.afterClose == undefined ? FancyBox.afterClose : options.afterClose;
    FancyBox.onUpdate = options.onUpdate == undefined ? FancyBox.onUpdate : options.onUpdate;
    FancyBox.onPlayStart = options.onPlayStart == undefined ? FancyBox.onPlayStart : options.onPlayStart;
    FancyBox.onPlayEnd = options.onPlayEnd == undefined ? FancyBox.onPlayEnd : options.onPlayEnd;

    return FancyBox;
}

FancyBox.ShowPopup = function () {

    $.fancybox.open({
        href: FancyBox.href,
        type: 'iframe',
        content: FancyBox.content,
        padding: FancyBox.padding,
        width: FancyBox.width,
        height: FancyBox.height,
        closeBtn: FancyBox.closeBtn,
        fitToView: false,
        autoSize: false,
        scrolling: "no",
        openEffect: "elastic",
        closeEffect: "fadeOut",
        helpers:
            {
                overlay:
                    {
                        closeClick: false,
                        locked: FancyBox.OverlayLocked
                    }
            },
        onCancel: FancyBox.onCancel,
        beforeLoad: FancyBox.beforeLoad,
        afterLoad: FancyBox.afterLoad,
        beforeShow: FancyBox.beforeShow,
        afterShow: FancyBox.afterShow,
        beforeClose: FancyBox.beforeClose,
        afterClose: FancyBox.afterClose,
        onUpdate: FancyBox.onUpdate,
        onPlayStart: FancyBox.onPlayStart,
        onPlayEnd: FancyBox.onPlayEnd
    });
}

FancyBox.ShowImgPopup = function(){
    $.fancybox.open({
        href: FancyBox.href,
        padding: 0,
        type: 'image',
        openEffect: 'elastic',
        closeEffect: 'fadeOut',
        helpers: {
            overlay: {
                locked: false
            }
        }
    });
}

FancyBox.InitImageGallery = function () {
    $(FancyBox.selector).fancybox({
        padding: 0,
        loop: false,
        type: 'image',
        openEffect: 'elastic',
        closeEffect: 'fadeOut',
        helpers: {
            overlay: {
                locked: false
            }
        }
    });
}

FancyBox.ShowInlinePopup = function () {

    $.fancybox.open({
        href: FancyBox.href,
        content: FancyBox.content,
        padding: FancyBox.padding,
        width: FancyBox.width,
        height: FancyBox.height,
        closeBtn: FancyBox.closeBtn,
        fitToView: false,
        autoSize: false,
        scrolling: "no",
        openEffect: "fade",
        closeEffect: "fadeOut",
        helpers:
            {
                overlay:
                    {
                        closeClick: false,
                        locked: FancyBox.OverlayLocked
                    }
            },
        afterClose: FancyBox.afterClose
    });
}

FancyBox.ClosePopup = function () {
    $.fancybox.close(true);
}