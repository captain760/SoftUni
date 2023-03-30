async function attachEvents() {
  const BASE_URL = 'http://localhost:3030/jsonstore/collections/students/';
  const table = document.getElementById('results');
  const btn = document.getElementById('submit');
  const inputs = document.querySelector("div.inputs")
  await LoadStudents();  
  btn.addEventListener('click', postObj)
  

  async function LoadStudents() {
    table.children[1].replaceChildren();
    let data = await fetch(BASE_URL)
    .then(res=>{
      if (!res.ok) throw(res.status);
      return res.json();
  })
  .catch(e=>{
      console.log(e.message)
  })
    let allStudents =  Object.values(data);
    for (const student of allStudents) {
      let newTr = generateElement('tr','',table.children[1],student._id)
      generateElement('td',student.firstName, newTr);
      generateElement('td',student.lastName, newTr);
      generateElement('td',student.facultyNumber, newTr);
      generateElement('td',student.grade, newTr);
    }
  }

  async function postObj() {
    let newObj = {};
    newObj.firstName = inputs.children[0].value;
    newObj.lastName = inputs.children[1].value;
    newObj.facultyNumber = inputs.children[2].value;
    newObj.grade = inputs.children[3].value;
    
    await fetch(BASE_URL,{
        method: 'POST',
        headers:{'Accept': 'application/json',
                 'Content-Type': 'application/json'
                },
        body: JSON.stringify(newObj)
    });
    inputs.children[0].value = '';
    inputs.children[1].value = '';
    inputs.children[2].value = '';
    inputs.children[3].value = '';
    await LoadStudents();
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