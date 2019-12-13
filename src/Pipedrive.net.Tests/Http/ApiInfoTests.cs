using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Pipedrive.Tests.Http
{
    public class ApiInfoTests
    {
        public class TheMethods
        {
            [Fact]
            public void CanClone()
            {
                var original = new ApiInfo(
                                new Dictionary<string, Uri>
                                {
                                    {
                                        "next",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=4&per_page=5")
                                    },
                                    {
                                        "last",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=131&per_page=5")
                                    },
                                    {
                                        "first",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=1&per_page=5")
                                    },
                                    {
                                        "prev",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=2&per_page=5")
                                    }
                                },
                                "5634b0b187fd2e91e3126a75006cc4fa",
                                new RateLimit(100, 75, 49));

                var clone = original.Clone();

                // Note the use of Assert.NotSame tests for value types - this should continue to test should the underlying
                // model are changed to Object types
                Assert.NotSame(original, clone);

                Assert.Equal(original.Etag, clone.Etag);
                Assert.NotSame(original.Etag, clone.Etag);

                Assert.Equal(original.Links.Count, clone.Links.Count);
                Assert.NotSame(original.Links, clone.Links);
                for (int i = 0; i < original.Links.Count; i++)
                {
                    Assert.Equal(original.Links.Keys.ToArray()[i], clone.Links.Keys.ToArray()[i]);
                    Assert.NotSame(original.Links.Keys.ToArray()[i], clone.Links.Keys.ToArray()[i]);
                    Assert.Equal(original.Links.Values.ToArray()[i].ToString(), clone.Links.Values.ToArray()[i].ToString());
                    Assert.NotSame(original.Links.Values.ToArray()[i], clone.Links.Values.ToArray()[i]);
                }

                Assert.NotSame(original.RateLimit, clone.RateLimit);
                Assert.Equal(original.RateLimit.Limit, clone.RateLimit.Limit);
                Assert.Equal(original.RateLimit.Remaining, clone.RateLimit.Remaining);
                Assert.Equal(original.RateLimit.ResetInSeconds, clone.RateLimit.ResetInSeconds);
                Assert.Equal(original.RateLimit.Reset, clone.RateLimit.Reset);
            }

            [Fact]
            public void CanCloneWithNullETag()
            {
                var original = new ApiInfo(
                    new Dictionary<string, Uri>
                    {
                        {
                            "next",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=4&per_page=5")
                        },
                        {
                            "last",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=131&per_page=5")
                        },
                        {
                            "first",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=1&per_page=5")
                        },
                        {
                            "prev",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=2&per_page=5")
                        }
                    },
                    null,
                    new RateLimit(100, 75, 776));

                var clone = original.Clone();

                Assert.NotNull(clone);
                Assert.Equal(4, clone.Links.Count);
                Assert.Null(clone.Etag);
                Assert.Equal(100, clone.RateLimit.Limit);
                Assert.Equal(75, clone.RateLimit.Remaining);
                Assert.Equal(776, clone.RateLimit.ResetInSeconds);
            }

            [Fact]
            public void CanCloneWithNullRateLimit()
            {
                var original = new ApiInfo(
                    new Dictionary<string, Uri>
                    {
                        {
                            "next",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=4&per_page=5")
                        },
                        {
                            "last",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=131&per_page=5")
                        },
                        {
                            "first",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=1&per_page=5")
                        },
                        {
                            "prev",
                            new Uri("https://api.github.com/repos/rails/rails/issues?page=2&per_page=5")
                        }
                    },
                    "123abc",
                    null);

                var clone = original.Clone();

                Assert.NotNull(clone);
                Assert.Equal(4, clone.Links.Count);
                Assert.Equal("123abc", clone.Etag);
                Assert.Null(clone.RateLimit);
            }
        }
    }
}
