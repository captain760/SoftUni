function solve(arr) {
    let phoneBook = {}
    for (const item of arr) {
       let entry = item.split(" ") 
       let name = entry[0];
       let phone = entry[1];
        // if(!phoneBook.hasOwnProperty(name)){
        //     phoneBook[name] = phone;            
        // } else 
        phoneBook[name] = phone;
    }
    for (const key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`)
    }
}
solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
)