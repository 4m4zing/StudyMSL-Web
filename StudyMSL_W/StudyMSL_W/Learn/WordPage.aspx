<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="WordPage.aspx.cs" Inherits="StudyMSL_W.Learn.WordPage" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link rel="stylesheet" href="<%= Page.ResolveUrl("~/assets/css/flickity.css")%>" media="screen"/>
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Heading -->
	<div id="heading" >
		<h1>Learn Words</h1>
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
                <asp:Button runat="server" id="btnHiddenWord1" style="display:none" onclick="btncWord1_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord2" style="display:none" onclick="btncWord2_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord3" style="display:none" onclick="btncWord3_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord4" style="display:none" onclick="btncWord4_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord5" style="display:none" onclick="btncWord5_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord6" style="display:none" onclick="btncWord6_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord7" style="display:none" onclick="btncWord7_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord8" style="display:none" onclick="btncWord8_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWord14" style="display:none" onclick="btncWord14_OnClicked"/>
                <asp:Button runat="server" id="btnHiddenWordU" style="display:none" onclick="btncWordU_OnClicked"/>

                <div class="carousel"
                  data-flickity='{ "freeScroll": false, "contain": false, "prevNextButtons": true, "pageDots": true, "cellAlign": "center"}'>
                    <div class="carousel-cell">
                        <p class="flickityText" >Greetings</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Pronouns</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Family</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Questions</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Conjunctions</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Auxiliary Verbs</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Feelings</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Verb</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >Transports</p>
                    </div>
                    <div class="carousel-cell">
                        <p class="flickityText" >User Uploads</p>
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
                    var btnHidden1 = $('#<%= btnHiddenWord1.ClientID %>');
                    var btnHidden2 = $('#<%= btnHiddenWord2.ClientID %>');
                    var btnHidden3 = $('#<%= btnHiddenWord3.ClientID %>');
                    var btnHidden4 = $('#<%= btnHiddenWord4.ClientID %>');
                    var btnHidden5 = $('#<%= btnHiddenWord5.ClientID %>');
                    var btnHidden6 = $('#<%= btnHiddenWord6.ClientID %>');
                    var btnHidden7 = $('#<%= btnHiddenWord7.ClientID %>');
                    var btnHidden8 = $('#<%= btnHiddenWord8.ClientID %>');
                    var btnHidden14 = $('#<%= btnHiddenWord14.ClientID %>');
                    var btnHiddenU = $('#<%= btnHiddenWordU.ClientID %>');

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
                            case 7:
                                btnHidden7.click();
                                break;
                            case 8:
                                btnHidden8.click();
                                break;
                            case 9:
                                btnHidden14.click();
                                break;
                            case 10:
                                btnHiddenU.click();
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
