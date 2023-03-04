function solve(num) {
    let numString = num.toString(10);
    while (average(numString)<5){
        numString+="9";
    }
    return +numString;

    function average(x) {
        let digitsArray = Array.from(x,Number);
        let sum = 0;
        for (let i = 0; i < digitsArray.length; i++) {
            sum+=digitsArray[i];            
        }
        return sum/digitsArray.length;
    }
}
console.log(solve(101))