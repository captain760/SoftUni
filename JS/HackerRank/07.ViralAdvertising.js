function viralAdvertising(n) {
    // Write your code here
    let shared = 5;
    let liked = 0;
    let com = 0;
    for (let i = 1; i <= n; i++) {
        liked = Math.floor(shared/2);
        shared = liked*3;
        com += liked;
    }
    return com;
}
console.log(viralAdvertising(5));