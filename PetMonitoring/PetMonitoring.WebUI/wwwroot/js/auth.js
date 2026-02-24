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



    if (successBox) {
        const submitHandler = (e) => {
            e.preventDefault();
            if (loginForm) {
                loginForm.style.display = "none";
                loginForm.addEventListener("submit", submitHandler);
            }
            if (registerForm) {
                registerForm.style.display = "none";
                registerForm.addEventListener("submit", submitHandler);
            }
            successBox.style.display = "block";
        };
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