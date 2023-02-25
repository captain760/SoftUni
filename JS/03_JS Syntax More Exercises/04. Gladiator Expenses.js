function solve(n,htp,swp,shp,arp){
let expenses = 0;
for (let i = 1; i <= n; i++) {
    if (i%2===0) expenses+=htp;
    if (i%3==0) expenses+=swp;
    if (i%6==0) expenses+=shp;
    if (i%12==0) expenses+=arp;
}
console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`)
}

solve(23,
    12.50,
    21.50,
    40,
    200
    )