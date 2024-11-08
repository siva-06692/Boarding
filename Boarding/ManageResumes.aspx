<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageResumes.aspx.cs" Inherits="Boarding.ManageResumes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: lavender;
            margin: 0;
            padding: 20px;
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

        /* Hover effect */
        .btn-back-to-search:hover {
            background-color: #218838;
        }

        

        /* Message label styling */
        .message-label {
            color: red;
            font-weight: bold;
        }

        /* Modal styles */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
            padding-top: 60px; /* Location of the box */
        }

        .modal-content {
            background-color: #fefefe;
            margin: 5% auto; /* 15% from the top and centered */
            padding: 20px;
            border: 1px solid #888;
            width: 80%; /* Could be more or less, depending on screen size */
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
            text-decoration: none;
            cursor: pointer;
        }
    </style>
    <script>
        function showModal(candidateId) {
            document.getElementById('modal').style.display = 'block';
            document.getElementById('candidateId').value = candidateId;
        }

        function closeModal() {
            document.getElementById('modal').style.display = 'none';
        }

        function blockCandidate() {
            var candidateId = document.getElementById('candidateId').value;
            var reason = document.getElementById('reason').value;

            // Here you can submit the reason and candidateId via AJAX or a form submission
            __doPostBack('candidateGrid', 'Block$' + candidateId + '$' + reason);
            closeModal();
        }

        window.onclick = function(event) {
            if (event.target == document.getElementById('modal')) {
                closeModal();
            }
        }
    </script>
</head>
<body>
    <form>
        <div class="container">
            <h2>Manage Resumes</h2>

            <div class="search-container">
                <asp:TextBox ID="txtskill" runat="server" CssClass="form-control" Placeholder="Enter skill"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" />
            </div>
            <asp:Label ID="prep_by" runat="server" Text="Label" Visible="False"></asp:Label>

            <asp:GridView ID="candidateGrid" runat="server" PageSize="5" AllowPaging="True" AutoGenerateColumns="False" CssClass="grid-container" OnRowCommand="candidateGrid_RowCommand" OnPageIndexChanging="candidateGrid_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="CandidateId" HeaderText="Candidate ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="ResumeFileName" HeaderText="Resume File Name" />
                    <asp:BoundField DataField="Skills" HeaderText="Skills" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnBlock" runat="server" Text="Block" CommandName="Block" CommandArgument='<%# Eval("CandidateId") %>' CssClass="btn btn-block" OnClientClick='<%# "showModal(\"" + Eval("CandidateId") + "\"); return false;" %>' />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
            <br />
            <asp:Button ID="btnBackToSearch" runat="server" Text="Back" CssClass="btn btn-back-to-search" OnClick="btnBackToSearch_Click" />


        <!-- Modal for Block Reason and Date -->
            <div id="blockModal" style="display:none;">
                <h3>Block Candidate</h3>
                <asp:Label ID="lblReason" runat="server" Text="Reason:" AssociatedControlID="txtReason" />
                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" />
                <asp:Label ID="lblBlockUntil" runat="server" Text="Block Until:" AssociatedControlID="blockedUntilDate" />
                <asp:TextBox ID="blockedUntilDate" runat="server" TextMode="Date" CssClass="form-control" />
                <asp:Button ID="btnConfirmBlock" runat="server" Text="Confirm Block" OnClick="btnConfirmBlock_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>
</asp:Content>
