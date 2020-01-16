const signUpButton = document.getElementById('registro');
const signInButton = document.getElementById('login');
const container = document.getElementById('containerLogin');

signUpButton.addEventListener('click', () => {
    container.classList.add("right-panel-active");
});

signInButton.addEventListener('click', () => {
    container.classList.remove("right-panel-active");
});

//////////////////////////////////



//https://codepen.io/FlorinPop17/pen/vPKWjd