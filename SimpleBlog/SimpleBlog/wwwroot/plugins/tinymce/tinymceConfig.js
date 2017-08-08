var Tinymce = {
    selector: 'textarea',
    heigth: '100%',
    width: '100%',
    init: function (options) {
        Tinymce.selector = options.selector ? options.selector : Tinymce.selector;
        Tinymce.heigth = options.heigth ? options.height : Tinymce.heigth;
        Tinymce.width = options.width ? options.width : Tinymce.width;
        tinymce.init({
            selector: Tinymce.selector,
            height: Tinymce.height,
            width: Tinymce.width,
            menubar: false,
            plugins: [
              'advlist autolink lists link image charmap print preview anchor',
              'searchreplace visualblocks code fullscreen',
              'insertdatetime media table contextmenu paste code'
            ],
            toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            content_css: '//www.tinymce.com/css/codepen.min.css'
        });
    },

    initAdvence: function(options) {
        Tinymce.selector = options.selector ? options.selector : Tinymce.selector;
        Tinymce.heigth = options.heigth ? options.height : Tinymce.heigth;
        Tinymce.width = options.width ? options.width : Tinymce.width;

        tinymce.init({
            selector: Tinymce.selector,
            height: Tinymce.height,
            width: Tinymce.width,
            theme: 'modern',
            plugins: [
              'advlist autolink lists link image charmap print preview hr anchor pagebreak',
              'searchreplace wordcount visualblocks visualchars code fullscreen',
              'insertdatetime media nonbreaking save table contextmenu directionality',
              'emoticons template paste textcolor colorpicker textpattern imagetools codesample toc'
            ],
            toolbar1: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            toolbar2: 'print preview media | forecolor backcolor emoticons | codesample',
            image_advtab: true,
            templates: [
              { title: 'Test template 1', content: 'Test 1' },
              { title: 'Test template 2', content: 'Test 2' }
            ],
            content_css: [
              '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });
    }
};