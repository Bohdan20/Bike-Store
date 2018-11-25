namespace StagesCycling.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    using Context;
    using StagesCycling.DAL.Entities;
    using System.Collections.Generic;
    using StagesCycling.DAL.Entities.Accessories;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            AddBasePrices(context);
            AddModels(context);
            AddPaintColors(context);
            AddArtworkBeltGuards(context);
            AddArtworkFlywheels(context);
            AddArtworkFrameForks(context);
            AddPlasticsColors(context);
            AddSeatTypes(context);
            AddHandlebarTypes(context);
            AddPedalTypes(context);
            AddPowerMeterTypes(context);
            AddConsoleTypes(context);
            AddSprintShiftTypes(context);
            AddAccessories(context);
            AddBikeNumberPlates(context);
            AddOrderConfiguration(context);
        }

        private void AddBasePrices(ApplicationDbContext context)
        {
            var defaultPrices = new List<BasePrice>()
            {
               new BasePrice()
               {
                   Id = 1,
                   Type = "StandartArtworkBeltGuard",
                   Price = 0
               },

               new BasePrice()
               {
                   Id = 2,
                   Type = "StandartArtworkFlywheel",
                   Price = 0
               },

               new BasePrice()
               {
                   Id = 3,
                   Type = "StandartArtworkFrameFork",
                   Price = 0
               },

                new BasePrice()
               {
                   Id = 4,
                   Type = "CustomArtworkBeltGuard",
                   Price = 25
               },

                 new BasePrice()
               {
                   Id = 5,
                   Type = "CustomArtworkFlywheel",
                   Price = 25
                 },

                  new BasePrice()
               {
                   Id = 6,
                   Type = "CustomArtworkFrameFork",
                   Price = 25
               },

                  new BasePrice()
               {
                   Id = 7,
                   Type = "StandartPaintColor",
                   Price = 0
               },

                  new BasePrice()
               {
                   Id = 8,
                   Type = "CustomPaintColor",
                   Price = 100
                  }
            };

            foreach (var item in defaultPrices)
                context.BasePrices.AddOrUpdate(item);
        }

        private void AddOrderConfiguration(ApplicationDbContext context)
        {
            var item = new OrderConfiguration()
            {
                MinBikeQuantity = 24,
                MaxDiscount = 95
            };

            context.OrderConfigurations.AddOrUpdate(item);
        }

        private void AddModels(ApplicationDbContext context)
        {
            var defaultModels = new List<Model>()
            {
                new Model()
                {
                    Title = "SC2",
                    Sourcing = "Giant",
                    BasePrice = 1579.11M,
                    ItemDefinedCost = 1400,
                    SKU = "971-0032",
                    DefaultSC2 = true,
                    DefaultSC3 = false,
                    ImageUrl = "route1"
                },

                new Model()
                {
                    Title = "SC3",
                    Sourcing = "Giant",
                    BasePrice = 1769.37M,
                    ItemDefinedCost = 1500,
                    SKU = "971-0033",
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    ImageUrl = "route2"
                }
            };

            foreach (var item in defaultModels)
                context.Models.AddOrUpdate(item);
        }

        private void AddPaintColors(ApplicationDbContext context)
        {
            var defaultColors = new List<PaintColor>()
            {
                new PaintColor()
                {
                    Title = "RAL2002",
                    Sourcing = "Giant",
                    ColorImageUrl = "RAL2002.png",
                    BikeImageUrl = "RAL2002bike.jpg",
                    BasePriceId = 7,
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                },

                new PaintColor()
                {
                    Title = "RAL2004",
                    Sourcing = "Giant",
                    ColorImageUrl = "RAL2004.png",
                    BikeImageUrl = "RAL2004bike.jpg",
                    BasePriceId = 7,
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                },

                new PaintColor()
                {
                    Title = "RAL3000",
                    Sourcing = "Giant",
                    ColorImageUrl = "RAL3000.png",
                    BikeImageUrl = "RAL3000bike.jpg",
                    BasePriceId = 7,
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                },

                new PaintColor()
                {
                    Title = "RAL3012",
                    Sourcing = "Giant",
                    ColorImageUrl = "RAL3012.png",
                    BikeImageUrl = "RAL3012bike.jpg",
                    BasePriceId = 7,
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                },

                new PaintColor()
                {
                    Title = "RAL4003",
                    Sourcing = "Giant",
                    ColorImageUrl = "RAL4003.png",
                    BikeImageUrl = "RAL4003bike.jpg",
                    BasePriceId = 7,
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                },

                new PaintColor()
                {
                    Title = "RAL6017",
                    Sourcing = "Giant",
                    ColorImageUrl = "RAL6017.png",
                    BikeImageUrl = "RAL6017bike.jpg",
                    BasePriceId = 7,
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                }
            };

            foreach (var item in defaultColors)
                context.PaintColors.AddOrUpdate(item);
        }

        private void AddArtworkBeltGuards(ApplicationDbContext context)
        {
            var defaultArtworkBeltGuards = new List<ArtworkBeltGuard>()
            {
                new ArtworkBeltGuard()
                {
                    Title = "Standard Stages branding SC2",
                    CustomImageUrl = "url",
                    Sourcing = "Giant",
                    BasePriceId = 1,
                    DefaultSC2 = true,
                    DefaultSC3 = false,
                    SKU = "000-5842"
                },

                new ArtworkBeltGuard()
                {
                    Title = "Standard Stages branding SC3",
                    CustomImageUrl = "url",
                    Sourcing = "Giant",
                    BasePriceId = 1,
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    SKU = "000-5845"
                }
            };

            foreach (var item in defaultArtworkBeltGuards)
                context.ArtworkBeltGuards.AddOrUpdate(item);
        }

        private void AddArtworkFlywheels(ApplicationDbContext context)
        {
            var defaultArtworkFlywheels = new List<ArtworkFlywheel>()
            {
                new ArtworkFlywheel()
                {
                    Title = "Standard Stages branding SC3",
                    CustomImageUrl = "url",
                    Sourcing = "Giant",
                    BasePriceId = 2,
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    SKU = "000-4145"
                }
            };

            foreach (var item in defaultArtworkFlywheels)
                context.ArtworkFlywheels.AddOrUpdate(item);
        }

        private void AddArtworkFrameForks(ApplicationDbContext context)
        {
            var defaultArtworkFrameForks = new List<ArtworkFrameFork>()
            {
                new ArtworkFrameFork()
                {
                    Title = "Standard Stages branding SC2",
                    CustomImageUrl = "url",
                    Sourcing = "Giant",
                    BasePriceId = 3,
                    DefaultSC2 = true,
                    DefaultSC3 = false,
                    SKU = "000-4145"
                },

                new ArtworkFrameFork()
                {
                    Title = "Standard Stages branding SC3",
                    CustomImageUrl = "url",
                    Sourcing = "Giant",
                    BasePriceId = 3,
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    SKU = "000-4145"
                }
            };

            foreach (var item in defaultArtworkFrameForks)
                context.ArtworkFrameForks.AddOrUpdate(item);
        }

        private void AddPlasticsColors(ApplicationDbContext context)
        {
            var defaultPlasticsColors = new List<PlasticsColorType>()
            {
                new PlasticsColorType()
                {
                    Title = "Stages standard - blue",
                    Sourcing = "Giant",
                    BasePrice = 0,
                    ItemDefinedCost = 0,
                    SKU = "000-3792",
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    ImageUrl = "blueKnobs.JPG"
                },

                new PlasticsColorType()
                {
                    Title = "Matte black",
                    Sourcing = "Giant",
                    BasePrice = 0,
                    ItemDefinedCost = 0,
                    SKU = "000-4237",
                    DefaultSC2 = true,
                    DefaultSC3 = false,
                    ImageUrl = "blackKnobs.JPG"
                }
            };

            foreach (var item in defaultPlasticsColors)
                context.PlasticsColorTypes.AddOrUpdate(item);
        }

        private void AddSeatTypes(ApplicationDbContext context)
        {
            var defaultSeats = new List<SeatType>()
            {
                new SeatType()
                {
                    Title = "Stages Brand Seat, 2018",
                    Sourcing = "Giant",
                    BasePrice = 50,
                    ItemDefinedCost = 30,
                    SKU = "000-5807",
                    DefaultSC2 = true,
                    DefaultSC3 = true,
                    ImageUrl = "Saddle.JPG"
                }
            };

            foreach (var item in defaultSeats)
                context.SeatTypes.AddOrUpdate(item);
        }

        private void AddHandlebarTypes(ApplicationDbContext context)
        {
            var defaultHandlebarTypes = new List<HandlebarType>()
            {
                new HandlebarType()
                {
                    Title = "Stages Roadbar™ - Black",
                    Sourcing = "Giant",
                    BasePrice = 149.29M,
                    ItemDefinedCost = 100,
                    SKU = "000-5930",
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    ImageUrl = "roadbarBlack.JPG"
                },

                new HandlebarType()
                {
                    Title = "Stages Roadbar™ - Blue",
                    Sourcing = "Giant",
                    BasePrice = 149.29M,
                    ItemDefinedCost = 100,
                    SKU = "000-5931",
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                    ImageUrl = "roadbarBlack.JPG"
                },

                new HandlebarType()
                {
                    Title = "Stages Rhythm Bar - Black",
                    Sourcing = "Giant",
                    BasePrice = 161.29M,
                    ItemDefinedCost = 100,
                    SKU = "000-5996",
                    DefaultSC2 = true,
                    DefaultSC3 = false,
                    ImageUrl = "rhythmBarBlack.JPG"
                },

                new HandlebarType()
                {
                    Title = "Stages Rhythm Bar - Blue",
                    Sourcing = "Giant",
                    BasePrice = 161.29M,
                    ItemDefinedCost = 100,
                    SKU = "971-0160",
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                    ImageUrl = "rhythmBarBlue.JPG"
                }
            };

            foreach (var item in defaultHandlebarTypes)
                context.HandlebarTypes.AddOrUpdate(item);
        }

        private void AddPedalTypes(ApplicationDbContext context)
        {
            var defaultPedalTypes = new List<PedalType>()
            {
                new PedalType()
                {
                    Title = "Stages RPS pedal,  SPD with toe cage",
                    Sourcing = "Giant",
                    BasePrice = 60,
                    ItemDefinedCost = 50,
                    SKU = "000-6805",
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                    ImageUrl = "STDPedals.JPG"
                },

                new PedalType()
                {
                    Title = "Stages SP3 pedal, 2018",
                    Sourcing = "Giant",
                    BasePrice = 99,
                    ItemDefinedCost = 50,
                    SKU = "971-0050",
                    DefaultSC2 = true,
                    DefaultSC3 = true,
                    ImageUrl = "SP3.JPG"
                },

                new PedalType()
                {
                    Title = "Stages SP2 pedal, 2018 - no toe cage kit",
                    Sourcing = "Giant",
                    BasePrice = 80,
                    ItemDefinedCost = 50,
                    SKU = "971-0051",
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                    ImageUrl = "SP2.JPG"
                }
            };

            foreach (var item in defaultPedalTypes)
                context.PedalTypes.AddOrUpdate(item);
        }

        private void AddPowerMeterTypes(ApplicationDbContext context)
        {
            var defaultPowerMeterTypes = new List<PowerMeterType>()
            {
                new PowerMeterType()
                {
                    Title = "Stages Power Meter - left crank",
                    Sourcing = "Inventory",
                    BasePrice = 549,
                    ItemDefinedCost = 500,
                    SKU = "000-6805",
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    ImageUrl = "PoweMeter.JPG"
                },

                new PowerMeterType()
                {
                    Title = "RPM cadence meter - left crank",
                    Sourcing = "Inventory",
                    BasePrice = 400,
                    ItemDefinedCost = 350,
                    SKU = "971-0050",
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                    ImageUrl = "leftCrank.JPG"
                },

                new PowerMeterType()
                {
                    Title = "No - include standard left crank",
                    Sourcing = "Inventory",
                    BasePrice = 20,
                    ItemDefinedCost = 10,
                    SKU = "971-0051",
                    DefaultSC2 = true,
                    DefaultSC3 = false,
                    ImageUrl = "leftCrank.JPG"
                }
            };

            foreach (var item in defaultPowerMeterTypes)
                context.PowerMeterTypes.AddOrUpdate(item);
        }

        private void AddConsoleTypes(ApplicationDbContext context)
        {
            var defaultConsoleTypes = new List<ConsoleType>()
            {
                new ConsoleType()
                {
                    Title = "Basic Console",
                    Sourcing = "Inventory",
                    BasePrice = 149,
                    ItemDefinedCost = 100,
                    SKU = "000-6805",
                    DefaultSC2 = false,
                    DefaultSC3 = true,
                    ImageUrl = "Console.JPG"
                }
            };

            foreach (var item in defaultConsoleTypes)
                context.ConsoleTypes.AddOrUpdate(item);
        }

        private void AddSprintShiftTypes(ApplicationDbContext context)
        {
            var defaulSprintShiftTypes = new List<SprintShiftType>()
            {
                new SprintShiftType()
                {
                    Title = "Yes - SprintShift [NEW version]",
                    Sourcing = "Inventory",
                    BasePrice = 20,
                    ItemDefinedCost = 10,
                    SKU = "000-6805",
                    DefaultSC2 = true,
                    DefaultSC3 = true,
                    ImageUrl = "sprintShift.JPG"
                },

                new SprintShiftType()
                {
                    Title = "No - basic knob adjustment",
                    Sourcing = "Inventory",
                    BasePrice = 0,
                    ItemDefinedCost = 0,
                    SKU = "000-6805",
                    DefaultSC2 = false,
                    DefaultSC3 = false,
                    ImageUrl = "sprintShiftSpacer.JPG"
                }
            };

            foreach (var item in defaulSprintShiftTypes)
                context.SprintShiftTypes.AddOrUpdate(item);
        }

        private void AddAccessories(ApplicationDbContext context)
        {
            var aerobar = new Aerobar()
            {
                Title = "Standard aerobar",
                Sourcing = "Inventory",
                BasePrice = 20,
                ItemDefinedCost = 10,
                SKU = "000-6805",
                ImageUrl = "Aerobar1.JPG"
            };

            context.Aerobars.AddOrUpdate(aerobar);

            var handlebarPost = new HandlebarPost()
            {
                Title = "HandlebarPost",
                Sourcing = "Inventory",
                BasePrice = 20,
                ItemDefinedCost = 10,
                SKU = "000-6805",
                ImageUrl = "url"
            };

            context.HandlebarPosts.Add(handlebarPost);

            var mediaShelf = new MediaShelf()
            {
                Title = "MediaShelf",
                Sourcing = "Inventory",
                BasePrice = 20,
                ItemDefinedCost = 10,
                SKU = "000-6805",
                ImageUrl = "mediaTray1.JPG"
            };

            context.MediaShelfs.Add(mediaShelf);

            var phoneHolder = new PhoneHolder()
            {
                Title = "PhoneHolder",
                Sourcing = "Inventory",
                BasePrice = 20,
                ItemDefinedCost = 10,
                SKU = "000-6805",
                ImageUrl = "phoneShelf.JPG"
            };

            context.PhoneHolders.Add(phoneHolder);

            var seatPost = new SeatPost()
            {
                Title = "SeatPost",
                Sourcing = "Inventory",
                BasePrice = 20,
                ItemDefinedCost = 10,
                SKU = "000-6805",
                ImageUrl = "url"
            };

            context.SeatPosts.Add(seatPost);

            var stagesDumbbellHolder = new StagesDumbbellHolder()
            {
                Title = "stagesDumbbellHolder",
                Sourcing = "Inventory",
                BasePrice = 20,
                ItemDefinedCost = 10,
                SKU = "000-6805",
                ImageUrl = "dumbbellHolder.JPG"
            };

            context.StagesDumbbellHolders.Add(stagesDumbbellHolder);

            var tabletHolder = new TabletHolder()
            {
                Title = "TabletHolder",
                Sourcing = "Inventory",
                BasePrice = 20,
                ItemDefinedCost = 10,
                SKU = "000-6805",
                ImageUrl = "BYODmount.JPG"
            };

            context.TabletHolders.Add(tabletHolder);
        }

        private void AddBikeNumberPlates(ApplicationDbContext context)
        {
            var defaultBikeNumberPlates = new List<StagesBikeNumberPlate>()
            {
                new StagesBikeNumberPlate()
                {
                    Title = "1-60",
                    ImageUrl = "url",
                    Sourcing = "Inventory",
                    BasePrice = 134.24M,
                    SKU = "000-5842"
                },
                new StagesBikeNumberPlate()
                {
                    Title = "61-100",
                    ImageUrl = "url",
                    Sourcing = "Inventory",
                    BasePrice = 93.56M,
                    SKU = "000-5842"
                },
                 new StagesBikeNumberPlate()
                {
                    Title = "1-80",
                    ImageUrl = "url",
                    Sourcing = "Inventory",
                    BasePrice = 174.92M,
                    SKU = "000-5842"
                },
                  new StagesBikeNumberPlate()
                {
                    Title = "Stages logo, 50 pieces",
                    ImageUrl = "url",
                    Sourcing = "Inventory",
                    BasePrice = 99.15M,
                    SKU = "000-5842"
                },
                   new StagesBikeNumberPlate()
                {
                    Title = "1-30 x 2 sets",
                    ImageUrl = "url",
                    Sourcing = "Inventory",
                    BasePrice = 134.24M,
                    SKU = "000-5842"
                },

            };

            foreach (var item in defaultBikeNumberPlates)
                context.StagesBikeNumberPlates.AddOrUpdate(item);
        }
    }
}
