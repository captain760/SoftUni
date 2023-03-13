function solve(arr) {
    let movies = [];
    for (const str of arr) {    
        let movie = {};
    if(str.split(" ")[0] === "addMovie"){
        let movieName = str.substr(9);
        movie.name = movieName;
        movies.push(movie)
    } else if (str.split(" directedBy ").length >1){
        let [movieName, director] = str.split(" directedBy ");
        for (const iterator of movies) {
            if (iterator.name === movieName){
                iterator.director = director;
            }
        }                    
    } else{
        let [movieName, date] = str.split(" onDate ");
        for (const iterator of movies) {
            if (iterator.name === movieName){
                iterator.date = date;
            }
        }    
    }
    }
    for (const iterator of movies) {
        if (iterator.name && iterator.director && iterator.date){
        let json = JSON.stringify(iterator);
        console.log(json)
        }        
    }
}

solve([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]
    )