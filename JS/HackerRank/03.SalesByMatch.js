function sockMerchant(n, ar) {
    // Write your code here
    let pairs = 0;
    let sorted = ar.sort((a,b)=>{return a-b});
    console.log(sorted);
for (let i = 0; i < n-1; i++) {
    if (sorted[i] === sorted[i+1] ) {
        pairs++;
        i++;
    }
    
}
console.log(pairs);
}

sockMerchant(10,[10, 20, 20, 10, 10, 30, 50, 10, 20, 50])