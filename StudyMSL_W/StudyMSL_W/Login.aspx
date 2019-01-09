<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudyMSL_W.Login" Async="true"%>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Login</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
	<section id="main" class="wrapper">
		<div class="inner" style="clear:initial">
			<div class="customcontent" >
                <div class="centered">
                    <br />     
                    <%--<asp:Label ID="lblUsername" runat="server" Text="Username" ></asp:Label>--%> 
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="&#xF007; Username" CssClass="centertextbox" ></asp:TextBox>
                    <br />
                    <%--<asp:Label ID="lblPassword" runat="server" Text="Password" ></asp:Label>--%> 
                    <asp:TextBox ID="txtPass" runat="server" placeholder="&#xF023; Password" TextMode="Password" CssClass="centertextbox" ></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSignIn" runat="server" Text="Login" OnClick="btnSignIn_Click" CssClass="centerbutton" />
                    <br />
                    <asp:Label ID="lblOr" runat="server" Text=" or you can  " ></asp:Label> 
                    <br />
                    <asp:Button ID="btnGuest" runat="server" Text="Continue as Guest" OnClick="btnGuest_Click" CssClass="centerbutton" />
                    <br />
                    <asp:HyperLink ID="hyperlinkSignUp" runat="server" NavigateUrl="~/register.aspx" CssClass="hyperlink" >New user? Sign up here</asp:HyperLink>
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