function openOrSenior(data){
    let res = [];
    for (const tuple of data) {
        
      let age = Number(tuple[0]);
      let hc = Number(tuple[1]);
      
            let str='Open';
            if (age>=55 && hc>7) {str='Senior'}
        res.push(str)
    }
    return res
  }

  console.log(openOrSenior([[45, 12],[55,21],[19, -2],[104, 20]]))