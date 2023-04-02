function solve() {
  let counter = 0;
  let answers = [];
  const quizDiv= document.getElementById('quizzie');
  const res= document.querySelector('#results>li>h1'); 
  const allAnswers = Array.from(document.querySelectorAll(".answer-text"));
  allAnswers.forEach(x=>x.addEventListener('click', check));

  function check(){
    if (counter === 0){
      if (this.textContent ==="onclick") {
        answers.push(true);
      }else {
        answers.push(false);        
      }
  
      quizDiv.children[1].style.display = 'none';
      quizDiv.children[2].style.display = 'block';
      
      counter++;
    } else if (counter === 1){
      if(this.textContent ==="JSON.stringify()"){
        answers.push(true);
      }else {
        answers.push(false);
      }
 
      quizDiv.children[2].style.display = 'none';
      quizDiv.children[3].style.display = 'block';
      
      counter++;
    } else if (counter === 2){
      if(this.textContent ==="A programming API for HTML and XML documents"){
        answers.push(true);
      }else {
        answers.push(false);
      }
      
      quizDiv.children[3].style.display = 'none';
      res.parentNode.parentNode.style.display = 'block';

        if (answers.includes(false)) {
        let correct = 0;
        answers.forEach(x=>{if (x) correct++});       
        let resText = `You have ${correct} right answers`
        res.textContent = resText;
       }else {
        let resText = "You are recognized as top JavaScript fan!"
        res.textContent = resText;
      }
    }    
  }
}
