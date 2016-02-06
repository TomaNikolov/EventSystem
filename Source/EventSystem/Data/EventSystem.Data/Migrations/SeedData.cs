namespace EventSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;

    using EventSystem.Models;

    public class SeedData
    {
        public static Random Rand = new Random();

        public List<Category> Categories;

        public List<User> Users;

        public List<Event> Events { get; set; }

        public List<Place> Places { get; set; }

        public User Admin { get; set; }

        public SeedData(List<User> users)
        {
            this.Users = users;

            this.Categories = new List<Category>();
            Categories.Add(new Category() { Name = "Music" });
            Categories.Add(new Category() { Name = "Theatre" });
            Categories.Add(new Category() { Name = "Cinema" });
            Categories.Add(new Category() { Name = "Sport" });
            Categories.Add(new Category() { Name = "Leasure" });
            Categories.Add(new Category() { Name = "Science" });
            Categories.Add(new Category() { Name = "Weather" });

            var country = new Country() { Name = "Bulgaria" };
            var adress = new Adress() { Street = "Otec Paisii 2", Latitude = 42.145404, Longitude = 24.7480313 };

            var cities = new List<City> { new City() { Name = "Plovdiv" }, new City() { Name = "Sofia" }, new City() { Name = "Varna" } };

            this.Places = new List<Place>();
            Places.Add(new Place() { Country = country, City = cities[this.GetRandomNumber(0, Places.Count - 1)] , Adress = adress, Venue = "Bar Fabric"  });
            Places.Add(new Place() { Country = country, City = cities[this.GetRandomNumber(0, Places.Count - 1)], Adress = adress, Venue = "Bar No Sense" });
            Places.Add(new Place() { Country = country, City = cities[this.GetRandomNumber(0, Places.Count - 1)], Adress = adress, Venue = "Bar Gramophone" });
            Places.Add(new Place() { Country = country, City = cities[this.GetRandomNumber(0, Places.Count - 1)], Adress = adress, Venue = "Bar Apartment" });

            this.Events = new List<Event>();

            Events.Add(new Event()
            {
                Title = "What is Lorem Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg1.jpg", ThumbnailPath ="~Content/Images/SeedImages/event1.jpg"}, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() {Ammount = 100, Price= 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "What is Lorem Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg2.jpg", ThumbnailPath = "~Content/Images/SeedImages/event2.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "What im Ipsuem Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg2.jpg", ThumbnailPath = "~Content/Images/SeedImages/event2.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "What ism Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg1.jpg", ThumbnailPath = "~Content/Images/SeedImages/event1.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "What isssing hiddenm?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg1.jpg", ThumbnailPath = "~Content/Images/SeedImages/event1.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "What at is Lor Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg1.jpg", ThumbnailPath = "~Content/Images/SeedImages/event1.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "Whem Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg1.jpg", ThumbnailPath = "~Content/Images/SeedImages/event1.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "em Ipsum has beenrem Ipsum?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg1.jpg", ThumbnailPath = "~Content/Images/SeedImages/event1.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
            Events.Add(new Event()
            {
                Title = "em Ipsum has been?",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry&amp;amp;amp;#39;s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                User = users[this.GetRandomNumber(0, Users.Count - 1)],
                Category = this.Categories[this.GetRandomNumber(0, Categories.Count - 1)],
                CreatedOn = DateTime.Now.AddDays(Rand.Next(-5, 5)),
                EventStart = DateTime.Now.AddDays(Rand.Next(10, 100)),
                Place = this.Places[this.GetRandomNumber(0, Places.Count - 1)],
                Images = new List<Image>() { new Image() { Path = "~Content/Images/SeedImages/bg1.jpg", ThumbnailPath = "~Content/Images/SeedImages/event1.jpg" }, new Image() { Path = "~Content/Images/SeedImages/bg3.jpg", ThumbnailPath = "~Content/Images/SeedImages/event3.jpg" } },
                Tickets = new List<Ticket>() { new Ticket() { Ammount = 100, Price = 20 }, new Ticket() { Ammount = 100, Price = 40 } }
            });
        }

        private int GetRandomNumber(int min, int max)
        {
            return Rand.Next(min, max + 1);
        }
    }
}
