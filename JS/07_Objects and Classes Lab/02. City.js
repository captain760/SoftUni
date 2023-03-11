function solve(obj) {
    let entries = Object.entries(obj);
    for (const [key,value] of entries) {
        console.log(`${key} -> ${value}`);            
        }
    
}
console.log(solve({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
}
))