$(document).ready(function () {
    GetEmployee();
});

function GetEmployee() {
    $.ajax({
        url: '/Employee/GetEmployeeList',
        type: 'Get',
        dataType: 'json',
        contentType:'application/json;charset=utf-8;',
        success: OnSuccess,
        error: function () {
            alert("Data can't get");
        }
    })
}

function OnSuccess(response) {
    $('#dataTableData').DataTable({
        bProcessing: true,
        bLengthChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'EmpId',
                render: function (data, type, row, meta) {
                    return row.empId
                }
            },
            {
                data: 'EmpName',
                render: function (data, type, row, meta) {
                    return row.empName
                }
            },
            {
                data: 'Email',
                render: function (data, type, row, meta) {
                    return row.email
                }
            },
            {
                data: 'Phone',
                render: function (data, type, row, meta) {
                    return row.phone
                }
            },
            {
                data: 'Designation',
                render: function (data, type, row, meta) {
                    return row.designation
                }
            },
            {
                data: 'Action',
                render: function (data, type, row, meta) {
                    return `
            <a href="#" class="btn btn-sm btn-primary onclick="Edit(${row.empId}">Edit</a>
            <a href="#" class="btn btn-sm btn-danger" onclick="Delete(${row.empId})">Delete</a>
        `;
                }
            }

        ]
    });
}

$('#btnAddEmployee').click(function () {
    $('#EmployeeModal').modal('show');
})

function AddEmployee() {
    var objData = {
        EmpName: $('#EmpName').val(),
        Email: $('#Email').val(),
        Phone: $('#Phone').val(),
        Designation: $('#Designation').val()
    };

    $.ajax({
        url: '/Employee/AddEmployee',
        type: 'POST',
        data: objData,
        contentType: 'application/xxx-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert("Data is added");
            ClearTextBox();
            GetEmployee();
            HideModalPopUp();
        },
        error: function () {
            alert("Data is not added");
        }
    });

    function HideModalPopUp() {
        $('#EmployeeModal').modal('hide');
    }

    function ClearTextBox() {
        $('#EmpName').val('');
        $('#Email').val('');
        $('#Phone').val('');
        $('#Designation').val('');
    }
}

function Delete(empId) {
    if (confirm('Are you sure, you want to delete this employee?')) {
        $.ajax({
            url: '/Employee/Delete?empId='+empId,
            type: 'DELETE',
            success: function () {
                alert('Record Deleted!');
                //GetEmployee();
                $('#dataTableData').DataTable().ajax.reload(); // Reload DataTable's data

            },
            error: function () {
                alert("Data is not deleted!");
            }
        });
    }
        
}


function Edit(empId) {
    $.ajax({
        url: '/Employee/Delete?empId=' + empId,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#EmployeeModal').modal('show');
            $('#EmpId').val(response.empId);
            $('#EmpName').val(response.empName);
            $('#Email').val(response.email);
            $('#Phone').val(response.phone);
            $('#Designation').val(response.designation);
            $('#AddEmployee').css('display', 'none');
            $('#btnUpdate').css('display', 'block');

            //$('#AddEmployee').hide();
            //$('#btnUpdate').show();
        },
        error: function () {
            alert("Data not found!");
        }
    });
}

//$('#dataTableData').DataTable({

//}) 