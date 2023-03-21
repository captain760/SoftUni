function extractText() {
    const liItems = Array.from(document.querySelectorAll('li'));
    const textArea = document.getElementById("result");
    for (const item of liItems) {
        textArea.textContent+=item.textContent+"\n";
    }
}