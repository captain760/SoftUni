function loadCommits() {
    const inputName = document.getElementById("username").value;	
	const repo = document.getElementById("repo").value;
	const commits = document.getElementById("commits");
	let address = "https://api.github.com/repos/"+inputName+"/"+repo+"/commits";
	repo.value = '';
	inputName.value = '';
    commits.textContent = '';
	fetch(address)
		.then(res=>{
            if (!res.ok) {
                throw (res.status);
            }
            return res.json();
        })
		.then(data=>{
			data.forEach((lnk) => {					
				let newLi = document.createElement("li");
				
				newLi.textContent = `${lnk.commit.author.name}: ${lnk.commit.message}`;
				
				commits.appendChild(newLi)			
			});
		})
		.catch((e)=>{
			let newLi = document.createElement("li");
			newLi.textContent = `Error: ${e} (Not Found)`;
            commits.appendChild(newLi);
		})
}