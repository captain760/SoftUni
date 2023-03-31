function solve() {
  const text = document.getElementById('text');
  const conv = document.getElementById('naming-convention');
  const res = document.getElementById('result');
  const textArr = text.value.toLowerCase().split(' ');

  if (conv.value === "Camel Case") {
    res.textContent = camelCase(textArr);
  }else if (conv.value === "Pascal Case"){
    res.textContent = pascalCase(textArr);
  } else{
    res.textContent = 'Error!'
  }

  function camelCase(arr){
    let output = '';
    let isFirst = true;
    for (const word of arr) {
      if(!isFirst)
      output+=word.charAt(0).toUpperCase() + word.substring(1);
      else{
      output = word;
      isFirst = false;
      }
    }
    
    return output;
  }
  function pascalCase(arr){
    let output = '';
    for (const word of arr) {
      output+=word.charAt(0).toUpperCase() + word.substring(1);
    }
    return output;
  }
}