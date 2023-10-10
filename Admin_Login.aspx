<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Login.Master" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="Cinema.Admin_Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <!-- top section start -->
            <div class="logo_section">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="logo"><a href="#">
                                <h1>Log In</h1></a></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- top section end --> 
    
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <div class="card-body">                     
                              
                        <div class="row">
                        <div class="col-md-12">
                            <label for="exampleInputEmail1" class="form-label">User Name</label>
                            <asp:TextBox ID="Textusername" type="text" runat="server" class="form-control"></asp:TextBox>                            
                        </div>

                        <div class="col-md-12">
                            <label for="exampleInputPassword1" class="form-label">Password</label>
                            <asp:TextBox ID="Textpassword" type="password" runat="server" class="form-control"></asp:TextBox>                           
                        </div>
                               
                        <div class="col-md-12">
                            <br />
                            <asp:Button type="button" class="btn btn-primary" ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                            <asp:Button type="button" class="btn btn-warning" ID="BtnClear" runat="server" Text="Clear" />
                        </div>
                           </div> 
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
