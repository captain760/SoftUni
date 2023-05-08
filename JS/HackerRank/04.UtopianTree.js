function utopianTree(n) {
    // Write your code here
    let res = 1;
for (let i = 0; i < n; i++) 
    i%2===0?res*=2:res+=1;
return res;
}

console.log(utopianTree(0));
console.log(utopianTree(1));
console.log(utopianTree(4));
