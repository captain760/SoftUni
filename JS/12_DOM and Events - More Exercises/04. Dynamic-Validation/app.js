function validate() {
    const email = document.getElementById('email');
    const template = /[a-z]+@[a-z]+\.[a-z]+/;
    email.addEventListener('change', checkMail);

    function checkMail() {       
        if (email.value.match(template)===null){
            email.classList.add('error'); 
                    
        }else{
            email.classList.remove('error');
        }        
    }
}