function decentNumber(n) {
    // Write your code here
    if (n===1) {
        console.log("-1");
        return};
    let c = [];
    for (let i = 0; i < n; i++) {
        c[i] =5;        
    }
    if (n%3===0) {
        console.log(c.join('')); 
         return;
    }
    let num =0;
    for (let j = 0; j <=  n; j+=5) {        
            for (let k = n-1; k >= n-j; k--) {
                c[k]=3;                
            }            
            if ((n-j)%3===0) {
                console.log(c.join(''));
                return;
            }
               
    }
    console.log("-1");
    return;
}

decentNumber(18);
