function solve(day, age){
if (age<0 || age>122){
    return("Error!");    
}
if(age<=18){
    switch(day){
    case "Weekday": console.log("12$");break;
    case "Weekend": console.log("15$");break;
    default: console.log("5$");
    }
} else if(age>18 && age<=64){
    switch(day){
    case "Weekday": console.log("18$");break;
    case "Weekend": console.log("20$");break;
    default: console.log("12$");
    }
} else{
    switch(day){
        case "Weekday": console.log("12$");break;
        case "Weekend": console.log("15$");break;
        default: console.log("10$");
        }
}
}