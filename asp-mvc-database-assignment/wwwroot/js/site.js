"use strict";

$(document).ready(function () {
    $("#btnPartial").click(function () {

        $.get("Cars/PartialCar/1", function (data, status) {

            console.log("Data: " + data + "\nStatus: " + status);

            $("#targetPartial").html(data);
        });
    });
});