<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="MemoryMatchingGame.aspx.cs" Inherits="StudyMSL_W.Games.MemoryMatchingGame" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Memory Matching Game - <asp:Label ID="lblQuestionType" runat="server"></asp:Label></h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
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
                    <asp:Label Text="Steps:  " runat="server" Font-Names="Arial Grey"></asp:Label>
                    <asp:Label ID ="lblSteps" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br />
                    <asp:Label Text="Score:  " runat="server" Font-Names="Arial Grey"></asp:Label>
                    <asp:Label ID ="lblScore" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br />
                    <asp:Label Text="Time left:  " runat="server" Font-Names="Arial Grey"></asp:Label>
                    <asp:Label ID ="lblTime" runat="server" Font-Names="Arial Black"></asp:Label>
                    <asp:Label Text="s" runat="server" Font-Names="Arial Black"></asp:Label>
                    <br />
                    <br /><br /> <!--src="https://imgplaceholder.com/420x320/ff7f7f/333333/fa-image"-->
                    <asp:ImageButton ID="imgbtnChoice1" runat="server" height ="15%" Width="15%" OnClick="imgbtnChoice1_OnClick" CssClass="imagebutton" />
                    <asp:ImageButton ID="imgbtnChoice2" runat="server" height ="15%" width="15%" OnClick="imgbtnChoice2_OnClick" CssClass="imagebutton" />
                    <br />
                    <asp:ImageButton ID="imgbtnChoice3" runat="server" height ="15%" width="15%" OnClick="imgbtnChoice3_OnClick" CssClass="imagebutton" />
                    <asp:ImageButton ID="imgbtnChoice4" runat="server" height ="15%" width="15%" OnClick="imgbtnChoice4_OnClick" CssClass="imagebutton" />
                    <br />
                    <asp:ImageButton ID="imgbtnChoice5" runat="server" height ="15%" width="15%" OnClick="imgbtnChoice5_OnClick" CssClass="imagebutton" />
                    <asp:ImageButton ID="imgbtnChoice6" runat="server" height ="15%" width="15%" OnClick="imgbtnChoice6_OnClick" CssClass="imagebutton" />
                    <br />
                    <asp:Label ID="lblTest" runat="server" ></asp:Label>
                </div>
			</div>
		</div>
    </section>
</asp:Content>


<%-- Footer ContentPlaceHolder --%>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
