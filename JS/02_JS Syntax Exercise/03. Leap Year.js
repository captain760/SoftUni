function solve(y){
if ((y%4===0 && y%100!==0)||(y%400===0)) {
    console.log("yes")
} else console.log("no")
}
solve(1984)
solve(2003)
solve(4)