function solve(pass) {
    let checkPassed = true;
    let lengthCheck = (str)=>{
        if (str.length<6 || str.length>10) {
           console.log("Password must be between 6 and 10 characters");
           checkPassed = false;
        }
        return;
    }
    let letersDigitsCheck = (str)=>{
        //Only letters and digits Regex
        let re = new RegExp("^[A-Za-z0-9]+$");
        if (!str.match(re)) {
           console.log("Password must consist only of letters and digits");
           checkPassed = false;
        }
        return;
    }
    let twoDigitsCheck = (str)=>{
        // at least two digits Regex
        let re = new RegExp("[0-9]{2,}");
        if (!str.match(re)) {
           console.log("Password must have at least 2 digits");
           checkPassed = false;
        }
        return;
    }
    lengthCheck(pass);
    letersDigitsCheck(pass);
    twoDigitsCheck(pass);
    if (checkPassed) console.log("Password is valid");
}

solve("logIn")