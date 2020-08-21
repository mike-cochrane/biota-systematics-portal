$(document).ready(function() {
    $("#back-to-top").hide(); //hide your div initially
    var topOfOthDiv = $("#section-head").offset().top;
    $(window).scroll(function() {
        if($(window).scrollTop() > topOfOthDiv) { //scrolled past the other div?
            $("#back-to-top").fadeIn(250); //reached the desired point -- show div
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