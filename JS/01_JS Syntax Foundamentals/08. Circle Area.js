function solve(a){
if(typeof(a)==="number"){
    return((a*a*Math.PI).toFixed(2));
}
console.log(`We can not calculate the circle area, because we receive a ${typeof(a)}.`)
};

