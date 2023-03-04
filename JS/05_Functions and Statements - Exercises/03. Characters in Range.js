function solve(a,b) {
    let chNum = (x) => x.charCodeAt(0);
    let result = [];
    if(chNum(a)>chNum(b)){
        for (let i = chNum(b)+1; i < chNum(a); i++){
            result.push(String.fromCharCode(i))
        }
    }else {
        for (let i = chNum(a)+1; i < chNum(b); i++){
            result.push(String.fromCharCode(i))
        }
    }
    return result.join(' ')
}


console.log(solve("a", "d"))