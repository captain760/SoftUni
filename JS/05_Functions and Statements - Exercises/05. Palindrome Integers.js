function solve(numbers) {
    for (let i = 0; i < numbers.length; i++) {
        const element = numbers[i];
        palindrom(element)?console.log("true"):console.log("false");
    }
    function palindrom(num) {
        let digitsArray = Array.from(num.toString(10),Number);
        let isEqual = true;
        for (let i = 0; i < digitsArray.length/2; i++) {
            if (digitsArray[i] !== digitsArray[digitsArray.length-1-i]) {
                isEqual = false;
                break;
            }            
        }
        return isEqual? true :false
    }
}

solve([32,2,232,1010])