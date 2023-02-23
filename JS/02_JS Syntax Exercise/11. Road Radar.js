function solve(speed, condition){
    let limit = 20;
    switch(condition){
        case "motorway": limit=130; break;
        case "interstate": limit=90; break;
        case "city": limit=50; break;
    }
    let speeding = speed-limit;
    let status = "reckless driving"
    if (speeding<=0) status="normal"
    else if (speeding>0 && speeding<=20) status = "speeding";
    else if (speeding>20 && speeding<=40) status = "excessive speeding";
    switch(status){
        case "normal":console.log(`Driving ${speed} km/h in a ${limit} zone`); break;
        default: console.log(`The speed is ${speeding} km/h faster than the allowed speed of ${limit} - ${status}`)
    }
}