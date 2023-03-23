function create(words) {
  for (const word of words) {
   const divElement = document.createElement("div");   
   const currElement = document.getElementById("content");
   currElement.appendChild(divElement);
  }
  const clElements = [...document.querySelectorAll("div#content>div")];
for (let i = 0; i < words.length; i++) {
   const pElement = document.createElement("p");
   pElement.textContent = words[i];   
   pElement.setAttribute("style", "display: none");   
   clElements[i].appendChild(pElement);
   clElements[i].addEventListener("click", clickHandler);
}
  
  function clickHandler(e) {
      let currentP = e.currentTarget.children;      
      currentP[0].setAttribute("style", "display: block");   
  }
}