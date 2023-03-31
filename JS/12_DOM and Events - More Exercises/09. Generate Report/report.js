function generateReport() {
    const output = document.getElementById('output');
    const inputs = Array.from(document.querySelectorAll('th>input'));
    let selected = [];
    let selIndex = [];

    for (const col of inputs) {
        selIndex.push(col.name)
        if (col.checked){
            selected.push(col.name)
        }
    }
    let data = Array.from(document.getElementsByTagName('tbody'))[0];
    let outputObj = [];
    
    for (const row of Array.from(data.children)) {
        let currObj = {}      
          
        for (const key of selected) {      
            
            currObj[key] = row.children[selIndex.indexOf(key)].textContent;
            
        }
        outputObj.push(currObj)
    }
    output.textContent = JSON.stringify(outputObj)
}