<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Seat_res_Report.aspx.cs" Inherits="Cinema.Admin_Seat_res_Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <!-- top section start -->
            <div class="logo_section">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="logo"><a href="#">
                                <h1>Reoprts</h1></a></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- top section end --> 
        <div class="container">
        <div class="row">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">                     
                              
                        <div class="row">
                            &nbsp;&nbsp;&nbsp; 
                            <asp:Button type="button" class="btn btn-primary" ID="BtnLogin" runat="server" Text="All Seat Reservation Details" OnClick="BtnLogin_Click" />
                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                            </div> 
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
