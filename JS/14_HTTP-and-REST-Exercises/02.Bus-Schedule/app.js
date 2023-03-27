function solve() {
    function depart() {
        const depart = document.getElementById('depart');
        const arrive = document.getElementById('arrive');
        const info = document.querySelector('#info>span');   
        const BASE_URL= 'http://localhost:3030/jsonstore/bus/schedule';
        let adr = BASE_URL
        
        if(depart.disabled === false){
            if (info.textContent === 'Not Connected'){
                info.textContent = `Next stop Depot`;
                depart.disabled = true;
                arrive.disabled = false;           
            }else{
                let thisStopName = info.textContent.split('Arriving at ')[1].trim();
                let nextStopId = '';
                fetch (adr)
                    .then(res =>{
                        if(res.status!==200)throw('Error')
                        return res.json();
                    })
                    .then(data=>{                        
                        for (const key in data) {                            
                            if (data[key].name === thisStopName){                                
                                nextStopId = data[key].next;
                                break;
                            }
                        };                                  
                        info.textContent = `Next stop ${data[nextStopId].name}`;                        
                        depart.disabled = true;
                        arrive.disabled = false;                        
                    })
                    .catch(e=>{
                        info.textContent = e.message
                        depart.disabled = true;
                        arrive.disabled = true;
                    })        
            }
        }
    }

    async function arrive() {
        const arrive = document.getElementById('arrive');
        const info = document.querySelector('#info>span');  
        const depart = document.getElementById('depart');
        if(arrive.disabled === false){
            let nextStopName = info.textContent.split('Next stop ')[1].trim();
            info.textContent = `Arriving at ${nextStopName}`;
            depart.disabled = false;
            arrive.disabled = true;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();