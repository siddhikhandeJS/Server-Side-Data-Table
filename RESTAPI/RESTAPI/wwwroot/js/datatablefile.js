$(document).ready(function () {
    GetEmployee();
});

function GetEmployee() {
    $.ajax({
        url: '/Employee/GetEmployeeList',
        type: 'Get',
        dataType: 'json',
        success: OnSuccess
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
            }
        ]
    });
}

//$('#dataTableData').DataTable({

//}) 