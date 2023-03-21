function calc() {
    const first = document.getElementById("num1");
    const second = document.getElementById("num2");
    const result = document.getElementById("sum");
    result.value = Number(first.value)+Number(second.value);    
}
