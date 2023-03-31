function encodeAndDecodeMessages() {
    const btns = Array.from(document.getElementsByTagName('button'));
    const msgs = Array.from(document.getElementsByTagName('textarea'));
    btns[0].addEventListener('click',encode);
    btns[1].addEventListener('click',decode);
    
    function encode() {
        const inmsg = msgs[0].value;       
        let element = '';
        for (let i = 0; i < inmsg.length; i++) {
            element += String.fromCharCode(inmsg.charCodeAt(i)+1);            
        }
        msgs[1].value = element;
        msgs[0].value = '';
    }

    function decode() {
        const inmsg = msgs[1].value;       
        let element = '';
        for (let i = 0; i < inmsg.length; i++) {
            element += String.fromCharCode(inmsg.charCodeAt(i)-1);            
        }
        msgs[1].value = element;
        
    }
}