function departmentsDataTable() {
    var controller = "/EducationalCenterUserArea/Departments";
    var width = 520;
    var height = 300;

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
             { data: "DepartmentTypeName" },
             { data: "Description" },
             { data: "Id", render: function (data) {
                 return `<div class='btn-group'><a class='btn btn-outline btn-info btn-sm' onclick=PopupForm('${controller}/update/${data}','ویرایش',${width},${height})><i class='fa fa-pencil'></i></a>` +
                                                       `<a class='btn btn-outline btn-danger btn-sm' onclick=deleteItem('${controller}/delete/${data}')><i class='fa fa-times'></i></a></div>`;
                     },
                     orderable: false,
                     width: "150px"
             }
        ],
        dom: "Bfrtip",
        buttons: [
             {
                 text: '<i class="fa fa-plus fa-fw"></i>' + 'دپارتمان جدید',
                 className: "btn btn-outline btn-success btnPopUp",
                 action: function (e, dt, node, config) {
                     $('.btnPopUp').prop('disabled', true);
                     PopupForm(`${controller}/Add`, 'افزودن', width, height);
                     $('.btnPopUp').prop('disabled', false);
                 }
             },
             { extend: 'excel', text: '<i class="glyphicon glyphicon-download-alt" aria-hidden="true"></i> فایل اکسل', className: "btn btn-outline btn-info", exportOptions: { columns: 'th:not(:last-child)' } },
             { extend: 'print', text: '<i class="glyphicon glyphicon-print" aria-hidden="true"></i> چاپ', className: "btn btn-outline btn-primary", exportOptions: { columns: 'th:not(:last-child)' } }
        ],
        language: {
            url: "//cdn.datatables.net/plug-ins/1.10.16/i18n/Persian.json"
        }
    });

    dataTable.buttons().container().prependTo($(dataTable.table().container()));
}