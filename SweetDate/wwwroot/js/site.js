const loginButtons = document.getElementsByClassName("login-button");
for (let i = 0; i < loginButtons.length; i++) {
    loginButtons[i].addEventListener("click", function () {
        document.getElementById("login-modal").style.display = "block";
    });
}

// Для кнопки Sign Up
const signupButtons = document.getElementsByClassName("signup-button");
for (let i = 0; i < signupButtons.length; i++) {
    signupButtons[i].addEventListener("click", function () {
        document.getElementById("signup-modal").style.display = "block";
    });
}

// Для кнопки закрытия в модальном окне "Log In"
document.getElementById("login-close").addEventListener("click", function () {
    document.getElementById("login-modal").style.display = "none";
});

// Для кнопки закрытия в модальном окне "Sign Up"
document.getElementById("signup-close").addEventListener("click", function () {
    document.getElementById("signup-modal").style.display = "none";
});

//обработчик события для закрытия модального окна при клике вне него
document.addEventListener("click", function (event) {
    // Проверяем, был ли клик сделан вне модальных окон
    if (event.target === document.getElementById("login-modal") ||
        event.target === document.getElementById("signup-modal")) {
        document.getElementById("login-modal").style.display = "none";
        document.getElementById("signup-modal").style.display = "none";
    }
});

// Обработчик события для кнопки "CREATE A NEW ACCOUNT"
document.getElementById("create-account-button").addEventListener("click", function () {
    // Закрываем модальное окно "Log In"
    document.getElementById("login-modal").style.display = "none";

    // Открываем модальное окно "Sign Up"
    document.getElementById("signup-modal").style.display = "block";
});

// Обработчик события для кнопки "ALREADY HAVE AN ACCOUNT"
document.getElementById("already-have-button").addEventListener("click", function () {
    document.getElementById("signup-modal").style.display = "none";
    
    document.getElementById("login-modal").style.display = "block";
});

const textSlider = document.getElementById("text-slider");
const textSlides = textSlider.querySelectorAll(".text-slide");
let currentIndex = 0;

function showSlide(index) {
    textSlides.forEach((slide, i) => {
        slide.style.display = i === index ? "block" : "none";
    });
}

function nextSlide() {
    currentIndex = (currentIndex + 1) % textSlides.length;
    showSlide(currentIndex);
    updateActiveDot();
}

function prevSlide() {
    currentIndex = (currentIndex - 1 + textSlides.length) % textSlides.length;
    showSlide(currentIndex);
    updateActiveDot();
}

document.getElementById("next-slide").addEventListener("click", nextSlide);
document.getElementById("prev-slide").addEventListener("click", prevSlide);

$(document).ready(function () {
    var currentIndex = 0;
    var slideCount = $(".avatar-slide").length;

    function showSlide(index) {
        $(".avatar-slide").hide();
        $(".avatar-slide:eq(" + index + ")").show();
    }

    $("#prev-slide").click(function () {
        currentIndex = (currentIndex - 1 + slideCount) % slideCount;
        showSlide(currentIndex);
    });

    $("#next-slide").click(function () {
        currentIndex = (currentIndex + 1) % slideCount;
        showSlide(currentIndex);
    });

    showSlide(currentIndex);
});






