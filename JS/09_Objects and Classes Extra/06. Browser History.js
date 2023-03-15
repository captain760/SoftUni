function solve(obj,arr) {
    let browser = {};
   for (const op of arr) {     
    let [action, tab] = op.split(" ");
    const parser = {
        openTab() {
            obj["Open Tabs"].push(tab);
            obj["Browser Logs"].push(tab);
        },
        closeTab(){
            if (obj["Open Tabs"])
        },
        clearHistory() {

        }
    }
    }
}


solve({"Browser Name":"Google Chrome","Open Tabs":["Facebook","YouTube","Google Translate"],
"Recently Closed":["Yahoo","Gmail"],
"Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]},
["Close Facebook", "Open StackOverFlow", "Open Google"]
)