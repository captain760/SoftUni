function solve(arr){
let total = 0;
let bc = 0;
let buyDay = 0;

let bcIsBought = false;
for (let i = 1; i <= arr.length; i++) {
    let gain = arr[i-1]*67.51;
    if(i%3===0) gain*=0.7;
    total+=gain;    
    if (total>=11949.16 && bcIsBought===false){
        buyDay=i;
        bcIsBought = true;
    }
    if (total/11949.16>=1){
        bc += Math.floor(total/11949.16);
        total-=Math.floor(total/11949.16)*11949.16;
    }
}
console.log(`Bought bitcoins: ${bc}`);
if (bc!==0)
console.log(`Day of the first purchased bitcoin: ${buyDay}`);
console.log(`Left money: ${total.toFixed(2)} lv.`);
}
solve([100, 200, 300])