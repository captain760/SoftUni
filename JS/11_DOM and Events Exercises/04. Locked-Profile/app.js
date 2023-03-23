function lockedProfile() {
    const btns = [...document.getElementsByTagName("button")];
    const usersHiddenInfo = [...document.getElementsByTagName("div#profile>div")];
    const users = Array.from(document.getElementsByClassName("profile"));
    for (const btn of btns) {
        btn.addEventListener("click", checker);
    }
    

    function checker(e) {
        let userIndex = users.findIndex((x=>x===e.currentTarget.parentNode))
        let btn = btns[userIndex];
        let parrentDiv =  e.currentTarget.parentNode;
        let radio = parrentDiv.querySelector('input[value=unlock]');
        if (radio.checked && btn.textContent ==="Show more"){
            parrentDiv.children[9].setAttribute("style", 'display:block');
            btn.textContent = "Hide it";
        }else
        if (radio.checked && btn.textContent === "Hide it"){            
            parrentDiv.children[9].setAttribute("style", 'display:none');
            btn.textContent = "Show more";
        }
    }
}