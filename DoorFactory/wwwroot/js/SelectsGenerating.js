﻿
function myFunction() {
    var id = $("#inputMaterialType").val();
    $.ajax({
        type: "GET",
        url: "/Home/GetMaterials",
        data: { ID: id },
        cache: false,
        success: function (data) {
            $('#BaseMaterialID').prop("disabled", false);
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

$(document).ready(function () {
    var person = { firstName: "John", lastName: "Doe", age: 50, eyeColor: "blue" };
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