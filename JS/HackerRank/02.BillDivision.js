function bonAppetit(bill, k, b) {
    // Write your code here
    let properSum = 0;
for (let i = 0; i < bill.length; i++) {
    if (i!==k) {
        properSum+=bill[i];
    }
}
let sumToPay = properSum/2;
if (sumToPay===b) {
    console.log('Bon Appetit');
} else{
    console.log(b-sumToPay);
}

}
bonAppetit([3,10,2,9],1,12);
bonAppetit([3,10,2,9],1,7);