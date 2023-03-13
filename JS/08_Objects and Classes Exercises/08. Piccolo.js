function solve(arr) {
    let parking = {};
    for (const iterator of arr) {
        let[com,regN] = iterator.split(", ");
        if(com === "IN"){
            parking[regN] = regN;
        }else{
            delete parking[regN]
        }
    }
    let sorted = Object.keys(parking).sort((a,b)=>a.localeCompare(b));
    if (sorted.length !==0){
    for (const iterator of sorted) {
        console.log(iterator)
    }} else {
        console.log("Parking Lot is Empty")
    }    
}

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']

)