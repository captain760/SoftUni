function solve(arr,n){
for (let i = 0; i < n; i++) {
    arr.push(arr.shift());
}
console.log(arr.join(" "))
}
solve([51, 47, 32, 61, 21], 2)