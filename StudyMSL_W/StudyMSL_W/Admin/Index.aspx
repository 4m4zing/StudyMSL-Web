<%@ Page Title="" Language="C#" MasterPageFile="~/Default_Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="StudyMSL_W.Admin.Index" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Admin Console</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Highlights -->
	<section class="wrapper">
		<div class="inner">
			<div class="highlights">
				<section>
					<div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/admin/approvecontents.aspx")%>" class="icon fa-vcard-o">
                                <span class="label">Icon</span></a>
							<h3>Approve Contents</h3>
						</header>
						<p>Categorized into alphabets and numbers</p>
					</div>
				</section>
                <section>
					<div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/admin/deletecontents.aspx")%>" class="icon fa-line-chart">
                                <span class="label">Icon</span></a>
							<h3>Delete Contents</h3>
						</header>
						<p>Categorized into many sections</p>
					</div>
				</section>
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
