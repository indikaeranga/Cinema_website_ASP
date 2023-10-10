<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_Movie_Detail.aspx.cs" Inherits="Cinema.User_Movie_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container" style="height:20px">
       
    </div>
    <cenner>
    <div class="container">
        
        <div class="card col-md-12" ><br />
        
            <div class="row g-0">
                <div class="col-md-6" style="align-content:center">
                    <asp:Image ID="MovieImage" runat="server" CssClass="img-fluid rounded-start" />
              

                </div>
                <div class="col-md-6">
                    <div class="card-body">
                        
                       <h1> <asp:Label ID="MovieTitle" class="card-title" runat="server" Text="MovieTitle"></asp:Label></h1>
                        <br />
                        
                        
                        <asp:Label class="card-text" ID="MovieDescription" runat="server" Text="Label"></asp:Label>
                        
                        <br />
                        <br />
                        <button type="button" class="btn btn-primary">Book Ticket</button>
                    </div>
                </div>
            </div><br />
        </div>
    </div></cenner>
</asp:Content>
