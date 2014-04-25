$(function() {
    //Post Editor

    //Use debounce to throttle previews
    $(".post-editor .content").on("keyup", $.debounce(function() {
        var that = this;

        var markdown = $(that).val();

        $.post(
            '/Util/MarkdownTransform',
            markdown,
            function(data, textStatus, jqXHR) {
                $(".post-editor .post-preview").html(data);
            });

    }, 600));

});