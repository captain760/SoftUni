function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);
 
    function onClick() {
       const textArea = document.querySelector('#inputs > textarea').value;
       const restaurantPara = document.querySelector('#bestRestaurant > p');
       const workersPara = document.querySelector('#workers > p');
       let restaurants = {};
 
       for (const restaurant of JSON.parse(textArea)) {
          let restaurantInfo = restaurant.split(' - ');
          let restaurantName = restaurantInfo[0];
          let workers = restaurantInfo[1].split(', ');
          if (!restaurants.hasOwnProperty(restaurantName)) {
             restaurants[restaurantName] = {};
             restaurants[restaurantName].workers = [];
             restaurants[restaurantName].bestSalary = 0;
             restaurants[restaurantName].avgSalary = 0;
             restaurants[restaurantName].sumAllSalaries = 0;
          }
 
          for (const worker of workers) {
             let workerName = worker.split(' ')[0];
             let workerSalary = Number(worker.split(' ')[1]);
             restaurants[restaurantName].workers.push({ name: workerName, salary: workerSalary });
             if (workerSalary > restaurants[restaurantName].bestSalary) {
                restaurants[restaurantName].bestSalary = workerSalary;
             }
             restaurants[restaurantName].sumAllSalaries += workerSalary;
 
          }
          restaurants[restaurantName].avgSalary = restaurants[restaurantName].sumAllSalaries / restaurants[restaurantName].workers.length;
 
       }
       console.log(restaurants);
       let bestRestaurant = (Object.entries(restaurants).sort((a, b) => b[1].avgSalary - a[1].avgSalary))[0];
console.log(bestRestaurant);
       restaurantPara.textContent += `Name: ${bestRestaurant[0]} Average Salary: ${bestRestaurant[1].avgSalary.toFixed(2)} Best Salary: ${bestRestaurant[1].bestSalary.toFixed(2)}`;
       let bestRestaurantWorkers = Object.entries(bestRestaurant[1])[0][1];
      console.log(bestRestaurantWorkers);
       for (const { name, salary } of bestRestaurantWorkers.sort((a, b) => b.salary - a.salary)) {
          workersPara.textContent += `Name: ${name} With Salary: ${salary} `;
       }
 
    }
 }