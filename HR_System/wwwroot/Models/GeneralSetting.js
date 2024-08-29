$(document).ready(function () {
    $('#tableSettings').DataTable({
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
            window.location.href = `/Admin/GeneralSettings/DeleteSettingEmps?Id=${id}`;
        }
    });
}

function Edit(id, name, extra, rival, datetimeEmp, officialLeave1, officialLeave2) {
    document.getElementById("title").innerHTML = "تعديل اعدادات الموظفين..";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("userId").value = id;
    document.getElementById("nameEmps").value = name;
    document.getElementById("extraSetting").value = extra;
    document.getElementById("rivalSetting").value = rival;
    document.getElementById("datetimeSetting").value = datetimeEmp;
    document.getElementById("day1Setting").value = officialLeave1;
    document.getElementById("day2Setting").value = officialLeave2;
    
    $('#exampleModal').modal('show');
    
    
}
function Rest() {
    document.getElementById("title").innerHTML = "اضف اعدادات الموظف..";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("userId").value = "";
    document.getElementById("nameEmps").value = "";
    document.getElementById("extraSetting").value = "";
    document.getElementById("rivalSetting").value = "";
    document.getElementById("datetimeSetting").value = "";
    document.getElementById("day1Setting").value = "";
    document.getElementById("day2Setting").value = "";
    $('#exampleModal').modal('show');
    
}
