// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Tailwind CSS configuration
tailwind.config = {
  corePlugins: {
    preflight: false,
  }
};

// On document ready
$(document).ready(() => {
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
});
