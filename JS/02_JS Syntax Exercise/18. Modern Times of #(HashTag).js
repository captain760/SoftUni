function solve(txt){
let reg = new RegExp("^#[A-z]+$");
let words = txt.split(" ");
for (let i = 0; i < words.length; i++) {
    if (reg.test(words[i])) {
        console.log(words[i].substring(1,words[i].length))
    }
}
}
solve('The symbol # is known #variously in English-speaking #regions as the #number sign')