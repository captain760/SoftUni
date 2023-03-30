function extract(content) {

// *** with RegEx***
// const strObj= document.getElementById(content);
// let final = [];
// let result = strObj.textContent.split(/[()]/);
// for (let i = 1; i < result.length; i+=2) {
//   final.push(result[i]);    
// }
// return final.join('; ');

const str= document.getElementById(content).textContent;
let final = [];
let openBrArr = str.split('(');
for (const firstSplit of openBrArr) {
    if (firstSplit.includes(')')){
        let closBrIndex = firstSplit.indexOf(')');
        let text = firstSplit.substring(0,closBrIndex);
        final.push(text);
    }
}
return final.join('; ');
}