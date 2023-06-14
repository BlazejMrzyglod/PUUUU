// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(
    () => {
        console.log("Pliki js wgrane poprawnie!")
        let braki = document.querySelectorAll("td")
        let errors = 0
        braki.forEach((x) => {
            if (x.innerHTML == 0) {
                console.log("Błedy w wypełnieniu")
                errors++;
            }
        })
        console.log("błędy:"+errors)
    })();
