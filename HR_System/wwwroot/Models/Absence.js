$(document).ready(function () {
    $('#tableAbsence').DataTable({
        "autoWidth": false,
        "responsive": true
    });
});

function Delete(id) {
    Swal.fire({
        title: "هل انت متاكد؟",
        text: "لم تتمكن من التراجع عن هذا!!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: '#3085d5',
        cancelButtonColor: '#d33',
        confirmButtonText: "نعم, احذف هذا!",
        cancelButtonText: "لا, الغاء!",
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = `/Admin/Absence/DeleteAbsence?Id=${id}`;
        }
    });
}

function Edit(id, department, name, theAudience, attendanceTime, departureDate, dateTime) {
    document.getElementById("title").innerHTML = "تعديل اعدادات الموظفين..";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("userId").value = id;
    document.getElementById("deptEmp").value = department;
    document.getElementById("nameEmps").value = name;
    document.getElementById("theAudienceEmp").value = theAudience;
    document.getElementById("AttendanceEmp").value = attendanceTime;
    document.getElementById("DepartureEmp").value = departureDate;
    document.getElementById("dateEmp").value = dateTime;

    
    $('#exampleModal').modal('show');
    
    
}
function Rest() {
    document.getElementById("title").innerHTML = "اضف اعدادات الموظف..";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("userId").value = "";
    document.getElementById("deptEmp").value = "";
    document.getElementById("nameEmps").value = "";
    document.getElementById("theAudienceEmp").value = "";
    document.getElementById("AttendanceEmp").value = "";
    document.getElementById("DepartureEmp").value = "";
    document.getElementById("dateEmp").value = "";
    $('#exampleModal').modal('show');
    
}
