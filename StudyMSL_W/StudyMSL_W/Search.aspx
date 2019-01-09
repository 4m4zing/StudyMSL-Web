<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="StudyMSL_W.Search" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Search</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
	<section id="main" class="wrapper">
		<div class="inner" style="clear:initial">
			<div class="customcontent" >
                <div class="centered">
                    <asp:Label ID="lblQuery" runat="server" Text="Enter A Query"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="centertextbox" ></asp:TextBox>
                    <br />
                    <asp:Label ID="lblCategory" runat="server" Text="Choose A Category"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="centertextbox" >
                        <asp:ListItem Text="Alphabets" Value="alphabet" Selected="True" />
                        <asp:ListItem Text="Numbers" Value="number" />
                        <asp:ListItem Text="Words" Value="word" />
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnSearch" runat="server" CssClass="centerbutton" Text="Search" OnClick="btnSearch_Click" />
                    <br />
                    <asp:Repeater ID="repSearch" runat="server" OnItemCommand="repSearch_ItemCommand">
                        <HeaderTemplate>
                            <ul></ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton ID="lbContentRedirect" runat="server" CssClass="navigationlink" CausesValidation="false"  
                                    Text=<%#Eval("image_name") %> CommandName='<%#Eval("image_id") %>' > <!---->
                                </asp:LinkButton>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            <ul></ul>
                        </FooterTemplate>
                    </asp:Repeater>
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