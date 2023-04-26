

function getTotalX(a, b) {
    let lowEnd = a[a.length-1];
    let highEnd = b[0];
    let res = 0;
    
    for (let i = lowEnd; i <= highEnd; i++) {
        let doSatisfy = true;
        for (let j = 0; j < a.length; j++) {
            if (i%a[j]!==0){doSatisfy = false; break}            
        }
        if (doSatisfy){
            for (let j = 0; j < b.length; j++) {
                if (b[j]%i!==0){doSatisfy = false; break}
            }
        }
        if (doSatisfy){res++};        
    }
return res;
}

console.log(getTotalX([2,4], [16,32,96]))