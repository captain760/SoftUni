function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
     const arrStr = Array.from(document.getElementsByTagName('textarea'))[0].value;   
      let restStr = JSON.parse(arrStr);
      let restObj ={};
      let average = {}
      for (const rest of restStr) {        
         let restArr= rest.split(" - ");
         let restName = restArr[0];         
         restObj[restName] = {};
         let restWorkersStr = restArr[1];
         let restWorkers = restWorkersStr.split(', ');
         for (const worker of restWorkers) {
            let[workName, workerSalary] = worker.split(' ');
            let workSalary = Number(workerSalary);            
            restObj[restName][workName] = workSalary;
         }
      }
      console.log(restObj);
      for (const rest in restObj) {
         let salSum = 0;
         counter = 0;
         for (const worker in restObj[rest]) {
            
            salSum+=restObj[rest][worker];
            counter++;
         }
         average[rest] = salSum/counter;
      }
      let tuples = [];
      for (const key in average) {
         tuples.push([key,average[key]]);
      };
      tuples.sort((a,b)=>{
         let result = b[1]-a[1];
         if (result===0) {
            return -1;
         }
         return result;
      })
      let bestRest = tuples[0][0];
      let bestAvg = tuples[0][1];
      let bestSal = 0;
      for (const key in restObj[bestRest]) {
         if (restObj[bestRest][key]>bestSal) {
            bestSal = restObj[bestRest][key];            
         }
      }
      let bestRestText = Array.from(document.querySelectorAll('#bestRestaurant>p'))[0];
      let bestWorkers = Array.from(document.querySelectorAll('#workers>p'))[0];
      bestRestText.textContent = `Name: ${bestRest} Average Salary: ${bestAvg.toFixed(2)} Best Salary: ${bestSal.toFixed(2)} `;
      let workOutput = '';
      let workTuples = [];
      for (const key in restObj[bestRest]) {
         workTuples.push([key,restObj[bestRest][key]]);
      };
      workTuples.sort((a,b)=> b[1]-a[1]);
         
      
      for (const key in workTuples) {
         workOutput+=`Name: ${workTuples[key][0]} With Salary: ${workTuples[key][1]} `
      }
      bestWorkers.textContent = workOutput;
   }
}