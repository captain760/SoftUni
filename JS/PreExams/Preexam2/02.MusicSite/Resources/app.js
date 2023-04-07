window.addEventListener('load', solve);

function solve() {
    
    let total = 0;
    const songState = {
        genre: null,
        songName: null,
        author: null,
        songDate: null,
    };
    
      const inputDOM = {
        genre: document.getElementById('genre'),
        songName: document.getElementById('name'),
        author: document.getElementById('author'),
        songDate: document.getElementById('date'),       
      };
    
      
        const addBtn = document.getElementById('add-btn');
        const allSongs = document.querySelector('#all-hits>div');
        const savedSongs = document.querySelector('#saved-hits>div');
        const totalLikes = document.querySelector('#total-likes>div>p');

       
      
    
      addBtn.addEventListener('click', addSongHandler);
    
      function addSongHandler(e) {
        e.preventDefault();
        const allFieldsHaveValue = Object.values(inputDOM)
          .every((input) => input.value !== '');
        if(!allFieldsHaveValue) {
          return;
        }
        
        let hitsDiv = generateElement('div','',allSongs, '', ['hits-info']);
        generateElement('img','',hitsDiv, '', '', {src: './static/img/img.png'});
        generateElement('h2', `Genre: ${inputDOM.genre.value}`, hitsDiv);
        generateElement('h2', `Name: ${inputDOM.songName.value}`, hitsDiv);
        generateElement('h2', `Author: ${inputDOM.author.value}`, hitsDiv);
        generateElement('h3', `Date: ${inputDOM.songDate.value}`, hitsDiv);
        const saveBtn = generateElement('button', 'Save song', hitsDiv, '', ['save-btn']);        
        const likeBtn = generateElement('button', 'Like song', hitsDiv, '', ['like-btn']);        
        const deleteBtn = generateElement('button', 'Delete', hitsDiv, '', ['delete-btn']);
        songState.genre = inputDOM.genre.value;
        songState.songName = inputDOM.songName.value;
        songState.author = inputDOM.author.value;
        songState.songDate = inputDOM.songDate.value;

        for (const field of Object.values(inputDOM)) {
            field.value = null;
        }
        

        saveBtn.addEventListener('click', saveHandler);
        likeBtn.addEventListener('click', likeHandler);
        deleteBtn.addEventListener('click', deleteHandler);
    }

    function saveHandler() {
        let hitsDiv = generateElement('div','',savedSongs, '', ['hits-info']);
        generateElement('img','',hitsDiv, '', '', {src: './static/img/img.png'});
        generateElement('h2', Array.from(this.parentNode.children)[1].textContent, hitsDiv);
        generateElement('h2', Array.from(this.parentNode.children)[2].textContent, hitsDiv);
        generateElement('h2', Array.from(this.parentNode.children)[3].textContent, hitsDiv);
        generateElement('h3', Array.from(this.parentNode.children)[4].textContent, hitsDiv);
        const deleteBtnS = generateElement('button', 'Delete', hitsDiv, '', ['delete-btn']);
        this.parentNode.remove();
        deleteBtnS.addEventListener('click', deleteHandler);
    }

    function likeHandler() {
      total++;
      totalLikes.textContent = `Total Likes: ${total}`;
      this.disabled = true;
    }

    function deleteHandler(e) {
      this.parentNode.remove(); 
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