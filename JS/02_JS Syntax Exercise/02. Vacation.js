function solve(num, type, day){
    let price =0;
switch(type){
    case "Students":{
        switch(day){
            case "Friday": price = num*8.45;break;
            case "Saturday": price = num*9.8;break;
            case "Sunday": price = num*10.46;break;
        }
        if (num>=30) price*=0.85;
    }break;
    case "Business":{
        if (num>=100) num-=10;
        switch(day){
            case "Friday": price = num*10.9;break;
            case "Saturday": price = num*15.6;break;
            case "Sunday": price = num*16;break;
        }        
    }break;
    case "Regular":{
        switch(day){
            case "Friday": price = num*15;break;
            case "Saturday": price = num*20;break;
            case "Sunday": price = num*22.5;break;
        } 
        if (num>=10 && num<=20) price*=0.95;       
    }break;
}
console.log(`Total price: ${price.toFixed(2)}`)
}
solve(30,"Students","Sunday")