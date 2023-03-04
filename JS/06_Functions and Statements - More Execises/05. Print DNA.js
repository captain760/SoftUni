function solve(n) {
    let counter = 0;
    let first = true;
    let sequence = ['A','T','C','G','T','T','A','G','G','G'];
    for (let i = 1; i <= n; i++) {
        
        if(i%2===0){
            console.log(`*${writeGene()}--${writeGene()}*`);
            continue;
        }
        if(first){
            console.log(`**${writeGene()}${writeGene()}**`);
            first = false;
            continue;
        }else{
            console.log(`${writeGene()}----${writeGene()}`);
            first = true;
            continue;
        }
        
    }
    function writeGene(){
        let current =  sequence[counter];
        counter++;
        if(counter ===10){
            counter=0;
        }
        return current
    }
}
solve(10)