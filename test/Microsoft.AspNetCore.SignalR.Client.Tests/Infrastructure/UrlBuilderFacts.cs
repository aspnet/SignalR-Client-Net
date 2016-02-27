// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.AspNet.SignalR.Client.Infrastructure
{
    public class UrlBuilderFacts
    {
        public class BuildNegotiate
        {
            [Theory]
            [InlineData(null, "")]
            [InlineData("", "")]
            [InlineData("MyConnectionData", "&connectionData=MyConnectionData")]
            public void BuildNegotiateReturnsValidUrlWithConnectionData(string connectionData, string expected)
            {
                var url = "http://fakeurl/";
                Assert.Equal(
                     url + "negotiate?clientProtocol=1.4" + expected,
                    UrlBuilder.BuildNegotiate(url, connectionData, null));
            }

            [Theory]
            [InlineData("bob=12345", "&bob=12345")]
            [InlineData("bob=12345&foo=leet&baz=laskjdflsdk", "&bob=12345&foo=leet&baz=laskjdflsdk")]
            [InlineData("", "")]
            [InlineData(null, "")]
            [InlineData("?foo=bar", "&foo=bar")]
            [InlineData("?foo=bar&baz=bear", "&foo=bar&baz=bear")]
            [InlineData("&foo=bar", "&foo=bar")]
            [InlineData("&foo=bar&baz=bear", "&foo=bar&baz=bear")]
            public void BuildNegotiateReturnsValidUrlWithCustomQueryString(string qs, string expected)
            {
                var url = "http://fakeurl/";

                Assert.Equal("http://fakeurl/negotiate?clientProtocol=1.4" + expected,
                    UrlBuilder.BuildNegotiate(url, null, qs));
            }
        }
    }
}