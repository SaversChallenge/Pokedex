using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Savers.Challenges.Pokedex.Models;
using Savers.Challenges.Pokedex.Models.Enums;
using Savers.Challenges.Pokedex.Models.Queries;
using Savers.Challenges.Pokedex.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Savers.Challenges.Pokedex.Tests
{
    [TestClass]
    public class PokedexFilterServiceTests
    {
        private readonly Mock<ILogger<PokedexFilterService>> _mockLogger;
        private readonly PokedexFilterService _pokedexFilterService;

        public PokedexFilterServiceTests()
        {
            _mockLogger = new Mock<ILogger<PokedexFilterService>>();
            _pokedexFilterService = new PokedexFilterService(_mockLogger.Object);
        }

        [TestMethod]
        public void Filter_NullEntities()
        {
            IEnumerable<PokedexEntry> entries = null;

            var query = new PokedexQuery();

            Assert.ThrowsException<ArgumentNullException>(() => _pokedexFilterService.Filter(ref entries, pokedexQuery: query));
        }

        [TestMethod]
        public void Filter_NullQuery()
        {
            IEnumerable<PokedexEntry> entries = new List<PokedexEntry>
            {
                new PokedexEntry
                {
                    Id = 1
                }
            };

            PokedexQuery query = null;

            Assert.ThrowsException<ArgumentNullException>(() => _pokedexFilterService.Filter(ref entries, pokedexQuery: query));
        }

        [TestMethod]
        public void Filter_NoFilter()
        {
            IEnumerable<PokedexEntry> entries = new List<PokedexEntry>
            {
                new PokedexEntry
                {
                    Id = 1
                }
            };

            PokedexQuery query = new PokedexQuery();

            _pokedexFilterService.Filter(ref entries, pokedexQuery: query);

            Assert.AreEqual(1, entries.Single().Id);
        }

        [TestMethod]
        public void Filter_HasDragonType_YieldsOne()
        {
            IEnumerable<PokedexEntry> entries = new List<PokedexEntry>
            {
                new PokedexEntry
                {
                    Id = 1,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Dragon,
                        PokemonType.Grass
                    }
                },
                new PokedexEntry
                {
                    Id = 2,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Grass
                    }
                }
            };

            PokedexQuery query = new PokedexQuery
            {
                Types = new PokemonType[] { PokemonType.Dragon }
            };

            _pokedexFilterService.Filter(ref entries, pokedexQuery: query);

            Assert.AreEqual(1, entries.Single().Id);
        }

        [TestMethod]
        public void Filter_HasDragonType_YieldsNone()
        {
            IEnumerable<PokedexEntry> entries = new List<PokedexEntry>
            {
                new PokedexEntry
                {
                    Id = 1,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Dragon,
                        PokemonType.Grass
                    }
                },
                new PokedexEntry
                {
                    Id = 2,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Grass
                    }
                }
            };

            PokedexQuery query = new PokedexQuery
            {
                Types = new PokemonType[] { PokemonType.Dragon, PokemonType.Psychic }
            };

            _pokedexFilterService.Filter(ref entries, pokedexQuery: query);

            Assert.AreEqual(0, entries.Count());
        }

        [TestMethod]
        public void Filter_HasDragonFlyingType_YieldsTwo()
        {
            IEnumerable<PokedexEntry> entries = new List<PokedexEntry>
            {
                new PokedexEntry
                {
                    Id = 1,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Dragon,
                        PokemonType.Grass
                    }
                },
                new PokedexEntry
                {
                    Id = 2,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Grass
                    }
                },
                new PokedexEntry
                {
                    Id = 3,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Flying
                    }
                },
                new PokedexEntry
                {
                    Id = 4,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Dragon,
                        PokemonType.Flying
                    }
                },
                new PokedexEntry
                {
                    Id = 5,
                    Types = new List<PokemonType>
                    {
                        PokemonType.Dragon,
                        PokemonType.Flying
                    }
                }
            };

            PokedexQuery query = new PokedexQuery
            {
                Types = new PokemonType[] { PokemonType.Dragon, PokemonType.Flying }
            };

            _pokedexFilterService.Filter(ref entries, pokedexQuery: query);

            Assert.AreEqual(2, entries.Count());
            Assert.IsTrue(entries.Any(e => e.Id == 4));
            Assert.IsTrue(entries.Any(e => e.Id == 5));
        }
    }
}