function solve(obj,arr) {    
   for (const op of arr) {     
    let [action, tab] = op.split(" ");
    action = action.toLowerCase();
    let parser = {
        open() {
            obj["Open Tabs"].push(tab);
            obj["Browser Logs"].push(op);
        },
        close(){
            if (obj["Open Tabs"].find(x=>x===tab)!==undefined){
                obj["Recently Closed"].push(tab);
                obj["Open Tabs"].splice(obj["Open Tabs"].indexOf(tab),1);
                obj["Browser Logs"].push(op);
            }
        },
        clear() {
            obj["Browser Logs"]=[];
            obj["Open Tabs"]=[];
            obj["Recently Closed"]=[];
        }
    };
    parser[action]();
    }
    console.log(`${obj["Browser Name"]}`);
    console.log(`Open Tabs: ${obj["Open Tabs"].join(", ")}`);
    console.log(`Recently Closed: ${obj["Recently Closed"].join(", ")}`);
    console.log(`Browser Logs: ${obj["Browser Logs"].join(", ")}`);

}


solve({"Browser Name":"Mozilla Firefox",
"Open Tabs":["YouTube"],
"Recently Closed":["Gmail", "Dropbox"],
"Browser Logs":["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]},
["Open Wikipedia", "Clear History and Cache", "Open Twitter"]

)