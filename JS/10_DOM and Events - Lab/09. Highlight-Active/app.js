function focused() {
    const inputs = document.getElementsByTagName("input");
    for (let i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener('focus',focusEvent);
        inputs[i].addEventListener('blur',blurEvent);        
    }
    function focusEvent(e) {
        e.currentTarget.parentElement.classList.add("focused");
    }

    function blurEvent(e) {
        e.currentTarget.parentElement.classList.remove("focused");
    }    
}