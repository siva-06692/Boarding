<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MRF.aspx.cs" Inherits="Boarding.MRF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<head>
    <title></title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            background-color:lavender;
        }
        .form-container {
            border: 1px solid #000;
            padding: 15px;
        }
        .form-header {
            background-color: #3172a7;
            padding: 5px;
            text-align: center;
            color: white;
            display: flex;
            align-items: center;
            justify-content: space-between;
        }
        .form-header h1 {
            margin: 0;
            font-size: 24px;
            flex-grow: 1;
            text-align: center;
        }
        .job,.tech, .remark {

            width: 1000px;
            height: 83px;
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
        <div class="container form-container">
            <div class="form-header">
                <h1>Manpower Request Form</h1>
             </div>
        
            <div class="row mb-3">
                <div class="col-md-3 mt-3">
                    <label for="Requestdate">Request Date</label>  
                </div>
            <div class="col-md-3 mt-3">
                <asp:TextBox ID="requestdate" CssClass="form-control" runat="server" />

            </div>
                <div class="col-md-3 mt-3">
                    <label for="Company" class="form-label">Company</label>
                </div>
                <div class="col-md-3 mt-3">
                    <asp:DropDownList ID="cbocompany" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cbocompany_id_SelectedIndexChanged" style="padding: 10px" Width="227px">
                       <asp:ListItem Value="0">--Select Company--</asp:ListItem> 
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 ">
                    <label for="positiontitle" class="form-label">Position Title</label>
                </div>
                <div class="col-md-3 ">
                    <input type="text" class="form-control" id="txtpositiontitle" runat="server" name="position-title"/>
                </div>
                <div class="col-md-3 ">
                    <label for="novacancies" class="form-label">No. of Vacancies</label>
                </div>
                <div class="col-md-3 ">
                    <asp:TextBox ID="txtnoofvacancies" CssClass="form-control" runat="server" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)"/>
                </div><br /><br />
                <div class="col-md-3">
                    <label for="department" class="form-label">Department</label>
                </div>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="cbodepartment" runat="server" style="padding: 10px" Width="245px" AppendDataBoundItems="True" OnSelectedIndexChanged="cbodept_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="0">--Select Department--</asp:ListItem> 
                    </asp:DropDownList>

                </div>
            </div>
              <div class="row mb-3 ">
                <div class="col-md-3">
                    <label for="reportingto" class="form-label">Reporting to</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="cboreportcompname" runat="server" style="padding: 10px" Width="245px" AppendDataBoundItems="True" OnSelectedIndexChanged="cboreport_compname_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="0">--Select Company--</asp:ListItem> 
                        </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="cboreportempcode" runat="server" style="padding: 10px" Width="245px" AppendDataBoundItems="True" OnSelectedIndexChanged="cboreport_empcode_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0">--Select EmpCode--</asp:ListItem> 
                    </asp:DropDownList>
                </div><br />
            </div>
                <div class="row mb-3">
                    <div class="col-md-3">
                        <label for="hod" class="form-label">First Level Approval</label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlhod_comp_id" runat="server" style="padding: 10px" Width="245px" AppendDataBoundItems="True" OnSelectedIndexChanged="cbofirst_level_approval_CompId_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">--Select Company--</asp:ListItem> 
                        </asp:DropDownList>
                    </div>
                     <div class="col-md-3">
                         <asp:DropDownList ID="ddlhodemp_code" runat="server" style="padding: 10px" Width="245px" AppendDataBoundItems="True" OnSelectedIndexChanged="cbofirst_level_approval_empcode_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">--Select EmpCode--</asp:ListItem> 
                        </asp:DropDownList>
                         
                     </div>
                </div>
                <div class="row mb-3">
                    <div class="col-md-3">
                        <label class="form-label">Reason for Recruitment:</label>
                    </div>
                    <div class="col-md-3 ">
                        <asp:DropDownList ID="cdorecruitment" runat="server" style="padding: 10px"  Width="245px" OnSelectedIndexChanged="cdorecruitment_SelectedIndexChanged" AutoPostBack="True" maxlength="500" >
                            <asp:ListItem Value="0">--Select reason--</asp:ListItem>
                            <asp:ListItem Value="B">Budgeted</asp:ListItem>
                            <asp:ListItem Value="N">New Position</asp:ListItem>
                            <asp:ListItem Value="R">Replacement</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3 ">
                       <label for="recruitment" class="form-label" >If Replacement(For Whom)</label>
                    </div>
                    <div class="col-md-3 ">
                       <input type="text" class="form-control" id="lblrecruitment" name="replace" runat="server" placeholder="EmpCode"  />
                    </div>
                </div>
             <div class="row mb-3 ">
                 <h4 style="background-color:#3172a7; text-align: center; color: #FFFFFF;" "text-align:center" >Candidate Specification</h4>
                   <div class="col-md-3 ">
                        <label for="qualification" class="form-label">Qualification</label>
                       </div>
                    <div class="col-md-3 ">
                        <input type="text" class="form-control" id="txtqualification" name="qualification" runat="server" placeholder="qualification"/>
                       </div>
                    <div class="col-md-3 ">
                        <label for="Experiance" class="form-label">Experience</label><br />
                         </div>
                    <div class="col-md-3 ">
                        <asp:TextBox ID="txtExperiance" CssClass="form-control" runat="server" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" /> 
                    </div>  
                 </div>
             <div class="row mb-3">
                   <div class="col-md-3">
                        <label for="describe" class="form-label">Technical/Functional Expertise</label>
                        <textarea id="txttechexpertise" runat="server" class="tech"></textarea>
                    </div>     
             </div>
            <div class="row mb-3">
                   <div class="col-md-3">
                        <label for="job" class="form-label">Brief Job Description</label>
                        <textarea id="jobdescription" runat="server" class="job"></textarea>
                    </div>     
             </div>
            <div class="row mb-3 ">
                    <div class="col-md-3">
                            <label for="remark">Remarks</label>  
                         <textarea id="txtremark" runat="server" class="remark" maxlength="500"></textarea>
                    </div>
                </div>
                <div class="row mb-3 ">
                   <div class="col-md-3">
                        <label for="status" class="form-label">Status</label>
                        </div>
                         <div class="col-md-3">
                       <asp:DropDownList ID="status" runat="server" style="padding: 10px" Width="245px">
                           <asp:ListItem Value="0">--Select status--</asp:ListItem>
                           <asp:ListItem Value="S">Submit</asp:ListItem>
                           <asp:ListItem Value="D">Draft</asp:ListItem>
                           <asp:ListItem Value="J">Reject</asp:ListItem>
                       </asp:DropDownList>
                   </div>
                    </div>
                   
            </div>
            <div>
            <button type="button"  id="btnsave"  runat="server"   onserverclick ="Submit_Click">Save</button>
            </div>
            <asp:Label   ID="err"   runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#FF3300" ></asp:Label>

        </form>
   </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
    
</asp:Content>
