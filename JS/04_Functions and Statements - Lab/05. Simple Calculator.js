function solve(a,b,ops) {
    const add = (a,b)=>a+b;
    const multiply = (a,b)=>a*b;
    const subtract = (a,b)=>a-b;
    const divide = (a,b)=>a/b;
    const operation = {
    "multiply": multiply,
    "divide": divide,
    "add": add,
    "subtract": subtract
   } ;
   return operation[ops](a,b);
}
console.log(solve(2,3,"add"))