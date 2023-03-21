function sumTable() {
const sum = document.getElementById("sum");
const elements= document.querySelectorAll('td:nth-child(even)')
let s =0;
const prices = Array.from(elements);
for (let i = 0; i < prices.length-1; i++) {    
     s += Number(prices[i].textContent);    
}
sum.textContent = s;
}