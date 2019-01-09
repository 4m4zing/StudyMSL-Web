<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="GamesPage.aspx.cs" Inherits="StudyMSL_W.GamesPage" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link rel="stylesheet" href="<%= Page.ResolveUrl("~/assets/css/flickity.css")%>" media="screen"/>
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Quizzes</h1>
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

                <%-- Hidden buttons for redirection --%>
                <asp:Button runat="server" id="btnHiddenAlphabetMemory" style="display:none" onclick="btncAlphabetMemory_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenAlphabetSpelling" style="display:none" onclick="btncAlphabetSpelling_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenNumberMemory" style="display:none" onclick="btncNumberMemory_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenNumberSpelling" style="display:none" onclick="btncNumberSpelling_OnClicked"/>

                <div class="carousel"
                  data-flickity='{ "freeScroll": false, "contain": false, "prevNextButtons": true, "pageDots": true, "cellAlign": "center"}'>
                    <div class="carousel-cell">
                        <p class="flickityText" >Alphabets</p>
                        <p>Memory Matching Game</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Alphabets</p>
                        <p>Picture Spelling Game</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Numbers</p>
                        <p>Memory Matching Game</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Numbers</p>
                        <p>Picture Spelling Game</p>
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
                    var btnHidden1 = $('#<%= btnHiddenAlphabetMemory.ClientID %>');
                    var btnHidden2 = $('#<%= btnHiddenAlphabetSpelling.ClientID %>');
                    var btnHidden3 = $('#<%= btnHiddenNumberMemory.ClientID %>');
                    var btnHidden4 = $('#<%= btnHiddenNumberSpelling.ClientID %>');

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
                            case 4:
                                btnHidden4.click();
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
