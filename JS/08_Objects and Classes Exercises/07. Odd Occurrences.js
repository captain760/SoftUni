function solve(str) {
    let words = str.toLowerCase().split(" ");
    let appearance = {};
    for (const w of words) {
        let wApp = 0;
        for (const currWord of words) {
            if (currWord === w) {
                wApp++;
            }
        }
        appearance[w] = wApp;
    }
    let arr = Object.entries(appearance);
    let oddsArr =[]
    for (const iterator of arr) {
        if (iterator[1]%2===1){
            oddsArr.push(iterator[0])
        }
    }
    console.log(oddsArr.join(" "))
}

solve('Cake IS SWEET is Soft CAKE sweet Food')