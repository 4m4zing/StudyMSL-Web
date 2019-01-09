<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="SentenceBuilderResults.aspx.cs" Inherits="StudyMSL_W.Learn.SentenceBuilderResults" %>


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
    <script type="text/javascript" src="<%# ConfigurationSettings.AppSettings["siteurl"] + "libgif-js-master/libgif.js" %>"></script>
    <!-- Main -->
    <section id="main" class="customwrapper">
		<div class="inner" style="clear:initial">
            <center>
                <br />
                <hr />
                <h2>Sentence Builder Result</h2>
                <p>Following is the sequential gestures as a sentence in the Malaysian Sign Language</p>
                <hr />
            </center>
			<div class="customcontent" style="clear:initial" >
                <div class="centered" style="clear:initial" >
                    <asp:Label ID ="lblName" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br />
                    <asp:Label ID ="lblNameMalay" runat="server" Font-Names="Arial Grey"></asp:Label>
                    <br /><br />
                    <asp:Image ID="imgLearn" runat="server" height ="40%" Width="70%" />
                    <br /><br />
                    <asp:Label ID ="lblDesc" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br />
                    <asp:Label ID ="lblDescMalay" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br /><br />
                    <asp:button Text="< Previous" runat="server" OnClick="btnPrevious_OnClick" CssClass="normalbutton" ></asp:button>
                    <asp:button Text="Next >" runat="server" OnClick="btnNext_OnClick" CssClass="normalbutton" ></asp:button>
                </div>
			</div>
		</div>
    </section>
    
    <script src="assets/js/jquery.min.js"></script>
	<script src="assets/js/browser.min.js"></script>
	<script src="assets/js/breakpoints.min.js"></script>
	<script src="assets/js/util.js"></script>
	<script src="assets/js/main.js"></script>
</asp:Content>


<%-- Footer ContentPlaceHolder --%>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>


