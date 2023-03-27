function getInfo() {
   const result = document.getElementById('result');
   const stopName = document.getElementById('stopName');
   const buses = document.getElementById('buses');
   const stopId = document.getElementById('stopId').value;
   let address = 'http://localhost:3030/jsonstore/bus/businfo/'+stopId;
   buses.replaceChildren();
   fetch(address)
    .then(res=>{
        if(res.status!==200) throw ("Error");
        return res.json();
    })
    .then(data=>{
        stopName.textContent = data.name;        
        for (const bus in data.buses) {
            let newLi = document.createElement('li');
            newLi.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`
            buses.appendChild(newLi)
        }        
    })
    .catch(e=>{
        stopName.textContent = 'Error';        
    })
}