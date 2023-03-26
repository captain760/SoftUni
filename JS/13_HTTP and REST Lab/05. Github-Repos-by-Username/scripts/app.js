function loadRepos() {
	const inputName = document.getElementById("username").value;	
	const repos = document.getElementById("repos");
	let address = "https://api.github.com/users/"+inputName+"/repos";
	repos.textContent = '';
	fetch(address)
		.then(res=>res.json())
		.then(data=>{
			data.forEach((lnk) => {			 
				console.log(lnk.full_name)
				let newLi = document.createElement("li");
				let newA = document.createElement("a");
				newA.textContent = lnk.full_name;
				newA.href = lnk.html_url;
				newLi.appendChild(newA);
				repos.appendChild(newLi)			
			});
		})
		.catch((e)=>{
			let newLi = document.createElement("li");
			newLi.textContent = e;
		})
}