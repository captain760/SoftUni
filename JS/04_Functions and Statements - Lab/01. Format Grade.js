function solve(grade) {
    if(grade<3){
        console.log("Fail (2)");
        return;
    } else if (grade<3.5){
        console.log(`Poor (${round()})`);
        return;
    } else if (grade<4.5){
        console.log(`Good (${round()})`)
        return;
    } else if (grade<5.5){
        console.log(`Very good (${round()})`)
        return;
    } else{
        console.log(`Excellent (${round()})`)
    }
    function round() {
        return grade.toFixed(2);
    }
}
solve(4.5)