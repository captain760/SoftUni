function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick(x) {
      let allTd = Array.from(document.querySelectorAll("tbody>tr>td"));  
      allTd.forEach((e) => {  
         e.parentElement.classList.remove('select');      
   })
      const srchText = document.getElementById("searchField");               
      allTd.forEach((e) => {         
         if (e.textContent.includes(srchText.value)){           
            e.parentElement.classList.add('select');
         }
      })
      srchText.value = "";
   }
}