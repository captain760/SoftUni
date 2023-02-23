function solve(a,b){
    let sum = 0;
    let arr = [];
    for (let i = a; i <= b; i++) {
        arr.push(i)
        sum+=i;        
    }
    console.log(arr.join(" "));
    console.log(`Sum: ${sum}`)
}
solve(0,26)