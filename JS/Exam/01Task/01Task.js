function sprint(input){
    let n = Number(input.shift());
    let users = {};
    let cmdParser = {
      'Add New': addtask,
      'Change Status': changeStatus,
      'Remove Task': removeTask,
    };
  
    for (let i = 0; i < n; i++) {
      const [ assignee, taskId, title, status, estPoints ] = input.shift().split(':');
      
      if (users.hasOwnProperty(assignee)){
      users[assignee].push({ taskId, title, status, estPoints });
    }else{
        users[assignee] = [{ taskId, title, status, estPoints }];
    }
    
    }
for (const line of input) {
    let cmdToken = line.split(':');
    let cmd = cmdToken[0];
    cmdParser[cmd](...cmdToken.slice(1));
}
let toDo = 0;
let inPr = 0;
let codeRev = 0;
let donePoints = 0;
for (const user in users) {
    
    for (const task of users[user]) {
        if (task.status==='ToDo'){toDo+=Number(task.estPoints);
        } else if (task.status==='In Progress'){inPr+=Number(task.estPoints);
        } else if (task.status==='Code Review'){codeRev+=Number(task.estPoints);
        } else if (task.status==='Done'){donePoints+=Number(task.estPoints);
        } 
    }
    
}
console.log(`ToDo: ${toDo}pts`);
console.log(`In Progress: ${inPr}pts`);
console.log(`Code Review: ${codeRev}pts`);
console.log(`Done Points: ${donePoints}pts`);

if(donePoints>=(inPr+codeRev+toDo)){
    console.log('Sprint was successful!');
} else {
    console.log('Sprint was unsuccessful...');
}

function addtask(assignee, taskId, title, status, estPoints) {
   if (!users.hasOwnProperty(assignee)) {
    console.log(`Assignee ${assignee} does not exist on the board!`);
   }else{
    users[assignee].push({taskId, title, status, estPoints})
   }
}

function changeStatus(assignee,taskId,newStatus) {
    if (!users.hasOwnProperty(assignee)) {
        console.log(`Assignee ${assignee} does not exist on the board!`);
       }else{
        let exist = false;
       for (const tasks of users[assignee]) {
        if (tasks.taskId === taskId) exist=true;
       }
       if (exist){
        let taskIndex = users[assignee].findIndex(x=>x.taskId ===taskId);
        users[assignee][taskIndex].status = newStatus;
       }else{
        console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
       }
       }
}

function removeTask(assignee, index) {
    if (!users.hasOwnProperty(assignee)) {
        console.log(`Assignee ${assignee} does not exist on the board!`);
       }else{
            if(index>=0 && index<users[assignee].length) {
                users[assignee].splice(index,1)
            }else{
                console.log('Index is out of range!');
            }
       }
    }
}

sprint([
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
]
)