function search() {
   const towns = document.getElementById('towns');
   const input = document.getElementById('searchText');
   const result = document.getElementById('result');
   const btn = Array.from(document.getElementsByTagName('button'))[0];
   result.textContent = '';
   for (const town of Array.from(towns.children)) {
      town.style.fontWeight = 'normal';
   }
   
   let counter = 0;
   for (const town of Array.from(towns.children)) {
      if (town.textContent.includes(input.value)){
         counter++;
         town.style.fontWeight = 'bold';
      }
   }
   result.textContent = `${counter} matches found`
}
