$(document).ready(function () {
    applyTriggerNotify();
    setTimeout(function () {
        $(".DoctorMM").addClass("active");
    }, 1000);

    var theTable = $('#doctorListGrid');
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

function AddNewDoctor() {
    showLoader();
    window.location.href = "/Provider/ProviderMaster";
}

var doctorListGrid = $("#doctorListGrid").grid({
    uiLibrary: "bootstrap",
    responsive: true,
    dataSource: {
        url: "/Provider/GetAllDoctorDetails_ForList",
    },
    autoLoad: true,
    columns: [
    { field: "DoctorID", title: "ID", width: 40 },
   { field: "Name", title: "Name", width: 100 },
   { field: "Address", title: "Address", width: 100 },
   { field: "Specility", title: "Specility", width: 100 },
   { field: "PhoneNo", title: "Phone No", width: 40 },
   { field: "Email", title: "Email", width: 40 },
   { field: "WebAddress", title: "Web Address", width: 100 },
   { field: "DoctorID", title: "", width: 30, type: "icon", icon: "glyphicon-pencil", tooltip: "Edit Doctor", events: { "click": UpdateDoctorDetails } },
    ],
    pager: { enable: true, limit: 10, sizes: [10, 20, 50, 100] }
});

function UpdateDoctorDetails(e) {
    window.location.href = "/Provider/ProviderMaster?DoctorID=" + e.data.record.DoctorID;
}