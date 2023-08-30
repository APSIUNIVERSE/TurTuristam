const passwordturr = document.getElementById("passwordtur");
const imgglazik = document.getElementById("glazik__img");

imgglazik.addEventListener("click", function (){
    if (passwordturr.getAttribute('type') == 'password'){
        passwordturr.setAttribute('type', 'text');
        imgglazik.setAttribute('src', '/img/open.svg')
        imgglazik.style.width = '24px';
        imgglazik.style.height = '16px';
        imgglazik.style.right = '8px';
        imgglazik.style.top = '32.2px';
    }
    else {
        passwordturr.setAttribute('type', 'password');
        imgglazik.setAttribute('src', '/img/Group 75.svg')
        imgglazik.style.width = '27px';
        imgglazik.style.height = '27px';
        imgglazik.style.right = '7px';
        imgglazik.style.top = '27px';
    }
    }
)