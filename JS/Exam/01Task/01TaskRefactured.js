function solve(input) {
    let [users, n] = [{},Number(input.shift())];
    for (let i = 0; i < n; i++) {
        let [assignee, taskId, title, status, points] = input[i].split(':');
        if (!users.hasOwnProperty(assignee)) users[assignee] = [];
        users[assignee].push({taskId, title, status, points:Number(points)})
    }
    
    console.log(users);
}
solve([
    '4',
    'Kiril:BOP-1213:Fix Typo:Done:1',
    'Peter:BOP-1214:New Products Page:In Progress:2',
    'Mariya:BOP-1215:Setup Routing:ToDo:8',
    'Georgi:BOP-1216:Add Business Card:Code Review:3',
    'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
    'Change Status:Georgi:BOP-1216:Done',
    'Change Status:Will:BOP-1212:In Progress',
    'Remove Task:Georgi:3',
    'Change Status:Mariya:BOP-1215:Done',
])