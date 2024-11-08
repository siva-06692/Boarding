<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compare resumes.aspx.cs" Inherits="Boarding.Compare_resumes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html>
<head>
    <title>Compare Resumes</title>
</head>
    <style>
            /* Custom styles for Compare Resumes page */
            .resume-container {
                width: 80%;
                margin: auto;
                padding: 20px;
                border: 1px solid #ddd;
                border-radius: 10px;
                background-color: #f9f9f9;
            }

            .resume-container h1 {
                text-align: center;
                color: #333;
                margin-bottom: 20px;
                font-family: Arial, sans-serif;
            }

            .grid-view {
                width: 100%;
                border-collapse: collapse;
                margin-top: 20px;
                font-family: Arial, sans-serif;
            }

            .grid-view th, .grid-view td {
                padding: 12px;
                border: 1px solid #ddd;
                text-align: left;
            }

            .grid-view th {
                background-color: #4CAF50;
                color: white;
            }

            .grid-view tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            .grid-view tr:hover {
                background-color: #ddd;
            }
        </style>
<body>
    <form id="form1">
        <div class="resume-container">
        <h1>Compare Resumes</h1>
       <asp:GridView ID="GridViewResumes" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="ResumeID" HeaderText="Resume ID" />
            <asp:BoundField DataField="ResumeText" HeaderText="Resume Text" />
            <asp:BoundField DataField="Score" HeaderText="Score" />
        </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>

</asp:Content>

