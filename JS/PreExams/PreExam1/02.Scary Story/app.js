window.addEventListener("load", solve);

function solve() {
  const inputDOM = {
    firstName: document.getElementById('first-name'), 
    lastName: document.getElementById('last-name'),
    age: document.getElementById('age'),
    title: document.getElementById('story-title'),
    genre: document.getElementById('genre'),
    story: document.getElementById('story'),
  };
  
  const obj = {
    firstName: '', 
    lastName: '',
    age: '',
    title: '',
    genre: '',
    story: '',
  }
  const preview = document.getElementById('preview-list');
  const main = document.getElementById('main');
  
  const publishBtn = document.getElementById('form-btn');
  publishBtn.addEventListener('click', publish)

function publish() {
  const allValued = Object.values(inputDOM).every(x=>x.value!=='')
  if (!allValued) return;
  obj.firstName = inputDOM.firstName.value;
  obj.lastName = inputDOM.lastName.value;
  obj.age = inputDOM.age.value;
  obj.title = inputDOM.title.value;
  obj.genre = inputDOM.genre.value;
  obj.story = inputDOM.story.value;
  
  this.disabled = true;
  const ul = document.getElementById('preview-list');
  ul.innerHTML = ''
  generateElement('h3', 'Preview', ul);
  let li = generateElement('li', '', ul, '',['story-info']);
  let ar = generateElement('article', '', li,);
  
  generateElement('h4', `Name: ${obj.firstName} ${obj.lastName}`, ar);
  generateElement('p', `Age: ${obj.age}`, ar,);
  generateElement('p', `Title: ${obj.title}`, ar,);
  generateElement('p', `Genre: ${obj.genre}`, ar,);
  generateElement('p', obj.story, ar,);
  let saveBtn = generateElement('button', 'Save Story', li, '',['save-btn']);
  let editBtn = generateElement('button', 'Edit Story', li, '',['edit-btn']);
  let deleteBtn = generateElement('button', 'Delete Story', li, '',['delete-btn']);  
  
  editBtn.addEventListener('click', edit);
  saveBtn.addEventListener('click', save);
  deleteBtn.addEventListener('click', deleteHandler);

  for (const key of Object.values(inputDOM)) {
    key.value = "";
  }
  publishBtn.disabled = true;
}

function edit() {
  for (const key in inputDOM) {
    inputDOM[key].value = obj[key]
    }    
    preview.innerHTML = '';
    generateElement('h3', 'Preview', preview);  
    publishBtn.disabled = false;  
}

function save() {
  main.innerHTML = '';
  generateElement('h1', 'Your scary story is saved!', main);
}

function deleteHandler() {
    preview.innerHTML = '';
    generateElement('h3', 'Preview', preview);   
    publishBtn.disabled = false;

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
}
