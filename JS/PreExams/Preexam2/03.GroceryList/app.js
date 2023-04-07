function solve(){
    const BASE_URL = 'http://localhost:3030/jsonstore/grocery/'
    const prodName = document.getElementById('product');
    const count = document.getElementById('count');
    const price = document.getElementById('price');
    let id;


    const loadAllBtn = document.getElementById('load-product');
    const addBtn = document.getElementById('add-product');
    const updBtn = document.getElementById('update-product');
    const tBody = document.getElementById('tbody');
    loadAllBtn.addEventListener('click', loadAll);
    addBtn.addEventListener('click', addProduct);
    updBtn.addEventListener('click', updProduct);

async function loadAll(e) {
    if (e) {e.preventDefault()};
    tBody.innerHTML = '';
    let res = await fetch(BASE_URL);
    let data = await res.json();
    for (const prod of Object.values(data)) {
        
        let tr = generateElement('tr', '',tBody, prod._id);
        generateElement('td', prod.product, tr, '', ['name']);
        generateElement('td', prod.count, tr, '', ['count-product']);
        generateElement('td', prod.price, tr, '', ['product-price']);
        let btn = generateElement('td', '', tr, '', ['btn']);
        let updateBtn = generateElement('button', 'Update', btn, '', ['update']);
        let deleteBtn = generateElement('button', 'Delete', btn, '', ['delete']);
        updateBtn.addEventListener('click', updateHandler);
        deleteBtn.addEventListener('click', deleteHandler);
    }

     
}

async function updProduct() {
    let prodObj = {};
    prodObj.product = prodName.value;
    prodObj.count = count.value;
    prodObj.price = price.value;
    
    let handler = {method: 'PATCH', body: JSON.stringify(prodObj)}
    let res = await fetch(`${BASE_URL}${id}`, handler);
    

        prodName.value = ''
        count.value = ''
        price.value = ''
        updBtn.disabled = true;
        addBtn.disabled = false;
        loadAll();

}

async function addProduct(e) {
    e.preventDefault();
    let prodObj = {};
    prodObj.product = prodName.value;
    prodObj.count = count.value;
    prodObj.price = price.value;
    
    let handler = {method: 'POST', body: JSON.stringify(prodObj)}
    let res = await fetch(BASE_URL, handler);
    

        prodName.value = ''
        count.value = ''
        price.value = ''
    loadAll();
}

function updateHandler() {
    id = this.parentNode.parentNode.id;
    prodName.value = Array.from(this.parentNode.parentNode.children)[0].textContent;
    count.value = Array.from(this.parentNode.parentNode.children)[1].textContent;
    price.value = Array.from(this.parentNode.parentNode.children)[2].textContent;
    updBtn.disabled = false;
    addBtn.disabled = true;
}

async function deleteHandler() {
    let idDel = this.parentNode.parentNode.id;
    let handler = {method: 'DELETE'};
    let res = await fetch(`${BASE_URL}${idDel}`, handler);
    loadAll()

}


}
function generateElement(type, content, parentNode, id, classes, attributes) {
        const element = document.createElement(type);
        if (content) {
            if (type === 'input'|| type === 'textarea') {
          element.value = content;
            } else {
          element.textContent = content;
            }
        }   
        if (id) {
          element.id = id;
        }
        //Array
        if (classes) {
          element.classList.add(...classes)
        }
        //Object
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
solve();