$(document).ready(function () {
    $('#tableOfficial').DataTable({
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
            window.location.href = `/Admin/OfficialVacations/DeleteOfficial?Id=${id}`;
        }
    });
}

function Edit(id, name, date) {
    document.getElementById("title").innerHTML = "تعديل الاجازات الرسمية..";
    document.getElementById("btnSave").value = "تعديل";
    document.getElementById("userId").value = id;
    document.getElementById("nameofficial").value = name;
    document.getElementById("officialdate").value = date;
       
    $('#exampleModal').modal('show');
    
    
}
function Rest() {
    document.getElementById("title").innerHTML = "اضف الاجازه الرسمية..";
    document.getElementById("btnSave").value = "حفظ";
    document.getElementById("userId").value = "";
    document.getElementById("nameofficial").value = "";
    document.getElementById("officialdate").value = "";
    $('#exampleModal').modal('show');
    
}
