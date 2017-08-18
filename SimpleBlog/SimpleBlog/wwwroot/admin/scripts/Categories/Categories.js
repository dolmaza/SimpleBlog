$(function () {
    setDefaults();
    initButtons();

    $("#category-code").numericInput();

    initJsTree();

    $("#refresh-btn").click(function() {
        refresh();
        return false;
    });

    $("#category-caption, #category-code").focus(function() {
        initButtons(false, true);
    });

    $("#category-caption, #category-code").blur(function () {
        initButtons();
    });

    $("#cancel-btn").click(function () {
        refresh();
        return false;
    });

    $("#save-btn").click(function() {
        if (shouldCreate) {
            createCategory(createUrl);
        } else {
            updateCategory(updateUrl);
        }

        return false;
    });

    $("#update-btn").click(function() {
        $("#category-caption").val(categoryCaption);
        $("#category-code").val(categoryCode);
        initButtons(false, true,true);

        return false;
    });

    $("#create-btn").click(function () {
        initButtons(false, true, true);
        shouldCreate = true;
        return false;
    });

});

var jsTree, categoryId, categoryParentId, categoryCaption, categoryCode, updateUrl, deleteUrl, shouldCreate;

function initJsTree() {

    jsTree = $("#categories-tree").on("changed.jstree", function (e, data) {
        var node = data.instance.get_node(data.selected[0]);
        console.log(node);
        categoryId = node.id;
        if (node.data) {
            categoryParentId = node.data.parentId;
            updateUrl = node.data.updateUrl;
            deleteUrl = node.data.deleteUrl;
            categoryCaption = node.data.caption;
            categoryCode = node.data.code;
        }
        
        initButtons(true);

    }).jstree({
        'core': {
            'multiple': false
        }
    });

}

function createCategory(url) {
    var caption = $("#category-caption").val();
    var code = $("#category-code").val();

    $.ajax({
        type: "POST",
        url: url,
        data: {
            ParentId: categoryId,
            Caption: caption,
            Code: code
        },
        dataType: "json",
        success: function(response) {
            if (response.isSuccess) {
                refresh();
            } else {
                bootbox.alert(globals.textAbort);

            }
        },
        error: function (response) {
            bootbox.alert(globals.textAbort);
        }
    });
}

function updateCategory(url) {
    var caption = $("#category-caption").val();
    var code = $("#category-code").val();

    $.ajax({
        type: "POST",
        url: url,
        data: {
            Id: categoryId,
            ParentId: categoryParentId,
            Caption: caption,
            Code: code
        },
        dataType: "json",
        success: function (response) {
            if (response.isSuccess) {
                var selector = $("#" + categoryId);
                selector.find("a span").text(caption + " - " + code);
                selector.attr("data-code", code);
                refresh();
            } else {
                bootbox.alert(globals.textAbort);
            }
        },
        error: function (response) {
            bootbox.alert(globals.textAbort);
        }
    });
}

function syncSortIndexes(url) {
    $.ajax({
        type: "POST",
        url: url,
        data: getSortedIndexes(),
        dataType: "json",
        success: function (response) {
            
        },
        error: function (response) {
            bootbox.alert(globals.textAbort);
        }
    });
}

function getData(url) {
    
}

function setDefaults() {
    categoryId = null;
    categoryParentId = null;
    categoryCaption = null;
    categoryCode = null;
    updateUrl = null;
    deleteUrl = null;
    shouldCreate = false;

    $("#category-caption").val("");
    $("#category-code").val("");

}

function initButtons(enableActionButtons, enableSaveButton, hideActionButtons) {
    if (enableActionButtons) {
        $("#category-control-btn-group a").removeClass("disabled");
    } else {
        $("#category-control-btn-group a").addClass("disabled");
    }

    if (enableSaveButton) {
        $("#save-btn").removeClass("disabled");
    } else {
        $("#save-btn").addClass("disabled");
    }

    if (hideActionButtons) {
        $("#category-control-btn-group a").hide();
        $("#cancel-btn").show();

    } else {
        $("#category-control-btn-group a").show();
        $("#cancel-btn").hide();
    }
}

function getSortedIndexes() {
    var sortIndexes = [];

    return sortIndexes;
}

function refresh() {
    setDefaults();
    initButtons();
    console.log(jsTree);
}