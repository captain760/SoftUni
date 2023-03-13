function solve(arr) {
    let searchWords = arr.shift().split(" ");
    let words = arr;
    let occurances = {};
    for (const sw of searchWords) {
        occurances[sw]=0;
       for (const w of words) {
        if (sw === w){
            occurances[sw]++;
        }
       } 
    }
   let sorted = Object.entries(occurances).sort((a,b)=>b[1]-a[1]);
   for (const iterator of sorted) {
    console.log(`${iterator[0]} - ${iterator[1]}`)
   }
}
solve([
    'is the', 
    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']
    
    )