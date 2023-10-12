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
                                                        <label for="totcount" class="form-label">Reservation ID : <span id="rid">0</span></label> <br />
                                                        <label for="totcount" class="form-label">Movie Name : <span id="movie">0</span></label> <br />
                                                        <label for="totcount" class="form-label">Theater : <span id="theater">0</span></label> <br />
                                                        <label for="totcount" class="form-label">Date : <span id="moviedate">0</span></label> <br />
                                                        <label for="totcount" class="form-label">Time : <span id="movietime">0</span></label> <br />
                                                        <label for="totcount" class="form-label">Adult Count : <span id="adultcount">0</span></label> <br />
                                                        <label for="totcount" class="form-label">Child Count : <span id="childcount">0</span></label> <br />
                                                        <label for="totcount" class="form-label">Total Price : <span id="price">0</span></label> <br />
                                                       <br />
                                                     <h2>  <label for="price" class="form-label">Thank you and enjoy the movie! <span id="thank you"></span></label></h2> <hr />
                                                    </div>
                                                    
                                                    <!--    </center> -->
                                                    <div class="col-md-12">
                                                        <br />
                                                        <asp:Button ID="BtnAdd" runat="server" class="btn btn-primary" Text="Download Ticket" OnClick="BtnAdd_Click" />


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
