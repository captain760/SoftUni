function solve(numOne, numTwo,numThree) {
    let numbers = [numOne, numTwo, numThree];
    let negatives = 0;
    for (let i = 0; i < 3; i++) {
        if (numbers[i]<0) negatives++;        
    }
    return (negatives%2===0)?"Positive":"Negative"
}
console.log(solve(2,-3,4))