function solve(arr) {
    let meetings = {};
    for (const req of arr) {
        let request = req.split(" ");
        let day = request[0];
        let name = request[1];
        if (meetings.hasOwnProperty(day)){
            console.log(`Conflict on ${day}!`)
        } else{
            meetings[day] = name;
            console.log(`Scheduled for ${day}`);
        }
    }
    for (const key in meetings) {
        console.log(`${key} -> ${meetings[key]}`)
    }
}

solve(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']
)