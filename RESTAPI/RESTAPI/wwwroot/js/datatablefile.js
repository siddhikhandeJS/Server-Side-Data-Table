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
                        <a href="#" class="btn btn-sm btn-primary" onclick="Edit(${row.empId})">Edit</a>
                        <a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="Delete(${row.empId})">Delete</a>
                    `;
                }
            }

        ]
    });
}

$('#btnAddEmployee').click(function () {
    ClearTextBox();
    $('#EmployeeModal').modal('show');
    //$('#id').hide();
    $('#AddEmployee').css('display', 'block');
    $('#btnUpdate').css('display', 'none');
    $('#employeeHeading').text('Add Employee');
})

function AddEmployee() {
    var empName = $('#EmpName').val().trim();
    var email = $('#Email').val().trim();
    var phone = $('#Phone').val().trim();
    var designation = $('#Designation').val().trim();

    // Frontend validation
    if (!empName || !email || !phone || !designation) {
        alert("All fields are required.");
        return;
    }

    var objData = {
        EmpName: empName,
        Email: email,
        Phone: phone,
        Designation: designation
    };


    $.ajax({
        url: '/Employee/AddEmployee',
        type: 'POST',
        data: JSON.stringify(objData),
        contentType: 'application/json;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert("Data added successfully!");
            ClearTextBox();
            HideModalPopUp();
            // Destroy the DataTable and reload using GetEmployee
            $('#dataTableData').DataTable().destroy();
            GetEmployee();
        },
        error: function () {
            alert("Data is not added");
        }
    });
}

function HideModalPopUp() {
    $('#EmployeeModal').modal('hide');
}

function ClearTextBox() {
    $('#EmpName').val('');
    $('#Email').val('');
    $('#Phone').val('');
    $('#Designation').val('');
}

function Delete(empId) {
    if (confirm('Are you sure, you want to delete this employee?')) {
        $.ajax({
            url: `/Employee/Delete?empId=${empId}`,
            type: 'DELETE',
            success: function () {
                alert('Record Deleted!');
                // Destroy the DataTable and reload using GetEmployee
                //$('#dataTableData').DataTable().destroy();
                //GetEmployee();

                // Get the DataTable instance
                var table = $('#dataTableData').DataTable();

                // Find the row by EmpId and remove it from the DataTable
                var row = table.rows().nodes().toArray().find(row => $(row).find('td:eq(0)').text() == empId);

                if (row) {
                    // Remove the row from the DataTable
                    table.row(row).remove().draw();
                }

            },
            error: function () {
                alert("Data is not deleted!");
            }
        });
    }
        
}


function Edit(empId) {
    $.ajax({
        url: `/Employee/Edit?empId=${empId}`,
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
            //or you can also use
        //    $('#AddEmployee').hide();
        //    $('#btnUpdate').show();
            $('#employeeHeading').text('Update Employee');
        },
        error: function () {
            alert("Data not found!");
        }
    });
}

function UpdateEmployee() {
    var empId = $('#EmpId').val().trim();
    var empName = $('#EmpName').val().trim();
    var email = $('#Email').val().trim();
    var phone = $('#Phone').val().trim();
    var designation = $('#Designation').val().trim();

    // Frontend validation
    if (!empName || !email || !phone || !designation) {
        alert("All fields are required.");
        return;
    }

    var objData = {
        EmpId: empId,
        EmpName: empName,
        Email: email,
        Phone: phone,
        Designation: designation
    };

    $.ajax({
        url: '/Employee/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert("Data updated successfully!");
            ClearTextBox();
            HideModalPopUp();
            
            // Destroy the DataTable and reload using GetEmployee
            //$('#dataTableData').DataTable().destroy();
            //GetEmployee();
           
            //DataTable instance
            var table = $('#dataTableData').DataTable();

            // Find the row by 'empId'
            var rowIndex = -1; // Default to -1 if not found

            table.rows().every(function (index) {
                var rowData = this.data();

                var rowEmpId = String(rowData.empId);  
                var inputEmpId = String(empId);  ;

                if (rowEmpId === inputEmpId) {
                    rowIndex = index; 
                }
            });

            if (rowIndex !== -1) {
                table.cell(rowIndex, 1).data(empName); 
                table.cell(rowIndex, 2).data(email);    
                table.cell(rowIndex, 3).data(phone);
                table.cell(rowIndex, 4).data(designation); 
                table.row(rowIndex).invalidate();  // Invalidate the row
                table.draw(); 
            }
        },
        error: function () {
            alert("Data is not updated");
        }
    });

}
