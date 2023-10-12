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
                                <div class="col-md-5">
                                    <div class="card">

                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col">
                                                    <!--    <center> -->
                                                    <div class="col-md-12">
                                                        <label for="adultSeat" class="form-label">Adult Seat</label>
                                                        <asp:TextBox ID="Textadult" runat="server" class="form-control" TextMode="Number" MaxLength="0"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <label for="childSeat" class="form-label">Child Seat</label>
                                                        <asp:TextBox ID="Textchild" type="text" runat="server" class="form-control" TextMode="Number" MaxLength="0"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12">
                                                        <label for="totcount" class="form-label">Total Count : <span id="totalCount">0</span></label>
                                                        <label for="price" class="form-label">Total Price : <span id="totalPrice">0</span></label>
                                                    </div>

                                                    <!--    </center> -->
                                                    <div class="col-md-12">
                                                        <br />
                                                        <asp:Button ID="BtnAdd" runat="server" class="btn btn-primary" Text="Book Now" OnClick="BtnAdd_Click" />


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-7">

                                    <div class="row">
                                        <div class="col">
                                        
                                            
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
