// function solve() {
//    const firstInp = document.getElementById('first'); 
//    const secondtInp = document.getElementById('second'); 
//    const div = document.getElementById('div'); 
//    const btn = document.getElementsByTagName('button')[0];
//    btn.addEventListener('click', sum);

//    function sum() {
//     div.textContent = firstInp.value + secondtInp.value;
//    }
// }
// solve()


//Double sorting

// heroes = [{hero:"Boris", points:34}, {hero:"Galina", points:34}, {hero:"Momo", points:54}]
// let sorted = heroes.sort((a,b)=>{
// let result = b.points-a.points;
// if(result ===0){
//     return b.hero.localeCompare(a.hero)
// }
// return result;
// });
// for (const obj of sorted) {
//     console.log(`${obj.hero} --> ${obj.points}`);
// }

//Double sorting

function solve(arr) {
    return arr.reduce((sum,x)=>sum+x)
}
const addArr = arr => arr.reduce((sum,x)=>sum+x);

console.log(solve([1,2,3,4,5,6,7,8,9,10]));
console.log(addArr([1,2,3,4,5,6,7,8,9,10]));