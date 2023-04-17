function solve(input){
    let users = [];
    let articles = [];
    let comments = {};
    for (const lineStr of input) {
        let line = lineStr.split(' ');
        if(line[0]==='user'){
            line.shift();
            users.push(line.join(' '));
        }else if (line[0]=== 'article'){
            line.shift();
            articles.push(line.join(' '));
        }else{            
            let sep = lineStr.split(': ');
            let user = sep[0].split(' posts on ')[0];
            let art = sep[0].split(' posts on ')[1];
            let title = sep[1].split(', ')[0];
            let comment = sep[1].split(', ')[1];
            if (articles.includes(art) && users.includes(user)){
                if(typeof comments[art]==='undefined') comments[art] = [];
                comments[art].push({user: user, title: title, comment: comment});
            }
        }
        
    }    
    let commentsArr = Object.entries(comments);
    let sortedComments = commentsArr.sort((a,b)=>b[1].length-a[1].length);
    for (const article of sortedComments) {
        console.log(`Comments on ${article[0]}`);
        
        let commArr = article[1];
        
        let sortedComm = commArr.sort((a,b)=>{return a.user.localeCompare(b.user)});
        for (const iterator of sortedComm) {
            console.log(`--- From user ${iterator.user}: ${iterator.title} - ${iterator.comment}`);
        }
    }
        
}


solve(['user aUser123', 'someUser posts on someArticle: NoTitle, stupidComment', 'article Books', 'article Movies', 'article Shopping', 'user someUser', 'user uSeR4', 'user lastUser', 'uSeR4 posts on Books: I like books, I do really like them', 'uSeR4 posts on Movies: I also like movies, I really do', 'someUser posts on Shopping: title, I go shopping every day', 'someUser posts on Movies: Like, I also like movies very much'])