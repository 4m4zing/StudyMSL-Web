<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="ViewProgress.aspx.cs" Inherits="StudyMSL_W.User.ViewProgress" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Progress</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
	<section id="main" class="wrapper">
		<div class="inner">
			<div class="content">
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="p_id">
                    <Columns>
                        <asp:BoundField DataField="content_id" HeaderText="Content ID" SortExpression="content_id" />
                        <asp:BoundField DataField="content_name" HeaderText="Content Name" SortExpression="content_name" />
                        <asp:BoundField DataField="content_desc" HeaderText="Description" SortExpression="content_desc" />
                        <asp:BoundField DataField="date_completed" HeaderText="Date Completed" SortExpression="date_completed" DataFormatString="{0:MM/dd/yyyy}"/>
                    </Columns>
                </asp:GridView>
                <%--<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=studymsl_dbEntities"  
                    DefaultContainerName="studymsl_dbEntities" EnableFlattening="False" EntitySetName="progresses">
                </asp:EntityDataSource>--%>
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
