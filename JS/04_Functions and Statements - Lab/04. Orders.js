function solve(prod, n) {
    const product = {
        "coffee":1.5,
        "coke":1.4,
        "water": 1.0,
        "snacks": 2.0
    }
    return (product[prod]*n).toFixed(2);
}
console.log(solve("coke", 3))