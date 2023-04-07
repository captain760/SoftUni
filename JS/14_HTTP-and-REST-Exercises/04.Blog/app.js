function attachEvents() {
   const BASE_URL = 'http://localhost:3030/jsonstore/blog/'
   const btnPosts = document.getElementById('btnLoadPosts');
   const btnViewPost = document.getElementById('btnViewPost');
   const sel = document.getElementById('posts');
   const heading = document.getElementById('post-title');
   const body = document.getElementById('post-body');
   const list = document.getElementById('post-comments');

   btnPosts.addEventListener('click', addPost);
   async function addPost() {
    
    let res = await fetch(BASE_URL+'posts')
        let res2 = await res.json();
        let data = Object.values(res2)
        for (const obj of data) {         
          let opt = document.createElement('option');
          opt.value = obj.id;
          opt.textContent = obj.title;
          sel.appendChild(opt);
      }
   };
   btnViewPost.addEventListener('click', viewPost);

   async function viewPost(){    
        let post = await fetch(BASE_URL+'comments')
        let res = await post.json();
        let data = Object.values(res);
        
        let selKey = sel.value;       
        let selObj = await getPostInfo(selKey);
        
        heading.textContent = '';
        body.textContent = '';
        list.innerHTML = '';

        heading.textContent = selObj.title;
        body.textContent = selObj.body;
        for (const key in data) {       
          
          if (data[key].postId === selObj.id){            
                generateElement('li',data[key].text,list,data[key].id)
            }
        }
   };  
   async function getPostInfo(k) {    
        let result = await fetch(BASE_URL+'posts')
        let res = await result.json();
        let data = Object.values(res);        
        let obj = data.find((x=>x.id === k));            
        return obj;   
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