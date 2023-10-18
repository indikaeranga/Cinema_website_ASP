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
                            <asp:Button type="button" class="btn btn-primary" ID="BtnAllSeats" runat="server" Text="All Seat Reservation Details" OnClick="BtnAllSeats_Click" />
                        </div>                       
                            <hr />                           
                        <div class="row">
                          &nbsp;&nbsp;&nbsp; <h4><asp:Label ID="Label1" runat="server" Text="Please select a Movie for display future reservations :"></asp:Label></h4>  &nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="DropDownList1_Moviename" runat="server" class="btn btn-secondary dropdown-toggle" ></asp:DropDownList>&nbsp;&nbsp;
                            <asp:Button type="button" class="btn btn-primary" ID="Btnbymovie" runat="server" Text="Reservation Details" OnClick="Btnbymovie_Click"  />
                            <br />                           
                        </div> 
                            <hr />
                        
                        <div class="row">
                                 &nbsp;&nbsp;&nbsp; <h4><asp:Label ID="Label2" runat="server" Text="Upcomming schedules and reservations listed below. Report will show the reservations of movie."></asp:Label></h4>  &nbsp;&nbsp;&nbsp;
                         
                        </div>
                        
                        <div class="row">
                          
                            <asp:Repeater ID="MovieRepeater" runat="server" OnItemCommand="MovieRepeater_ItemCommand">
                                <ItemTemplate>
                                    <div class="col-lg-4 col-sm-4">
                                        <div class="card"> <br /> 
                                            <h5 class="shirt_text">Movie : <%# Eval("Movie_Name") %></h5>
                                            <h5 class="shirt_text">Theater : <%# Eval("Theater_Name") %></h5>
                                            <h5 class="shirt_text">Date : <%# Eval("Date") %></h5>
                                            <h5 class="shirt_text">Time : <%# Eval("Time") %></h5>
                                            
                                            <center>
                                                <asp:Button runat="server" Text="Show This Report" CssClass="btn btn-primary"
                                                    CommandName="Select" CommandArgument=<%# Eval("Schedule_ID") %> > </asp:Button> 
                                            </center><br />
                                        </div> <br />
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                           
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
