function solve(arr) {
    let addressBook = {};
    for (const item of arr) {
        let [name,address] = item.split(":");        
        addressBook[name] = address;
    }
    let entries = Object.keys(addressBook)
    .sort((a,b)=>a.localeCompare(b));
    for (const iterator of entries) {
        console.log(`${iterator} -> ${addressBook[iterator]}`); 
    }  
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
)