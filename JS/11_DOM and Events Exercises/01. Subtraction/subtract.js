function subtract() {
    const first = document.getElementById("firstNumber");
    const second = document.getElementById("secondNumber");
    const result = document.getElementById("result");
    let res = Number(first.value) - Number(second.value);
    result.textContent = res;
}