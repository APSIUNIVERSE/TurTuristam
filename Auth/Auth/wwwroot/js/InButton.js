const nametur = document.getElementById("nametur");
const passwordtur = document.getElementById("passwordtur");
const inbutton = document.getElementById("inbutton");

nametur.addEventListener("input", function() {
    if (nametur.value !== "" && passwordtur.value !== "") {
        inbutton.classList.remove("invalid");
        // Ваши действия при заполненных полях ввода
    } else {
        inbutton.classList.add("invalid");
        // Ваши действия при пустых полях ввода
    }
});

passwordtur.addEventListener("input", function() {
    if (nametur.value !== "" && passwordtur.value !== "") {
        inbutton.classList.remove("invalid");
        // Ваши действия при заполненных полях ввода
    } else {
        inbutton.classList.add("invalid");
        // Ваши действия при пустых полях ввода
    }
});