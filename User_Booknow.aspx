<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_Booknow.aspx.cs" Inherits="Cinema.User_Booknow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

          <div class="fashion_section">
         <div id="main_slider" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
               <div class="carousel-item active">
                  <div class="container"> <br /><br />
                     <h1 class="fashion_taital">Select Available Theaters</h1>
                     <div class="fashion_section_2">
                        
                         <div class="row">

                             <asp:Repeater ID="MovieRepeater" runat="server">
                                 <ItemTemplate>
                                     <div class="col-lg-4 col-sm-4">
                                         <div class="box_main">
                                             <h4 class="shirt_text">Theater : <%# Eval("Theater") %></h4>
                                             <h4 class="shirt_text">Date : <%# ((DateTime)Eval("Showing_Date")).ToString("yyyy-MM-dd") %></h4>
                                             <h5 class="shirt_text">Time : <%# ((DateTime)Eval("Show_Time")).ToString("HH:mm:ss") %></h5>
                                             <hr />
                                      
                                             
                                             <center>
                                                 <button type="button" class="btn btn-primary" onclick="window.location.href='<%# "User_Seat_Select.aspx?Schedule_ID=" + Eval("Schedule_ID") %>'">
                                                     Select This Ticket
                                                 </button>
                                             </center>
                                            
                                         </div>
                                     </div>
                                 </ItemTemplate>


                             </asp:Repeater>
                         
                        </div>
                     </div>
                  </div>
               </div>
                </div>
             </div>
          </div>
</asp:Content>
