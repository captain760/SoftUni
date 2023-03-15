function solve(input) {

    function sortObj(obj) {
        return Object.keys(obj).sort((x, y) => x.localeCompare(y)).reduce(function (result, key) {
          result[key] = obj[key];
          return result;
        }, {});
    }

    let classes = {};
    for (const line of input) {
        let currLine = line.split(", ");        
        let studentName = currLine[0].split(": ")[1]; 
        let grade = +currLine[1].split(": ")[1] + 1; 
        let score = +currLine[2].split(": ")[1]; 
        if(score >= 3){           
            if(!(grade in classes)){
                classes[grade] = {"students": [studentName], "scores": [score]};           
            } else{
                classes[grade]["students"].push(studentName);
                classes[grade]["scores"].push(score);                 
            }
        }        
    }
    let sorted = sortObj(classes);
    
    for (const key in sorted) {
        console.log(`${key} Grade`);
        console.log(`List of students: ${sorted[key]["students"].join(", ")}`);
        let average = (sorted[key]["scores"].reduce((a,b)=>a+b))/(sorted[key]["scores"].length);
        console.log(`Average annual score from last year: ${average.toFixed(2)}`);
        console.log();
    }
}

solve([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
        "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
        "Student name: George, Grade: 8, Graduated with an average score: 2.83",
        "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
        "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
        "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
        "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
        "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
        "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
        "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
        "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
        "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
    ]
    )