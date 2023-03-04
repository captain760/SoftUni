function getSmallest(a,b,c) {
    let numbers = [a,b,c];
    return  Math.min(...numbers);    
}

console.log(getSmallest(2,3,4))