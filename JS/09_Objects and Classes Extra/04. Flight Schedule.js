function solve(input) {
    let sectorFlights  = input[0];
    let changedFlights  = input[1];
    let searchedStatus  = input[2][0];
    let flights = {}
    for (const iterator of sectorFlights) {
        let arr = iterator.split(" ");
        let flightNumber = arr.shift();
        let destination = arr.join(" ");
        flights[flightNumber] = destination;
    }
    let changed = {};
    for (const iterator of changedFlights) {
        let [flightNumber, status] = iterator.split(" ");
        changed[flightNumber] = status;
    }
    let statuses = {};
    for (const key in flights) {
        statuses[key] = flights[key];
    }
    for (const key in changed) {
        if (statuses.hasOwnProperty(key)){
            statuses[key] = changed[key];
        }
    }
    if(searchedStatus === "Ready to fly"){
        for (const key in flights) {
            if(!changed.hasOwnProperty(key)){
                console.log(`{ Destination: '${flights[key]}', Status: 'Ready to fly' }`)
            }
        }
    } else{
        for (const key in flights) {
            if (changed.hasOwnProperty(key)){
                console.log(`{ Destination: '${flights[key]}', Status: '${searchedStatus}' }`) 
            }
            
        }
    } 
}

solve([['WN269 Delaware',
'FL2269 Oregon',
 'WN498 Las Vegas',
 'WN3145 Ohio',
 'WN612 Alabama',
 'WN4010 New York',
 'WN1173 California',
 'DL2120 Texas',
 'KL5744 Illinois',
 'WN678 Pennsylvania'],
 ['DL2120 Cancelled',
 'WN612 Cancelled',
 'WN1173 Cancelled',
 'SK330 Cancelled'],
 ['Ready to fly']
]
)