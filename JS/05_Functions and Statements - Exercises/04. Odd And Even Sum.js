function solve(number) {
    let numString = number.toString();
    let num = [];
    for (let i = 0; i < numString.length; i++) {
        num.push(+numString[i]);        
    }
    // ***shortest way of creating array of digits from a number***

    // let num = Array.from(number.toString(10), Number)
    
    

    let evenSum = (n)=>{
        let sum =0;
        for (let i = 0; i < n.length; i++) {
            if(n[i]%2===0) sum+=n[i];          
        }
        return sum;
    }

    let oddSum = (n)=>{
        let sum =0;
        for (let i = 0; i < n.length; i+=1) {
            if(n[i]%2===1) sum+=n[i];            
        }
        return sum;
    }

    console.log(`Odd sum = ${oddSum(num)}, Even sum = ${evenSum(num)}`);
}

solve(1000435)