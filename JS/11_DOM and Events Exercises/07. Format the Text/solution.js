function solve() {
  const inp = document.getElementById("input");
  
  const out = document.getElementById("output");
  let sentences = inp.value.split(".");
 
for (let i = 0; i < sentences.length; i++) {  
  if(sentences[i] === ''){      
      sentences.splice(i,1);
      i--;
  }  
}
  if (sentences.length<=3){
    let newP = document.createElement("p");
    for (let i = 0; i < sentences.length; i++) {
      newP.textContent += sentences[i]+"."; 
    }    
    out.appendChild(newP)
  } else{
    let pNumber = 0;
    let cicles = (sentences.length)/3;
      for (let i = 1; i < cicles; i++) {      
      let newP = document.createElement("p");
      newP.textContent = sentences[pNumber*3]+"." + sentences[pNumber*3+1]+ "." + sentences[pNumber*3+2]+ '.';     
      out.appendChild(newP);   
      pNumber++;
    }
    let newP = document.createElement("p");
    for (let i = pNumber*3; i < sentences.length-1; i++) {      
      newP.textContent += sentences[i] + '.';      
    }
    newP.textContent+=sentences[sentences.length-1]+".";   
    out.appendChild(newP)
  }
}