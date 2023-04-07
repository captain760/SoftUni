async function lockedProfile() {
    const BASE_URL = 'http://localhost:3030/jsonstore/advanced/profiles/';
    const main = document.getElementById('main');
    await LoadProfiles();


    async function LoadProfiles() {
        
        main.replaceChildren();
        let data = await fetch(BASE_URL)
        .then(res=>{
          if (!res.ok) throw(res.status);
          return res.json();
      })
      .catch(e=>{
          console.log(e.message)
      })
      let userN =1;
        let allProfiles =  Object.values(data);
        for (const profile of allProfiles) {          
          let newDiv = generateElement('div','',main,'', ['profile']);
          generateElement('img','', newDiv, '',['userIcon'], {src:'./iconProfile2.png'});
          generateElement('label','Lock', newDiv);
          generateElement('input','', newDiv,'','',{type:'radio', name:`user${userN}Locked`, value: 'lock', checked: ''});
          generateElement('label','Unlock', newDiv);
          generateElement('input','', newDiv,'','',{type:'radio', name:`user${userN}Locked`, value: 'unlock'});
          generateElement('br','',newDiv);
          generateElement('hr','',newDiv);
          generateElement('label','Username', newDiv);
          generateElement('input','', newDiv,'','',{type:'text', name:`user${userN}Username`, value: profile.username, disabled: '', readonly: ''});
          let userInfo = generateElement('div', '', newDiv, `user${userN}HiddenFields`, '', {style: 'display:none'});
          //userInfo.style.display = 'none'
          generateElement('hr','',userInfo);
          generateElement('label','Email', userInfo);
          generateElement('input','', userInfo,'','',{type:'email', name:`user${userN}Email`, value: profile.email, disabled: '', readonly: ''});
          generateElement('label','Age', userInfo);
          generateElement('input','', userInfo,'','',{type:'email', name:`user${userN}Age`, value: profile.age, disabled: '', readonly: ''});
          generateElement('button', 'Show more', newDiv)
          userN++;
        }
        const showMore = Array.from(document.querySelectorAll('#main>div>button'));
        
        for (let i = 0; i < userN-1; i++) {
            showMore[i].addEventListener('click', show);            
        }

        function show() {
            const lock = this.parentNode.children[4];
            if (this.parentNode.children[10].textContent === 'Hide it' && lock.checked){
                this.parentNode.children[9].style.display = 'none';
                this.parentNode.children[10].textContent = 'Show more'
            }else if (lock.checked && this.parentNode.children[10].textContent === 'Show more'){
                this.parentNode.children[9].style.display = 'block';
                this.parentNode.children[10].textContent = 'Hide it'
            }
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