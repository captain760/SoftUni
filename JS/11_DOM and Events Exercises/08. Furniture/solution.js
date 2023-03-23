function solve() {
  
const [inpArea,outArea] = Array.from(document.getElementsByTagName('textarea'));
const [genBtn, buyBtn] = Array.from(document.getElementsByTagName('button'));
const tBody = Array.from(document.getElementsByTagName('tbody'))[0];
genBtn.addEventListener("click", generate);
buyBtn.addEventListener("click", buy);

function generate() {  
  let arr = JSON.parse(inpArea.value);
  for (const {img, name, price, decFactor} of arr) {
    const newTr = generateElement('tr','',tBody);
    const newTdImage = generateElement('td','',newTr);
    generateElement('img','',newTdImage,'','',{src:img});
    const newTdName = generateElement('td', '', newTr);
    generateElement('p', name, newTdName);
    const newTdPrice = generateElement('td', '', newTr);
    generateElement('p',price,newTdPrice);
    const newTdfactor = generateElement('td', '', newTr);
    generateElement('p',decFactor, newTdfactor);
    const newTdMark = generateElement('td', '', newTr);
    generateElement('input','',newTdMark, '', '',{type:'checkbox'});
  }
 
}

function buy(e) {
  const marked = Array.from(document.querySelectorAll('input:checked'));
  
  let names = [];
  let totalPrice = 0;
  let totalFactor = 0;
  let outString = '';
  for (const mark of marked) {
        let currName = mark.parentElement.parentElement.children[1].children[0].textContent;
        names.push(currName);
        totalPrice += Number(mark.parentElement.parentElement.children[2].children[0].textContent);
        totalFactor += Number(mark.parentElement.parentElement.children[3].children[0].textContent);
    
  }
   outString += `Bought furniture: ${names.join(", ")}\n`
   outString += `Total price: ${totalPrice.toFixed(2)}\n`
   outString += `Average decoration factor: ${totalFactor/names.length}`
   outArea.textContent = outString;
}

function generateElement(type, content, parentNode, id, classes, attributes) {
  const element = document.createElement(type);
  if (content && type === 'input') {
    element.value = content;
  }
  if (content && type !== 'input') {
    element.textContent = content;
  }
  if (id) {
    element.id = id;
  }
  if (classes) {
    element.classList.add(...classes)
  }
  if (attributes) {
    for (const key in attributes) {
      element.setAttribute(key, attributes[key])
    }
  }
  if (parentNode) {
    parentNode.appendChild(element);
  }
  return element;
}
}