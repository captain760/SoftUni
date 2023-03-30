function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/phonebook/';
    const list = document.getElementById('phonebook');
    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');
    const person = document.getElementById('person');
    const phone = document.getElementById('phone');

    loadBtn.addEventListener('click',loadPhones);
    createBtn.addEventListener('click', postObj);

    async function loadPhones() {
        list.replaceChildren();
        let phonebook = await fetch(BASE_URL)
        .then(res=>{
            if (!res.ok) throw(res.status);
            return res.json();
        })
        .catch(e=>{
            console.log(e.message)
        })
        let data = Object.values(phonebook)
        for (const key in data) {            
            
          let liElm = generateElement('li',data[key].person+': '+data[key].phone,list );
          let delBtn = generateElement('button','Delete',liElm,data[key]._id);
          delBtn.addEventListener('click',deleteObj);
      }
        
        
    }

    async function postObj() {
        let newObj = {};
        newObj.person = person.value;
        newObj.phone = phone.value;
        await fetch(BASE_URL,{
            method: 'POST',
            headers:{'Accept': 'application/json',
                     'Content-Type': 'application/json'
                    },
            body: JSON.stringify(newObj)
        });
        person.value = "";
        phone.value = "";
        loadPhones();
    }
    async function deleteObj() {
        await fetch(BASE_URL+this.id,{
            method: 'DELETE',
        })
        .then(loadPhones)
        .catch((e)=>console.log(e.message));        
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
attachEvents();