function solve([x1,y1,x2,y2]) {
    let distance = (a,b,c,d) =>Math.sqrt(Math.pow((c-a),2)+Math.pow((d-b),2));
    if (distance(x1,y1,0,0)-Math.round(distance(x1,y1,0,0)) === 0) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
    }else{
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`)
    }
    if (distance(x2,y2,0,0)-Math.round(distance(x2,y2,0,0)) === 0) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
    }else{
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`)
    }
    if (distance(x1,y1,x2,y2)-Math.round(distance(x1,y1,x2,y2)) === 0) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
    }else{
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
    }
}

solve([2,1,1,1])