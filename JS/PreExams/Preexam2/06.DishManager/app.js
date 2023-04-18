window.addEventListener("load", solve);

function solve() {
  const form = Array.from(document.getElementsByTagName('form'))[0];
    const fn = document.getElementById('first-name');
    const ln = document.getElementById('last-name');
    const age = document.getElementById('age');
    const gender = document.getElementById('genderSelect');
    const task = document.getElementById('task');
 
    const submitBtn = document.getElementById('form-btn');
    const clearBtn = document.getElementById('clear-btn');
    const res = document.getElementById('progress-count');
    
    const inProg = document.getElementById('in-progress');
    const finished = document.getElementById('finished');
    
    let dish = {};
    let i = 0;
    submitBtn.addEventListener('click', submitHandler);
 
    function submitHandler(e) { 
     if (e) {
         e.preventDefault();
     }
 
     if(fn.value == ''
     || ln.value == ''
     || age.value == ''
     || gender.value == ''
     || task.value == '' 
     )
    {
        return;
     }
 
     dish.firstName = fn.value;
     dish.lastName = ln.value;
     dish.age = age.value;
     dish.gender = gender.value;
     dish.task = task.value;
     
     let li = generateElement('li', '',inProg, '',['each-line']);
     let ar = generateElement('article', '', li);
     generateElement('h4', `${fn.value} ${ln.value}`, ar);
     generateElement('p', `${gender.value}, ${age.value}`, ar);
     generateElement('p', `Dish description: ${task.value}`, ar);
     let editBtn = generateElement('button', 'Edit', li, '',['edit-btn']);
     let completeBtn = generateElement('button', 'Mark as complete', li, '',['complete-btn']);

     form.reset();
     i++;
     res.textContent = i;
      //submitBtn.disabled = true;
 
 
      editBtn.addEventListener('click', editHandler);
      completeBtn.addEventListener('click', completeHandler);
    }

    function editHandler() {
     fn.value = dish.firstName;
     ln.value = dish.lastName;
     age.value = dish.age;
     gender.value = dish.gender;
     task.value = dish.task ;
     //submitBtn.disabled = false;
     inProg.innerHTML = '';
     generateElement('h3', 'In progress', inProg);
     i--;
     res.textContent = i;
    }

    function completeHandler() {
      finished.appendChild(this.parentNode);
      i--;
      res.textContent = i;
      let editBtn = Array.from(finished.getElementsByClassName('edit-btn'))[0];
        let completeBtn = Array.from(finished.getElementsByClassName('complete-btn'))[0];
        editBtn.remove();
        completeBtn.remove();

        clearBtn.addEventListener('click', clearHandler);
    }


    function clearHandler() {
      finished.innerHTML = '';
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
