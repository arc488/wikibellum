
window.setBelligerentsHeight = () => {
    var target = document.getElementById("target");
    var overview = document.getElementById("overview");
    var belligerents = document.getElementById("belligerents");
    var height = overview.clientHeight;
    belligerents.style.maxHeight = height + "px";
}
