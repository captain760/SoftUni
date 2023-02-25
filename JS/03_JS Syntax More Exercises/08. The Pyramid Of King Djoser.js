function solve(base, incr){
let stone =0;
let marble =0;
let lapis =0;
let gold =0;
let height = 0;
if (base>0){
    if (base%2===0) gold = Math.ceil(4*incr)
else gold = Math.ceil(incr);
height++;
}
let fifth = 0
for (let i = base; i > 2; i-=2) {
    stone += ((i-2)**2);
    fifth++;
    if (fifth%5===0){
        lapis += ((4*i-4));
    } else {
        marble += ((4*i-4));
    }
    height++;    
}
console.log(`Stone required: ${Math.ceil(stone*incr)}`);
console.log(`Marble required: ${Math.ceil(marble*incr)}`);
console.log(`Lapis Lazuli required: ${Math.ceil(lapis*incr)}`);
console.log(`Gold required: ${gold}`);
console.log(`Final pyramid height: ${Math.floor(height*incr)}`);
}
solve(3,0.1)