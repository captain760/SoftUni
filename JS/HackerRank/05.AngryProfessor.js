function angryProfessor(k, a) {
    // Write your code here
let arrivedOnTime = 0;
for (let i = 0; i < a.length; i++) {
    if (a[i]<=0) {
        arrivedOnTime++;
    }
    if (arrivedOnTime===k) {
        return 'NO'
    }
}
return 'YES';
}
console.log(angryProfessor(3,[-1,-3,4,2]));
console.log(angryProfessor(2,[0,-1,2,1]));