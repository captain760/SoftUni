function solve(input) {
    let courses = {};
    for (const line of input) {
        let lineArr = line.split(': ');
        if(lineArr.length>1){
            let [courseName, capacity] = [lineArr[0], lineArr[1]];
            if (courses.hasOwnProperty(courseName)){
                courses[courseName].capacity += Number(capacity);
            } else {
                courses[courseName] = {};
                courses[courseName].users = [];
                courses[courseName].capacity = Number(capacity);
            }
        }else{
            lineArr = line.split('] with email ');
            let leftPart = lineArr[0].split('[');
            let rightPart = lineArr[1].split(' joins ');
            let [user, credits] = [leftPart[0], leftPart[1]];
            let [email, courseName] = [rightPart[0], rightPart[1]];
            if (courses.hasOwnProperty(courseName) && courses[courseName].capacity>0){
                courses[courseName].capacity--;
                let student = {};
                student.user = user;
                student.email = email;
                student.credits = Number(credits);
                courses[courseName].users.push(student);                
            }
        }
    }
    let arrCourses = Object.entries(courses);
    let sortedCourses = arrCourses.sort((a,b)=> b[1].users.length - a[1].users.length);
    for (const course of sortedCourses) {
        console.log(`${course[0]}: ${course[1].capacity} places left`);
        let students = course[1].users;
        let sortedStudents = students.sort((a,b)=> b.credits - a.credits);
        for (const user of sortedStudents) {
            console.log(`--- ${user.credits}: ${user.user}, ${user.email}`);
        }
    }
    
}

solve(['JavaBasics: 2', 'user1[25] with email user1@user.com joins C#Basics', 'C#Advanced: 3', 'JSCore: 4', 'user2[30] with email user2@user.com joins C#Basics', 'user13[50] with email user13@user.com joins JSCore', 'user1[25] with email user1@user.com joins JSCore', 'user8[18] with email user8@user.com joins C#Advanced', 'user6[85] with email user6@user.com joins JSCore', 'JSCore: 2', 'user11[3] with email user11@user.com joins JavaBasics', 'user45[105] with email user45@user.com joins JSCore', 'user007[20] with email user007@user.com joins JSCore', 'user700[29] with email user700@user.com joins JSCore', 'user900[88] with email user900@user.com joins JSCore'])