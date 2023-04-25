// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function setActiveNavLink() {
    var navLinks = document.querySelectorAll(".nav-link");
    navLinks.forEach(function (navLink) {
        navLink.addEventListener("click", function (e) {
            if (!e.target.classList.contains("active")) {
                navLinks.forEach(function (navLink) {
                    navLink.classList.remove("active")
                })
                e.target.classList.add("active")
            }
        });
    });
}
//window.addEventListener("load", setActiveNavLink);
