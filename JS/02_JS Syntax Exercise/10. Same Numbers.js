function solve(a){
    let arr = a.toString().split("");
    let sum = +arr[0];
    let isSame=true;
    let ref = arr[0];
    for (let i = 1; i < arr.length; i++) {
            sum+=+arr[i];
            if(ref!==arr[i]) isSame=false;
            ref = arr[i];
        }    
    console.log(isSame);
    console.log(sum)
}

solve(222222)