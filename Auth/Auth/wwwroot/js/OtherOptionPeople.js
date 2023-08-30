const select = document.getElementById('mySelect');
const inputContainer = document.getElementById('inputContainer');
const textInput = document.getElementById('textInput');

select.addEventListener('change', function() {
    const selectedOption = this.options[this.selectedIndex];
    const selectedValue = selectedOption.value;

    if (selectedValue === 'other') {
        inputContainer.style.display = 'block';
    } else {
        inputContainer.style.display = 'none';
    }
});
