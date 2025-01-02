$(document).ready(function () {
    loadEmployees();
    loadDepartments();
});
function loadEmployees() {
        $('#employeeTable').DataTable({
            processing: true,
            serverSide: true,
            ajax: {
                url: '/Employee/GetEmployeeList',
                type: 'POST'
            },
            columns: [
                { data: 'EmpId' },
                { data: 'EmpName' },
                { data: 'Email' },
                { data: 'Phone' },
                { data: 'Designation' },
                { data: 'Department.DeptName', defaultContent: 'No Department' },
                {
                    data: 'EmpId',
                    render: function (data) {
                        return `
                            <button class="btn btn-sm btn-primary edit-btn" data-id="${data}">Edit</button>
                            <button class="btn btn-sm btn-danger delete-btn" data-id="${data}">Delete</button>
                        `;
                    }
                }
            ]
        });
    }

    function loadDepartments() {
        $.ajax({
            url: '/Department/GetAllDepartments',
            type: 'GET',
            success: function (response) {
                let deptDropdown = $('#DeptId');
                deptDropdown.empty();
                deptDropdown.append('<option value="">Select Department</option>');
                response.forEach(function (dept) {
                    deptDropdown.append(`<option value="${dept.DeptId}">${dept.DeptName}</option>`);
                });
            }
        });
    }

    $('#btnAddEmployee').click(function () {
        $('#EmployeeModal').modal('show');
        $('#employeeForm')[0].reset();
        $('#btnSaveEmployee').show();
        $('#btnUpdateEmployee').hide();
        $('#employeeModalTitle').text('Add Employee');
    });

    $('#btnSaveEmployee').click(function () {
        const employee = {
            EmpName: $('#EmpName').val().trim(),
            Email: $('#Email').val().trim(),
            Phone: $('#Phone').val().trim(),
            Designation: $('#Designation').val().trim(),
            DeptId: $('#DeptId').val()
        };

        if (!employee.EmpName || !employee.Email || !employee.Phone || !employee.Designation) {
            alert('All fields are required.');
            return;
        }

        $.ajax({
            url: '/Employee/AddEmployee',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(employee),
            success: function (response) {
                alert(response);
                $('#EmployeeModal').modal('hide');
                $('#employeeTable').DataTable().ajax.reload();
            },
            error: function () {
                alert('Error saving employee.');
            }
        });
    });

    $(document).on('click', '.edit-btn', function () {
        const empId = $(this).data('id');
        $.ajax({
            url: `/Employee/Edit?empId=${empId}`,
            type: 'GET',
            success: function (response) {
                $('#EmployeeModal').modal('show');
                $('#EmpId').val(response.EmpId);
                $('#EmpName').val(response.EmpName);
                $('#Email').val(response.Email);
                $('#Phone').val(response.Phone);
                $('#Designation').val(response.Designation);
                $('#DeptId').val(response.DeptId);
                $('#btnSaveEmployee').hide();
                $('#btnUpdateEmployee').show();
                $('#employeeModalTitle').text('Edit Employee');
            },
            error: function () {
                alert('Error fetching employee data.');
            }
        });
    });

    $('#btnUpdateEmployee').click(function () {
        const employee = {
            EmpId: $('#EmpId').val().trim(),
            EmpName: $('#EmpName').val().trim(),
            Email: $('#Email').val().trim(),
            Phone: $('#Phone').val().trim(),
            Designation: $('#Designation').val().trim(),
            DeptId: $('#DeptId').val()
        };

        if (!employee.EmpName || !employee.Email || !employee.Phone || !employee.Designation) {
            alert('All fields are required.');
            return;
        }

        $.ajax({
            url: '/Employee/Update',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(employee),
            success: function (response) {
                alert(response);
                $('#EmployeeModal').modal('hide');
                $('#employeeTable').DataTable().ajax.reload();
            },
            error: function () {
                alert('Error updating employee.');
            }
        });
    });

    $(document).on('click', '.delete-btn', function () {
        const empId = $(this).data('id');
        if (confirm('Are you sure you want to delete this employee?')) {
            $.ajax({
                url: `/Employee/Delete?empId=${empId}`,
                type: 'DELETE',
                success: function (response) {
                    alert(response);
                    $('#employeeTable').DataTable().ajax.reload();
                },
                error: function () {
                    alert('Error deleting employee.');
                }
            });
        }
    });

