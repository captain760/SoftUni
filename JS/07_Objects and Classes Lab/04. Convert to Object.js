function solve(json) {
    let obj = JSON.parse(json);
    for (const key in obj) {
        console.log(`${key}: ${obj[key]}`)
    }
}
solve('{"name": "George", "age": 40, "town": "Sofia"}')