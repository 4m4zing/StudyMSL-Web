<%@ Page Title="" Language="C#" MasterPageFile="~/Default_User.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="StudyMSL_W.User.Index" %>


<%-- Head ContentPlaceHolder --%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>


<%-- Banner ContentPlaceHolder --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBanner" runat="server">
    <!-- Banner -->
	<section id="banner">
		<div class="inner">
            <asp:Image ID="imgStudyMSL" runat="server" height ="10%" width="10%" style="border-radius: 50%;" />
			<h1>Malaysian Sign Language Learning Portal</h1>
			<p>A web-based Malaysian Sign Language Learning Portal</p>
            <br />	
		</div>
		<video autoplay loop muted playsinline src="<%= Page.ResolveUrl("~/images/banner.mp4")%>"></video>
	</section>
</asp:Content>


<%-- Content ContentPlaceHolder --%>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
    <!-- Highlights -->
	<section class="wrapper">
		<div class="inner">
			<header class="special">
				<h2>What is MSL?</h2>
				<p>Malaysian Sign Language is the most efficient means of communication for those of hearing-impared</p>
			</header>
			<div class="highlights">
				<section>
					<div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/learn/fingerspellingpage.aspx")%>" class="customA" >
                                <asp:Image ID="imgFingerspelling" runat="server" height ="20%" width="35%" />
                                <h3>Fingerspelling</h3>
							</a>
						</header>
						<p>Categorized into alphabets and numbers</p>
					</div>
				</section>
                <section>
					<div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/learn/wordpage.aspx")%>" class="customA" >
                                <asp:Image ID="imgWord" runat="server" height ="20%" width="35%" />
							    <h3>Words</h3>
							</a>
						</header>
						<p>Categorized into many sections</p>
					</div>
				</section>
                <section>
					<div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/learn/sentencebuilder.aspx")%>" class="customA" >
                                <asp:Image ID="imgSentence" runat="server" height ="20%" width="35%" />
							    <h3>Sentences</h3>
							</a>
						</header>
						<p>Generates sentences</p>
					</div>
				</section>
				<section>
					<div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/gamespage.aspx")%>" class="customA" >
                                <asp:Image ID="imgGame" runat="server" height ="20%" width="35%" />
							    <h3>Games</h3>
							</a>
						</header>
						<p>Categorized into memory game and fingerspelling game</p>
					</div>
				</section>
				<section>
                        <div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/quizzespage.aspx")%>" class="customA" >
                                <asp:Image ID="imgQuiz" runat="server" height ="20%" width="35%" />
							    <h3>Quizzes</h3>
							</a>
						</header>
						<p>Categorized into alphabets, numbers and words</p>
					</div>
				</section>
                <section>
                        <div class="content">
						<header>
							<a href="<%= Page.ResolveUrl("~/search.aspx")%>" class="customA" >
                                <asp:Image ID="imgSearch" runat="server" height ="20%" width="35%" />
							    <h3>Search</h3>
							</a>
						</header>
						<p>Search any alphabet, number or word</p>
					</div>
				</section>
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
