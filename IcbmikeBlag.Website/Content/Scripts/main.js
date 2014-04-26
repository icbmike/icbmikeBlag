$(function() {
    //Post Editor

    //Use debounce to throttle previews
    $(".post-editor .content").on("keyup", $.debounce(function() {
        var that = this;

        var markdown = $(that).val();

        $.post(
            '/Util/TransformMarkdown',
            {markdown: markdown},
            function(data, textStatus, jqXHR) {
                $(".post-editor .post-preview").html(data);
            });

    }, 600));


    //Reply visibility toggling

    $(".comment header a").on("click", function() {
        var that = this;
        var comment = $(that).closest(".comment");
        var replyEditor = $(comment.find(".reply-editor"));

        if (replyEditor.is(":visible")) {
            replyEditor.hide();
        } else {
            replyEditor.show();
        }
    });

});