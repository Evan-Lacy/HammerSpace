namespace HammerSpace.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HammerSpace.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HammerSpace.Data.ApplicationDbContext";
        }

        protected override void Seed(HammerSpace.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #region Movie Seed Data
            context.Movies.AddOrUpdate(

                //new Movie
                //{
                //    MovieTitle = "string",
                //    MovieDescription = "string",
                //    MovieRunTime = double,
                //    Director = "string",
                //    MovieRating = MovieRating.[Rating],
                //    MovieGenre = MovieGenre.[Genre],
                //    ReleaseYear = int,
                //}

                new Movie
                {
                    MovieTitle = "Tolkien",
                    MovieDescription = "As a young student, J.R.R. Tolkien finds love, friendship and artistic inspiration among a group of fellow outcasts. Their brotherhood soon strengthens as Tolkien weathers the storm of a tumultuous courtship with Edith Bratt and the outbreak of World War I. These early life experiences later inspire the budding author to write the classic fantasy novels \"The Hobbit\" and \"The Lord of the Rings.\"",
                    MovieRunTime = 112,
                    Director = "Dome Karukoski",
                    MovieRating = MovieRating.PG13,
                    MovieGenre = MovieGenre.Drama,
                    ReleaseYear = 2019,
                }, 

                new Movie
                {
                    MovieTitle = "Sonic The Hedgehog",
                    MovieDescription = "The world needed a hero -- it got a hedgehog. Powered with incredible speed, Sonic embraces his new home on Earth -- until he accidentally knocks out the power grid, sparking the attention of uncool evil genius Dr. Robotnik. Now, it's supervillain vs. supersonic in an all-out race across the globe to stop Robotnik from using Sonic's unique power to achieve world domination.",
                    MovieRunTime = 98,
                    Director = "Jeff Fowler",
                    MovieRating = MovieRating.PG,
                    MovieGenre = MovieGenre.Comedy,
                    ReleaseYear = 2020,
                },

                new Movie
                {
                    MovieTitle = "Alita: Battle Angel",
                    MovieDescription = "Set several centuries in the future, the abandoned Alita is found in the scrapyard of Iron City by Ido, a compassionate cyber-doctor who takes the unconscious cyborg Alita to his clinic. When Alita awakens, she has no memory of who she is, nor does she have any recognition of the world she finds herself in. As Alita learns to navigate her new life and the treacherous streets of Iron City, Ido tries to shield her from her mysterious past.",
                    MovieRunTime = 122,
                    Director = "Robert Rodriguez",
                    MovieRating = MovieRating.PG13,
                    MovieGenre = MovieGenre.Action,
                    ReleaseYear = 2019,
                },

                new Movie
                {
                    MovieTitle = "The Internship (Unrated)",
                    MovieDescription = "After old-school salesmen Billy (Vince Vaughn) and Nick (Owen Wilson) find themselves downsized, Billy decides that, despite their complete lack of technological savvy, they should work for Google. The friends somehow manage to finagle internships at the Internet giant and promptly head out to Silicon Valley. Viewed with disdain by most of their fellow interns, Billy and Nick join forces with the rest of the misfit \"nooglers\" to make it through a series of competitive team challenges.",
                    MovieRunTime = 122,
                    Director = "Shawn Levy",
                    MovieRating = MovieRating.R,
                    MovieGenre = MovieGenre.Comedy,
                    ReleaseYear = 2013,
                }
                );
            #endregion

            #region Games Seed Data
            context.Games.AddOrUpdate(

                //new Games.BoardGame
                //{
                //    GameTitle = "string",
                //    GameDescription = "string",
                //    AveragePlaytime = double,
                //    MinGamePlayers = int,
                //    MaxGamePlayers = int,
                //    GameType = Games.GameType.[Type],
                //    BoardGameGenre = Games.Genre.[Genre],
                //    Category = "string",
                //    BGPublisher = "string",
                //    IsCardGame = bool,
                //    IsDiceGame = bool
                //},
                //new Games.VideoGame
                //{
                //    GameTitle = "string",
                //    GameDescription = "string",
                //    AveragePlaytime = double,
                //    MinGamePlayers = int,
                //    MaxGamePlayers = int,
                //    GameType = Games.GameType.[Type],
                //    VideoGameGenre = Games.Genre.[Genre],
                //    Console = "string",
                //    VGPublisher = "string",
                //    LocalCoop = bool,
                //    ESRBRating = Games.ESRBRating.[Rating]
                //},

                new Games.BoardGame
                {
                    GameTitle = "Cheap Shot",
                    GameDescription = "Have you ever wanted to insult your friends while playing gin rummy? Look no further than this game, developed by GutBustin' Games. Create the best insults you can with the cards available to score the most points.",
                    AveragePlaytime = 3,
                    MinGamePlayers = 2,
                    MaxGamePlayers = 6,
                    GameType = Games.GameType.BoardGame,
                    BoardGameGenre = Games.Genre.Party,
                    Category = "Gin Rummy-based insults",
                    BGPublisher = "GutBustin' Games",
                    IsCardGame = false,
                    IsDiceGame = true
                },

                new Games.BoardGame
                {
                    GameTitle = "Stratego",
                    GameDescription = "A strategy game designed to test your ability to read your oppnent and to predict opposing strategies, Stratego is a brilliant game for the tactical mind. As long as you capture the enemies flag before they get yours, then you shall emerge victorious on the battlefield.",
                    AveragePlaytime = 4,
                    MinGamePlayers = 2,
                    MaxGamePlayers = 2,
                    GameType = Games.GameType.BoardGame,
                    BoardGameGenre = Games.Genre.Strategy,
                    Category = "Battlefield tactics and friendship destroying fun!",
                    BGPublisher = "N/A",
                    IsCardGame = false,
                    IsDiceGame = false
                },

                new Games.VideoGame
                {
                    GameTitle = "Assassin's Creed Valhalla",
                    GameDescription = "You play as Eivor, the fearless leader of the Norse people of the Raven Clan in 10th century England. The tales of how you fight to gain alliances, track down the hidden Order of the Ancients, and grow in power yourself are all yours for the taking, should you decide to pick up the axe and fight as a fierce Norse Vikingr.",
                    AveragePlaytime = 30,
                    MinGamePlayers = 1,
                    MaxGamePlayers = null,
                    GameType = Games.GameType.VideoGame,
                    VideoGameGenre = Games.Genre.ActionAdventure,
                    Console = "Xbox One, Xbox Series X, Playstation 4, Playstation 5, PC",
                    VGPublisher = "Ubisoft",
                    LocalCoop = false,
                    ESRBRating = Games.ESRBRating.M
                }

                );
            #endregion


            context.SaveChanges();
        }
    }
}
