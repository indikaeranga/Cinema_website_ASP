<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_Tickets_Details.aspx.cs" Inherits="Cinema.User_Tickets_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="fashion_section">
         <div id="main_slider" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
               <div class="carousel-item active">
                  <div class="container"> <br /><br />
                     <h1 class="fashion_taital">Your Booking Details</h1>
                     <div class="fashion_section_2">
                        
                         <div class="row"> 
                                <div class="col-md-5 mx-auto">
                                    <div class="card">

                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col">
                                                    <!--    <center> -->
                                                 
                                                 
                                                    <div class="col-md-12">
                                                        <label for="totcount" class="form-label">Reservation ID :</label>
                                                         <asp:Label ID="lblrid" class="card-title" runat="server"></asp:Label>
                                                        <br />
                                                       
                                                        <label for="totcount" class="form-label">Movie Name : </label>
                                                        <asp:Label ID="lblMoviename" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Theater : </label> 
                                                        <asp:Label ID="lbltheater" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Date : </label> 
                                                        <asp:Label ID="lbldate" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Time : </label>
                                                        <asp:Label ID="lbltime" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Adult Count : </label>
                                                        <asp:Label ID="lbladultcount" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Child Count : </label>
                                                        <asp:Label ID="lblchildcount" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Total Count : </label>
                                                        <asp:Label ID="lbltotalcount" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Total Price : </label> 
                                                        <asp:Label ID="lbltotprice" class="card-title" runat="server" ></asp:Label>
                                                        <br />

                                                        <label for="totcount" class="form-label">Email Address : </label> 
                                                        <asp:Label ID="lblphone" class="card-title" runat="server" ></asp:Label>
                                                        <br />
                                                        <br />
                                                     <h2>  <label for="price" class="form-label">Thank you and enjoy the movie! <span id="thank you"></span></label></h2> <hr />
                                                    </div>
                                                    
                                                    <!--    </center> -->
                                                    <div class="col-md-12">
                                                        <br />
                                                        <asp:Button ID="BtnAdd" runat="server" class="btn btn-primary" Text="Download Ticket" OnClick="BtnAdd_Click" /> &nbsp;&nbsp;
                                                        <asp:Button ID="btnmail" runat="server" class="btn btn-success" Text="Email Ticket" OnClick="btnmail_Click"  />
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                             
                            </div>
                        </div>
                </div>
            </div>

        </div>
    </div>
    </div>
</asp:Content>
