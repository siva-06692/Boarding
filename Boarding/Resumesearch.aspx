<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Resumesearch.aspx.cs" Inherits="Boarding.Resumesearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        body {
            background-color: lavender;
        }
        form label {
            width: 120px;
            font-weight: bold;
        }
        form input[type="text"] {
            width: 80%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }
        form .file-upload-container {
            display: flex;
            justify-content: flex-start;
            gap: 10px;
            align-items: center;
            margin-bottom: 20px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        .table th {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            background-color: #4CAF50;
            color: white;
        }

        .table-hover tbody tr:hover {
            background-color: #f5f5f5;
        }

        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 8px;
        }

        /* Styling for the search area */
        .search-container {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }

        .search-container input[type="text"] {
            width: 70%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-right: 10px;
        }

        .search-container button {
            padding: 8px 16px;
            font-size: 14px;
            color: #fff;
            background-color: #007bff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .search-container button:hover {
            background-color: #0056b3;
        }

        /* Styling for the grid/table */
        .grid-container {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .grid-container th, .grid-container td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        .grid-container th {
            background-color: #f2f2f2;
            font-weight: bold;
        }

        /* Styling for action buttons */
        .btn {
            padding: 5px 10px;
            font-size: 12px;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn-block {
            background-color: #dc3545;
        }

        .btn-block:hover {
            background-color: #c82333;
        }

        .btn-blockup {
            background-color: #28a745;
        }

        .btn-blockup:hover {
            background-color: #218838;
        }

        /* Default button style */
        .btn-back-to-search {
            background-color: green;
            color: white;
            border: 2px solid green;
            transition: background-color 0.3s, color 0.3s;
        }

         /* Default button style */
         .btn-back-to-search {
             background-color: green;
             color: white;
             border: 2px solid green;
             transition: background-color 0.3s, color 0.3s;
         }

 /* Hover effect */
 .btn-back-to-search:hover {
     background-color: #218838;
 }
        .message-label {
            color: red;
            font-weight: bold;
        }

         .modal {
        display: none;
        position: fixed;
        z-index: 1;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgba(0, 0, 0, 0.4);
    }

    .modal-content {
        background-color: #fefefe;
        margin: 10% auto;
        padding: 20px;
        border: 1px solid #888;
        width: 80%;
    }

    .close {
        color: #aaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }

    .close:hover,
    .close:focus {
        color: black;
        cursor: pointer;
    }
        

        input[type="button"]:hover {
            background-color: #218838;
        }
        button {
            padding: 10px 20px;
            font-size: 1em;
            margin: 5px;
            cursor: pointer;
        }
        button[type="button"] {
            background-color: #4CAF50;
            color: white;
            border: none;
        }
    </style>
    

</head>
<body>
    <form>
        <div class="file-upload-container">
            <label for="lblage">Age:</label>
            <input type="text" id="txtMinAge" runat="server" placeholder="Min Age">
            <input type="text" id="txtMaxAge" runat="server" placeholder="Max Age">
            <label>Qualification:</label>
            <asp:TextBox ID="txtQualification" runat="server" Placeholder="Qualification"></asp:TextBox><br />
        </div>   
        <div>
            <label>Skills:</label>
            <asp:TextBox ID="txtSkills" runat="server" Placeholder="Skills"></asp:TextBox><br />
        </div>
        <br />
        <div>
            <label>Experience:</label>
            <asp:TextBox ID="txtExperience" runat="server" Placeholder="Experience"></asp:TextBox>
        <br />
        </div>
        <br />
        <div>
        <asp:CheckBox ID="chkIncludeBlocked" runat="server" Text="Include Blocked" />
        </div>
        <asp:Button ID="btnSearch" runat="server" AutoPostBack="True" Text="Search" OnClick="btnSearch_Click" BackColor="#00CC00" ForeColor="White" />
        <br />
        <asp:GridView ID="gvResumes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" DataKeyNames="ResumeFileName">
            <Columns>
                <asp:BoundField DataField="CandidateID" HeaderText="CandidateID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                <asp:BoundField DataField="Skills" HeaderText="Skills" />
                <asp:BoundField DataField="Experience" HeaderText="Experience" />
                <asp:BoundField DataField="IsBlocked" HeaderText="IsBlocked" />
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkfilename" runat="server"  Text='<%# Eval("ResumeFileName") %>' OnClick="lnkfilename_Click" >Download</asp:LinkButton>
                    </ItemTemplate>
                   </asp:TemplateField>
             <asp:TemplateField HeaderText="Manage">
            <ItemTemplate>
                 <asp:HyperLink ID="hlManage" runat="server" Text="Manage" NavigateUrl='<%# "ManageResumes.aspx?CandidateID=" + Eval("CandidateID") %>' />
                     
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>
        </asp:GridView>


       
    <asp:Label ID="Label1" runat="server" CssClass="message-label"></asp:Label>
    <br />





     <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>

</form>
</body>
</html>
</asp:Content>
