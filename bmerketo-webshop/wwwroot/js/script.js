const toggleMobileMenu = () => {

    try {
        const menu = document.querySelector("#menu")
        const openIcon = document.querySelector(".open-icon")
        const closeIcon = document.querySelector(".close-icon")

        menu.classList.toggle("open-menu");
        openIcon.classList.toggle("hidden");
        closeIcon.classList.toggle("hidden");
    }
    catch { }
}




