function solve(word, text){
    let words = text.split(" ");
    let isFound = false;
    for (let i = 0; i < words.length; i++) {
        if(words[i].toLowerCase()===word.toLowerCase()){
            isFound = true;
            break;
        }        
    }
    if (isFound===true) console.log(word)
    else console.log(`${word} not found!`)
}

solve('python',
'JavaScript is the best programming language'
)