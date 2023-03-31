function solve() {
const inp = document.getElementById('input');
const result = document.getElementById('result');
const selectin = document.getElementById('selectMenuFrom');
const selectOut = document.getElementById('selectMenuTo');
const optBinary = document.createElement('option');
optBinary.textContent = 'Binary';
optBinary.value = 'binary'
selectOut.appendChild(optBinary);
const optHex = document.createElement('option');
optHex.textContent = 'Hexadecimal';
optHex.value = 'hexadecimal'
selectOut.appendChild(optHex);
const btn = Array.from(document.getElementsByTagName('button'))[0];
btn.addEventListener('click', convert);
function convert() {
    let selection = selectOut.value;
    let input = parseFloat(inp.value);
    if (selection === 'binary'){
        res = (input>>>0).toString(2);
    } else if (selection === 'hexadecimal'){
        res = (input>>>0).toString(16).toUpperCase();
    }
    result.value = res;
}
  
}