function solve(x,op,y){
let result = 0;
switch(op){
    case "+": result = x+y;break;
    case "-": result = x-y;break;
    case "*": result = x*y;break;
    case "/": result = x/y;break;
}
console.log(result.toFixed(2));
}
solve(25.5,
    '-',
    3
    )