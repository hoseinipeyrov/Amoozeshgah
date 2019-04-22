function SubmitForm(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    popup.dialog('close');
                    dataTable.ajax.reload();
                    $.notify(data.message);

                } else {
                    $.notify(data.message, { className: "error" });
                }
            }
        });
    }

    return false;
}

function deleteItem(deleteUrl) {
            swal({
            title: "حذف",
            text: "آیا مطمین هستید؟",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "بله، مطمین هستم",
            cancelButtonText: "انصراف",
            closeOnConfirm: false
        },
          function () {
              
              $.ajax({
                  type: "POST",
                  url: deleteUrl,
                  success: function (data) {
                      if (data.success) {
                          swal({
                              title: "حذف شد",
                              text: data.message,
                              type: "success",
                              confirmButtonText: 'باشه'

                          });
                          dataTable.ajax.reload();

                      } else {
                          $.notify(data.message, { className: "error" });
                      }
                  }
              });
          });
  
}