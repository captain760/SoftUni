function solve(a,b,c){
    let number=c;
if(a>=b && a>=c){
        number =a;
} else if(b>=a && b>=c){
    number =b;
}
    console.log(`The largest number is ${number}.`)
}
solve(4,4,1)