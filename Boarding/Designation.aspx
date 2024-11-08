<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="Boarding.Designation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

<html>
<head >
    <title></title>
    <style type="text/css">
       
        table {
            width: 70%;
            margin: 20px auto;
            border:0;
           
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
        }
        label {
            display: inline-block;
            width: 100%;
            padding: 5px;
            font-size: 1em;
            
        }
        body{
            background: #2c7da0;
            text-align:center;
            
            
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
            border-collapse: collapse;
            
        }

        .auto-style3 {
            width: 191px;
            height:50px;
        }

        .auto-style4 {
            width: 191px;
            height: 34px;
        }
        .auto-style5 {
            border-style: none;
        border-color: inherit;
        border-width: medium;
height: 34px;
            }
        .auto-style6 {
            border-style: none;
        border-color: inherit;
        border-width: medium;
height: 50px;
            }

        .auto-style7 {
            margin-left: 19;
        }

    </style>  
</head>
<body>
    <form id="form1" method="post">
    <h2 style="text-align: center;color:white ">Designation Master</h2>
    <table >
        <tr>
            <th class="auto-style4" style="font-style: normal;border: none; font-weight: normal">CompanyName</th>
            <td class="auto-style5">
              <label id="companyNameLabel" >
               <label id="designationNameLabel"><asp:DropDownList ID="cboCompany" runat="server" AppendDataBoundItems="True" Height="30px" Width="450px">
                <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                </asp:DropDownList>
               </label>
            </label>
           </td>
     </tr>
     <tr>
        <td class="auto-style3" style="font-style: normal;border: none; font-weight: normal">DesignationName</td>
           <td class="auto-style6" >
                &nbsp;&nbsp;
                <asp:TextBox ID="TxtDesigName" runat="server" MaxLength="100"  style="margin-top: 0px"  Width="442px" CssClass="auto-style7"></asp:TextBox>
          </td>
     </tr>
   </table>
   
    <div class="button-container">
        <button type="submit" id="btnsave" runat="server"   onserverclick ="Submit_Click">Submit</button>
        <button type="reset" id="btnreset" runat="server" aria-disabled="False" onserverclick ="reset_Click">Exit</button>
    </div>
        <br />
        <asp:Label   ID="err"   runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="White" ></asp:Label>
        
         </form>

</body>
</html>
</asp:Content>
