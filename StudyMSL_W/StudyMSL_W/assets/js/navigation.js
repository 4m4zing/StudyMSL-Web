var toggle = false;

/* Toggle the hamburger icon */
function hamburger(x) {
    x.classList.toggle("change");
    if (toggle === false)
    {
        toggle = true;
        openNav();
    }
    else
    {
        toggle = false;
        closeNav();
    }
} 

/* Set the width of the side navigation to 250px and the left margin of the page content to 250px and add a black background color to body */
function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
    //document.getElementById("main").style.marginLeft = "250px"; /*-->left-side*/
    document.getElementById("main").style.marginRight = "250px"; /*right-side<--*/
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
}

/* Set the width of the side navigation to 0 and the left margin of the page content to 0, and the background color of body to white */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginRight = "0"; /*right-side<--*/
    //document.getElementById("main").style.marginLeft = "0"; /*-->left-side*/
    document.body.style.backgroundColor = "white";
}

/* Set the username label and hamburger icon to hovercolor */
function changeColor() {
    var hovercolor = "#F1588C"; //StudyMSL Pink
    document.getElementById("myA").style.color = hovercolor;
    document.getElementById("hambar1").style.backgroundColor = hovercolor;
    document.getElementById("hambar2").style.backgroundColor = hovercolor;
    document.getElementById("hambar3").style.backgroundColor = hovercolor;
} 

/* Reset the username label and hamburger icon to default color */
function resetColor() {
    var defaultcolor = "#FFFFFF"; //White
    document.getElementById("myA").style.color = defaultcolor;
    document.getElementById("hambar1").style.backgroundColor = defaultcolor;
    document.getElementById("hambar2").style.backgroundColor = defaultcolor;
    document.getElementById("hambar3").style.backgroundColor = defaultcolor;
}