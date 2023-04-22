function racing(input) {
    let horses = input.shift().split('|');
    let comParser = {
        'Retake' : retake,
        'Trouble': trouble,
        'Rage': rage,
        'Miracle': miracle
    };
    for (let i = 0; i < input.length; i++) {
        if(input[i] === 'Finish') {
            console.log(horses.join('->'));
            console.log(`The winner is: ${horses[horses.length-1]}`);

            break;
        };
        let cmdLine = input[i].split(' ');
        let cmd = cmdLine[0];
        comParser[cmd](...cmdLine.slice(1))        
    }

    function retake(overtaking, overtaken) {

        if (horses.indexOf(overtaken)>horses.indexOf(overtaking)){
            let temp = horses[horses.indexOf(overtaken)];
            horses[horses.indexOf(overtaken)] = horses[horses.indexOf(overtaking)];
            horses[horses.indexOf(overtaking)] = temp;
            console.log(`${horses[horses.indexOf(overtaking)]} retakes ${horses[horses.indexOf(overtaken)]}.`);
        }
        
    }

    function trouble(horse) {
        let horseIndex =horses.indexOf(horse); 
        if (horseIndex>0){
            let temp = horses[horseIndex];
            horses[horseIndex] = horses[horseIndex-1];
            horses[horseIndex-1] = temp;
            console.log(`Trouble for ${horse} - drops one position.`);
        }
        
    }

    function rage(horse) {
        let horseIndex =horses.indexOf(horse); 
        if (horseIndex===horses.length-1) {

        }else if (horseIndex === horses.length-2) {
            let temp = horses[horseIndex];
            horses[horseIndex] = horses[horseIndex+1];
            horses[horseIndex+1] = temp;    
        }else if (horseIndex <= horses.length-2) {
            let temp = horses[horseIndex];
            horses[horseIndex] = horses[horseIndex+1];
            horses[horseIndex+1] = horses[horseIndex+2];
            horses[horseIndex+2] = temp; 
            
        }
        console.log(`${horse} rages 2 positions ahead.`);
        
    }

    function miracle() {
        let horse = horses[0];
        let temp = horses.shift();
        horses.push(temp);
        console.log(`What a miracle - ${horse} becomes first.`);
    }
}

racing(['Bella|Alexia|Sugar',
'Retake Alexia Sugar',
'Rage Bella',
'Trouble Bella',
'Finish']


)