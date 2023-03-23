function toggle() {
    const btn = document.getElementsByTagName("span")[0];
    const txt = document.getElementById("extra");
    console.log(btn)
    if (btn.textContent === "More"){
        txt.setAttribute("style", "display:block");
        btn.textContent= "Less";
    } else{
        txt.setAttribute("style", "display:none");
        btn.textContent= "More";
    }
}