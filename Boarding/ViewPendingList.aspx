<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewPendingList.aspx.cs" Inherits="Boarding.ViewPendingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE HTML>
    <head>
        
         <style>
         html, body {
            height: 100%;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items:center;
            background-color:rgb(252, 232, 252); 
         }

         .hide
         {
             display:none;
         }
         .container {
                width: 90%;
            }

        .grid-container {
            margin-top: 20px;
            display: flex;
            justify-content: center;
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
        
        
</style>
   <body>
        <div class="grid-container">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  CssClass="grid"
                AllowPaging="True" PageSize="10" OnRowCreated="GridView1_RowCreated"
                OnPageIndexChanging="GridView1_PageIndexChanging" Visible="True">
                <AlternatingRowStyle BackColor="#99CCFF" /> 
                <RowStyle BackColor="#CCFFCC" />   
                <Columns>

                    <asp:TemplateField HeaderText =" MRF Company ID" >
                        <ItemTemplate>
                        <asp:Label ID="lblmrfcompid" runat="server" Text='<%# Eval("Company_Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="MRF_Company_Id" HeaderText="MRF Company Name" />
                    
                    <asp:TemplateField HeaderText="MRF NO">
                        <ItemTemplate>
                            <asp:LinkButton ID="link_MRFNo" runat="server" Text='<%# Eval("MRF_NO") %>' OnClick="GetMrfnodetails"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="MRF_Date" HeaderText="MRF Date" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Position_title" HeaderText="Position Title" />
                    <asp:BoundField DataField="No_of_vacancies" HeaderText="No of Vacancies" />
                    <asp:BoundField DataField="Department_Name" HeaderText="Department Name" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />

                </Columns>
            </asp:GridView>
        </div>
    </body>
</asp:Content>
