var AjaxLoader = new Object();

AjaxLoader.IsVisible = false;
AjaxLoader.html = '<div class="gm_loader"><div class="gm_loader_bg"></div><div class="gm_loader_content"><div><span class="gm_loader_logo"></span><span class="gm_loader_bar"></span></div></div></div>';

AjaxLoader.ShowLoader = function () {

    if (!AjaxLoader.IsVisible) {
        $("body").append(AjaxLoader.html);
        AjaxLoader.IsVisible = true;
    }
}

AjaxLoader.HideLoader = function () {
    if (AjaxLoader.IsVisible) {
        $(".gm_loader").remove();
        AjaxLoader.IsVisible = false;

    }
}

$.fn.extend({
    ShowLoader: function () {
        this.append(AjaxLoader.html);        
    },
    HideLoader: function () {
        this.find(".gm_loader").fadeOut(1500, function () { $(this).remove(); });
    }
});
