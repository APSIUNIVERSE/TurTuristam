window.onload = () => {
    const uploadFile = document.getElementById("regorgskan");
    const uploadBtn = document.getElementById("regorgskan-btn");
    const uploadText = document.getElementById("regorgskan-text");

    button.addEventListener("click", function(event) {
        // Предотвращаем стандартное поведение кнопки
        event.preventDefault();
    });
    
    
    uploadBtn.addEventListener("click", function () { uploadFile.click(); });
}