function solve(fruitType,weight,pricePerKg){
    let money = (weight/1000)*pricePerKg;

    console.log(`I need $${money.toFixed(2)} to buy ${(weight/1000).toFixed(2)} kilograms ${fruitType}.`);
}
solve('orange', 2500, 1.80)