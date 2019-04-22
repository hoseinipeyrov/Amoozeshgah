var popup;
function ClosePopUp() {
    popup.dialog('close');
}
function PopupForm(url, dialogTitle, dialogWidth, dialogHeight) {
    var formDiv = $('<div/>');
    $.get(url)
     .done(function (response) {
         formDiv.html(response);
         popup = formDiv.dialog({
             autoOpen: true,
             hide: 'fade',
             show: 'fade',
             width: dialogWidth,
             height: dialogHeight,
             resizable: false,
             modal: true,
             title: dialogTitle,
             close: function () {
                 popup.dialog('destroy').remove();
             }
         });
     });
}