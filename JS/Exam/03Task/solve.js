
function attachEvents() {
 const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';
 const loadAllBtn = document.getElementById('load-board-btn');
 const addBtn = document.getElementById('create-task-btn');
 const addTitle = document.getElementById('title');
 const addDescr = document.getElementById('description');
 let allTasks = [];
 let currTask = {
  title: null,
  description: null,
  status: null,
  _id: null
 }
 
 const tasks = Array.from(document.querySelectorAll('.task-list'));
 const toDoArt = document.getElementById('todo-section');
 const inPrArt = document.getElementById('in-progress-section');
 const codeRevArt = document.getElementById('code-review-section');
 const doneArt = document.getElementById('done-section');
 loadAllBtn.addEventListener('click', loadAll);
 addBtn.addEventListener('click', addTask);
 
 async function loadAll(e) {
    if (e) {e.preventDefault()};
    currTask = {
      title: null,
      description: null,
      status: null,
      _id: null
     }
    tasks.forEach(x=>x.innerHTML = '');
    let res = await fetch(BASE_URL);
    let data = await res.json();
   
    for (const task of Object.values(data)) {
        let parr = doneArt;
        if(task.status === "ToDo"){
            parr = toDoArt
        }else if (task.status === 'In Progress'){
            parr = inPrArt;
        }else if (task.status === 'Code Review'){
            parr = codeRevArt;
        }
        currBtn = 'Close';
        if(task.status === "ToDo"){
           currBtn = 'Move to In Progress';
        }else if (task.status === 'In Progress'){
            currBtn = 'Move to Code Review';
        }else if (task.status === 'Code Review'){
            currBtn = 'Move to Done';
        }
        let li = generateElement('li', '',Array.from(parr.children)[1], task._id,['task']);
        generateElement('h3', task.title, li);
        generateElement('p', task.description, li);
        let btn = generateElement('button', currBtn, li);
        let title = task.title;
        let description = task.description;
        let status = task.status;
        let _id = task._id;
        currTask[_id] = {title: title, description: description, status: status, _id: _id};
        allTasks.push(currTask[_id]);
        
        btn.addEventListener('click', move);
    }
    }

 async function move() {
      let currId = this.parentNode.id;      
      let currTask = allTasks.find(x=>x._id === currId);
      
      if (currTask.status === 'ToDo'){currTask.status ='In Progress';patch()}
      else if (currTask.status === 'In Progress'){currTask.status ='Code Review';patch()}
      else if (currTask.status === 'Code Review'){currTask.status ='Done';patch()}
      else if (currTask.status === 'Done'){closeTask()};
      loadAll();
      
      async function patch() {
        
       let handler = {method: 'PATCH',
                      body: JSON.stringify(currTask)};
      await fetch(`${BASE_URL}${currId}`, handler);
      }
      
      
      async function closeTask() {
        let handler = {method: 'DELETE'};
        await fetch(`${BASE_URL}${currId}`, handler)
      }

}

 async function addTask() {
      let newTask = {};
      newTask.title = addTitle.value;
      newTask.description = addDescr.value;
      newTask.status = 'ToDo';      
      handler = {method: 'POST',
                 body: JSON.stringify(newTask)};
      await fetch(BASE_URL, handler);

      addTitle.value = '';
      addDescr.value = '';
      
      loadAll();
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