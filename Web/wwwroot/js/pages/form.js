$(document).ready(function () {
    var data = [{
        "name": "yeni form"
    }
    ];
    GetAllList(data);
 
});
function GetAllList(data) {

 
    CreateFormDataTable(data);
}
function GetAllOnSuccess() {

    CreateFormDataTable();

}
function Search(val) {
    dt.search(val).draw();
}

var dt = null;
function CreateFormDataTable(data) {
    dt = $('#FormList').DataTable({
        destroy: true,
        data: data,
        language: { url: "https://cdn.datatables.net/plug-ins/1.11.3/i18n/tr.json" },
        "order": [[1, "desc"]],
        columns: [
            { data: "name" },
            {
                "width": "15%",
                render: function (data, type, row) {

                    var editButton = "<a class='btn btn-success btn-xs' href='/form/edit/" + row.id + "' data-toggle='tooltip' title='Form Düzenle'><i class='fa fa-edit'></i></a>";
                    var detailButton = "<a class='btn btn-success btn-xs' href='/form/edit/" + row.id + "' data-toggle='tooltip' title='Detay Göster'><i class='fa fa-info'></i></a>";
                    return editButton + " " + detailButton;

                }
            }
        ],
        "columnDefs": [
            {
                "visible": false,
                "searchable": false
            }
        ]
    });
}
