function solve(num){
    let arr = (num.toString()).split("");
    let sum=0;
    for (let digit of arr) {
        sum+=+digit;
    }
    console.log(sum)
}
solve(245678)