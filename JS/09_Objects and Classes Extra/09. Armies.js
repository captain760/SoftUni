function solve(input) {
    let leaders = [];
    for (const line of input) {
        let leader = {};
        let lineArr = line.split(" ");
        let last = lineArr.pop();
        if( last === "arrives"){
            leader.ime = lineArr.join(" ");
            leaders.push(leader)
        }else if(last === "defeated"){
            leader.ime = lineArr.join(" ");
            let index = leaders.indexOf(leaders.find((x)=>x.ime===leader.ime));
            leaders.splice(index,1,0);
        }
        if (line.split(": ").length>1){
            let lineArr1 = line.split(": ");
            let leadIme = lineArr1.shift();
            let armyName = lineArr1[0].split(", ")[0];
            if(leaders.find((x)=>x.ime===leadIme)){
                leaders[leaders.indexOf(leaders.find((x)=>x.ime===leadIme))].army = armyName;
                leaders[leaders.indexOf(leaders.find((x)=>x.ime===leadIme))].count = +lineArr1[0].split(", ")[1];
            }
        }
        if (line.split(" + ").length>1){
            let lineArr2 = line.split(" + ");
            let armyName= lineArr2[0];
            let armyCount= +lineArr2[1];
            if (leaders.find((x)=>x.army===armyName)){
                leaders[leaders.indexOf(leaders.find((x)=>x.army===armyName))].count += armyCount;
            }
        }
    }
    console.log(leaders)
}

solve(['Rick Burr arrives', 'Fergus: Wexamp, 30245', 'Rick Burr: Juard, 50000', 'Findlay arrives', 'Findlay: Britox, 34540', 'Wexamp + 6000', 'Juard + 1350', 'Britox + 4500', 'Porter arrives', 'Porter: Legion, 55000', 'Legion + 302', 'Rick Burr defeated', 'Porter: Retix, 3205'])