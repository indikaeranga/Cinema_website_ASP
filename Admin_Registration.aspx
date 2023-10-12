<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Registration.aspx.cs" Inherits="Cinema.Admin_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- top section start -->
            <div class="logo_section">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="logo"><a href="#">
                                <h1>Manage Admin Details</h1></a></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- top section end --> 

      <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card" >
                    
                    <div class="card-body">
                        <div class="row"> 
                            <div class="col">
                            <!--    <center> -->
                                <div class="col-md-12">
                                    <label for="nameinput" class="form-label">Name</label>
                                    <asp:TextBox ID="TextName" runat="server" type="text" class="form-control"></asp:TextBox>                              
                                    
                                </div>
                                <div class="col-md-12">
                                    <label for="usernameinput" class="form-label">User Name</label>
                                    <asp:TextBox ID="TextUserName" type="text" runat="server" class="form-control"></asp:TextBox>                                 
                                </div>
                                <div class="col-md-12">
                                    <label for="exampleInputEmail1" class="form-label">Email</label>                                   
                                    <asp:TextBox ID="TextEmail" type="email" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <label for="exampleInputPassword1" class="form-label">Password</label>                                  
                                    <asp:TextBox ID="TextPassword" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <!--    </center> -->
                                <div class="col-md-12">
                                    <br />
                                    <asp:Button ID="BtnAdd" runat="server" OnClientClick="return validateForm();" class="btn btn-primary" Text="Add New" OnClick="BtnAdd_Click" />
                                    <asp:Button ID="BtnUpdate" runat="server"  class="btn btn-warning" Text="Update" />
                                    <asp:Button ID="BtnDelete" runat="server"  class="btn btn-danger" Text="Delete" />
                                    
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
                            <div class="col"> <h5>Admins</h5>
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

  <script type="text/javascript">
      function validateForm() {
        var name = document.getElementById('<%= TextName.ClientID %>').value;
        var username = document.getElementById('<%= TextUserName.ClientID %>').value;
        var email = document.getElementById('<%= TextEmail.ClientID %>').value;
        var password = document.getElementById('<%= TextPassword.ClientID %>').value;

          if (name === '') {
              alert('Please enter a name.');
              return false; // Prevent the form from submitting
          }
          if (name.length > 20) {
              alert('Name should not exceed 20 characters.');
              return false;
          }

          if (username === '') {
              alert('Please enter a username.');
              return false;
          }
          if (username.length > 50) {
              alert('Username should not exceed 50 characters.');
              return false;
          }

          if (email === '') {
              alert('Please enter an email address.');
              return false;
          }

          if (password === '') {
              alert('Please enter a password.');
              return false;
          }
          if (password.length < 8) {
              alert('Password should be at least 8 characters.');
              return false;
          }
          if (!/[a-z]/.test(password) || !/[A-Z]/.test(password)) {
              alert('Password should contain both upper and lower case characters.');
              return false;
          }

          // If all checks pass, the form will submit
          return true;
      }
  </script>

</asp:Content>
