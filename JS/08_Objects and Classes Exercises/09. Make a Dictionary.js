function solve(input){
let dic = {};
let arr = []
for (const iterator of input) {
    let entry = JSON.parse(iterator);
    arr.push(entry);    
}
dic = Object.assign({},...arr);
let sorted = Object.entries(dic).sort((a,b)=>a[0].localeCompare(b[0]));
for (const key of sorted) {
    console.log(`Term: ${key[0]} => Definition: ${key[1]}`)
}
}

solve([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
    ]
    )