function solve(firstName, lastName, hairColor) {
    let obj = {
        name: firstName,
        lastName,
        hairColor
    }
    let json = JSON.stringify(obj);
    console.log(json);
}
solve('George', 'Jones', 'Brown')