// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Xunit;

namespace Microsoft.AspNetCore.SignalR.Client
{
    public class ConnectionFacts
    {
        [Fact]
        public void Connection_ctor_validates_params()
        {
            Assert.Equal(
                "url",
                Assert.Throws<ArgumentNullException>(() => new Connection(null)).ParamName);

            var ex = Assert.Throws<ArgumentException>(() => new Connection("abc?"));
            Assert.Equal($"Url cannot contain query string directly. Pass query string values in using available overload.{Environment.NewLine}Parameter name: url", ex.Message);
            Assert.Equal("url", ex.ParamName);
        }

        [Fact]
        public void Connection_ctor_initializes_properties()
        {
            var connection = new Connection("url");
            Assert.Equal("url/", connection.Url);
            Assert.Null(connection.QueryString);

            connection = new Connection("url", "qs");
            Assert.Equal("url/", connection.Url);
            Assert.Equal("qs", connection.QueryString);
        }
    }
}