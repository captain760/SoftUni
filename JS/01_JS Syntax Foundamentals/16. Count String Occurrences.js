function solve(txt, word){
let count = 0;
let arr=txt.split(" ")
for (let wrd of arr) {
    if (wrd===word){
        count++;
    }
}
console.log(count)
}

solve('This is a word and it also is a sentence','is')