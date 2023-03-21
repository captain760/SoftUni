function deleteByEmail() {
    const inputField = document.getElementsByName("email")[0];
    const result = document.getElementById('result');
    const allMails = Array.from(document.querySelectorAll('td:nth-child(even)'));
    if (allMails.find((x)=>x.textContent===inputField.value)){
        let index = allMails.findIndex((x)=>x.textContent===inputField.value);
        allMails[index].parentElement.remove();
        result.textContent = "Deleted";
    }else{
        result.textContent = "Not found.";
    }
}