<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="SentenceBuilder.aspx.cs" Inherits="StudyMSL_W.Learn.SentenceBuilder" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Malaysian Sign Language Gestures</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
    <section id="main" class="wrapper">
		<div class="inner" style="clear:initial">
			<div class="customcontent" >
                <div class="centered">
                    <asp:Label ID="lblEnteratext" runat="server" Text="Enter A Sentence" Font-Names="Arial Black" ></asp:Label>
                    <br />
                    <asp:TextBox ID="txtSentence" runat="server" CssClass="centertextbox" ></asp:TextBox>
                    <br />
                    <asp:Label ID="lblLanguage" runat="server" Text="Choose Language of Input" Font-Names="Arial Black" ></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="centertextbox" >
                        <asp:ListItem Text="English" Value="english" Selected="True" />
                        <asp:ListItem Text="Malay" Value="malay" />
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="centerbutton" />
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
