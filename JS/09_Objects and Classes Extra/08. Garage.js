function solve(input) {
    let garages = {};
    for (const line of input) {        
        let car = line.split(" - ")[1]; 
        let carProps = [];
        let properties = car.split(", ");
        for (const p of properties) {
            let property = {}
            let [key,value] = p.split(": ");
            property[key] = value;
            carProps.push(property)
        }
        let garageNumber = Number(line.split(" - ")[0]);            
        if (garages.hasOwnProperty(garageNumber)){
            garages[garageNumber].push(carProps)
        }else{
            garages[garageNumber] = [];
            garages[garageNumber].push(carProps)
        } 
    }
   for (const g in garages) {
    console.log(`Garage № ${g}`)
    for (const c of garages[g]) {        
        let propStrArr = [];
        for (const iterator of c) {
            let entries = Object.entries(iterator);
            let propString = entries[0].join(" - ");
            propStrArr.push(propString)
        }          
        console.log(`--- ${propStrArr.join(", ")}`)
    }    
   }
}

solve(['1 - color: blue, fuel type: diesel', '1 - color: red, manufacture: Audi', '2 - fuel type: petrol', '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'])