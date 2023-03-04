function solve(n) {
    function rowN(x) {
        let row = x.toString(10);
        let arr = [];
        for (let i = 0; i < x; i++) {
            arr.push(row);          
        }
        return arr.join(" ");
    }
    for (let i = 0; i < n; i++) {
       console.log(rowN(n))     
    }
}

solve(7)