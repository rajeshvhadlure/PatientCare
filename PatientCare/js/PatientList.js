$(document).ready(function () {
    applyTriggerNotify();
    setTimeout(function () {
        $(".PatientMM").addClass("active");
    }, 1000);
    localStorage.timerValue = null;
    var theTable = $('#patientListGrid');
    theTable.find("tbody > tr").find("td:eq(1)").mousedown(function () {
        $(this).prev().find(":checkbox").click()
    });

    $("#filter").keyup(function () {
        $.uiTableFilter(theTable, this.value);
    })

    $('#filter-form').submit(function () {
        theTable.find("tbody > tr:visible > td:eq(1)").mousedown();
        return false;
    }).focus();

});

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

var clinicname = getParameterByName('ClinicName');
if (clinicname != null) {
    $("#PartialClinicDDL").val(clinicname);
} else {
    clinicname = $("#PartialClinicDDL").val();
}

var patientListGrid = $("#patientListGrid").grid({
    uiLibrary: "bootstrap",
    responsive: true,
    dataSource: {
        url: "/Patient/GetAllPatientDetails_ForList", data: { clinicName: clinicname }
    },
    autoLoad: true,
    columns: [
		//{ field: "SerialNo", title: "Serial No", width: 20 },
		{ field: "PatientID", hidden: true, title: "ID", width: 20 },
        { field: "FullName", title: "Name", width: 70 },
        { field: "GenderStr", title: "Gender", width: 30 },
        { field: "TimeSpentstr", title: "(Current Month) Billable Time", width: 50 },
        { field: "DoctorsName", title: "Primary Physician", width: 80 },
        { field: "age", title: "Age", width: 30 },
        { field: "StatusName", title: "Status", width: 100, renderer: function (value, record) { return createSelect(value, record); } },
        { field: "PatientID", title: "Preview", width: 20, type: "icon", icon: "glyphicon-eye-open", tooltip: "Preview", events: { "click": PreviewPatientProfile } },
		{ field: "PatientID", title: "Edit", width: 20, type: "icon", icon: "glyphicon-pencil", tooltip: "Edit Patient", events: { "click": UpdatePatientDetails } },
		//{ field: "PatientID", title: "Report", width: 20, type: "icon", icon: "glyphicon-pencil", tooltip: "Edit Patient", events: { "click": UpdatePatientReport } },
		{ field: "PatientID", title: "Survey", width: 20, type: "icon", icon: "glyphicon-list-alt", tooltip: "Survey", events: { "click": AddNewSurvey } },
        //{ field: "PatientID", title: "Last CCM Note", width: 40, type: "icon", icon: "glyphicon-pencil", tooltip: "Edit", events: { "click": UpdateCCMDetails } },
        //{ field: "PatientID", title: "Care Plan Updated", width: 40, type: "icon", icon: "glyphicon-pencil", tooltip: "Edit" }
    ],
    pager: { enable: true, limit: 10, sizes: [10, 20, 50, 100] }
});

function RemoveCCMNoteDetails() {
    $("#ConfirmNoteModel").modal("hide");
}

function AddNewCCMNoteDetails() {
    var timespan = $('#hdnTimeSpan').val();
    if (timespan != '') {
        window.location.href = "/Patient/PatientIndividualProfile?PatientID=" + $('#hdnpatientId').val() + "&TimeSpent=" + $("#hdnTimeSpan").val();
    } else {
        window.location.href = "/Patient/PatientIndividualProfile?PatientID=" + $('#hdnpatientId').val();
    }
}

function AddNewSurvey(e) {
    window.location.href = "/SurveyReport/SurveyForm?PatientID=" + e.data.record.PatientID;
}

function AddNewPatient() {
    showLoader();
    window.location.href = "/Patient/PatientMaster?ClinicName=" + $("#PartialClinicDDL").val();
}

function OnChangePartialClinicDDL() {
    $("#SearchFirstName").val('');
    $("#SearchLastName").val('');
    $("#ClinicName").val($("#PartialClinicDDL").val());
    patientListGrid.reload({ clinicName: $("#PartialClinicDDL").val() });
}

function SearchPatient() {
    patientListGrid.reload({ clinicName: $("#PartialClinicDDL").val(), FirstName: $("#SearchFirstName").val(), LastName: $("#SearchLastName").val() });
}

function UpdatePatientDetails(e) {
    window.location.href = "/Patient/PatientMaster?PatientID=" + e.data.record.PatientID;
}

function UpdatePatientReport(e) {
    window.location.href = "/Patient/PatientReport?PatientID=" + e.data.record.PatientID;
}

function UpdateCCMDetails(e) {
    var patientId = e.data.record.PatientID;
    var timespan = e.data.record.TimeSpentstr;
    $('#hdnpatientId').val(patientId);
    $('#hdnTimeSpan').val(timespan);
    $("#ConfirmNoteModel").modal("show");
}

var offices = ["Enrolled", "On Hold-Hospitalized", "On Hold-Home Health", "On TCM", "Declined", "Discharged from CCM-other reason"];

function createSelect(selItem, record) {

    var id = record.PatientID;
    var sel = "<select id='ddlStatus' onchange='GetSelectedTextValue(this," + id + ")' class='form-control'><option>Select</option>";
    for (var i = 0; i < offices.length; ++i) {
        if (offices[i] == selItem) {
            sel += "<option selected value = '" + offices[i] + "' >" + offices[i] + "</option>";
        }
        else {
            sel += "<option  value = '" + offices[i] + "' >" + offices[i] + "</option>";
        }
    }
    sel += "</select>";
    return sel;
}

function GetSelectedTextValue(ddlStatus, id) {
    var selectedValue = ddlStatus.value;

    $.ajax({
        url: '/Patient/UpdatePatientStatus',
        type: 'POST',
        data: { 'PatientId': id, 'StatusName': selectedValue },
        cache: false,
        async: false,
        success: function (data) {
            hideLoader();
            $.notify("Status updated successfully", "success");
        }
    });
}


function PreviewPatientProfile(e) {
    var patientId = e.data.record.PatientID;
    // window.location.href = "/Patient/PatientIndividualProfile?PatientID=" + e.data.record.PatientID;
    $('#hdnpatientId').val(patientId);
    $("#ConfirmNoteModel").modal("show");
}