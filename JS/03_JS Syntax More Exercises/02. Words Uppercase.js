function solve(txt){
let re = new RegExp(/\w+/g);
let arr = txt.match(re);
let newArr = [];
for (let word of arr) {
    let word1 = word.toUpperCase();
    newArr.push(word1);
}
    console.log(newArr.join(", "));
}
solve('Hi, how are you?')