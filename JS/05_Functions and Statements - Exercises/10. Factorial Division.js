function solve(x,y) {
    let firstFact = factorial(x);
    let secondFact = factorial(y);
    console.log((firstFact/secondFact).toFixed(2));

    function factorial(a) {
        let result=1;
        if (a<0) return -1;
        if (a>0){
            result=a*factorial(a-1);
        }
        return result;
    }
}

solve(5,2)