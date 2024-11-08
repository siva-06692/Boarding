<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewApprovalMRFList.aspx.cs" Inherits="Boarding.ViewApprovalMRFList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">

        <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>


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

        .container {
               width: 100%;
              
           }

           .grid-container {
               margin-top: 20px;
               display: flex;
               justify-content: left;
               width:100%;
           }

           .grid {
                width: 100%;
                border-collapse: collapse;
                border: solid 1px #525252;

            }

            .grid th, .grid td {
                padding: 10px;
                text-align: left;
                border: solid 1px #dcdcdc;
            }

            .grid th {
                background-color: rgb(83,145,245);
            }

        .button-container {
            text-align: right; 
            margin-top: 20px;
        }

        button,reset {
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
        button[type=reset]{
            background-color: #4CAF50;
            color: white;
            border: none;
        }
        /* Add this to your CSS or <style> section */
        .btn-custom {
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            cursor: pointer;
            border-radius: 5px;
        }


        .auto-style2 {
            position: relative;
            width: 25%;
            -ms-flex: 0 0 25%;
            flex: 0 0 auto;
            max-width: 25%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        
        </style>
</head>
<body>
    <form>
        <div class="container form-container">
            <div class="form-header">
                <h1>Manpower Updation</h1>
             </div>
         
            <div class="row mb-3">
                <div class="col-md-3 mt-3">
                    <label for="Requestdate">Request Date</label>  
                </div>
            <div class="col-md-3 mt-3">
                <asp:TextBox ID="requestdate" CssClass="form-control" runat="server" />
            </div>
                 <div class="col-md-3 mt-3">
                        <label for="Mrfno">MRF No</label>  
                 </div>
                <div class="col-md-3 mt-3">
                    <asp:TextBox ID="txtmrfno" CssClass="form-control" runat="server" />
                </div>
                 <asp:Label ID="lblmrfcompid" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="lblmrfno" runat="server" Visible="False"></asp:Label>
                <div class="col-md-3 mt-3">
                    <label for="Company" class="form-label">Company</label></div>
                <div class="col-md-3 mt-3">
                    <asp:DropDownList ID="cbocompany" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cbocompany_id_SelectedIndexChanged" style="padding: 10px" Width="227px">
                       <asp:ListItem Value="0">--Select Company--</asp:ListItem> 
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 mt-3">
                    <label for="positiontitle" class="form-label">Position Title</label>
                </div>
                <div class="col-md-3 mt-3">
                    <input type="text" class="form-control" id="txtpositiontitle" runat="server" name="position-title"/>
                </div>
                <div class="col-md-3 mt-3">
                    <label for="novacancies" class="form-label">No. of Vacancies</label>
                </div>
                <div class="col-md-3 mt-3">
                     <asp:TextBox ID="txtnoofvacancies" CssClass="form-control" runat="server" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />

                </div><br /><br />
                <div class="col-md-3 mt-3">
                    <label for="department" class="form-label">Department</label>
                </div>
                <div class="col-md-3 mt-3">
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
                       <input type="text" class="form-control" id="txtrecruitment" name="replace" runat="server" placeholder="EmpCode"  />
                    </div>
                </div>
             <div class="row mb-2 ">
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
             <div class="row mb-2">
                   <div class="col-md-3">
                        <label for="describe" class="form-label">Technical/Functional Expertise</label>
                    </div>
                    <div class="col-md-10">
                        <textarea id="txttechexpertise" runat="server" class="tech"></textarea>
                    </div>     
             </div>
            <div class="row mb-2">
                   <div class="col-md-3">
                        <label for="job" class="form-label">Brief Job Description</label>
                        <textarea id="jobdescription" runat="server" class="job"></textarea>
                    </div>     
             </div>
            <div class="row mb-2">
                    <div class="col-md-3">
                            <label for="remark"class="form-label">Remarks</label>  
                         <textarea id="txtremark" runat="server" class="remark" maxlength="500"></textarea>
                    </div>
                </div>
                <div class="row mb-2 ">
                   <div class="col-md-3 mt-3">
                        <label for="status" class="form-label">Status</label>
                        </div>
                         <div class="auto-style2">
                       <asp:DropDownList ID="dbostatus" runat="server" style="padding: 10px" Width="245px">
                           <asp:ListItem Value="0">--Select status--</asp:ListItem>
                           <asp:ListItem Value="A">Approved</asp:ListItem>
                           <asp:ListItem Value="J">Reject</asp:ListItem>
                       </asp:DropDownList>
                   </div>
                    <div class="col-md-3 mt-3">
                        <label for="vacancycode" class="form-label">Vacancy Code</label>
                    </div>
                    <div class="col-md-3 mt-3">
                         <asp:TextBox ID="txtvacancycode" CssClass="form-control" runat="server" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                    </div>
                   </div>

            <div class="row mb-2">
                  <div class="col-md-15">  
                       <label for="MRFlog" class="form-label">MRF Log</label><br />
                        <div class="grid-container">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="grid"
                                          Visible="true" AllowPaging="True" PageSize="10" DataKeyNames=""
                                          OnPageIndexChanging="GridView1_PageIndexChanging">
                                <AlternatingRowStyle BackColor="#99CCFF" />
                                <RowStyle BackColor="#CCFFCC" />
                                <Columns>
                                    <asp:BoundField DataField="Log_No" HeaderText="Log No" />
                                    <asp:BoundField DataField="Prepared_By_With_Company"  HeaderText="Prepared By" />
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                    <asp:BoundField DataField="Log_remark" HeaderText="Log_remark" />
                                    <asp:BoundField DataField="Prepared_DateTime" HeaderText="Prepared DateTime" DataFormatString="{0:dd/MM/yyyy  HH:MM:ss}" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="row mb-2">
    <div class="col-md-15">
        <label for="lblTobeapproved" class="form-label">To Be Approved By</label>
        <asp:ScriptManager ID="scriptmanager1" runat="server">  
        </asp:ScriptManager>  
        <div class="grid-container">
            <asp:UpdatePanel ID="updatepanel" runat="server">  
            <ContentTemplate>  
            <table class="table table-bordered">
                <thead>
                    <tr style="background-color:cornflowerblue">
                        <th>S.No</th>
                        <th>Company Name</th>
                        <th>Employee Name</th>
                        <th>Employee Code</th>
                        <th>Designation</th>
                    </tr>
                </thead>
                <tbody>
                    <tr style= "background-color:palegreen">
                        <td>1</td>
                           <td>
                                <asp:DropDownList ID="cbocompany1" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cbocompany1_id_SelectedIndexChanged" style="padding: 5px" Width="210px">
                                 <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                        <td>
                            <asp:DropDownList ID="cboempname1" runat="server" style="padding: 5px" Width="210px" AppendDataBoundItems="True"  AutoPostBack="True" OnSelectedIndexChanged ="cboempname1_id_SelectedIndexChanged">
                            <asp:ListItem Value="0">--Select Employee--</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmpCode1" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtdesignation1" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" AutoPostBack="True" />
                         </td>
                    </tr>
                    
                    <tr style= "background-color:deepskyblue">
                        <td>2</td>
                        <td>
                                <asp:DropDownList ID="cbocompany2" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cbocompany2_id_SelectedIndexChanged" style="padding: 5px" Width="210px">
                                <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            <asp:DropDownList ID="cboempname2" runat="server" style="padding: 5px" Width="210px" AppendDataBoundItems="True"  AutoPostBack="True"  OnSelectedIndexChanged="cboempname2_id_SelectedIndexChanged">
                           <asp:ListItem Value="0">--Select Employee--</asp:ListItem>
                           </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmpCode2" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtdesignation2" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                        </td>
                    </tr>
                    <tr style= "background-color:palegreen">
                        <td>3</td>
                        <td>
                               <asp:DropDownList ID="cbocompany3" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cbocompany3_id_SelectedIndexChanged" style="padding: 5px" Width="210px">
                                <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                               <asp:DropDownList ID="cboempname3" runat="server" style="padding: 5px" Width="210px" AppendDataBoundItems="True" AutoPostBack="True"  OnSelectedIndexChanged="cboempname3_id_SelectedIndexChanged">
                               <asp:ListItem Value="0">--Select Employee--</asp:ListItem>
                               </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmpCode3" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtdesignation3" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                        </td>
                    </tr>
                    <tr style= "background-color:deepskyblue">
                        <td>4</td>
                        <td>
                            <asp:DropDownList ID="cbocompany4" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cbocompany4_id_SelectedIndexChanged" style="padding: 5px" Width="210px">
                           <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                           </asp:DropDownList>
                            </td>
                            <td>
                            <asp:DropDownList ID="cboempname4" runat="server" style="padding: 5px" Width="210px" AppendDataBoundItems="True" AutoPostBack="True"  OnSelectedIndexChanged="cboempname4_id_SelectedIndexChanged">
                           <asp:ListItem Value="0">--Select Employee--</asp:ListItem>
                           </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmpCode4" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtdesignation4" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                       </td>
                    </tr>
                    <tr style= "background-color:palegreen">
                        <td>5</td>
                              <td>
                                <asp:DropDownList ID="cbocompany5" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cbocompany5_id_SelectedIndexChanged" style="padding: 5px" Width="210px">
                                <asp:ListItem Value="0">--Select Company--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            <asp:DropDownList ID="cboempname5" runat="server" style="padding: 5px" Width="210px" AppendDataBoundItems="True" AutoPostBack="True"  OnSelectedIndexChanged="cboempname5_id_SelectedIndexChanged">
                           <asp:ListItem Value="0">--Select Employee--</asp:ListItem>
                           </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmpCode5" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                        </td>
                        <td>
                           <asp:TextBox ID="txtdesignation5" CssClass="form-control" runat="server" style="padding: 5px" Width="210px" onkeypress="return event.charCode == 46 || (event.charCode >= 48 && event.charCode <= 57)" />
                        </td>
                    </tr>
                </tbody>
            </table>
           </ContentTemplate>  
           </asp:UpdatePanel> 
        </div>
    </div>
</div>
            
            <div class="button-container">
            <asp:Button ID="btnsave"  runat="server" Text="Submit" OnClientClick="return showConfirmationModal();" OnClick="Submit_Click" CssClass="btn-custom"/>
            <button type="reset" id="btnreset" runat="server" onserverclick="Reset_Click">Exit</button>
        </div>

        <div class="modal fade" id="confirmationModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Workflow has not been defined.Shall we proceed MRF to next level?</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Would you like to continue?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button>
                        <button type="button" class="btn btn-primary" id="confirmYesButton">Yes</button>
                    </div>
                </div>
            </div>
        </div>

        <div>
            <asp:Label ID="err" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#FF3300"></asp:Label>
        </div>


        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
        <script type="text/javascript">
            function showConfirmationModal() {
                var modal = new bootstrap.Modal(document.getElementById('confirmationModal'), {});
                modal.show();
                return false;
            }

            $(document).ready(function () {
                $('#confirmYesButton').click(function () {
                    // Hide the modal before triggering the actual save button click
                    $('#confirmationModal').modal('hide');

                    // Prevents the modal from reappearing
                    setTimeout(function () {
                        document.getElementById('<%= btnsave.ClientID %>').onclick = null; // Detaches the onclick handler to prevent looping
            $('#<%= btnsave.ClientID %>').click();
        }, 500); // Delay to ensure the modal closes before form submission
    });
}); 



        </script>



</body>

</asp:Content>
