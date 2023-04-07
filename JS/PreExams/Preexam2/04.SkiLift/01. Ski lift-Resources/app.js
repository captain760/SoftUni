window.addEventListener('load', solve);

function solve() {
    const form = Array.from(document.getElementsByTagName('form'))[0];
   const fn = document.getElementById('first-name');
   const ln = document.getElementById('last-name');
   const np = document.getElementById('people-count');
   const fd = document.getElementById('from-date');
   const nd = document.getElementById('days-count');

   const nextBtn = document.getElementById('next-btn');
   const mainDiv = document.getElementById('main');
   const body = document.getElementById('body');
   const list = document.querySelector('.ticket-info-list');
   const confList = document.querySelector('.confirm-ticket');
   
   let ticket = {};

   nextBtn.addEventListener('click', nextHandler);

   function nextHandler(e) {
    if (e) {
        e.preventDefault();
    }

    if(fn.value == ''
    || ln.value == ''
    || nd.value == ''
    ||np.value == ''
    || fd.value == '')
   {
        return;
    }

    ticket.firstName = fn.value;
    ticket.lastName = ln.value;
    ticket.count = np.value;
    ticket.fromDate = fd.value;
    ticket.daysCount = nd.value;
    
    let li = generateElement('li', '', list, '',['ticket']);
    let ar = generateElement('article','',li);
    generateElement('h3', `Name: ${fn.value} ${ln.value}`, ar);
    generateElement('p', `From date: ${fd.value}`, ar);
    generateElement('p', `For ${nd.value} days`, ar);
    generateElement('p', `For ${np.value} people`, ar);
    let editBtn = generateElement('button', 'Edit', li, '', ['edit-btn']);
    let contBtn = generateElement('button', 'Continue', li, '', ['continue-btn']);    
    editBtn.addEventListener('click', editHandler);
    contBtn.addEventListener('click', continueHandler);
    form.reset();
    nextBtn.disabled = true;


    function editHandler() {
        fn.value = ticket.firstName;
        ln.value = ticket.lastName;
        np.value = ticket.count;
        fd.value = ticket.fromDate;
        nd.value = ticket.daysCount
        nextBtn.disabled = false;
        this.parentNode.remove();
    }

    function continueHandler() {
        let li = this.parentNode;
        confList.appendChild(li);
        let oldBtnEdit = Array.from(confList.querySelectorAll('button.edit-btn'))[0];
        let oldBtnCont = Array.from(confList.querySelectorAll('button.continue-btn'))[0];
        
        let confBtn = generateElement('button', 'Confirm', confList.children[0], '', ['confirm-btn']);
        let cancelBtn = generateElement('button', 'Cancel', confList.children[0], '', ['cancel-btn']);
        
        confBtn.addEventListener('click', confirmHandler);
        cancelBtn.addEventListener('click', cancelHandler);
        oldBtnEdit.remove();
        oldBtnCont.remove();
    }

    function confirmHandler() {
        mainDiv.remove();
        generateElement('h1', 'Thank you, have a nice day!',body, 'thank-you');
        let backBtn = generateElement('button', 'Back',body, 'back-btn');
        backBtn.addEventListener('click', backHandler);
    }

    function backHandler() {
        window.location.reload();
    }

    function cancelHandler() {
        
        this.parentNode.remove();
        nextBtn.disabled = false;
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


    
    
