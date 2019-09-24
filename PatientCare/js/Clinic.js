$(document).ready(function () {
    applyTriggerNotify();

    setTimeout(function () {
        $(".ClinicMM").addClass("active");
    }, 1000);

    var theTable = $('#clinicListGrid');
    theTable.find("tbody > tr").find("td:eq(1)").mousedown(function () {
        $(this).prev().find(":checkbox").click()
    });

    $("#filter").keyup(function () {
        $.uiTableFilter(theTable, this.value);
    })

    $('#filter-form').submit(function () {
        theTable.find("tbody > tr:visible > td:eq(1)").mousedown();
        return false;
    }).focus(); //Give focus to input field
});

function RegisterNewClinic() {
    showLoader();
    window.location.href = "/Clinic/ClinicMaster";
}

var clinicListGrid = $("#clinicListGrid").grid({
    uiLibrary: "bootstrap",
    responsive: true,
    dataSource: {
        url: "/Clinic/GetAllClinicDetails_ForList",
    },
    autoLoad: true,
    columns: [
   { field: "SerialNo", title: "Serial No", width: 40 },
   { field: "ClinicID", hidden : true, title: "ID", width: 40 },
   { field: "Name", title: "Name", width: 100 },
   { field: "Address", title: "Address", width: 100 },
   { field: "ClinicID", title: "", width: 30, type: "icon", icon: "glyphicon-pencil", tooltip: "Edit Clinic", events: { "click": UpdateClinicDetails }, },
   { field: "Name", title: "", width: 30, type: "icon", icon: "glyphicon-user", tooltip: "Patient List", events: { "click": ClinicPatient }, },
    ],
    pager: { enable: true, limit: 10, sizes: [10, 20, 50, 100] }
});

function ClinicPatient(e) {
    window.location.href = "/Patient/Index?ClinicName=" + e.data.record.Name;
}

function UpdateClinicDetails(e) {
    window.location.href = "/Clinic/ClinicMaster?ClinicID=" + e.data.record.ClinicID;
}

function DeleteClinicDetails(e) {
    var ClinicID = e.data.record.ClinicID;
    $.ajax({
        type: "POST",
        url: "/Clinic/DeleteClinicDetails",
        data: '{ ClinicID: ' + ClinicID + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            hideLoader();
            $.notify("clinic deleted successfully", "success");
            clinicListGrid.reload();
        },
        failure: function (response) {
            $.notify(response.responseText, "error");
        },
        error: function (response) {
            $.notify(response.responseText, "error");
            clinicListGrid.reload();
        }
    });
}



