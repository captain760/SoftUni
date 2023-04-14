function solve(input) {
    let leaders = {};
    for (const line of input) {
       
        let lineArr = line.split(" ");
        let last = lineArr.pop();
        if( last === "arrives"){
            let ime = lineArr.join(" ");
            leaders[ime] = {};
            leaders[ime].total = 0;
            
        }else if(last === "defeated"){
            let ime = lineArr.join(" ");
            
            if (leaders.hasOwnProperty(ime)){
            delete leaders[ime]}

        }
        if (line.split(": ").length>1){
            let lineArr1 = line.split(": ");
            let leadIme = lineArr1.shift();
            let armyName = lineArr1[0].split(", ")[0];
            let count = Number(lineArr1[0].split(", ")[1]);
            if(leaders.hasOwnProperty(leadIme)){
                leaders[leadIme][armyName] =  count;               
                leaders[leadIme].total += count;                
            }
        }
        if (line.split(" + ").length>1){
            let lineArr2 = line.split(" + ");
            let armyName= lineArr2[0];
            let armyCount= Number(lineArr2[1]);
            
            for (const armies of Object.values(leaders)) {
                if(armies.hasOwnProperty(armyName)){
                    armies[armyName]+=armyCount;
                    armies.total+=armyCount;
                }
            }
        }
    }
    let leadersArr = Object.entries(leaders)
    let sorted = leadersArr.sort((a,b)=>{
       return b[1].total-a[1].total});
    for (const [key,value] of sorted) {       
        console.log(`${key}: ${value.total}`);
        let armiesArr = Object.entries(value);
        armiesArr.sort((a,b)=>{
            return b[1]-a[1];
        })
        armiesArr.shift();
        for (const [armyName, count] of armiesArr) {
            console.log(`>>> ${armyName} - ${count}`);
        }
        
    }
}

solve(['Rick Burr arrives', 'Fergus: Wexamp, 30245', 'Rick Burr: Juard, 50000', 'Findlay arrives', 'Findlay: Britox, 34540', 'Wexamp + 6000', 'Juard + 1350', 'Britox + 4500', 'Porter arrives', 'Porter: Legion, 55000', 'Legion + 302', 'Rick Burr defeated', 'Porter: Retix, 3205'])