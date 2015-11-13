$(function () {
    var $research = $('.research');
    $research.find("tr").not('.accordion').hide();
    $research.find("tr").eq(0).show();

    $research.find(".accordion").click(function () {
        $research.find('.accordion').not(this).siblings().fadeOut(500);
        $(this).siblings().fadeToggle(500);
    }).eq(0).trigger('click');
});