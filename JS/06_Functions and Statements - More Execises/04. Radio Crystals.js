function solve([desired, ...cristals]) {
    
   for (let i = 0; i < cristals.length; i++) {
    let currentCristal = cristals[i];

    let cuts = 0;
    console.log(`Processing chunk ${currentCristal} microns`);
    while (currentCristal/4>=desired){
        cuts++;
        currentCristal /=4;
    }
    
    if (cuts>0) {
        console.log(`Cut x${cuts}`);
        currentCristal = Math.floor(currentCristal);
        console.log("Transporting and washing");
    }

    let laps = 0;
    while (currentCristal*0.8>=desired){
        laps++;
        currentCristal = currentCristal - currentCristal*0.2;
    }
    
    if (laps>0) {
        console.log(`Lap x${laps}`);
        currentCristal = Math.floor(currentCristal);
        console.log("Transporting and washing");
    }

    let grinds = 0;
    while (currentCristal-20>=desired){
        grinds++;
        currentCristal = currentCristal - 20;
    }
    
    if (grinds>0) {
        console.log(`Grind x${grinds}`);
        currentCristal = Math.floor(currentCristal);
        console.log("Transporting and washing");
    }

    let etches = 0;
    while (currentCristal-2>=desired){
        etches++;
        currentCristal = currentCristal - 2;
    }
    
    if (etches>0) {
        if (currentCristal-desired>=1) {
            etches++;
            currentCristal = currentCristal - 2;
        }
        console.log(`Etch x${etches}`);
        currentCristal = Math.floor(currentCristal);
        console.log("Transporting and washing");
    }

    let rays = 0;
    if (currentCristal<desired){
        rays++;
        currentCristal = currentCristal + 1;
    }
    
    if (rays>0) {
        console.log(`X-ray x${rays}`);        
    }

    console.log(`Finished crystal ${currentCristal} microns`)
   } 
   
}

solve([1375, 50000])