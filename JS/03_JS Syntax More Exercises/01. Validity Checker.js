function solve(x1,y1,x2,y2){
function dist(a,b,c,d){
    return ((c-a)**2+(d-b)**2)**0.5;
}
let state = "valid"
if(dist(x1,y1,0,0)-Math.round(dist(x1,y1,0,0))!==0){
state = "invalid"
}
console.log(`{${x1}, ${y1}} to {0, 0} is ${state}`)
state = "valid"
if(dist(x2,y2,0,0)-Math.round(dist(x2,y2,0,0))!==0){
state = "invalid"
}
console.log(`{${x2}, ${y2}} to {0, 0} is ${state}`)
state = "valid"
if(dist(x1,y1,x2,y2)-Math.round(dist(x1,y1,x2,y2))!==0){
state = "invalid"
}
console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${state}`)
}
solve(2, 1, 1, 1)