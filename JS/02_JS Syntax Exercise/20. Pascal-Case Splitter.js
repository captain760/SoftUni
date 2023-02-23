function solve(str){
    let re = new RegExp(/[A-Z][a-z]*/g)
    arr = str.match(re);
    console.log(arr.join(", "));
}
solve('SplitMeIfYouCanHaHaYouCantOrYouCan')