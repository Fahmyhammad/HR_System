$(document).ready(function () {
    $('#tableUsers').DataTable({
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
            window.location.href = `/Admin/Accounts/DeleteUser?Id=${id}`;
        }
    });
}

function Edit(id, name, email, roleName, activeUser) {
    document.getElementById("title").innerHTML = "تعديل مجموعة المستخدمين..";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("userId").value = id;
    document.getElementById("userName").value = name;
    document.getElementById("emailUser").value = email;
    document.getElementById("RoleUser").value = roleName;
    var result = document.getElementById("checkUser");
    if (result == true) {
        result.checked = true;
    }
    else {
        result.checked = false;
    }
    $('#exampleModal').modal('show');
    $('#grComPass').hide();
    $('#grPass').hide();
    document.getElementById("passUser").value = "********";
    document.getElementById("compPassUser").value = "********";
}
function Rest() {
    document.getElementById("title").innerHTML = "اضف مجموعة المستخدمين..";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("userId").value = "";
    document.getElementById("userName").value = "";
    document.getElementById("emailUser").value = "";
    document.getElementById("checkUser").checked = false;
    $('#exampleModal').modal('show');
    $('#grComPass').show();
    $('#grPass').show();
    document.getElementById("passUser").value = "";
    document.getElementById("compPassUser").value = "";
}



function ChangePassword(id) {
    document.getElementById('userPassId').value = id;
    $('#ChangePassModal').modal('show');
}