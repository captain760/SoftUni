function solve(number) {
    function progressBar(x) {
       let bar = "[" + "%".repeat(x/10) +".".repeat((100-x)/10)+"]";
       return bar
    }
    if (number<100) {
        console.log(`${number}% ${progressBar(number)}`);
        console.log("Still loading...")
    } else{
        console.log("100% Complete!");
        console.log(progressBar(number));
    }
}

solve(0)