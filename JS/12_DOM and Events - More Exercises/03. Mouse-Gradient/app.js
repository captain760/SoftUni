function attachGradientEvents() {
    const hoverArea = document.getElementById('gradient');
    const resultDiv = document.getElementById('result');
    hoverArea.addEventListener('mousemove', percentage)

    function percentage(e) {
        let x = Math.floor(e.offsetX*100/300);
        resultDiv.textContent = x+'%';
    }
}