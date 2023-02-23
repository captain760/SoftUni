function solve(n, a,b,c,d,e){
let result = +n;
let opp = a+","+b+","+c+","+d+","+e;
let opps = opp.split(",")
for (let i = 0; i < 5; i++) {
    switch(opps[i]){
        case "chop": {
           result/=2;
           console.log(result);
        };break;
        case "dice": {
            result=result**0.5;
            console.log(result);
         };break;
         case "spice": {
            result++;
            console.log(result);
         };break;
         case "bake": {
            result*=3;
            console.log(result);
         };break;
         case "fillet": {
            result*=0.8;
            console.log(result);
         };break;
    } 
}
}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')