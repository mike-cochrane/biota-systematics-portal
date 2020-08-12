$(document).ready(function() {
    
});

function ToggleVisibility(el, collapsibleItem, showItem) {
    $(el).hide();
    $(collapsibleItem + "-" + showItem).show();
    $(collapsibleItem + "-content").slideToggle("fast");
}