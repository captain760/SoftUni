
function attachEvents() {
     
  const inp = document.getElementById('title');
  const addBtn = document.getElementById('add-button');
  const loadBtn = document.getElementById('load-button');
  const list = document.getElementById('todo-list');
  const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';
  loadBtn.addEventListener('click', load);
  addBtn.addEventListener('click', addHandler);

  async function addHandler(e) {
    e?.preventDefault();
    let title = {'name': inp.value};
    let handler = {method: 'POST', body: JSON.stringify(title)}
    let res = await fetch(BASE_URL, handler);
    load();
  }

 async function load(e) {
    e?.preventDefault();
    list.innerHTML = '';
    let res = await fetch(BASE_URL);
    let data = await res.json();    
    for (const toDo of Object.values(data)) {
        const li = generateElement('li','',list, toDo._id);
        generateElement('span', toDo.name, li);
        let removeBtn = generateElement('button', 'Remove', li);
        let editBtn = generateElement('button', 'Edit', li);
        removeBtn.addEventListener('click', removeHandler);
        editBtn.addEventListener('click', editHandler);
    }
    
    async function removeHandler() {
                let li = this.parentNode
                let id = li.id;
                let handler = {method:'DELETE'}
                let res = await fetch(`${BASE_URL}${id}`, handler)
                li.remove();
                load();
    }

     function editHandler() {
        
        let li = this.parentNode
        let id = li.id;
        let span = Array.from(li.children)[0];
        let edit = Array.from(li.children)[2];
        console.log(li, id,span,edit);
        let newInput = document.createElement('input');
        newInput.value = span.textContent;
        li.prepend(newInput);
        let submitBtn = document.createElement('button');
        submitBtn.textContent = 'Submit';
        submitBtn.addEventListener('click',submitPatch)
        li.appendChild(submitBtn);
        span.remove();
        edit.remove();
    }

    async function submitPatch() {
        let li = this.parentNode;
        let id = li.id;
        let title = {'name': Array.from(this.parentNode.children)[0].value};
        let handler = {method:'PATCH', body: JSON.stringify(title)}
        let res = await fetch(`${BASE_URL}${id}`, handler);        
        load();
    }
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

attachEvents();
