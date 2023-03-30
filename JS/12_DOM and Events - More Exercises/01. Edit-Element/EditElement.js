function editElement(ref, match, replacer){
  let result = ref.textContent.split(match).join(replacer);
  ref.textContent = result;
}
