<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CodePathsCSF.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//code.jquery.com/jquery-1.11.2.min.js"></script>

    <script>
        
        $(document).ready(function (){
            
            $('#btnGetEmployee').click(function ()
        {
            var empId = $('#txtId').val();
            
            $.ajax({
            url: 'TestFiles/WebForm1.aspx/getemployeeById',
            method: 'post', 
            contentType: "application/json", 
            data: '{employeeId:' + empId + '}', 
            dataType: "json",
            success: function(data) 
            
            {
                $('#txtName').val(data.d.Name); 
                $('#txtGender').val(data.d.Gender);
                $('#txtSalary').val(data.d.Salary);
            }, 
            error: function (error) 
            { alert(error); 
            } 
        }); 
        });
        });
      
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    ID:
        <input id="txtId" type="text" style="width:86px" />
        <input type="button" id="btnGetEmployee" value="Get Employee" />
        <br />
        <br />
        <table border="1" style="border-collapse:collapse">

            <tr>
                <td>Name</td>
                <td><input id="txtName" />
                </td>

            </tr>

            <tr>
                 <td>Gender</td>
                <td><input id="txtGender" /></td>

            </tr>
            <tr>

                <td>Salary</td>
                <td><input id="txtSalary" /></td>
            </tr>

        </table>
        
    </form>
</body>
</html>
