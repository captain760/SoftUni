function solve(a,b,c) {
    let sum = (a,b) => a+b;
    let subtract = (a,b) => a-b;
    return subtract(sum(a,b),c);
}

console.log(solve(1,2,3))