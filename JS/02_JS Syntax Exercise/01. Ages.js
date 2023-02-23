function solve(age){
    let state = "elder"
if(age<0) state = "out of bounds"
else if (age<3) state="baby"
else if (age<14) state="child"
else if (age<20) state="teenager"
else if (age<66) state="adult";
console.log(state);
}
solve(70)