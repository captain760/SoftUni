function addItem() {
    const sec = document.getElementById('menu')
    const txt = document.getElementById('newItemText');
    const val = document.getElementById('newItemValue');
    const opt = document.createElement("option");
    opt.textContent = txt.value;
    opt.value = val.value;
    sec.appendChild(opt);
    txt.value = "";
    val.value = "";
}