function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/messenger';
    const refreshBtn = document.getElementById('refresh');
    const sendBtn = document.getElementById('submit');
    let auth = document.querySelector('input[name="author"]');
    let cont = document.querySelector('input[name="content"]');
    const txtArea = document.getElementById('messages');

    sendBtn.addEventListener('click', postMsg);
    function postMsg() {
        let newObj = {};
        newObj.author = auth.value;
        newObj.content = cont.value;
        fetch(BASE_URL,{
            method: 'POST',
            headers:{'Accept': 'application/json',
                     'Content-Type': 'application/json'
                    },
            body: JSON.stringify(newObj)
        });
    }
    refreshBtn.addEventListener('click', refreshTxt);

    function refreshTxt() {
        fetch(BASE_URL)
        .then(res=>{
            if(!res.ok){
                throw (res.status)
            }
            return res.json();
        })
        .then(data=>{
            let allMsg = '';
            for (const msg in data) {                
                allMsg+=data[msg].author+': '+data[msg].content+'\n';
            }
            txtArea.textContent = allMsg.trim();
        })
        .catch(e=>{
            console.log(e.message)
        })
    }
}

attachEvents();