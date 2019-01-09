<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudyMSL_W.Register" Async="true" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Register</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
	<section id="main" class="wrapper">
		<div class="inner">
			<div class="customcontent">
                <div class="centered">
                    <asp:Label ID="lblNewName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" placeholder="&#xF044;" ></asp:TextBox>
                    <br />
                    <asp:Label ID="lblNewUsername" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="&#xF007;" ></asp:TextBox>
                    <br />
                    <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="&#xF0e0;" ></asp:TextBox>
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="&#xF023;" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Re-enter Password"></asp:Label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="&#xF023;" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Sign Up" OnClick="btnSubmit_Click" />
                </div>
            </div>
		</div>
	</section>

    <!-- Scripts -->
	<script src="assets/js/jquery.min.js"></script>
	<script src="assets/js/browser.min.js"></script>
	<script src="assets/js/breakpoints.min.js"></script>
	<script src="assets/js/util.js"></script>
	<script src="assets/js/main.js"></script>
</asp:Content>