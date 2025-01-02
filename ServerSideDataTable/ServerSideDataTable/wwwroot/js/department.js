$(document).ready(function () {
    loadDepartments();
});

function loadDepartments() {
    $.ajax({
        url: '/Department/GetDepartmentList',
        type: 'Post',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: OnSuccess,
        error: function () {
            alert("Data can't get");
        }
    });
}
//$('#departmentTable').DataTable({

//});
function OnSuccess(response) {
    $('#departmentTable').DataTable({
        destroy: true, // Allow reinitialization
        bProcessing: true,
        bLengthChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'DeptId',
                render: function (data, type, row, meta) {
                    return row.deptId
                }
            },
            {
                data: 'DeptName',
                render: function (data, type, row, meta) {
                    return row.deptName
                }
            },
            {
                data: 'Action',
                render: function (data, type, row, meta) {
                    return `
                            <button href="#" class="btn btn-sm btn-primary" onclick="Edit(${row.deptId})">Edit</button>
                            <button href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="Delete(${row.deptId})">Delete</button>
                        `;
                    }
            }
        ]
    });
}

$('#btnSaveDepartment').click(function () {
        $('#DepartmentModal').modal('show');
        $('#departmentForm')[0].reset();
        $('#btnSaveDepartment').show();
        $('#btnUpdateDepartment').hide();
        $('#departmentModalTitle').text('Add Department');
});

function AddDepartment() {
    var deptName = $('#DeptName').val().trim();

    if (!deptName) {
        alert("All fields are required.");
        return;
    }

    var objData = {
        DeptName: deptName
    };

        $.ajax({
            url: '/Department/AddDepartment',
            type: 'POST',
            data: JSON.stringify(objData),
            contentType: 'application/json;charset=utf-8;',
            success: function (response) {
                alert("Dapartment added!");
                ClearTextBox();
                HideModalPopUp();
                loadDepartments();
            },
            error: function () {
                alert('Error saving department.');
            }
        });
}

function HideModalPopUp() {
    $('#DepartmentModal').modal('hide');
}

function ClearTextBox() {
    $('#DeptName').val('');
}

function Edit(deptId) {
        $.ajax({
            url: `/Department/EditDepartment?deptId=${deptId}`,
            type: 'GET',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function (response) {
                    $('#DepartmentModal').modal('show');
                    $('#DeptId').val(response.DeptId);
                    $('#DeptName').val(response.DeptName);
                    $('#btnSaveDepartment').css('display', 'none');
                    $('#btnUpdateDepartment').css('display', 'block');
                    $('#departmentModalTitle').text('Edit Department');
            },
            error: function () {
                alert('Error fetching department data.');
            }
        });
}

function UpdateDepartment() {
    var deptId= $('#DeptId').val().trim();
    var deptName = $('#DeptName').val().trim();
    
    if (!deptName) {
        alert("All fields are required.");
        return;
    }

    var objData = {
        DeptId : deptId,
        DeptName : deptName
    };

    $.ajax({
        url: '/Department/UpdateDepartment',
        type: 'POST',
        data: JSON.stringify(objData), // Convert the object to JSON string
        contentType: 'application/json;charset=utf-8;', // Ensure the content type is JSON
         dataType: 'json',
        success: function () {
                alert("Data updated successfully!");
                ClearTextBox();
                HideModalPopUp();
                loadDepartments();
            },
            error: function () {
                alert('Error updating department.');
            }
    });
}

function Delete(deptId) {
        if (confirm('Are you sure you want to delete this department?')) {
            $.ajax({
                url: `/Department/DeleteDepartment?deptId=${deptId}`,
                type: 'DELETE',
                success: function (response) {
                    alert("Department Deleted!");

                    // Get the DataTable instance
                    var table = $('#departmentTable').DataTable();
                    // Find the row by EmpId and remove it from the DataTable
                    var row = table.rows().nodes().toArray().find(row => $(row).find('td:eq(0)').text() == deptId);

                    if (row) {
                        // Remove the row from the DataTable
                        table.row(row).remove().draw();
                    }
                },
                error: function () {
                    alert('Error deleting department.');
                }
            });
        }
}
