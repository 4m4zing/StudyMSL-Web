<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="QuizzesPage.aspx.cs" Inherits="StudyMSL_W.QuizzesPage" %>


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
                <asp:Button runat="server" id="btnHiddenAlphabetMCQ" style="display:none" onclick="btncAlphabetMCQ_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenAlphabetFITB" style="display:none" onclick="btncAlphabetFITB_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenNumberMCQ" style="display:none" onclick="btncNumberMCQ_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenNumberFITB" style="display:none" onclick="btncNumberFITB_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWordMCQ" style="display:none" onclick="btncWordMCQ_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWordFITB" style="display:none" onclick="btncWordFITB_OnClicked"/>

                <div class="carousel"
                  data-flickity='{ "freeScroll": false, "contain": false, "prevNextButtons": true, "pageDots": true, "cellAlign": "center"}'>
                    <div class="carousel-cell">
                        <p class="flickityText" >Alphabets</p>
                        <p>Multiple Choice Questions</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Alphabets</p>
                        <p>Fill in the Blank Questions</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Numbers</p>
                        <p>Multiple Choice Questions</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Numbers</p>
                        <p>Fill in the Blank Questions</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Words</p>
                        <p>Multiple Choice Questions</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Words</p>
                        <p>Fill in the Blank Questions</p>
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
                    var btnHidden1 = $('#<%= btnHiddenAlphabetMCQ.ClientID %>');
                    var btnHidden2 = $('#<%= btnHiddenAlphabetFITB.ClientID %>');
                    var btnHidden3 = $('#<%= btnHiddenNumberMCQ.ClientID %>');
                    var btnHidden4 = $('#<%= btnHiddenNumberFITB.ClientID %>');
                    var btnHidden5 = $('#<%= btnHiddenWordMCQ.ClientID %>');
                    var btnHidden6 = $('#<%= btnHiddenWordFITB.ClientID %>');

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
                            case 5:
                                btnHidden5.click();
                                break;
                            case 6:
                                btnHidden6.click();
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
