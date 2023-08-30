const getpassword = document.getElementById("getpassword");
const app = document.querySelector(".app");

getpassword.addEventListener("click", function (){
    this.style.display = 'none';
    app.insertAdjacentHTML("beforeend", "<span class='span__timer'>Отправить повторно через 30 сек.</span>")
    let spantimer = document.querySelector(".span__timer");
    console.log(spantimer);
    var time = 30;
    function changeContent(){
        time--;
        spantimer.innerText = "Отправить повторно через "+time+" сек.";
        if (time === 0){
            clearInterval(timerid);
            spantimer.remove();
            getpassword.style.display = 'inline-block';
        }
    }
    let timerid = setInterval(changeContent, 1000);
    
    }
    
)