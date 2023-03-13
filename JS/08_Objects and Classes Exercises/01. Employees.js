function solve(arr) {
     let person = {};
     for (const name of arr) {
        person[name] = name.length;
     }
     let entries = Object.entries(person);
     for (const iterator of entries) {
        console.log(`Name: ${iterator[0]} -- Personal Number: ${iterator[1]}`)
     }     
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    )