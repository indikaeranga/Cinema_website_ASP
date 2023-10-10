<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Theater.aspx.cs" Inherits="Cinema.Theater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- top section start -->
    <div class="logo_section">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="logo">
                        <a href="#">
                            <h1>Manage Theater Details</h1>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- top section end -->
    <!-- movie section start -->
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">

                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <!--    <center> -->
                                <div class="col-md-12">
                                    <label for="exampleInputEmail1" class="form-label">Theater Name</label>
                                    <input type="Text" class="form-control" id="TheaterName">
                                </div>
                                <div class="col-md-12">
                                    <br />
                                   <!--   <button type="button" class="btn btn-primary">Add New</button> -->
                                    <button type="button" class="btn btn-warning">Update</button>

                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card">

                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <h5>Theater Details</h5>
                                <center>
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th scope="col">#</th>
                                                <th scope="col">Theater Name</th>
                                              
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">1</th>
                                                <td>Silver</td>
                                               
                                            </tr>
                                            <tr>
                                                <th scope="row">2</th>
                                                <td>Gold</td>
                                               
                                            </tr>
                                          <tr>
                                                <th scope="row">3</th>
                                                <td>Platinum</td>
                                               
                                            </tr>
                                        </tbody>
                                    </table>
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
