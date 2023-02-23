function solve(txt, word){
    while(txt.includes(word)){
        txt = txt.replace(word, "*".repeat(word.length))
    }
    console.log(txt)
}


solve("I am guy. I am crazy guy!","guy")