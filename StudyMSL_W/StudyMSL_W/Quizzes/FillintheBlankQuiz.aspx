<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="FillintheBlankQuiz.aspx.cs" Inherits="StudyMSL_W.Quizzes.FillintheBlankQuiz" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Fill in the Blank Quiz - <asp:Label ID="lblQuestionType" runat="server"></asp:Label></h1>
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
                <p><asp:Label ID="lblInstruction" runat="server"></asp:Label></p>
                <hr />
            </center>
			<div class="customcontent" style="clear:initial" >
                <div class="centered" style="clear:initial" >
                    <asp:Label Text="Question:  " runat="server" Font-Names="Arial Grey"></asp:Label>
                    <asp:Label ID ="lblQuestion" runat="server" Font-Names="Arial Black"></asp:Label>
                    <asp:Label Text="/10" runat="server" Font-Names="Arial Grey"></asp:Label>
                    <br />
                    <asp:Label Text="Score:  " runat="server" Font-Names="Arial Grey"></asp:Label>
                    <asp:Label ID ="lblScore" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br />
                    <asp:Label Text="Time left:  " runat="server" Font-Names="Arial Grey"></asp:Label>
                    <asp:Label ID ="lblTime" runat="server" Font-Names="Arial Black"></asp:Label>
                    <asp:Label Text="s" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br /><br />
                    <asp:Image ID="imgQuestion" runat="server" height ="40%" Width="70%"/> <%--src="https://imgplaceholder.com/420x320/ff7f7f/333333/fa-image"--%>
                    <br /><br />
                    <asp:TextBox ID="txtAnswer" runat="server" CssClass="centertextbox" placeholder="&#xF044; Answer" ></asp:TextBox>
                    <br />
                    <asp:button ID="btnAnswer" Text="Check Answer" runat="server" CssClass="centerbutton" OnClick="btnCheckAnswer_OnClick" ></asp:button>
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

