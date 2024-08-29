$(document).ready(function () {
    $('#tableRole').DataTable();
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
            window.location.href =`/Admin/Accounts/DeleteRole?Id=${id}`;
        }
    });
}

function Edit(id, name) {
    document.getElementById("title").innerHTML = "تعديل مجموعة المستخدمين..";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("roleId").value = id;
    document.getElementById("roleName").value = name;
    //document.getElementById("roleForm").action = `/Admin/Accounts/EditRole`;
    $('#exampleModal').modal('show');
}
function Rest() {
    document.getElementById("title").innerHTML = "اضف مجموعة المستخدمين..";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("roleId").value = "";
    document.getElementById("roleName").value = "";
    //document.getElementById("roleForm").action = `/Admin/Accounts/EditRole`;
    $('#exampleModal').modal('show');
}