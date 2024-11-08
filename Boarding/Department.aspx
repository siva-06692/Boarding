<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="Boarding.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

<html>
<head>
    <title></title>
    <style type="text/css">
        table {
            width: 50%;
            margin: 20px auto;
            border-collapse: collapse;
        }

        table, th, td {
            border: 2px solid black;
        }

        th, td {
            padding: 10px;
            text-align: left;
        }

        th,td{
            background-color: #f2f2f2;
            border: none;
        }
         body{
            background: #2c7da0;
            text-align:center;
    
         }
        .auto-style2 {
            width: 379px;
        }
         .button-container {
     display: flex;
     justify-content: center;
     margin-top: 20px;
     
 }

 button {
     padding: 10px 20px;
     font-size: 1em;
     margin: 5px;
     cursor: pointer;
     
 }

 button[type="submit"] {
     background-color: #4CAF50;
     color: white;
     border: none;
 }

        button[type="reset"] {
            background-color: #f44336;
            color: white;
            border: none;
        }
        .auto-style3 {
            width: 988px;
            border: none;
        }
        .auto-style4 {
            width: 90%;
            height: 86px;
            margin-left: 88px;
            margin-right: 0px;
            
        }
        .auto-style5 {
            width: 425px;
            border: none;
        }
    </style>
</head>
<body>
    <form id="form1"> 
        <h3 style="color: #FFFFFF; font-size: xx-large;">Department Master</h3>
        <p>&nbsp;</p>
        
    <table class="auto-style4">  
        <tr> 
            <th class="auto-style5" style="font-family: Arial, Helvetica, sans-serif; font-weight: normal">Company Name</th>
             <td style="font-family: Arial, Helvetica, sans-serif" >
            <label id="CompanyName"><asp:DropDownList ID="cboCompany" runat="server" AppendDataBoundItems="True" Height="25px" Width="441px">
             <asp:ListItem Value="0">--Select Company--</asp:ListItem>
             </asp:DropDownList>
            </label>
        </td>  
        </tr> 
        <tr>
            <th class="auto-style5" style="font-family: Arial, Helvetica, sans-serif; font-weight: normal">Department Name</th>
            <td class="auto-style3" style="font-family: Arial, Helvetica, sans-serif">
            <asp:TextBox ID="Deptname" runat="server" MaxLength="100" style="margin-top: 0px" Width="543px"></asp:TextBox>
            </td>
        </tr>
        <tr>  
            <th class="auto-style5" style="font-family: Arial, Helvetica, sans-serif; font-weight: normal">Department_Head_Company_Name</th>
            <td class="auto-style2" style="font-family: Arial, Helvetica, sans-serif">  
                <asp:DropDownList ID="ddl_dept_head_comp_name"  runat="server" AppendDataBoundItems="true" DataTextField="Department_Head_Company_Name"   
                    DataValueField="Department_head_Company_id" AutoPostBack="True"   
                    onselectedindexchanged="ddl_dept_head_comp_name_SelectedIndexChanged" Width="450px">  
                    <asp:ListItem Value="0">--Select Company--</asp:ListItem>  
                </asp:DropDownList>  
            </td>   
        </tr>  
        <tr>  
            <th class="auto-style5" style="font-family: Arial, Helvetica, sans-serif; font-weight: normal">Department_Head_Emp_Name</th>  
            <td class="auto-style3" style="font-family: Arial, Helvetica, sans-serif">  
                <asp:DropDownList ID="ddl_dept_head_empname" runat="server" AppendDataBoundItems="true" DataTextField="Department_Head_Emp_Name"   
                    DataValueField="Department_head_emp_code" onselectedindexchanged="ddl_dept_head_empname_SelectedIndexChanged" Width="447px">   
                    <asp:ListItem Value="0">--Select_Employee--</asp:ListItem>  
                </asp:DropDownList>  
            </td>    
        </tr>  
    </table> 
        <div class="button-container">
        <button type="submit" id="btnsave" runat="server"   onserverclick ="Submit_Click">Submit</button>
        <button type="reset" id="btnreset" runat="server" onserverclick ="Reset_Click">Exit</button>
        </div>
        <br />
        <asp:Label   ID="err"   runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="White" ></asp:Label>
      
</form>  
</body>
</html>
</asp:Content>
