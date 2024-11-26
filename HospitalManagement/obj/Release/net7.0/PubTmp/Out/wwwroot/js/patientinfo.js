function getUrlPath() {
    // Get the current URL
    const currentUrl = window.location.href;

    // Create a URL object
    const url = new URL(currentUrl);

    // Construct the base URL
    const baseUrl = `${url.protocol}//${url.hostname}${url.port ? ':' + url.port : ''}/`;

    return baseUrl;
}



function savePatientInfo() {
    $("#SubmitButton").hide();
    var patientInfo = {
        PatientId: $("#PatientId").val(),
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        Email: $("#Email").val(),
        Gender: $("#Gender").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        MedicalRecords: $("#MedicalRecords").val(),

    };

    $.ajax({
        type: "POST",
        url: getUrlPath() + "PatientInfo/CreatePost",
        data: { model: patientInfo },
        success: function (result) {
            debugger
            if (result == "success") {
                alert('Data Saved Successfully');
                window.location.reload();
            } else {
                //toastr.error(result);
            }
        },
        error: function (result) {
            alert("Cannot Save Data. Please try again.");
        }
    });
}


function saveAppointment() {
    //$("#SubmitButton").hide();
    debugger
    var appointmentdate = $("#AppointmentDate").val();
    if (appointmentdate == null || appointmentdate == "") {
        alert("appointmentdate is not selected");
        return false;
    }
    var appointmentInfo = {
        AppointmentId: $("#AppointmentId").val(),
        PatientId: $("#PatientId").val(),
        Title: $("#Title").val(),
        Description: $("#Description").val(),
        StartTime: $("#StartTime").val(),
        EndTime: $("#EndTime").val(),
        IsAllDay: $("#IsAllDay").val(),
        Status: $("#Status").val(),
        AppointmentDate: $("#AppointmentDate").val(),
        DoctorId: $("#DoctorIdd").val(),

    };


    $.ajax({
        type: "POST",
        url: getUrlPath() + "Appointment/CreatePost",
        data: { model: appointmentInfo },
        success: function (result) {
            debugger
            if (result == "success") {
                alert('Data Saved Successfully');
                window.location.href = getUrlPath() + "Appointment/Index";
            } else if (result == "AppointmentFailed") {
                alert('Appointment Already exists');
                return false;
            }
            else {
                alert('Something went wrong. Please check all the fields');
                return false;
                //toastr.error(result);
            }
        },
        error: function (result) {
            alert("Cannot Save Data. Please try again.");
        }
    });
}


