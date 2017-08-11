$(function () {
    setDefaults();

    $("#category-code").numericInput();

    $("#categories-tree").jstree({});

    $("#save-btn").click(function() {
        if (categoryId) {
            updateCategory(updateUrl);
        } else {
            createCategory(createUrl);
        }

        return false;
    });

});

var categoryId, categoryParentId, updateUrl, deleteUrl;

function createCategory(url) {
    var caption = $("#category-caption").val();
    var code = $("#category-code").val();

    $.ajax({
        type: "POST",
        url: url,
        data: {
            ParentId: categoryParentId,
            Caption: caption,
            Code: code
        },
        dataType: "json",
        success: function(response) {
            if (response.isSuccess) {
                setDefaults();
            } else {
                console.log(response);

                bootbox.alert(globals.textAbort);

            }
        },
        error: function (response) {
            console.log("error");

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
                selector.text(caption);
                selector.attr("data-code", code);
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
    updateUrl = null;
    deleteUrl = null;

    $("#category-caption").val("");
    $("#category-code").val("");

}

function getSortedIndexes() {
    var sortIndexes = [];

    return sortIndexes;
}