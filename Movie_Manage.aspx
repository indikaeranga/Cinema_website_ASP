<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Movie_Manage.aspx.cs" Inherits="Cinema.Movie_Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <!-- top section start -->
            <div class="logo_section">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="logo"><a href="#">
                                <h1>Manage Movie Details</h1></a></div>
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
                                    <asp:TextBox ID="Textmoviename" type="Text" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-12"> <br />
                                    <label  class="form-label">Description</label>                                   
                                    <asp:TextBox ID="TextDescription" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>                               
                                <div class="col-md-12">
                                    <br />
                                    <div class="btn-group" role="group" aria-label="Basic radio toggle button group">                                                                            
                                        <asp:RadioButton GroupName="RadioGroup" ID="RadioButton1" runat="server" class="btn-check"  Text="  Active"/> <br />&nbsp;&nbsp;&nbsp;&nbsp;                                                                        
                                        <asp:RadioButton GroupName="RadioGroup" class="btn-check" ID="RadioButton2" runat="server" Text="  InActive"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                </div>
                                
                                
                                 <div class="col-md-12"> <br />
                                     <label for="formFile" class="form-label">Select Movie Upload Date</label>
                                    <asp:Calendar class="form-control" ID="Calendar1" runat="server"></asp:Calendar>   
                                </div> 
                                <div class="col-md-12">
                                    <label for="formFile" class="form-label">Select Movie Image</label>                                    
                                    <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
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
                            <div class="col"> <h5>Movies</h5>
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
