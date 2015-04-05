

$(document).ready(function () {
        
    var indexPageFrameOrgBkgdColor = $("#FrameWhoWeAre").css("backgroundColor");
    var $indexPageGeneralInfoFrames    = $("#FrameWhoWeAre").add("#FrameWhereWeAre").add("#FrameWhyWeAre");

    $(function () {
        $indexPageGeneralInfoFrames.mouseover(function () {
            $(this).css("backgroundColor", "CornflowerBlue");
        });
    });

    $(function () {
        $indexPageGeneralInfoFrames.mouseleave(function () {
            $(this).css("backgroundColor", indexPageFrameOrgBkgdColor);
        });
    });
    //alert(" jQuery is working");
});

