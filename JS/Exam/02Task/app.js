window.addEventListener('load', solve);

function solve() {
    let total = 0;
    let tasks = {};
    let i=0;
    let currId = '';
         
        let title= document.getElementById('title');
        let descr = document.getElementById('description');
        let lab = document.getElementById('label');
        let points = document.getElementById('points');       
        let assignee =  document.getElementById('assignee');     
        let hiddenId =  document.getElementById('task-id');     
      
    
      
        const createBtn = document.getElementById('create-task-btn');
        const delBtn = document.getElementById('delete-task-btn');
        const form = document.getElementById('create-task-form');
        const newTasks = document.getElementById('tasks-section')
        const totalP = document.getElementById('total-sprint-points')

       
      
    
      createBtn.addEventListener('click', addTaskHandler);
    
      function addTaskHandler(e) {
        e.preventDefault();
        if(title.value == ''
            || descr.value == ''
            || lab.value == ''
            ||points.value == ''
            || assignee.value == '')
        {
        return;
        }
        i++;

        tasks[`task-${i}`] = {title: title.value, description: descr.value, label: lab.value, points: points.value, assignee: assignee.value, id: i};
        hiddenId.value = `task-${i}`;
        let ar = generateElement('article','',newTasks, `task-${i}`, ['task-card']);
        let titleClass = 'feature';
        let feature = String.fromCharCode(8865);
        if (lab.value ==='Low Priority Bug'){titleClass = 'low-priority'; feature = String.fromCharCode(9737)}
        else if (lab.value ==='High Priority Bug'){titleClass = 'high-priority'; feature = String.fromCharCode(9888)}
        generateElement('div',lab.value+' '+feature, ar, '', ['task-card-label', titleClass]);
        generateElement('h3',title.value, ar, '', ['task-card-title']);
        generateElement('p',descr.value, ar,'',['task-card-description']);
        generateElement('div', `Estimated at ${points.value} pts`,ar,'',['task-card-points']);
        generateElement('div', `Assigned to: ${assignee.value}`,ar,'',['task-card-assignee']);
        let btns = generateElement('div','',ar,'',['task-card-actions']);
        let deleteBtn = generateElement('button', 'Delete', btns);
        total += Number(points.value);
        totalP.textContent = `Total Points ${total}pts`;
        form.reset();
        deleteBtn.addEventListener('click', deleteTaskHandler);
        
            
        function deleteTaskHandler() {
            currId = this.parentNode.parentNode.id;
            let currTask = tasks[currId];
            createBtn.disabled = true;
            
            title.disabled = true;
            descr.disabled = true;
            lab.disabled = true;
            points.disabled = true;
            assignee.disabled = true;     

            delBtn.disabled = false;
            title.value = currTask.title;
            descr.value = currTask.description;
            lab.value = currTask.label;
            points.value = currTask.points;
            assignee.value = currTask.assignee;
            hiddenId.value = currId;
            delBtn.addEventListener('click', deleteTask)
        }

        function deleteTask() {
            total-=Number(tasks[currId].points);
            totalP.textContent = `Total Points ${total}pts`
            delete tasks[currId];
            let currElement = document.getElementById(currId);
            currElement.remove();
            form.reset();
            title.disabled = false;
            descr.disabled = false;
            lab.disabled = false;
            points.disabled = false;
            assignee.disabled = false;
            createBtn.disabled = false;
            delBtn.disabled = true;

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