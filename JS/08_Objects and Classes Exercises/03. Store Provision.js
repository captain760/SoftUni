function solve(arr1,arr2) {
    let products = {};
   
    for (let i = 0; i < arr1.length; i+=2) {
        let name = arr1[i];
        let quan = +arr1[i+1];
        products[name] = quan;
        
    }
    for (let i = 0; i < arr2.length; i+=2) {
        let name = arr2[i];
        let quan = +arr2[i+1];
        if(products.hasOwnProperty(name)){
            products[name]+=quan;
        }else{
            products[name] = quan;
        }
    }
        for (const key in products) {
            console.log(`${key} -> ${products[key]}`);
        }   
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
    )