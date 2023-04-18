function squareDigits(num){
  let numArr = num.toString().split('');
  let res = '';
  for (const digit of numArr) {
    res+=Number(digit)*digit;
  }
    return Number(res);
  }

  console.log(squareDigits(3212))