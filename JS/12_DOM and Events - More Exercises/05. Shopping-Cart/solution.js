function solve() {
  const checoutBtn = document.querySelector('button.checkout');
  const addBtn = Array.from(document.querySelectorAll('button.add-product'));
  const textArea = document.getElementsByTagName('textarea')[0];
  let output = '';
  for (const iterator of addBtn) {
   iterator.addEventListener('click', addProduct);
  }
  checoutBtn.addEventListener('click', checkout)
  let bougthProd = {}

  function addProduct() {
   textArea.disabled = false;
   let prodDiv = this.parentNode.parentNode;
   let name = prodDiv.children[1].children[0].textContent;
   let price = Number(prodDiv.children[3].textContent);
   if(!bougthProd[name]){
   bougthProd[name] = price;
   }else{
      bougthProd[name] += price;      
   }
   output+=`Added ${name} for ${price.toFixed(2)} to the cart.\n`;
   textArea.textContent = output;
  }

  function checkout() {
   let totalPrice =0;
   let productNames = []
   for (const key in bougthProd) {
      totalPrice+=bougthProd[key];
      productNames.push(key);
   }
   output+=`You bought ${productNames.join(', ')} for ${totalPrice.toFixed(2)}.`
   textArea.textContent = output;
   checoutBtn.disabled = true;
   for (const btn of addBtn) {
      btn.disabled = true;
   }
  }
}