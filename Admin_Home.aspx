<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Home.aspx.cs" Inherits="Cinema.Admin_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="logo_section">
         <div class="container">
             <div class="row">
                 <div class="col-sm-12">
                     <div class="logo">
                         <h1> Welcome <asp:Label id="lblName" runat="server" Text="Label"></asp:Label> </h1>


                     </div>
                 </div>
             </div>
         </div>
     </div>
</asp:Content>
