function solve(arr) {
    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this. name = name;
            this.time = time;
        }
    }
    let n = arr[0];
    let songs = [];
    for (let i = 1; i <= n; i++) {
        let [type, name, time] = arr[i].split("_")
        songs.push(new Song(type, name, time));
    }
    if (arr[arr.length-1]==="all"){
        for (const song of songs) {
            console.log(`${song.name}`);
        }
    } else {
        let category = arr[arr.length-1];
        for (const song of songs) {
            if (song.typeList === category){
                console.log(`${song.name}`);
            }
        }
    }
}
solve([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
    
    )