<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_Seat_Select.aspx.cs" Inherits="Cinema.User_Seat_Select" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
      <div class="fashion_section">
         <div id="main_slider" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
               <div class="carousel-item active">
                  <div class="container"> <br /><br />
                     <h1 class="fashion_taital">Select your Tickets</h1>
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
                                                    <div class="col-md-12">
                                                        <label for="phonenm" class="form-label">Phone</label>
                                                        <asp:TextBox ID="txtphonenumber" type="text" runat="server" class="form-control" TextMode="Number" MaxLength="0"></asp:TextBox>
                                                    </div>
                                                    <br />
                                                    <div class="col-md-12">
                                                        <label for="totcount" class="form-label">Total Count : <span id="totalCount">0</span></label>
                                                        <label for="price" class="form-label"> <span id="totalPrice"></span></label>
                                                    </div>

                                                    <!--    </center> -->
                                                    <div class="col-md-12">
                                                        <br />
                                                        <asp:Button ID="BtnAdd" runat="server" OnClientClick="return validateTextBoxes();"  class="btn btn-primary" Text="Book Now" OnClick="BtnAdd_Click"/>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-7">

                                    <div class="row">
                                        <div class="col">
                                            <h3>Ticket Prices</h3>
                                           <hr />
                                                <h4>
                                                    <asp:Label ID="Label1" class="card-title" runat="server" Text="Adult :"></asp:Label>
                                            
                                                    <asp:Label ID="lbladultprice" class="card-title" runat="server" Text="adult"></asp:Label>
                                                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    <asp:Label ID="Label2" class="card-title" runat="server" Text="Child :"></asp:Label>
                                              
                                                    <asp:Label ID="lblchildprice" class="card-title" runat="server" Text="child"></asp:Label>
                                                </h4>
                                                <br />
                                            
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

<script type="text/javascript">
    document.addEventListener("DOMContentLoaded", function () {
        var textAdult = document.getElementById('<%= Textadult.ClientID %>');
        var textChild = document.getElementById('<%= Textchild.ClientID %>');
        var totalCount = document.getElementById("totalCount");

        // Function to calculate and update the total count
        function calculateTotal() {
            var adultValue = parseInt(textAdult.value) || 0;
            var childValue = parseInt(textChild.value) || 0;
            var total = adultValue + childValue;
            totalCount.textContent = total;
        }

        // Attach event listeners to both text boxes for input changes
        textAdult.addEventListener("input", calculateTotal);
        textChild.addEventListener("input", calculateTotal);
    });
</script>

<script type="text/javascript">
    // Function to calculate the total price
    document.addEventListener("DOMContentLoaded", function () {
        var adultSeats = parseInt(document.getElementById('<%= Textadult.ClientID %>').value) || 0;
        var childSeats = parseInt(document.getElementById('<%= Textchild.ClientID %>').value) || 0;       
        // Get the adult and child ticket prices
        var adultPrice = parseFloat(document.getElementById('<%= lbladultprice.ClientID %>').value) || 0;
        var childPrice = parseFloat(document.getElementById('<%= lblchildprice.ClientID %>').value) || 0;
        var totalPrice = document.getElementById("totalPrice");
        // Calculate the total price
    function calculateTotalPrice() {
        var adultcount = parseInt(adultSeats.value) || 0;
        var childcount = parseInt(childSeats.value) || 0;
        var adultprice = parseFloat(adultPrice.value) || 0;
        var childPrice = parseFloat(childPrice.value) || 0;

        var Price = (adultSeats * adultPrice) + (childSeats * childPrice);
        totalPrice.textContent = Price;
    }
    // Attach event listeners to both text boxes for input changes
    adultSeats.addEventListener("input", calculateTotal);
    childSeats.addEventListener("input", calculateTotal);
    });
    // You can call calculateTotalPrice whenever you want to update the total price dynamically
</script>

    <script>
        function validateTextBoxes() {
            var adultTextBox = document.getElementById('<%= Textadult.ClientID %>');
            var childTextBox = document.getElementById('<%= Textchild.ClientID %>');
            var phone = document.getElementById('<%= txtphonenumber.ClientID %>');

            if (adultTextBox.value.trim() === "" && childTextBox.value.trim() === "") {
                alert("At least adult or child ticket should be select.");
                return false;
            }

            if (phone.value.trim().length != 10 ) {
                alert('Enter 10 digit phone number');
                return false;
            }

            return true;
        }
    </script>


</asp:Content>
