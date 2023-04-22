function courses() {
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';
    const loadAllBtn = document.getElementById('load-course');
    const addBtn = document.getElementById('add-course');
    const editBtn = document.getElementById('edit-course');

     const addTitle = document.getElementById('course-name');
     const addType = document.getElementById('course-type');
    const addDescr = document.getElementById('description');
    const addTeacher = document.getElementById('teacher-name');

    const coursesList = document.getElementById('list');
    let allCourses = [];
    let id = null;
    let currCourse = {
        title: null,
        type: null,
        description: null,
        teacher: null,
        _id: null
       }
    loadAllBtn.addEventListener('click', loadAll);
    addBtn.addEventListener('click', addCourse);
    editBtn.addEventListener('click', editCourse);



    async function loadAll(e) {
        if (e) {e.preventDefault()};
        currCourse = {
            title: null,
            type: null,
            description: null,
            teacher: null,
            _id: null
         }
        coursesList.innerHTML = '';
        let res = await fetch(BASE_URL);
        let data = await res.json();
        for (const course of Object.values(data)) {
            
            let div = generateElement('div', '',coursesList, course._id,['container']);
            generateElement('h2', course.title, div);
            generateElement('h3', course.teacher, div);
            generateElement('h3', course.type, div);
            generateElement('h4', course.description, div);
            let editBtn = generateElement('button', 'Edit Course', div, '',['edit-btn']);
            let finishBtn = generateElement('button', 'Finish Course', div, '',['finish-btn']);
            let title = course.title;
            let description = course.description;
            let type = course.type;
            let teacher = course.teacher;
            let _id = course._id;
            currCourse[_id] = {title: title, description: description, type: type, teacher: teacher, _id: _id};
            allCourses.push(currCourse[_id]);
            
            editBtn.addEventListener('click', edit);
            finishBtn.addEventListener('click', finish);
        }
    }

    async function addCourse() {
      let newCourse = {};
      newCourse.title = addTitle.value;
      newCourse.description = addDescr.value;
      newCourse.type = addType.value;      
      newCourse.teacher = addTeacher.value;      
      handler = {method: 'POST',
                 body: JSON.stringify(newCourse)};
      await fetch(BASE_URL, handler);

      addTitle.value = '';
      addDescr.value = '';
      addType.value = '';
      addTeacher.value = '';

      loadAll();
    }

    async function edit() {
        id = this.parentNode.id;
        currCourse = allCourses.find(x=>x._id ===id);
    //     let courseObj = {};
    // courseObj.title = currCourse.title;
    // courseObj.type = currCourse.type;
    // courseObj.teacher = currCourse.teacher;
    // courseObj.description = currCourse.description;
    // courseObj._id = currCourse._id;
    addTitle.value = currCourse.title;
    addType.value = currCourse.type;
    addTeacher.value = currCourse.teacher;
    addDescr.value = currCourse.description;
    this.parentNode.remove();
    addBtn.disabled = true;
    editBtn.disabled = false;
    
    
    }

async function editCourse() {
    let courseObj = {};
    courseObj.title = addTitle.value;
    courseObj.type = addType.value;
    courseObj.teacher = addTeacher.value;
    courseObj.description = addDescr.value;
    courseObj._id = id;
    let handler = {method: 'PUT', body: JSON.stringify(courseObj)}
    let res = await fetch(`${BASE_URL}${id}`, handler);
    
    addTitle.value = '';
    addType.value = '';
    addTeacher.value = '';
    addDescr.value = '';
    addBtn.disabled = false;
    editBtn.disabled = true;
    loadAll();

}

    async function finish() {
        let idDel = this.parentNode.id;
    let handler = {method: 'DELETE'};
    let res = await fetch(`${BASE_URL}${idDel}`, handler);
    loadAll()
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

  courses();