function solve(words, template){
let arr = words.split(", ").sort(function(a, b){
    let x = a.toLowerCase();
    let y = b.toLowerCase();
    if (x < y) {return -1;}
    if (x > y) {return 1;}
    return 0;
  }).reverse();
for (let i = 0; i < arr.length; i++) {
    // ---this to be included if the word is repeating---
    // while((template.includes("*".repeat(arr[i].length)))){ 
        template = template.replace("*".repeat(arr[i].length), arr[i])

    // }
}
console.log(template)
}
solve('great, learning, aa',
'softuni * is ** ***** place for ******** new * programming ** languages'
)