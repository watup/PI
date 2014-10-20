

$(document).ready(function() {

    TurnJunkIntoButtons();

    GenerateToolTips();

    // turn triggers into a button with an icon
    $('.create-dialog-trigger').button({
        icons: {
            primary: "ui-icon-circle-plus"
        }
    });

});


// turn stuff into buttons if it has the correct class
function TurnJunkIntoButtons() {
    $('.make-me-a-button').button();
}

function GenerateToolTips() {
    $(document).tooltip();
}

// method for submitting form contained within dialog window
// and placing resulting view back into dialog window

function DoAjaxPost(btnClicked) {
    var $form = $(btnClicked).parents('form');
    var $dialog = $(btnClicked).parents('.dialog-contents');
    //console.log($dialog.html());

    $.ajax({
        type: "POST",
        url: $form.attr('action'),
        data: $form.serialize(),
        error: function (xhr, status, error) {
            //do something about the error  
            alert(error);
        },
        success: function (response) {
            // put the response into the dialog
            $dialog.html(response);

        }
    });

    return false; // if it's a link to prevent post

}