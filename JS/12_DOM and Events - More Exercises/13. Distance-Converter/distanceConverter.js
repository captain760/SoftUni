function attachEventsListeners() {
    const btn = document.getElementById('convert');
    btn.addEventListener('click', convert);

    function convert() {
        const inNum = Number(document.getElementById('inputDistance').value);
        const outTag = document.getElementById('outputDistance');
        const convFromInd = document.getElementById('inputUnits').selectedIndex;
        const convToInd = document.getElementById('outputUnits').selectedIndex;
        let convToMtrs = [1000, 1, 0.01, 0.001, 1609.34, 0.9144, 0.3048, 0.0254];
        let mtrs = inNum*convToMtrs[convFromInd];
        let outNum = mtrs/convToMtrs[convToInd];
        outTag.value = outNum;
    }
}