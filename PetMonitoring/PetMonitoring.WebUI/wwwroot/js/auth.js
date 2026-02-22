document.addEventListener("DOMContentLoaded", () => {

    const toggle = document.getElementById("themeToggle");
    const icon = document.getElementById("themeIcon");

    if (toggle && icon) {
        toggle.addEventListener("click", () => {
            document.body.classList.toggle("dark");
            icon.textContent = document.body.classList.contains("dark") ? "🌙" : "☀️";
        });
    }

    const loginForm = document.getElementById("loginForm");
    const registerForm = document.getElementById("registerForm");
    const successBox = document.getElementById("successBox");

    function showRegister() {
        if (loginForm) loginForm.style.display = "none";
        if (registerForm) registerForm.style.display = "block";
    }

    function showLogin() {
        if (registerForm) registerForm.style.display = "none";
        if (loginForm) loginForm.style.display = "block";
    }

    if (loginForm && registerForm && successBox) {
        const submitHandler = (e) => {
            e.preventDefault();
            loginForm.style.display = "none";
            registerForm.style.display = "none";
            successBox.style.display = "block";
        };

        loginForm.addEventListener("submit", submitHandler);
        registerForm.addEventListener("submit", submitHandler);
    }

    const password = document.getElementById("password");
    const bar = document.querySelector(".bar");

    if (password && bar) {
        password.addEventListener("input", (e) => {
            const value = e.target.value;
            const strength = Math.min(100, value.length * 10);

            bar.style.width = strength + "%";
            bar.style.background =
                strength < 40 ? "#ff5252" :
                    strength < 70 ? "orange" :
                        "#00c853";
        });
    }

});