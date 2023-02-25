function solve(arr){
    let username = arr[0];
    function reverse(str){
        let newStr = "";
        for (let i = str.length-1; i >=0; i--) {
            newStr+=str[i];            
        }
        return newStr;
    }
    let realPass = reverse(arr[0])
for (let i = 1; i < 5; i++) {
    let pass = arr[i];
    if (pass===realPass) {console.log(`User ${username} logged in.`)
    return;
}
    else{
        if (i!==4) 
        console.log("Incorrect password. Try again.")
        else console.log(`User ${username} blocked!`)
    }
}
}
solve(['sunny','rainy','cloudy','sunny','not sunny'])