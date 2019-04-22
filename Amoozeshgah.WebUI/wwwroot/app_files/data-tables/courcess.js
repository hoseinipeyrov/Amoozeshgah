function courcessDataTable() {
    var controller = "/EducationalCenterUserArea/Courses";
        var width = 600;
        var height=460;

        dataTable = $('.datatable').DataTable({
            bFilter: false,
            bInfo: false,
            ajax: {
                url: `${controller}/GetAll`,
                type: "GET",
                datatype: "json"
            },
            columns: [
                 { data: "Name" },
                 { data: "Code" },
                 { data: "Capacity" },
                 { data: "SessionCount" },
                 { data: "Description" },
                 {
                     data: "Id", render: function (data)
                     {
                     return `<div class='btn-group'><a class='btn btn-default btn-sm' onclick=PopupForm('${controller}/update/${data}','ویرایش',${width},${height})><i class='fa fa-pencil'></i> ویرایش</a>` +
                                                   `<a class='btn btn-danger btn-sm' onclick=deleteItem('${controller}/delete/${data}')><i class='fa fa-pencil'></i> حذف</a>`+
                                                   `<a class='btn btn-info btn-sm' href='SessionSchedule/Index/${data}'><i class='fa fa-clock-o'></i> جلسات</a></div>`;
                     },
                    orderable: false,
                    width: "250px"
                 }
            ],
            dom: "Bfrtip",
            buttons: [
                 {
                     text: '<i class="fa fa-plus fa-fw"></i>' + 'تشکیل کلاس جدید',
                     className: "btn btn-outline btn-success",
                     action: function (e, dt, node, config) {
                         PopupForm(`${controller}/Add`, 'افزودن', width, height);
                     }
                 },
                 { extend: 'excel', text: '<i class="glyphicon glyphicon-download-alt" aria-hidden="true"></i> فایل اکسل', className: "btn btn-outline btn-info",exportOptions: {columns: 'th:not(:last-child)'}},
                 { extend: 'print', text: '<i class="glyphicon glyphicon-print" aria-hidden="true"></i> چاپ', className: "btn btn-outline btn-primary", exportOptions: { columns: 'th:not(:last-child)' } }
            ],
            language: {
                url: "//cdn.datatables.net/plug-ins/1.10.16/i18n/Persian.json"
            }
        });

        dataTable.buttons().container().prependTo($(dataTable.table().container()));
}


