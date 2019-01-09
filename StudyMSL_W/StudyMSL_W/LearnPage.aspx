<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="LearnPage.aspx.cs" Inherits="StudyMSL_W.LearnPage" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link rel="stylesheet" href="<%= Page.ResolveUrl("~/assets/css/flickity.css")%>" media="screen"/>
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Learn</h1>
	</div>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Main -->
	<section id="main" class="wrapper">
		<div class="inner">
			<div class="content">

                <!-- Scripts -->
	            <script type="text/javascript" src="<%= Page.ResolveUrl("~/assets/js/jquery.min.js")%>"></script>
	            <script type="text/javascript" src="<%= Page.ResolveUrl("~/assets/js/flickity2.1.2.pkgd.js")%>"></script>
	            <script src="assets/js/browser.min.js"></script>
	            <script src="assets/js/breakpoints.min.js"></script>
	            <script src="assets/js/util.js"></script>
	            <script src="assets/js/main.js"></script>

                <%-- Buttons for redirection --%>
                <asp:Button runat="server" id="btnHiddenFingerspelling" style="display:none" onclick="btncFingerspelling_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord" style="display:none" onclick="btncWord_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenSentence" style="display:none" onclick="btncSentence_OnClicked"/>

                <div class="carousel"
                  data-flickity='{ "freeScroll": false, "contain": false, "prevNextButtons": true, "pageDots": true, "cellAlign": "center"}'>
                    <div class="carousel-cell">
                        <p class="flickityText" >Fingerspelling</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Words</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Sentences</p>
                    </div>
                </div>

                <%--<script type="text/javascript">
                    function carouseldiv()
                    {
                        var btnHidden = $('#<%= btnHidden.ClientID %>');
                        if(btnHidden != null)
                        {
                            //btnHidden.click();
                        }
                    }
                </script>--%>
                <script type="text/javascript">
                    var btnHidden1 = $('#<%= btnHiddenFingerspelling.ClientID %>');
                    var btnHidden2 = $('#<%= btnHiddenWord.ClientID %>');
                    var btnHidden3 = $('#<%= btnHiddenSentence.ClientID %>');

                    var $carousel = $('.carousel').flickity({
                        initialIndex: 0
                    });
                    //var $logger = $('.logger');

                    $carousel.on('staticClick.flickity', function (event, pointer, cellElement, cellIndex) {
                        // dismiss if cell was not clicked
                        if (!cellElement) {
                            return;
                        }

                        // change cell background with .is-clicked
                        $carousel.find('.is-clicked').removeClass('is-clicked');
                        $(cellElement).addClass('is-clicked');

                        //Handle Button Click
                        switch (cellIndex + 1) {
                            case 1:
                                btnHidden1.click();
                                break;
                            case 2:
                                btnHidden2.click();
                                break;
                            case 3:
                                btnHidden3.click();
                                break;
                            default:
                        }
                        //$logger.text('Cell ' + (cellIndex + 1) + ' clicked');
                    });
                </script>
            </div>
        </div>
    </section>
</asp:Content>


<%-- Footer ContentPlaceHolder --%>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>


<%-- SidebarNavigation ContentPlaceHolder --%>
<%--<asp:Content ID="Content5" ContentPlaceHolderID="cphSidebar" runat="server">
</asp:Content>--%>

