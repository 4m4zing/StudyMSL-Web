<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="StudyMSL_W.User.ChangePassword" Async="true" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Change Password</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
	<section id="main" class="wrapper">
		<div class="inner">
			<div class="customcontent">
                <div class="centered">
                    <asp:Label ID="lblCurrentPass" runat="server" Text="Enter Current Password"></asp:Label>
                    <asp:TextBox ID="txtCurrentPass" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblNewPassword" runat="server" Text="Enter New Password"></asp:Label>
                    <asp:TextBox ID="txtSubmitNewPassword" runat="server" TextMode="Password" ></asp:TextBox>
                    <br />
                    <asp:Label ID="lblConfirmNewPassword" runat="server" Text="Confirm New Password"></asp:Label>
                    <asp:TextBox ID="txtResubmitNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
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


<%-- Footer ContentPlaceHolder --%>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
