//Adds functionality of showing the related courses for related department on course registration page
$(".no-hide").addClass("hide");
$("#department").on("change",
    function () {
        $("#courseList").val("0");
        var depId = $(this).val();
        $(".no-hide").addClass("hide");
        $("." + depId).removeClass("hide");
    });
