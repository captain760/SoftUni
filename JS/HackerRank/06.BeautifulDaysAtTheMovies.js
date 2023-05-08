function beautifulDays(i, j, k) {
    // Write your code here
    let beautifulDays =0;
for (let num = i; num <= j; num++) {
    let revNum = Number(Array.from(num.toString()).reverse().join(""));
    let dif =Math.abs(num-revNum);
    if (dif%k===0) {
        beautifulDays++;
    }
}
return beautifulDays
}
console.log(beautifulDays(20,23,6));