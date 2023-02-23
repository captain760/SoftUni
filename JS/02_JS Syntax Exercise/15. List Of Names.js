function solve(arr){
    
    arr = arr.sort(function(a, b){
        let x = a.toLowerCase();
        let y = b.toLowerCase();
        if (x < y) {return -1;}
        if (x > y) {return 1;}
        return 0;
      });
    for (let i = 0; i < arr.length; i++) {
        console.log(`${i+1}.${arr[i]}`);
    }    
}
solve(["John", "Bob", "Christina", "Ema"])