$(document).ready(function () {
    GetDoctorList();
});

var SaveDoctor = function () {
    debugger;
    var docname = $("#txtName").val();
    var docmobile = $("#txtMobile").val();
    var email = $("#txtEmail").val();
    var state = $("#txtState").val();
    var city = $("#txtCity").val();
    
    var model = {
        DocName: docname,
        DocMobile: docmobile,
        Email: email,
        State: state,
        City: city,
      
    };

    $.ajax({
        url: "/Doctor/SaveDoctor",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
            GetDoctorList();
        },
        error: function (response) {
            alert(response.Message)
        }

    });
}

var GetDoctorList = function () {
    debugger;
    var search = $("#txtSearch").val();
    var model = {
        Search: search
    }

    $.ajax({
        url: "/Doctor/GetDoctorList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblDoctor tbody").empty();
            debugger;
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.DocId +
                    "</td><td>" + elementValue.DocName +
                    "</td><td>" + elementValue.DocMobile +
                    "</td><td>" + elementValue.Email +
                    "</td><td>" + elementValue.State +
                    "</td><td>" + elementValue.City +
                    "</td><td>" + elementValue.PatientName +
                    "</td><td>" + elementValue.PatientMobile +
                    "</td></tr>";

            });
            $("#tblDoctor tbody").append(html);
        }
    });
}


