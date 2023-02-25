function solve(y){
let total = 0;
let days = 0;
while (y>=100){
    total+=y-26;
    y-=10;
    days++;
}
total-=26;
if (total<0) total=0;
console.log(days);
console.log(total);
}
solve(450)