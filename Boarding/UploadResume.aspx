<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UploadResume.aspx.cs" Inherits="Boarding.UploadResume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
    body{
        background-color:lavender;
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
     form .file-upload-container input[type="file"] {
    padding: 5px;
    color:black;
}

form .file-upload-container input[type="submit"],
form .file-upload-container input[type="button"] {
    padding: 8px 16px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

form .file-upload-container input[type="submit"]:hover,
form .file-upload-container input[type="button"]:hover {
    background-color: #0056b3;
}

form .file-upload-container label {
    width: auto;
}
    input[type="button"], input[type="submit"] {
    background-color: #28a745;
    color: white;
    border: none;
    padding: 10px 20px;
    text-transform: uppercase;
    border-radius: 4px;
    cursor: pointer;
}

input[type="button"]:hover, input[type="submit"]:hover {
    background-color: #218838;
}

/* Styling the message label */
form .lbl-message {
    font-size: 14px;
    color: #ff0000;
    margin-top: 10px;
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
.lbl-message{
    color:green
}


    </style>
</head>
 <body>
        <form>
            <div class="file-upload-container">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
            </div>
            <div>
                <asp:Label ID="lblResumeFileName" runat="server" Visible="false"></asp:Label>

                <label>Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            </div>
             <div>
                 <label>DOB:</label>
                 <asp:TextBox ID="TxtDOB" runat="server"></asp:TextBox><br />
           </div>
            <div>
                <label>Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><br />
            </div>
            <div>
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            </div>
            <div>
                <label>Experience:</label>
                <asp:TextBox ID="txtExperience" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <label>Qualification:</label>
                <asp:TextBox ID="txtQualification" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <label>Skills:</label>
                <asp:TextBox ID="txtSkills" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
            </div>
             <asp:Label ID="lblMessage" runat="server" Text="" CssClass="lbl-message"></asp:Label> <br />
            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="Submit_Click" />
           
            <div><br />
            </div>
        </form>
    </body>
</html>
</asp:Content>
