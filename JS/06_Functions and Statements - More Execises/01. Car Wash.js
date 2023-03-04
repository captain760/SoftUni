function solve(commands) {
    let cleanliness = 0;
    let soap = (x)=>x+10;
    let water = (x)=>x*1.2;
    let vacuum = (x)=>x*1.25;
    let mud = (x) => x*0.9;
    let operations = {
        "soap":soap,
        "water":water,
        "vacuum cleaner":vacuum,
        "mud":mud
    }
    for (let i = 0; i < commands.length; i++) {
        cleanliness=operations[commands[i]](cleanliness);        
    }
    return console.log(`The car is ${cleanliness.toFixed(2)}% clean.`)
}

solve(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);