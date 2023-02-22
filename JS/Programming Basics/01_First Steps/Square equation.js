function solve(a,b,c){
    let d=b*b-4*a*c;
    if (d>0){
        console.log("There are two real solutions:")
        console.log(`x1 = ${(-b-d**0.5)/2*a}`);
        console.log(`x2 = ${(-b+d**0.5)/2*a}`);
    }else if (d===0){
        console.log("There is one real solution:")
        console.log(`x1 = x2 = ${(-b-d**0.5)/2*a}`);
    }else{
        console.log("There are no real solutions!!!");
    }    
}

solve(1,-2,-3);
