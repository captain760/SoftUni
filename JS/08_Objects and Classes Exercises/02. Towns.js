function solve(arr) {
    
    let towns = [];
    
        for (let i = 0; i < arr.length; i++) {            
        let [name, lat, lon] = arr[i].split(" | ");
        
        let town = name;
        let latitude = Number(lat).toFixed(2);
        let longitude = Number(lon).toFixed(2);
        let townItem = {town,latitude,longitude}
        towns.push(townItem);
    }
    for (const iterator of towns) {
        console.log(iterator);
    }
    
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
)