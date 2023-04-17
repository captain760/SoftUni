function solve(input) {
    let shelves = {};
    for (const line of input) {
        let lineArr = line.split(' -> ');
        if (lineArr.length>1){
            let shelfId = lineArr[0];
            let shelfGenre = lineArr[1];
            if(!shelves.hasOwnProperty(shelfId)){
                shelves[shelfId] = {};
                shelves[shelfId].genre = shelfGenre;
                shelves[shelfId].books = [];
            }

        }else{
            lineArr = line.split(': ');
            let bookTitle = lineArr.shift();
            let bookInfoArr = lineArr[0].split(", ");
            let bookAuthor = bookInfoArr[0];        
            let bookGenre = bookInfoArr[1];   
            for (const shelf in shelves) {
                
                if (shelves[shelf].genre === bookGenre){
                    shelves[shelf].books.push({title: bookTitle, author: bookAuthor})
                }
            }
        }
    }
   let shelvesArr = Object.entries(shelves);
   let sortedShelves = shelvesArr.sort((a,b)=>b[1].books.length - a[1].books.length);
   for (const shelf of sortedShelves) {
    
    console.log(`${shelf[0]} ${shelf[1].genre}: ${shelf[1].books.length}`);
    let booksArr = Object.values(shelf[1].books);
    for (const book of booksArr) {
        console.log(`--> ${book.title}: ${book.author}`);
    }
   }
}

solve(['1 -> history', '1 -> action', 'Death in Time: Criss Bell, mystery', '2 -> mystery', '3 -> sci-fi', 'Child of Silver: Bruce Rich, mystery', 'Hurting Secrets: Dustin Bolt, action', 'Future of Dawn: Aiden Rose, sci-fi', 'Lions and Rats: Gabe Roads, history', '2 -> romance', 'Effect of the Void: Shay B, romance', 'Losing Dreams: Gail Starr, sci-fi', 'Name of Earth: Jo Bell, sci-fi', 'Pilots of Stone: Brook Jay, history'])