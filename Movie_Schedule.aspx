<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Movie_Schedule.aspx.cs" Inherits="Cinema.Movie_Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <!-- top section start -->
            <div class="logo_section">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="logo"><a href="#">
                                <h1>Manage Movie Scheduling</h1></a></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- top section end --> 
    <!-- movie section start -->
     <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card" >
                    
                    <div class="card-body">
                        <div class="row"> 
                            <div class="col">
                            <!--    <center> -->
                                <div class="col-md-12">
                                    <label for="exampleInputEmail1" class="form-label">Movie Name</label>
                                    <asp:DropDownList ID="DropDownList1_Moviename" runat="server" class="form-control"></asp:DropDownList>                           
                                </div>
                                 <div class="col-md-12">
                                    <label for="exampleInputEmail1" class="form-label">Theater Name</label>
                                    <asp:DropDownList ID="DropDownList1_theater" runat="server" class="form-control"></asp:DropDownList>                           
                                </div>
                                 <div class="col-md-12"> <br />
                                     <label for="formFile" class="form-label">Select Movie Upload Date</label>
                                    <asp:Calendar class="form-control" ID="Calendar1" runat="server"></asp:Calendar>   
                                </div> 

                                 <div class="col-md-12">
                                    <label for="exampleInputEmail1" class="form-label">Movie Schedule Time</label>
                                    <asp:DropDownList ID="DropDownList2_moviescheduletime" runat="server" class="form-control"></asp:DropDownList>                           
                                </div>

                                <div class="col-md-12"> <br />
                                    <label  class="form-label">Adult Ticket Price</label>                                   
                                    <asp:TextBox ID="Txtadultprice" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>                               
                             
                                <div class="col-md-12"> <br />
                                    <label  class="form-label">Child Ticket Price</label>                                   
                                    <asp:TextBox ID="Txtchildprice" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                </div>  
                                                                                           
                                <div class="col-md-12">
                                    <br />
                                    <asp:Button ID="bthAdd" class="btn btn-primary" runat="server" Text="Add New" OnClick="bthAdd_Click" />
                                    <asp:Button ID="btnUpdate" class="btn btn-warning" runat="server" Text="Update" />

                                </div>
                               

                            </div> 
                        </div>
                    </div>
                </div>
            </div>

             <div class="col-md-7">
                <div class="card" >
                    
                    <div class="card-body">
                        <div class="row"> 
                            <div class="col"> <h5>Movies schedule</h5>
                                <center>
                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"></asp:GridView>  
                                </center>
                            </div> 
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    <!-- movie section end -->

</asp:Content>
