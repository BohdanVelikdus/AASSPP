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
                Country country = new Country
                {
                    //Id = 1,
                    Name = "USA"
                };


                Owner ow1 = new Owner()
                {
                    //Id = 2,
                    Name = "John",
                    Surname = "Doe",
                    PESEL = "05232313573",
                    Sex = "Male",
                    Born = new DateTime(1903, 1, 1),
                    Email = "140083@student.uni.opole.pl",
                    Home = "ul. Katowicka, Opole, 45-161",
                    Country = country,
                    CountryId = country.Id,
                    Phone = "+48903903903",
                    Cards = new List<Card>() {
                        new Card{
                            //Id = 3,
                            Number = "1234123412341234",
                            Name = "KDV",
                            PIN = 1234,
                            CVV = 178,
                            ExpireDate = new DateTime(2024,9,10),
                            Money = 1024,
                            Cashins = new List<Cashin>(){
                                new Cashin{
                                    //Id = 4,
                                    Sum = 1000
                                }
                            },
                            Cashouts = new List<Cashout>(){
                                new Cashout{
                                    //Id = 5,
                                    Sum = 100
                                }
                            },
                            Transfers = new List<Transfer>(){
                                new Transfer{
                                    //Id = 6,
                                    Sender = "Test sender",
                                    Receiver = "I for ow1",
                                    Sum = 1000,
                                    Text = "test send",
                                    Time = new DateTime(1823, 2,1),
                                }
                            }
                        }
                    }

                };
                Owner ow2 = new Owner()
                {
                    //Id = 7,
                    Name = "Smith",
                    Surname = "Doe",
                    PESEL = "05367389573",
                    Sex = "Male",
                    Born = new DateTime(1905, 1, 1),
                    Email = "150083@student.uni.opole.pl",
                    Home = "ul. Katowicka, Warszawa, 45-161",
                    Country = country,
                    CountryId = country.Id,
                    Phone = "+48803803803",
                    Cards = new List<Card>() {
                        new Card{
                            //Id = 8,
                            Number = "1234123412341234",
                            Name = "KDV",
                            PIN = 1234,
                            CVV = 178,
                            ExpireDate = new DateTime(2024,9,10),
                            Money = 1024,
                            Cashins = new List<Cashin>(){
                                new Cashin{
                                    //Id = 9,
                                    Sum = 1234
                                }
                            },
                            Cashouts = new List<Cashout>(){
                                new Cashout{
                                    //Id = 10,
                                    Sum = 100
                                }
                            },
                            Transfers = new List<Transfer>(){
                                new Transfer{
                                    //Id = 11,
                                    Sender = "Test sender",
                                    Receiver = "I for ow1",
                                    Sum = 1000,
                                    Text = "test send",
                                    Time = new DateTime(1823, 2,1)
                                }
                            }
                        }
                    }
                };
                //card owning
                ow1.Cards.ElementAt(0).Owner = ow1;
                ow1.Cards.ElementAt(0).OwnerId = ow1.Id;
                //cashins setup foreign key ID
                ow1.Cards.ElementAt(0).Cashins.ElementAt(0).CardId = ow1.Cards.ElementAt(0).Id;
                ow1.Cards.ElementAt(0).Cashins.ElementAt(0).Card = ow1.Cards.ElementAt(0);
                //cashouts
                ow1.Cards.ElementAt(0).Cashouts.ElementAt(0).CardId = ow1.Cards.ElementAt(0).Id;
                ow1.Cards.ElementAt(0).Cashouts.ElementAt(0).Card = ow1.Cards.ElementAt(0);
                //transfer
                ow1.Cards.ElementAt(0).Transfers.ElementAt(0).CardId = ow1.Cards.ElementAt(0).Id;
                ow1.Cards.ElementAt(0).Transfers.ElementAt(0).Card = ow2.Cards.ElementAt(0);

                //card owning 
                ow2.Cards.ElementAt(0).Owner = ow2;
                ow2.Cards.ElementAt(0).OwnerId = ow2.Id;
                //cashins setup
                ow2.Cards.ElementAt(0).Cashins.ElementAt(0).CardId = ow2.Cards.ElementAt(0).Id;
                ow2.Cards.ElementAt(0).Cashins.ElementAt(0).Card = ow2.Cards.ElementAt(0);
                //cashouts
                ow2.Cards.ElementAt(0).Cashouts.ElementAt(0).CardId = ow2.Cards.ElementAt(0).Id;
                ow2.Cards.ElementAt(0).Cashouts.ElementAt(0).Card = ow2.Cards.ElementAt(0);
                // transfer
                ow2.Cards.ElementAt(0).Transfers.ElementAt(0).CardId = ow2.Cards.ElementAt(0).Id;
                ow2.Cards.ElementAt(0).Transfers.ElementAt(0).Card = ow1.Cards.ElementAt(0);

                var Owners_ = new List<Owner>() { 
                    ow1,
                    ow2
                };

                dataContext.Owners.AddRange(Owners_);
                dataContext.SaveChanges();
            }
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


        }
    }
}
