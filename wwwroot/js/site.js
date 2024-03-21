// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Tailwind CSS configuration
tailwind.config = {
  darkMode: "class",
  corePlugins: {
    preflight: false,
  },
  theme: {
    extend: {
      colors: {
        primary: "var(--primary)",
        "on-primary": "var(--on-primary)",
        "primary-container": "var(--primary-container)",
        "on-primary-container": "var(--on-primary-container)",
        "primary-fixed": "var(--primary-fixed)",
        "on-primary-fixed": "var(--on-primary-fixed)",
        "primary-fixed-dim": "var(--primary-fixed-dim)",
        "on-primary-fixed-variant": "var(--on-primary-fixed-variant)",
        secondary: "var(--secondary)",
        "on-secondary": "var(--on-secondary)",
        "secondary-container": "var(--secondary-container)",
        "on-secondary-container": "var(--on-secondary-container)",
        "secondary-fixed": "var(--secondary-fixed)",
        "on-secondary-fixed": "var(--on-secondary-fixed)",
        "secondary-fixed-dim": "var(--secondary-fixed-dim)",
        "on-secondary-fixed-variant": "var(--on-secondary-fixed-variant)",
        tertiary: "var(--tertiary)",
        "on-tertiary": "var(--on-tertiary)",
        "tertiary-container": "var(--tertiary-container)",
        "on-tertiary-container": "var(--on-tertiary-container)",
        "tertiary-fixed": "var(--tertiary-fixed)",
        "on-tertiary-fixed": "var(--on-tertiary-fixed)",
        "tertiary-fixed-dim": "var(--tertiary-fixed-dim)",
        "on-tertiary-fixed-variant": "var(--on-tertiary-fixed-variant)",
        error: "var(--error)",
        "error-container": "var(--error-container)",
        "on-error": "var(--on-error)",
        "on-error-container": "var(--on-error-container)",
        background: "var(--background)",
        "on-background": "var(--on-background)",
        outline: "var(--outline)",
        "inverse-on-surface": "var(--inverse-on-surface)",
        "inverse-surface": "var(--inverse-surface)",
        "inverse-primary": "var(--inverse-primary)",
        shadow: "var(--shadow)",
        "surface-tint": "var(--surface-tint)",
        "outline-variant": "var(--outline-variant)",
        scrim: "var(--scrim)",
        surface: "var(--surface)",
        "on-surface": "var(--on-surface)",
        "surface-variant": "var(--surface-variant)",
        "on-surface-variant": "var(--on-surface-variant)",
        "surface-container-highest": "var(--surface-container-highest)",
        "surface-container-high": "var(--surface-container-high)",
        "surface-container": "var(--surface-container)",
        "surface-container-low": "var(--surface-container-low)",
        "surface-container-lowest": "var(--surface-container-lowest)",
        "surface-dim": "var(--surface-dim)",
        "surface-bright": "var(--surface-bright)",
      }
    }
  }
};

// On document ready
$(document).ready(() => {
  // Show body
  $("body").fadeIn();

  // Init dark mode switch
  $("#darkmode-switch").prop("checked", localStorage.getItem("dark") === "1");
  $("body").toggleClass("dark", localStorage.getItem("dark") === "1");

  // Toggle dark mode on switch change
  $("#darkmode-switch").on("change", () => {
    // Toggle class on dark body based on localstorage value of isdark
    $("body").toggleClass("dark", localStorage.getItem("dark") === "0");
    // Set localstorage value of isdark to 1 if body has class dark
    localStorage.setItem("dark", $("body").hasClass("dark") ? "1" : "0");
  });

  $("#logout-btn").on("click", () => {
    ui("#logout-dialog");
  });

  $("#logout-cancel").on("click", () => {
    ui("#logout-dialog");
  });
});
