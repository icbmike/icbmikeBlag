$(function() {
    //Post Editor

    //Use debounce to throttle previews
    $(".post-editor .content").on("keyup", $.debounce(function() {
        var that = this;
        console.log(that);
    }, 600));

});