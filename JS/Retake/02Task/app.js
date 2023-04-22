window.addEventListener("load", solve);

function solve() {
    const form = Array.from(document.getElementsByTagName('form'))[0];
    const title = document.getElementById('task-title');
    const cat = document.getElementById('task-category');
    const cont = document.getElementById('task-content');
    
 
    const publishBtn = document.getElementById('publish-btn');
   
    const review = document.getElementById('review-list');
    const uploaded = document.getElementById('published-list');
    
    let task = {};
    let i = 0;
    publishBtn.addEventListener('click', publishHandler);
 
    function publishHandler(e) { 
     if (e) {
         e.preventDefault();
     }
 
     if(title.value == ''
     || cat.value == ''
     || cont.value == ''     
     )
    {
        return;
     }
 
     task.title = title.value;
     task.cat = cat.value;
     task.cont = cont.value;
     
     
     let li = generateElement('li', '',review, '',['rpost']);
     let ar = generateElement('article', '', li);
     generateElement('h4', `${title.value}`, ar);
     generateElement('p', `Category: ${cat.value}`, ar);
     generateElement('p', `Content: ${cont.value}`, ar);
     let editBtn = generateElement('button', 'Edit', li, '',['action-btn', 'edit']);
     let postBtn = generateElement('button', 'Post', li, '',['action-btn', 'post']);

     form.reset();
     
      editBtn.addEventListener('click', editHandler);
      postBtn.addEventListener('click', postHandler);
    }

    function editHandler() {
       title.value = task.title;
       cat.value = task.cat;
       cont.value = task.cont;
     
     review.innerHTML = '';
    
    }
    function postHandler() {
        uploaded.appendChild(this.parentNode);
      
      let btns = Array.from(uploaded.querySelectorAll('button'));
        for (const btn of btns) {
            btn.remove();
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
}