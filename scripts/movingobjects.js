$(window).scroll(function() {
    $(".slide-to-right-anim").each(function(){
        var pos = $(this).offset().top;

        var winTop = $(window).scrollTop();
        if (pos < winTop + 800) {
        $(this).addClass("slide-to-right");
        }
    });
});

$(window).scroll(function() {
    $(".slide-to-left-anim").each(function(){
        var pos = $(this).offset().top;

        var winTop = $(window).scrollTop();
        if (pos < winTop + 800) {
        $(this).addClass("slide-to-left");
        }
    });
});