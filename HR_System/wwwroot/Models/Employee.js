$(document).ready(function () {
    $('#tableEmps').DataTable({
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
            window.location.href = `/Admin/Employees/DeleteEmps?Id=${id}`;
        }
    });
}

function Edit(id, name, address, phone, gender, nationality, HourlyPrice, date, national_id, retirementdate, salary, attendancetime, departuredate) {
    document.getElementById("title").innerHTML = "تعديل مجموعة الموظفين..";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("userId").value = id;
    document.getElementById("userName").value = name;
    document.getElementById("addressEmp").value = address;
    document.getElementById("phoneEmp").value = phone;
    document.getElementById("genderEmp").value = gender;
    document.getElementById("nationalityEmp").value = nationality;
    document.getElementById("HourlyPriceEmp").value = HourlyPrice;
    document.getElementById("dateEmp").value = date;
    document.getElementById("nationalIDEmp").value = national_id;
    document.getElementById("retirementDateEmp").value = retirementdate;
    document.getElementById("salaryEmp").value = salary;
    document.getElementById("attendanceTimeEmp").value = attendancetime;
    document.getElementById("departureDateEmp").value = departuredate;
    
    $('#exampleModal').modal('show');
    
    
}
function Rest() {
    document.getElementById("title").innerHTML = "اضف مجموعة المستخدمين..";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("userId").value = "";
    document.getElementById("userName").value = "";
    document.getElementById("addressEmp").value = "";
    document.getElementById("phoneEmp").value = "";
    document.getElementById("genderEmp").value = "";
    document.getElementById("nationalityEmp").value = "";
    document.getElementById("HourlyPriceEmp").value = "";
    document.getElementById("dateEmp").value = "";
    document.getElementById("nationalIDEmp").value = "";
    document.getElementById("retirementDateEmp").value = "";
    document.getElementById("salaryEmp").value = salary;
    document.getElementById("attendanceTimeEmp").value = "";
    document.getElementById("departureDateEmp").value = "";
    $('#exampleModal').modal('show');
    
}
