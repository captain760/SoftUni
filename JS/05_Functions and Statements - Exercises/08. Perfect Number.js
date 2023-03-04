function solve(number) {
    
    function findDivisors(x) {
        let divisors = [];
        for (let i = 1; i < x; i++) {
            if (x%i===0) {
                divisors.push(i);
            }
        }
        return divisors;          
    }
    let sum = findDivisors(number).reduce((a,b)=>a+b);
    (number===sum)?console.log("We have a perfect number!"): console.log("It's not so perfect.");
}

solve(1236498)