using AASSPP.Data;
using AASSPP.Models;

namespace AASSPP
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext dataContext) { 
            this.dataContext = dataContext;
        }

        public void SeedDataContex() {
            if (!dataContext.Owners.Any())
            {
                Owner ow1 = new Owner()
                {
                    Id = 13,
                    Name = "John",
                    Surname = "Doe",
                    PESEL = "05232313573",
                    Sex = "Male",
                    Born = new DateTime(1903, 1, 1),
                    Email = "140083@student.uni.opole.pl",
                    Home = "ul. Katowicka, Opole, 45-161",
                    Country = new Country()
                    {
                        Id = 1,
                        Name = "USA"
                    },
                    Accounts = new List<Account>() {
                        new Account() {
                            Id = 1034,
                            PIN = 1111,
                            Number = "12123412341234123412341234",
                            Type = new AccountType() {
                                Id = 1,
                                AccountClass = "Debit"
                            },
                            Money = 1000,
                            Cards = new List<Card>()
                            {
                                new Card()
                                {
                                    Id = 1,
                                    Number = "1234123412341234",
                                    Name = "KDV",
                                    PIN = 1111,
                                    CVV = 123,
                                    Cashins = new List<Cashin>() {
                                        new Cashin() {
                                            Id = 1,
                                            Sum = 100
                                        }
                                    },
                                    Cashouts = new List<Cashout>() {
                                        new Cashout() {
                                            Id = 2,
                                            Sum = 100
                                        }
                                    }
                                }
                            },
                            Transfers = new List<Transfer>() {
                                new Transfer() {
                                    Id = 1,
                                    Sender = "ABC DEF",
                                    Receiver = "RFT DSA",
                                    Sum = 400,
                                    Text = "pay2",
                                    Time = new DateTime(1932,5,5)
                                }
                            }
                        }
                    }
                };
                Owner ow2 = new Owner()
                {
                    Id = 13,
                    Name = "Smith",
                    Surname = "Doe",
                    PESEL = "05367389573",
                    Sex = "Male",
                    Born = new DateTime(1905, 1, 1),
                    Email = "150083@student.uni.opole.pl",
                    Home = "ul. Katowicka, Warszawa, 45-161",
                    Country = new Country()
                    {
                        Id = 2,
                        Name = "UAR"
                    },
                    Accounts = new List<Account>(){
                            new Account(){
                                Id = 3400,
                                PIN = 1111,
                                Number = "45454545454545454545454545",
                                Type = new AccountType(){
                                    Id = 1,
                                    AccountClass = "Debit"
                                },
                                Money = 2000,
                                Cards = new List<Card>()
                                {
                                    new Card()
                                    {
                                        Id = 1,
                                        Number = "2341234123412341",
                                        Name = "KDV",
                                        PIN = 1111,
                                        CVV = 123,
                                        Cashins = new List<Cashin>(){
                                            new Cashin(){
                                                Id = 1,
                                                Sum = 100
                                            }
                                        },
                                        Cashouts = new List<Cashout>(){
                                            new Cashout(){
                                                Id = 2,
                                                Sum = 100
                                            }
                                        }
                                    }
                                },
                                Transfers = new List<Transfer>(){
                                    new Transfer(){
                                        Id = 1,
                                        Sender = "ABC DEF",
                                        Receiver = "RFT DSA",
                                        Sum = 50,
                                        Text = "pay",
                                        Time = new DateTime(1923, 4,4)
                                    }
                                }
                            }
                    },
                };
                ow1.Accounts.ElementAt(0).Transfers.ElementAt(0).AccountSender = ow2.Accounts.ElementAt(0);
                ow1.Accounts.ElementAt(0).Transfers.ElementAt(0).AccountReceiver = ow1.Accounts.ElementAt(0);

                ow2.Accounts.ElementAt(0).Transfers.ElementAt(0).AccountSender = ow1.Accounts.ElementAt(0);
                ow2.Accounts.ElementAt(0).Transfers.ElementAt(0).AccountReceiver = ow2.Accounts.ElementAt(0);

                var Owners = new List<Owner>() {
                    ow1, 
                    ow2
                };
                

                //var pokemonOwners = new List<PokemonOwner>()
                //{
                //    new PokemonOwner()
                //    {
                //        Pokemon = new Pokemon()
                //        {
                //            Name = "Pikachu",
                //            BirthDate = new DateTime(1903,1,1),
                //            PokemonCategories = new List<PokemonCategory>()
                //            {
                //                new PokemonCategory { Category = new Category() { Name = "Electric"}}
                //            },
                //            Reviews = new List<Review>()
                //            {
                //                new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                //                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                //                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                //                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                //                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                //                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                //            }
                //        },
                //        Owner = new Owner()
                //        {
                //            FirstName = "Jack",
                //            LastName = "London",
                //            Gym = "Brocks Gym",
                //            Country = new Country()
                //            {
                //                Name = "Kanto"
                //            }
                //        }
                //    },
                //    new PokemonOwner()
                //    {
                //        Pokemon = new Pokemon()
                //        {
                //            Name = "Squirtle",
                //            BirthDate = new DateTime(1903,1,1),
                //            PokemonCategories = new List<PokemonCategory>()
                //            {
                //                new PokemonCategory { Category = new Category() { Name = "Water"}}
                //            },
                //            Reviews = new List<Review>()
                //            {
                //                new Review { Title= "Squirtle", Text = "squirtle is the best pokemon, because it is electric", Rating = 5,
                //                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                //                new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
                //                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                //                new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                //                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                //            }
                //        },
                //        Owner = new Owner()
                //        {
                //            FirstName = "Harry",
                //            LastName = "Potter",
                //            Gym = "Mistys Gym",
                //            Country = new Country()
                //            {
                //                Name = "Saffron City"
                //            }
                //        }
                //    },
                //                    new PokemonOwner()
                //    {
                //        Pokemon = new Pokemon()
                //        {
                //            Name = "Venasuar",
                //            BirthDate = new DateTime(1903,1,1),
                //            PokemonCategories = new List<PokemonCategory>()
                //            {
                //                new PokemonCategory { Category = new Category() { Name = "Leaf"}}
                //            },
                //            Reviews = new List<Review>()
                //            {
                //                new Review { Title="Veasaur",Text = "Venasuar is the best pokemon, because it is electric", Rating = 5,
                //                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                //                new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
                //                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                //                new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                //                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                //            }
                //        },
                //        Owner = new Owner()
                //        {
                //            FirstName = "Ash",
                //            LastName = "Ketchum",
                //            Gym = "Ashs Gym",
                //            Country = new Country()
                //            {
                //                Name = "Millet Town"
                //            }
                //        }
                //    }
                //};
                //dataContext.PokemonOwners.AddRange(pokemonOwners);
                //dataContext.SaveChanges();
            }
        }
    }
}
