
var showHtml;
var inputcount = 1;
var jsonHtml;

$(document).ready(function () {
    

});
function addComponent(id) {
    $.ajax({
        url: '/Form/AddForm?Id=' + id,
        type: 'get',
        success: function (response) {
            if (response.status) {
                addHtmlTag(response.data);
               
            }
            else {
                alert("hata");
            }
        }
    });
}

function changeName(id) {
    OpenModal("changeComponentNameModal");
    $("#nameChange").click(function () {
        var json = $('#changeformid').serializeArray();
        $('#'+id).text(json[0].value);
        CloseModal("changeComponentNameModal");
    });
}
$("#save").click(function () {
    jsonObj = [];
    $(".json").each(function () {

        var value = $(this).prop("tagName").toLowerCase();
        var id = $(this).attr('id');

        item = {}
        item["id"] = id;
        item["value"] = value;

        jsonObj.push(item);
    });

    
    var formName = $("#formName").attr("value");

    var formdatas = {
        formdatas: jsonObj,
        formName: formName
    };
    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Form/AddDynamicForm',
        data: formdatas,
        success: function (response) {
            if (response.status) {
                window.location.href = '/Form/CreateForm';
            }
        },     
    });

});
function addHtmlTag(data) {

    var divrowstart = "<div class='row'>";
    var divrowfinish = "</div>";

    var divcolstart = "<div class='col-6'>";
    var divcolfinish = "</div>";

    var inputtagstart = "<" + data.value + " class='" + data.hasClass + "'" + "id='" + data.value + inputcount + "'>";
    var inputtagfinish = "</" + data.value + ">";

    var isSpan = "<span>" + data.value + "</span>";
    if (data.value == "label") {
        $("#saveButton").before(divrowstart + divcolstart + inputtagstart + data.value.toString() + inputtagfinish + divcolfinish + divrowfinish);
        $('#' + data.value + inputcount).attr('onclick', 'changeName(this.id)');
        $('#' + data.value + inputcount).addClass('json');
    }
    else {
        $("#saveButton").before(divcolstart + inputtagstart + inputtagfinish + divcolfinish);
        $('#' + data.value + inputcount).addClass('json');
    }
   
    inputcount++;
}

function CloseModal(modalId) {
    $('#' + modalId).modal('hide');
}
function OpenModal(modalId) {
    $('#' + modalId).modal('show');
    $('#nameValue').val("");
}