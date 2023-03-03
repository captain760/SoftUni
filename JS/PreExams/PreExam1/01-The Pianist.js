function pianist(input){
    let n =+input.shift();
    let collection = {};
    for (let i = 0; i < n; i++) {
        let [piece, composer, key] =input.shift().split("|");
        collection[piece] = {composer,key};
    }
    input.forEach(line=>{
        let tokens = line.split("|")
        let command = tokens.shift()
    if (command ==="Add"){
        let [piece, composer, key] = tokens;
        if (collection.hasOwnProperty(piece)){
            console.log(`${piece} is already in the collection!`)
        } else {
            collection[piece] = {composer,key};
            console.log(`${piece} by ${composer} in ${key} added to the collection!`)
        }
    } else if (command ==="Remove"){
        let piece = tokens.shift();
        if (collection.hasOwnProperty(piece)){
            delete collection[piece];
            console.log(`Successfully removed ${piece}!`)
        } else {
               console.log(`Invalid operation! ${piece} does not exist in the collection.`)
        }
    } else if (command ==="ChangeKey"){
        let piece = tokens.shift();
        let newKey = tokens.shift();
        if (collection.hasOwnProperty(piece)){
            collection[piece].key = newKey;
            console.log(`Changed the key of ${piece} to ${newKey}!`)
        } else {
               console.log(`Invalid operation! ${piece} does not exist in the collection.`)
        }
    }else if (command === "Stop"){
        let entries = Object.entries(collection);
        for (const [melody, info] of entries) {
            console.log(`${melody} -> Composer: ${info.composer}, Key: ${info.key}`);
        }
    }
    else console.log("wrong command!!!")
})
}

pianist([
    '3',
    'Fur Elise|Beethoven|A Minor',
    'Moonlight Sonata|Beethoven|C# Minor',
    'Clair de Lune|Debussy|C# Minor',
    'Add|Sonata No.2|Chopin|B Minor',
    'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
    'Add|Fur Elise|Beethoven|C# Minor',
    'Remove|Clair de Lune',
    'ChangeKey|Moonlight Sonata|C# Major',
    'Stop'  
  ]
  )