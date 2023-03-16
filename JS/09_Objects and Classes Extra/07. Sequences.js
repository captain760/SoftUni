function solve(input) {
    let set = [];
   for (const line of input) {
    let currArr = JSON.parse(line).sort((a,b)=>b-a);
    let joinedCurrentArray = currArr.join(",");
    if(set.length===0){
        set.push(currArr)
    }else{
        let isSame = false
        for (const arr of set) {
            if (arr.join(",")===joinedCurrentArray){
                isSame = true;
                break;
            }
        }
        if (!isSame){
            set.push(currArr)
        }
    }
   } 
   set.sort((a,b)=>a.length-b.length)
  set.forEach(x=>console.log(`[${x.join(", ")}]`))
}

solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
"[10, 1, -17, 0, 2, 13]",
"[4, -3, 3, -2, 2, -1, 1, 0]"]

)