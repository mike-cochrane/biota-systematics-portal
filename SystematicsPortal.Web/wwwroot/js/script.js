$(document).ready(function() {
    $("#back-to-top").hide();
    var topOfOthDiv = $("#page-content").offset().top;
    $(window).scroll(function() {
        if($(window).scrollTop() > topOfOthDiv) { 
            $("#back-to-top").fadeIn(250);
        } else {
            $("#back-to-top").fadeOut(250);
        }
    });
});

function ToggleVisibility(el, collapsibleItem, showItem) {
    $(el).hide();
    $(collapsibleItem + "-" + showItem).show();
    $(collapsibleItem + "-content").slideToggle("fast");
}