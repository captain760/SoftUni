function colorize() {
   const allRows = Array.from(document.getElementsByTagName('tr'));
   for (let i = 1; i < allRows.length; i+=2) {
    let currRow = allRows[i];
    currRow.setAttribute("style", "background-color:teal");
    }   
}