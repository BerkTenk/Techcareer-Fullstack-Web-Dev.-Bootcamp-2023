// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    function logCheckboxValues() {
        var isHomeValue = document.getElementById("isHomeCheckbox").checked;
        var isActiveValue = document.getElementById("isActiveCheckbox").checked;

        console.log("Is Home:", isHomeValue);
        console.log("Is Active:", isActiveValue);
    }
