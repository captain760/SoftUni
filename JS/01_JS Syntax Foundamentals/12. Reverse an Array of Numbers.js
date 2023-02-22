// function solve(n,arr){
//     let newArr = [];
//    for (let i = n-1; i >=0 ; i--) {
//     newArr[n-1-i] = arr[i]   
//    } 
//    let output = "";
//   for (let num  of newArr) {
//     output+=`${num} `;
//   }
//   console.log(output)
// }
function solve(n, arr){
    let newArr = [];
    for (let i = n-1; i >=0; i--){
        newArr.push(arr[i])
    }
    let output = "";
    for (let num  of newArr) {
             output+=`${num} `;
    }
    console.log(output)
}
solve(3, [10, 20, 30, 40, 50])