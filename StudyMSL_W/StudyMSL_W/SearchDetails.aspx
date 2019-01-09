<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="SearchDetails.aspx.cs" Inherits="StudyMSL_W.SearchDetails" Async="true" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Search Details</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
    <section id="main" class="wrapper">
		<div class="inner" style="clear:initial">
			<div class="customcontent" style="clear:initial" >
                <div class="centered" style="clear:initial" >
                    <asp:Label ID ="lblName" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br />
                    <asp:Label ID ="lblNameMalay" runat="server" Font-Names="Arial Grey"></asp:Label>
                    <br /><br />
                    <asp:Image ID="imgResult" runat="server" height ="40%" Width="70%" />
                    <br /><br />
                    <asp:Label ID ="lblDesc" runat="server" ></asp:Label>
                    <br />
                    <asp:Label ID ="lblDescMalay" runat="server" ></asp:Label>
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