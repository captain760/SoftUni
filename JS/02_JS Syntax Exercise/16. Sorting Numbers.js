function solve(arr){
let sorted = arr.sort(function(a, b){return a - b});
let result = [];

  for (let i = 0; i < sorted.length/2; i+=1) {
    result.push(sorted[i]);
    result.push(sorted[sorted.length-1-i])
}
if (sorted.length%2===1) {
result.pop();    
}
return(result)
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56, 33])