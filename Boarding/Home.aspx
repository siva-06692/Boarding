<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Boarding.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <!DOCTYPE html>
    <html>
        <head>
            <title> </title>
                <link href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet">
            <style>
                body {
                    font-family: Arial, sans-serif;
                    margin: 0;
                    padding: 20px;
                    background-color: rgb(252, 232, 252);
                    font-family: sans-serif;
                    text-align: center;
                }
                .breadcrumb {
                        list-style: none;
                        display: flex;
                        padding: 10px 0;
                        background-color: #e9ecef;
                        border-radius: 5px;
                    }

                    .breadcrumb li {
                        margin-right: 5px;
                    }

                    .breadcrumb li a {
                        text-decoration: none;
                        color: #007BFF;
                    }

                    .breadcrumb li a:hover {
                        text-decoration: underline;
                    }

                    .breadcrumb .active {
                        color: #6c757d;
                    }



                .container {
                    display: flex;
                    gap: 20px;
                    justify-content: flex-start;
                    margin-top: 20px;
                    
                }
                .container2{
                    display: flex;
                    gap: 20px;
                    justify-content: flex-start;
                    margin-top: 20px;
                    margin-left:10px;
                    
                }

                .heading {
                    text-align: left;
                    margin-left: 20px; 
                }


                .small-box {
                    position: relative;
                    width: 200px;
                    height: 200px;
                    background-color: lightblue;
                    border-radius: 10px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                    display: flex;
                    flex-direction: column;
                    justify-content: center;
                    align-items: center;
                    padding: 20px;
                    color: #ac47f1;
                    background-size: 80px;
                    background-position: right;
                    background-repeat: no-repeat;
                }

                    .orange {
                        background-color: rgb(255, 165, 0);
                        background-image: url(https://cdn-icons-gif.flaticon.com/12035/12035178.gif);
                        background-blend-mode: multiply;
                        opacity: 0.9;
                    }

                    .yellow {
                        background-color: rgb(255, 255, 0);
                        color: #000; 
                        background-image: url(https://cdn-icons-gif.flaticon.com/17626/17626878.gif); 
                        background-blend-mode: multiply;
                        opacity: 0.9; 
                    }

                    .green {
                        background-color: rgb(0, 128, 0);
                        background-image: url(https://cdn-icons-gif.flaticon.com/15700/15700522.gif); 
                        background-blend-mode: multiply;
                        opacity: 0.9; 
                    }

                    .red {
                        background-color: rgb(235, 5, 70);
                        background-image: url(https://cdn-icons-gif.flaticon.com/14165/14165003.gif); 
                        background-blend-mode: multiply;
                        opacity: 0.9; 
                    }
                    .blue{
                        background-image: url(https://cdn-icons-gif.flaticon.com/11188/11188709.gif); 
                        background-blend-mode: multiply;
                        opacity: 0.9; 
                    }
                    .lightpink {
                        background-color:rgb(240, 117, 223);
                        background-image: url(https://cdn-icons-gif.flaticon.com/11677/11677478.gif); 
                        background-blend-mode: multiply;
                        opacity: 0.9; 
                    }
                    .lightgreen {
                        background-color:rgb(51, 222, 29);
                       background-image: url(https://cdn-icons-gif.flaticon.com/11237/11237478.gif); 
                        background-blend-mode: multiply;
                        opacity: 0.9; 
                    }
                    .pink {
                        background-color:rgb(241, 32, 91);
                       background-image: url(https://cdn-icons-gif.flaticon.com/14165/14165003.gif); 
                        background-blend-mode: multiply;
                        opacity: 0.9;   
                    }

                    
                    .small-box:hover{
                        background:ivory; 
                    }

                    .icon-top-left {
                        position: absolute;
                        top: 10px;
                        left: 10px;
                        color:black;
                    }

                    .lbl_draft_count {
                        position: absolute;
                        bottom: 50px;
                        left: 50px;
                        font-size: 50px;
                    }
                    .lbl_submitted_count {
                        position: absolute;
                        bottom: 50px;
                        left: 50px;
                        font-size: 50px;
                    }
                   
                    .lbl_rejected_count {
                        position: absolute;
                        bottom: 50px;
                        left: 50px;
                        font-size: 50px;
                    }
                    .lbl_closed_count
                    {
                        position: absolute;
                        bottom: 50px;
                        left: 50px;
                        font-size: 50px;
                    }
                    .lbl_pending_to_be_approved_count
                    {
                        position: absolute;
                        bottom: 50px;
                        left: 50px;
                        font-size: 50px;
                    }
                    .lbl_approved_count
                    {
                        position: absolute;
                        bottom: 50px;
                        left: 50px;
                        font-size: 50px;
                    }
                    .lbl_approver_rejected_Count
                    {
                        position: absolute;
                        bottom: 50px;
                        left: 50px;
                        font-size: 50px;
                    }
                     .lbl_draft_count label,.lbl_submitted_count label,
                     .lbl_rejected_count label, 
                     .lbl_closed_count label,.lbl_pending_to_be_approved_count label,
                      .lbl_approved_count label,.lbl_approver_rejected_Count label
                    {
                        color:rgb(138, 10, 133);
                    }
                    .lbl_draft_count label :hover,.lbl_submitted_count label :hover,
                    .lbl_rejected_count label :hover, 
                    .lbl_closed_count label :hover,.lbl_pending_to_be_approved_count label :hover,
                     .lbl_approved_count label :hover,.lbl_approver_rejected_Count label :hover{
                        color:rgb(13, 12, 13);
                        text-decoration:underline;
                        
                    }

                .icon {
                    font-size: 24px;
                    font-weight: bold;
                    margin-bottom: 40px;
                }
                .view-more {
                    margin-top: auto;
                    font-size: 16px;
                    color: #007BFF;
                }

                .view-more a {
                    text-decoration: none;
                    color: inherit;
                }

                .view-more a:hover {
                    text-decoration: underline;
                }
            </style>
        </head>
        <body>
            <div class="heading">
                <h4>My Requests</h4>
            </div>
            <div class="container">
                
                <div class="small-box orange">
                    <div class="icon-top-left">
                        <span class="icon icon-pencil">Draft</span>
                    </div>
                    <div class="lbl_draft_count">
                        <asp:Label ID="lbl_Draft_Count" runat="server" ></asp:Label>
                    </div>
                    <div class="view-more">
                        <a href="ViewPendingList.aspx"  runat="server" onclick="location.href=this.href+'?status=D';return false;" id="href_draft">View More &rarr;</a>
                    </div>
                </div>

                <div class="small-box yellow">
                    <div class="icon-top-left">
                        <span class="icon icon-file-text">Inprogress</span>
                    </div>
                    <div class="lbl_submitted_count">
                        <asp:Label ID="lbl_Submit_Count" runat="server"></asp:Label>
                    </div>
                    <div class="view-more">
                        <a href="ViewPendingList.aspx"  runat="server" onclick="location.href=this.href+'?status=S';return false;" id="href_submit">View More &rarr;</a>
                    </div>
                </div>

                

                <div class="small-box red">
                    <div class="icon-top-left">
                        <span class="icon icon-thumbs-down">Rejected</span>
                    </div>
                    <div class="lbl_rejected_count">
                        <asp:Label ID="lbl_Rejected_Count" runat="server"></asp:Label>
                    </div>
                    <div class="view-more">
                        <a href="ViewPendingList.aspx"  runat="server" onclick="location.href=this.href+'?status =J';return false;" id="href_reject">View More &rarr;</a>
                    </div>
                </div>

                <div class="small-box blue">
                    <div class="icon-top-left">
                        <span class="icon  icon-remove-sign">Closed</span>
                    </div>
                    <div class="lbl_closed_count">
                        <asp:Label ID="lbl_Closed_Count" runat="server"></asp:Label>
                    </div>
                    <div class="view-more">
                        <a href="#">View More &rarr;</a>
                    </div>
                </div>
            </div>
            <div class="heading">
                <br />
                <h4>My Approval List</h4>
            </div>
            <div class="container2">
                <div class="small-box lightpink">
                    <div class="icon-top-left">
                        <span class="icon icon-exclamation-sign">Pending to be approved</span>
                    </div>
                     <div class="lbl_pending_to_be_approved_count">
                     <asp:Label ID="lbl_Pending_to_be_approved_Count" runat="server"></asp:Label>
                 </div>
                    <div class="view-more">
                        <a href="ViewApprovalList.aspx"  runat="server" onclick="location.href=this.href+'?status=S';return false;" id="href_submitted">View More &rarr;</a>
                    </div>
                </div>

                <div class="small-box lightgreen">
                    <div class="icon-top-left">
                        <span class="icon icon-check-sign">Approved</span>
                    </div>
                        <div class="lbl_approved_count">
                            <asp:Label ID="lbl_approved_count" runat="server"></asp:Label>
                        </div>
                    <div class="view-more">
                        <a href="ApprovedList.aspx"  runat="server" onclick="location.href=this.href+'?status=A';return false;" id="href_Approved">View More &rarr;</a>
                    </div>
                </div>

                <div class="small-box pink">
                    <div class="icon-top-left">
                        <span class="icon icon-thumbs-down">Rejected</span>
                    </div>
                        <div class="lbl_approver_rejected_Count">
                            <asp:Label ID="lbl_approver_rejected_Count" runat="server"></asp:Label>
                        </div>
                    <div class="view-more">
                        <a href="ViewApprovalList.aspx"  runat="server" onclick="location.href=this.href+'?status=J';return false;" id="href_Rejected">View More &rarr;</a>
                    </div>
                </div>
            </div>
        </body>
    </html>
</asp:Content>






