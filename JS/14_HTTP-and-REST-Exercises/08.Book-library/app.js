function attachEvents() {
  const BASE_URL = 'http://localhost:3030/jsonstore/collections/books/';
  const loadAll = document.getElementById('loadBooks');
  const table = document.getElementsByTagName('tbody')[0];
  const  submit = document.getElementById('form').children[5];
  const  title = document.getElementById('form').children[2];
  const  author = document.getElementById('form').children[4];
  const formTitle = document.getElementsByTagName('h3')[0];
  let bookId = '';
  loadAll.addEventListener('click', loadAllBooks);
 
  submit.addEventListener('click', postObj)

 
  
  async function loadAllBooks() {
    table.replaceChildren();
    let data = await fetch(BASE_URL)
    .then(res=>{
      if (!res.ok) throw(res.status);
      return res.json();
  })
  .catch(e=>{
      console.log(e.message)
  })
    let allBooks =  Object.entries(data);
    for (const [key, value] of allBooks) {
      let newTr = generateElement('tr','',table,key)
      generateElement('td',value.title, newTr);
      generateElement('td',value.author, newTr);
      let btnsField = generateElement('td','', newTr);
      let editBtn = generateElement('button', 'Edit',btnsField);
      let deleteBtn = generateElement('button', 'Delete',btnsField);
      editBtn.addEventListener('click', editBook);
      deleteBtn.addEventListener('click', deleteBook);
    }
  }

  async function editBook() {    
    formTitle.textContent = "Edit FORM";
    submit.textContent = "Save";
    title.value = this.parentNode.parentNode.children[0].textContent;
    author.value = this.parentNode.parentNode.children[1].textContent;
    bookId = this.parentNode.parentNode.id;    
    }

    async function deleteBook() {
      bookId = this.parentNode.parentNode.id;
      await fetch(BASE_URL+bookId,{
        method: 'DELETE',
    })
    .then(loadAllBooks)
    .catch((e)=>console.log(e.message));    
    }

    async function postObj() {
      let methodVal = "POST";
      let newObj = {};
      newObj.title = title.value;
      newObj.author = author.value;      
    if (formTitle.textContent === "Edit FORM"){
      methodVal = "PUT";      
      formTitle.textContent = "FORM";
      submit.textContent = "Submit";
    }    
    await fetch(BASE_URL+bookId,{
        method: methodVal,
        headers:{'Accept': 'application/json',
                 'Content-Type': 'application/json'
                },
        body: JSON.stringify(newObj)
    });
    title.value = '';
    author.value = '';
    bookId = '';    
    await loadAllBooks();


    async function deleteBook() {
          
  }
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
attachEvents();