$(function() {
    $("#users-table").dataTable({
        "columnDefs": [{
            "targets": [-1, -2], // column or columns numbers
        "orderable": false  // set orderable for selected columns
    }]
    });

    $(".delete-btn").click(function() {
        var url = $(this).attr("href");

        bootbox.confirm("ნამდვილად გსურთ წაშლა?",
            function(result) {
                if (result) {
                    window.location = url;
                }
            });

        return false;
    });
});