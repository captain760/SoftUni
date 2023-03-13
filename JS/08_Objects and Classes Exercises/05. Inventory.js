function solve(arr) {
 
    let heroes = [];
    for (const iterator of arr) {
        let currentHero = {}
        let [heroName, heroLevel, heroItems] = iterator.split(" / ");
        currentHero.hero = heroName;
        currentHero.level = +heroLevel;
        currentHero.items = heroItems.split(", ");
        heroes.push(currentHero);
    }
    let sorted = heroes.sort((a,b)=> a.level - b.level);
    for (const hero of sorted) {
        console.log(`Hero: ${hero.hero}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(", ")}`);
    }
}
solve([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
)