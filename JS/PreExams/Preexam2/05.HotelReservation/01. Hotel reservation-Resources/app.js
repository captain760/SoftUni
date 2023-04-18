window.addEventListener('load', solve);

function solve() {
    const form = Array.from(document.getElementsByTagName('form'))[0];
    const fn = document.getElementById('first-name');
    const ln = document.getElementById('last-name');
    const din = document.getElementById('date-in');
    const dout = document.getElementById('date-out');
    const pc = document.getElementById('people-count');
 
    const nextBtn = document.getElementById('next-btn');
    const res = document.getElementById('verification');
    const body = document.getElementById('body');
    const info = document.querySelector('.info-list');
    const conf = document.querySelector('.confirm-list');
    
    let reservation = {};
 
    nextBtn.addEventListener('click', nextHandler);
 
    function nextHandler(e) { 
     if (e) {
         e.preventDefault();
     }

     if(fn.value == ''
     || ln.value == ''
     || din.value == ''
     || dout.value == ''
     || pc.value == '' 
     || dout.value<=din.value)
    {
        return;
     }
 
     reservation.firstName = fn.value;
     reservation.lastName = ln.value;
     reservation.din = din.value;
     reservation.dout = dout.value;
     reservation.pc = pc.value;
     
     let li = generateElement('li','',info,'',['reservation-content']);
     let ar = generateElement('article','',li);
     generateElement('h3', `Name: ${fn.value} ${ln.value}`,ar);
     generateElement('p', `From date: ${din.value}`,ar);
     generateElement('p', `To date: ${dout.value}`,ar);
     generateElement('p', `For ${pc.value} people`,ar);
     let editBtn = generateElement('button', 'Edit', li,'',['edit-btn']);
     let continueBtn = generateElement('button', 'Continue', li,'',['continue-btn']);
     form.reset();
    //  fn.value = '';
    //  ln.value = '';
    //  din.value = '';
    //  dout.value = '';
    //  pc.value = '' ;
     nextBtn.disabled = true;


     editBtn.addEventListener('click', editHandler);
     continueBtn.addEventListener('click', continueHandler);
    }

    function editHandler() {
     fn.value = reservation.firstName;
     ln.value = reservation.lastName;
     din.value = reservation.din;
     dout.value = reservation.dout;
     pc.value = reservation.pc ;
     nextBtn.disabled = false;
     info.innerHTML = '';
    }

    function continueHandler() {
        conf.appendChild(this.parentNode);
        let editBtn = Array.from(conf.getElementsByClassName('edit-btn'))[0];
        let contBtn = Array.from(conf.getElementsByClassName('continue-btn'))[0];
        editBtn.remove();
        contBtn.remove();
        let confBtn = generateElement('button', 'Confirm', Array.from(conf.children)[0],'',['confirm-btn']);
        confBtn.addEventListener('click', confirmHandler);
        let cancelBtn = generateElement('button', 'Cancel', Array.from(conf.children)[0],'',['cancel-btn']);
        cancelBtn.addEventListener('click', cancelHandler)
    }

    function confirmHandler() {
        Array.from(conf.children)[0].remove();
        nextBtn.disabled = false;
        res.textContent = 'Confirmed.';
        res.classList.add('reservation-confirmed')
    }

    function cancelHandler() {
        Array.from(conf.children)[0].remove();
        nextBtn.disabled = false;
        res.textContent = 'Cancelled.';
        res.classList.add('reservation-cancelled')
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