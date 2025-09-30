<%@ Page Title="" Language="C#" MasterPageFile="~/project.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ASP_Project.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <!-- ? Preloader Start -->
    <div id="preloader-active">
        <div class="preloader d-flex align-items-center justify-content-center">
            <div class="preloader-inner position-relative">
                <div class="preloader-circle">
                </div>
                <div class="preloader-img pere-text">
                    <img src="assets/img/logo/loder.png" alt="">
                </div>
            </div>
        </div>
    </div>
    <!-- Preloader Start -->

</asp:Content>
<asp:Content ID="Content6" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
<main class="login-body" data-vide-bg="assets/img/login-bg.mp4">
    

        <div class="login-form card">
            <!-- Logo -->
            <div class="logo-login text-center mb-4">
                <a href="index.">
                    <img src="assets/img/logo/loder.png" alt="Logo" style="width:120px;" />
                </a>
            </div>          
            <h2>User Registration</h2>
            
            <asp:Panel ID="Panel1" runat="server" CssClass="form-box">

                <!-- Full Name -->
                <div class="form-input">
                    <label for="txtName">Full Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Full Name"></asp:TextBox>
                </div>

                <!-- Email -->
                <div class="form-input">
                    <label for="txtEmail">Email Address</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Email Address"></asp:TextBox>
                </div>

                <!-- Password -->
                <div class="form-input">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Password"></asp:TextBox>
                </div>

                <!-- Confirm Password -->
                <div class="form-input">
                    <label for="txtConfirmPassword">Confirm Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Confirm Password"></asp:TextBox>
                </div>

                <!-- Profile Photo -->
                <div class="form-input">
                    <label for="fuPhoto">Profile Photo</label>
                    <asp:FileUpload ID="fuPhoto" runat="server" CssClass="form-control" />
                </div>

                <!-- Submit Button -->
                <div class="form-input pt-20">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
                </div>

                <!-- Message Label -->
                <asp:Label ID="lblMessage" runat="server" CssClass="success-msg"></asp:Label>

                <!-- Login Link -->
                <p class="pt-10">Already have an account? <a href="Login.aspx">Login</a></p>
            </asp:Panel>
    
        </div>

</main>


</asp:Content>
<asp:Content ID="Content7" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <!-- JS here -->
    <script src="./assets/js/vendor/modernizr-3.5.0.min.js"></script>
    <!-- Jquery, Popper, Bootstrap -->
    <script src="./assets/js/vendor/jquery-1.12.4.min.js"></script>
    <script src="./assets/js/popper.min.js"></script>
    <script src="./assets/js/bootstrap.min.js"></script>
    <!-- Jquery Mobile Menu -->
    <script src="./assets/js/jquery.slicknav.min.js"></script>

    <!-- Jquery Slick , Owl-Carousel Plugins -->
    <script src="./assets/js/owl.carousel.min.js"></script>
    <script src="./assets/js/slick.min.js"></script>
    <!-- One Page, Animated-HeadLin -->
    <script src="./assets/js/wow.min.js"></script>
    <script src="./assets/js/animated.headline.js"></script>
    <script src="./assets/js/jquery.magnific-popup.js"></script>

    <!-- Date Picker -->
    <script src="./assets/js/gijgo.min.js"></script>
    <!-- Nice-select, sticky -->
    <script src="./assets/js/jquery.nice-select.min.js"></script>
    <script src="./assets/js/jquery.sticky.js"></script>
    <!-- Progress -->
    <script src="./assets/js/jquery.barfiller.js"></script>

    <!-- counter , waypoint,Hover Direction -->
    <script src="./assets/js/jquery.counterup.min.js"></script>
    <script src="./assets/js/waypoints.min.js"></script>
    <script src="./assets/js/jquery.countdown.min.js"></script>
    <script src="./assets/js/hover-direction-snake.min.js"></script>

    <!-- contact js -->
    <script src="./assets/js/contact.js"></script>
    <script src="./assets/js/jquery.form.js"></script>
    <script src="./assets/js/jquery.validate.min.js"></script>
    <script src="./assets/js/mail-script.js"></script>
    <script src="./assets/js/jquery.ajaxchimp.min.js"></script>

    <!-- Jquery Plugins, main Jquery -->
    <script src="./assets/js/plugins.js"></script>
    <script src="./assets/js/main.js"></script>
</asp:Content>

