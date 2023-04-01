function solve() {
    let complexity = 9;
    let controlSum = 0;
    for (let i = 1; i <= complexity; i++) {
        controlSum += i;    
    }
    let rows = Array.from(Array.from(document.getElementsByTagName('tbody'))[0].children)
    let btns = Array.from(document.getElementsByTagName('button'));
    let tbl = Array.from(document.getElementsByTagName('table'))[0];
    let par = document.querySelector('#check > p')
    btns[0].addEventListener('click', check);
    btns[1].addEventListener('click', clear);
    
    function check() {
        let matrix = [];
        for (let i = 0; i < complexity; i++) {
            matrix[i] = []
            for (let j = 0; j < complexity; j++) {
                matrix[i][j] =Number(rows[i].children[j].children[0].value)
            }    
        }
        let isSolved = true;
        for (let i = 0; i < complexity; i++) {
            let sum = 0;
            for (let j = 0; j < complexity; j++) {
                sum+=matrix[i][j];            
            }
            if (sum!==controlSum) {
                isSolved = false;
            }
        }
        for (let i = 0; i < complexity; i++) {
            let sum = 0;
            for (let j = 0; j < complexity; j++) {
                sum+=matrix[j][i];            
            }
            if (sum!==controlSum) {
                isSolved = false;
            }
        }
        if (isSolved) {
            tbl.style.border = '2px solid green';
            par.textContent = 'You solve it! Congratulations!'
            par.style.color = 'green';
        } else{
            tbl.style.border = '2px solid red';
            par.textContent = 'NOP! You are not done yet...'
            par.style.color = 'red';
        }
    }
    
    function clear() {
        for (let i = 0; i < complexity; i++) {
            for (let j = 0; j < complexity; j++) {
               rows[i].children[j].children[0].value = ''
            }    
        }
        tbl.style.border = 'none';
            par.textContent = '';        
    }
    
    }