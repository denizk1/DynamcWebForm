var inputcount = 1;
$(document).ready(function () {
    //var data = [{
    //    "name": "yeni form"
    //}
    //];
    //GetAllList(data);
 
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
                    return detailButton;

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
function detail(detail) {

    $.ajax({
        url: '/Form/FormDetail',
        type: 'get',
        success: function (result) {
            formdetailhtml(detail);
            window.location.href = '/Form/FormDetail';
        }
    });
}
function formdetailhtml(detail) {

    for (var i = 0; i < detail.length; i++) {
        var data = detail[i];

        var divrowstart = "<div class='row'>";
        var divrowfinish = "</div>";

        var divcolstart = "<div class='col-6'>";
        var divcolfinish = "</div>";

        var inputtagstart = "<" + data.Value + "id='" + data.Id + "'>";
        var inputtagfinish = "</" + data.Value + ">";

        var isSpan = "<span>" + data.Value + "</span>";
        if (data.value == "label") {
            $("#savedetailButton").before(divrowstart + divcolstart + inputtagstart + data.Value.toString() + inputtagfinish + divcolfinish + divrowfinish);
            $('#' + data.Value + inputcount).addClass('d-flex align - items - center fs - 6 fw - bold mb - 2');
        }
        else {
            $("#savedetailButton").before(divcolstart + inputtagstart + inputtagfinish + divcolfinish);
            $('#' + data.Value + inputcount).addClass('form-control form - control - solid');
        }

    }

}