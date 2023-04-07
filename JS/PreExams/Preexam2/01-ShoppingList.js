function shoppigList(input) {
    let list = input.shift().split('!');
    cmdParser = {
        'Urgent': urgent,
        'Unnecessary':unnecessary,
        'Correct': correct,
        'Rearrange': rearrange
    }

    for (const line of input) {
        if (line==="Go Shopping!") {
            break;
        }
        let cmdToken = line.split(' ');
        let cmd = cmdToken[0];
        cmdParser[cmd](...cmdToken.slice(1))
    }
        console.log(list.join(', '));

        function urgent(item) {
            if (!list.includes(item)) {
                list.unshift(item)
            }
        }

        function unnecessary(item) {
            if (list.includes(item)) {
                let index = list.indexOf(item)
                list.splice(index,1);
            }
        }

        function correct(oldItem,newItem) {
            if (list.includes(oldItem)) {
                let index = list.indexOf(oldItem);                
                list.splice(index,1,newItem);
            }
        }

        function rearrange(item) {

            if (list.includes(item)) {
                let index = list.indexOf(item)
                list.push(list.splice(index,1)[0]);

            }
        }
}

shoppigList(["Milk!Pepper!Salt!Water!Banana",
"Urgent Himal",
"Urgent Salt",
"Unnecessary Milk",
"Unnecessary Goat",
"Correct Pepper Onion",
"Rearrange Water",
"Rearrange Pater",
"Correct Water1 Potatoes",
"Go Shopping!"])
