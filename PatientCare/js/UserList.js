function AddNewUser() {
    showLoader();
    var i = 10;
    window.location.href = "/User/AddUser";
}

$(document).ready(function () {
    applyTriggerNotify();
    setTimeout(function () {
        $(".UserMM").addClass("active");
    }, 1000);

    var theTable = $('#userListGrid');
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

var userListGrid = $("#userListGrid").grid({
    uiLibrary: "bootstrap",
    responsive: true,
    dataSource: {
        url: "/User/GetAllUserDetails_ForList",
    },
    autoLoad: true,
    columns: [
   { field: "SerialNo", title: "Sr. No.", width: 40 },
   { field: "UserID", title: "ID", width: 40 },
   { field: "FullName", title: "Name", width: 100 },
   { field: "AddressLine", title: "Address", width: 100 },
   { field: "MobileNumber", title: "Mobile Number", width: 40 },
   { field: "GenderStr", title: "Gender", width: 50 },
   { field: "UserID", title: "", width: 30, type: "icon", icon: "glyphicon-pencil", tooltip: "Edit User", events: { "click": UpdateUserDetails } },
    ],
    pager: { enable: true, limit: 10, sizes: [10, 20, 50, 100] }
});

function UpdateUserDetails(e) {
    window.location.href = "/User/AddUser?UserID=" + e.data.record.UserID;
}
