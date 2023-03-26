function loadRepos() {
   const resDiv = document.getElementById("res");
   fetch("https://api.github.com/users/testnakov/repos")
      .then((rep)=>rep.text())
      .then((text)=>{
         resDiv.textContent = text;
      })
      .catch((e)=>console.error(e))
}