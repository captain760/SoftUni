function solve(firstName, lastName, age) {
    let obj = {}
    obj.firstName = firstName;
    obj.lastName = lastName;
    obj.age = +age;
    return obj;
}
console.log(solve("Peter", 
"Pan",
"20"
))