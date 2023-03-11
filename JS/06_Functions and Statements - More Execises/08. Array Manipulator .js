function solve(arr, commands) {
  for (let i = 0; i < commands.length; i++) {
    let currCommArr = commands[i].split(" ");
    let currComm = currCommArr[0];
    if (currComm === "add") {
        let index = +currCommArr[1];
        let element = +currCommArr[2];
        arr.splice(index,0,element)
    }
    if (currComm === "addMany") {
        let index = +currCommArr[1];
        let elements = currCommArr.slice(2,currCommArr.length).map((x)=>+x);
        arr.splice(index,0,elements);
        arr = arr.flat();
        
    }
    if (currComm === "contains") {
        let element = +currCommArr[1];
        let result = arr.indexOf(element);
        console.log(result)
    }
    if (currComm === "remove") {
        let index = +currCommArr[1];        
        arr.splice(index,1)
    }
    if (currComm === "shift") {
        let positions = +currCommArr[1];
        for (let i = 0; i < positions; i++) {
            arr.push(arr.shift());            
        }
    }
    if (currComm==="sumPairs") {
        let result = [];        
        if (arr.length%2===0){
            for (let i = 0; i < arr.length-1; i++) {
                result.push(arr[i]+arr[i+1]); 
                i++;               
            }
        } else{
            for (let i = 0; i < arr.length-2; i++) {
                result.push(arr[i]+arr[i+1]); 
                i++;               
            }
            result.push(arr[arr.length-1]);
        }
        arr = result;
    }
    if (currComm === "print"){
        console.log(`[ ${arr.join(", ")} ]`)
    }
  }
}

solve([2, 2, 4, 2, 4],
    ["add 1 4", "sumPairs", "print"]
    )