function addItem() {
    const ulItem = document.getElementById('items');
    const input = document.getElementById('newItemText');
    let newLi = document.createElement('li');
    let newA = document.createElement('a');
    newA.textContent = "[Delete]";
    newA.setAttribute('href','#')
    newLi.textContent = input.value;
    newA.addEventListener('click', deleteElement)
    newLi.appendChild(newA)
    ulItem.appendChild(newLi);
    input.value= "";
    
    function deleteElement(e){
        let currentLi = e.currentTarget.parentElement;
        currentLi.remove();
    }
}