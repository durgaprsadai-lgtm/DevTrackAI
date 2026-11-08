(() => {
  const storageKey = "devtrackai-theme";
  const toggleButton = document.getElementById("theme-toggle");

  const updateThemeButton = () => {
    if (!toggleButton) {
      return;
    }

    const isDark = document.body.classList.contains("dark-mode");
    toggleButton.setAttribute("aria-pressed", String(isDark));
    toggleButton.querySelector("span").textContent = isDark ? "Light mode" : "Dark mode";

    const icon = toggleButton.querySelector("i");
    icon.classList.toggle("fa-sun", isDark);
    icon.classList.toggle("fa-moon", !isDark);
  };

  window.toggleTheme = () => {
    const isDark = document.body.classList.toggle("dark-mode");

    try {
      localStorage.setItem(storageKey, isDark ? "dark" : "light");
    } catch {
      // Keep the current-page toggle functional if browser storage is disabled.
    }

    updateThemeButton();
  };

  toggleButton?.addEventListener("click", window.toggleTheme);
  updateThemeButton();
})();