function solve(arr,n){
    let newArr=[];
    for (let i = 0; i < arr.length; i+=n) {
        newArr.push(arr[i]);        
    }
    return(newArr);
}
solve(['dsa','asd', 'test', 'tset'], 2)