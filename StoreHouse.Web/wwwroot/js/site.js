// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Nav() {
    var width = document.getElementById("mySidenav").style.width;
    if (width === "0px" || width == "") {
        document.getElementById("mySidenav").style.width = "270px";
        $('.animated-icon').toggleClass('open');
    }
    else {
        document.getElementById("mySidenav").style.width = "0px";
        $('.animated-icon').toggleClass('open');
    }
}