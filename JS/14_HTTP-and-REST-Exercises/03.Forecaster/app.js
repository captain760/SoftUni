function attachEvents() {
    
    const btnPressed = document.getElementById('submit');
    
    btnPressed.addEventListener('click',cli=>{ 
    
    const location = document.getElementById('location').value;   
    const forecast = document.getElementById('forecast');    
    const currentCond = document.getElementById('current');    
    const upcomingDiv = document.getElementById('upcoming');
    while (currentCond.childNodes.length > 1) {
        currentCond.removeChild(currentCond.lastChild);
    };
    while (upcomingDiv.childNodes.length > 1) {
        upcomingDiv.removeChild(upcomingDiv.lastChild);
    }
        
    const BASE_URL = 'http://localhost:3030/jsonstore/forecaster/';
    let locCode = '';
    fetch(BASE_URL+'locations/')
        .then(res=>{
            if (!res.ok){throw res.status};
            return res.json();
        })
        .then(data=>{
            for (const key of data) {
                if(key.name === location){
                    locCode = key.code;
                    break;
                }
            }
            if (locCode){
                let conSym = {
                    'Sunny': '\u2600',
                    'Partly sunny': '\u26C5',
                    'Overcast': '\u2601',
                    'Rain': '\u2614',
                    'Degrees': '\u00B0'
                };
                forecast.setAttribute('style','display:block');
                fetch(BASE_URL+'today/'+locCode)
                    .then(res=>{
                        if (!res.ok){throw res.status}
                        return res.json();
                    })
                    .then(data=>{
                        
                        let conText = data.forecast.condition;  
                        const newForDiv = generateElement('div','',currentCond, '',['forecasts']);
                        generateElement('span',conSym[conText],newForDiv, '',['condition','symbol']);
                        const newCond = generateElement('span', '',newForDiv,'',['condition']);
                        generateElement('span', data.name, newCond, '',['forecast-data']);
                        generateElement('span', data.forecast.low+conSym.Degrees+'/'+data.forecast.high+conSym.Degrees, newCond, '',['forecast-data']);
                        generateElement('span', conText, newCond, '',['forecast-data']);

                    })
                    .catch(e=>{
                        forecast.setAttribute('style','display:block');
                        forecast.textContent = 'Error';
                        
                    });
                fetch(BASE_URL+'upcoming/'+locCode)
                    .then(res=>{
                    if (!res.ok){throw res.status}
                    return res.json();
                    })
                    .then(data=>{
                        const newCont = generateElement('div','',upcomingDiv,'',['forecast-info']);
                        for (let i = 0; i < data.forecast.length; i++) {                            
                            const newSpanUpcoming = generateElement('span','',newCont,'',['upcoming']);
                            generateElement('span',conSym[data.forecast[i].condition],newSpanUpcoming,'',['symbol']);
                            generateElement('span',data.forecast[i].low+conSym.Degrees+'/'+data.forecast[i].high+conSym.Degrees,newSpanUpcoming,'',['forecast-data']);
                            generateElement('span',data.forecast[i].condition,newSpanUpcoming,'',['forecast-data']);                             
                        }
                    })
                    .catch(e=>{
                        forecast.setAttribute('style','display:block');
                        forecast.textContent = 'Error';
                        
                    });

            }


        })
        .catch(e=>{
            forecast.setAttribute('style','display:visible');
            forecast.textContent = 'Error'
        })
    })
}
function generateElement(type, content, parentNode, id, classes, attributes) {
  const element = document.createElement(type);
  if (content && type === 'input') {
    element.value = content;
  } 
  if (content && type !== 'input') {
    element.textContent = content;
  }
  if (id) {
    element.id = id;
  }
  //Array
  if (classes) {
    element.classList.add(...classes)
  }
  //Object
  if (attributes) {
    for (const key in attributes) {
      element.setAttribute(key, attributes[key])
    }
  }
  if (parentNode) {
    parentNode.appendChild(element);
  }
  return element;
}
attachEvents();