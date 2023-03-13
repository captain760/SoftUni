function solve(input) {
    let products = {};
    for (const line of input) {
        let product = {};
        let [name, price] = line.split(" : ");
        products[name] = Number(price);
        
    }
    let entities = Object.entries(products)
    let sorted = entities.sort((a,b)=>a[0].localeCompare(b[0]));
    let setLetter = sorted[0][0][0];
    console.log(setLetter)
    for (let i = 0; i < sorted.length; i++) {
        let currLetter = sorted[i][0][0];
        if (currLetter===setLetter){
            console.log(`  ${sorted[i][0]}: ${sorted[i][1]}`)
        }else{
            setLetter = currLetter;
            console.log(setLetter);
            console.log(`  ${sorted[i][0]}: ${sorted[i][1]}`)
        }
    }
}

solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]
    )