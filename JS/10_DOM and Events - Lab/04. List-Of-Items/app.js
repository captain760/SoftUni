function addItem() {
    const ulItems = document.getElementById("items");
    const input = document.getElementById("newItemText");
    const liElement = document.createElement("li")
    liElement.textContent = input.value;
    ulItems.appendChild(liElement);
    input.value = "";
}