using _01.DogVet;

var dv = new DogVet();
var d1 = new Dog("1", "a", Breed.Bulldog, 1, 0);
var d2 = new Dog("2", "b", Breed.CockerSpaniel, 1, 1);
var d3 = new Dog("3", "a", Breed.GermanShepherd, 0, 2);
var d4 = new Dog("4", "c", Breed.Bulldog, 1, 5);
var o1 = new Owner("1", "a");
var o2 = new Owner("2", "a");

var dogsByB = dv.GetDogsByBreed(Breed.CockerSpaniel);


dv.AddDog(d1, o1);
dv.AddDog(d2, o1);
dv.AddDog(d3, o2);
dv.AddDog(d4, o2);
var dogsByA = dv.GetAllDogsByAge(-1);