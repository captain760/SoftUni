function pianist(input) {
    let n = +input.shift();
    let obj = {};
    for (let i = 0; i < n; i++) {
        let inputLine = input.shift();
        let [piece, composer, key] = inputLine.split('|');
        obj[piece] = {composer, key};        
    }
    
    let comParser = {
        'Add' : add,
        'Remove': remove,
        'ChangeKey': change
    };
    for (let i = 0; i < input.length; i++) {
        if(input[i] === 'Stop') break;
        let cmdLine = input[i].split('|');
        let cmd = cmdLine[0];
        comParser[cmd](...cmdLine.slice(1))        
    }
    for (const pc in obj) {
        console.log(`${pc} -> Composer: ${obj[pc].composer}, Key: ${obj[pc].key}`);
    }

    function add(piece, composer,key) {
        if (obj.hasOwnProperty(piece)) {
            console.log(`${piece} is already in the collection!`);
        }else {
            obj[piece] = {composer,key};
            console.log(`${piece} by ${composer} in ${key} added to the collection!`);
        }
    }

    function remove(piece) {
        if (obj.hasOwnProperty(piece)) {
            delete obj[piece];
            console.log(`Successfully removed ${piece}!`);
        } else{
            console.log(`Invalid operation! ${piece} does not exist in the collection.`);
        }
    }

    function change(piece, newKey) {
        if (obj.hasOwnProperty(piece)) {
            obj[piece].key = newKey;
            console.log(`Changed the key of ${piece} to ${newKey}!`);
        } else{
            console.log(`Invalid operation! ${piece} does not exist in the collection.`);
        }
    }
}
pianist ([
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