function attachEventsListeners() {
const daysBtn = document.getElementById('daysBtn');
daysBtn.addEventListener('click', convert);
const hoursBtn = document.getElementById('hoursBtn');
hoursBtn.addEventListener('click', convert);
const minutesBtn = document.getElementById('minutesBtn');
minutesBtn.addEventListener('click', convert);
const secondsBtn = document.getElementById('secondsBtn');
secondsBtn.addEventListener('click', convert);

function convert() {
    const days = document.getElementById('days');
    const hours = document.getElementById('hours');
    const minutes = document.getElementById('minutes');
    const seconds = document.getElementById('seconds');
    if(days.value){
        hours.value = 24*days.value;
        minutes.value = 1440*days.value;
        seconds.value = 86400*days.value;
    }else
    if(hours.value){
        days.value = +hours.value/24;
        minutes.value = 60*hours.value;
        seconds.value = 3600*hours.value;
    }else
    if(minutes.value){
        hours.value = +minutes.value/60;
        days.value = +minutes.value/1440;
        seconds.value = 60*minutes.value;
    }else
    if(seconds.value){
        hours.value = +seconds.value/3600;
        minutes.value = +seconds.value/60;
        days.value = +seconds.value/86400;
    }
}
    
}