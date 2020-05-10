
function ChangeDeliveryBlockVisibility() {
    if ($("#NeedDelivery").prop("checked") === true) {
        $("#deliveryBlock").show();
    }
    else {
        $("#deliveryBlock").hide();
    }
}

function GetBaseMaterials() {
    var id = $("#BaseMaterialCategoryID").val();
    $.ajax({
        type: "GET",
        url: "/Home/GetMaterials",
        data: { ID: id },
        cache: false,
        success: function (data) {
            $('#BaseMaterialID').children('option').remove();
            for (index = 0; index < data.length; index++) {
                $('#BaseMaterialID').append(new Option(data[index].name, data[index].materialId));
            } 
        },
        error: function () {
            alert("Error!");
        }
    });
}

function GetLocks() {
    var id = $("#LockCategoryID").val();
    $.ajax({
        type: "GET",
        url: "/Home/GetMaterials",
        data: { ID: id },
        cache: false,
        success: function (data) {
            $('#LockID').children('option').remove();
            for (index = 0; index < data.length; index++) {
                $('#LockID').append(new Option(data[index].name, data[index].materialId));
            }
        },
        error: function () {
            alert("Error!");
        }
    });
}

$(document).ready(function () {
    $("#test").click(function () {
        $.ajax({
            type: "GET",
            url: "/Home/GetMaterials",
            data: { ID: 3 },
            cache: false,
            success: function (data) {
                $("#test").text(data.length);
                alert("Success!");
            },
            error: function () {
                alert("Error!");
            }
        });
    });
});