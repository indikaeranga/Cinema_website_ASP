<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_Home.aspx.cs" Inherits="Cinema.User_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


          <!-- fashion section start -->
      <div class="fashion_section">
         <div id="main_slider" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
               <div class="carousel-item active">
                  <div class="container"> <br /><br />
                     <h1 class="fashion_taital">Showing Now Movie Collection</h1>
                     <div class="fashion_section_2">
                        
                         <div class="row">

                             <asp:Repeater ID="MovieRepeater" runat="server">
                                 <ItemTemplate>
                                     <div class="col-lg-4 col-sm-4">
                                         <div class="box_main">
                                             <h4 class="shirt_text"><%# Eval("Movie_Name") %></h4>
                                             <p class="price_text">Category <span style="color: #262626;">: <%# Eval("Movie_ID") %></span></p>
                                             <div class="tshirt_img">

                                                 <img src='<%# ResolveUrl(Eval("Movie_Image_Location").ToString()) %>' alt='<%# Eval("Movie_Image_Location") %>' />
                                             </div>

                                             <div class="btn_main">
                                                 <div class="buy_bt"><a href='<%# "User_Booknow.aspx?Movie_ID=" + Eval("Movie_ID") %>'>Book Now</a></div>
                                                 <div class="seemore_bt"><a href='<%# "User_Movie_detail.aspx?Movie_ID=" + Eval("Movie_ID") %>'>More Details</a></div>
                                             </div>
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
            <!--    <div class="carousel-item"> 
                  <div class="container">
                     <h1 class="fashion_taital">Trending Action Movies</h1>
                     <div class="fashion_section_2">
                        <div class="row">
                           <div class="col-lg-4 col-sm-4">
                              <div class="box_main">
                                 <h4 class="shirt_text">Man T -shirt</h4>
                                 <p class="price_text">Price  <span style="color: #262626;">$ 30</span></p>
                                 <div class="tshirt_img"><img src="images/tshirt-img.png"></div>
                                 <div class="btn_main">
                                    <div class="buy_bt"><a href="#">Buy Now</a></div>
                                    <div class="seemore_bt"><a href="#">See More</a></div>
                                 </div>
                              </div>
                           </div>
                           <div class="col-lg-4 col-sm-4">
                              <div class="box_main">
                                 <h4 class="shirt_text">Man -shirt</h4>
                                 <p class="price_text">Price  <span style="color: #262626;">$ 30</span></p>
                                 <div class="tshirt_img"><img src="images/dress-shirt-img.png"></div>
                                 <div class="btn_main">
                                    <div class="buy_bt"><a href="#">Buy Now</a></div>
                                    <div class="seemore_bt"><a href="#">See More</a></div>
                                 </div>
                              </div>
                           </div>
                           <div class="col-lg-4 col-sm-4">
                              <div class="box_main">
                                 <h4 class="shirt_text">Woman Scart</h4>
                                 <p class="price_text">Price  <span style="color: #262626;">$ 30</span></p>
                                 <div class="tshirt_img"><img src="images/women-clothes-img.png"></div>
                                 <div class="btn_main">
                                    <div class="buy_bt"><a href="#">Buy Now</a></div>
                                    <div class="seemore_bt"><a href="#">See More</a></div>
                                 </div>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
               
            </div>
            <a class="carousel-control-prev" href="#main_slider" role="button" data-slide="prev">
            <i class="fa fa-angle-left"></i>
            </a>
            <a class="carousel-control-next" href="#main_slider" role="button" data-slide="next">
            <i class="fa fa-angle-right"></i>
            </a>
         </div>
      </div>
      <!-- fashion section end -->


      <!-- Javascript files-->
      <script src="js/jquery.min.js"></script>
      <script src="js/popper.min.js"></script>
      <script src="js/bootstrap.bundle.min.js"></script>
      <script src="js/jquery-3.0.0.min.js"></script>
      <script src="js/plugin.js"></script>
      <!-- sidebar -->
      <script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
      <script src="js/custom.js"></script>
      <script>
         function openNav() {
           document.getElementById("mySidenav").style.width = "250px";
         }
         
         function closeNav() {
           document.getElementById("mySidenav").style.width = "0";
         }
      </script>
</asp:Content>
