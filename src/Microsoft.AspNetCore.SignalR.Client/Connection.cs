// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;

namespace Microsoft.AspNetCore.SignalR.Client
{
    public class Connection
    {
        public Connection(string url)
            : this(url, null)
        {
        }

        public Connection(string url, string queryString)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.Contains("?"))
            {
                throw new ArgumentException(Resources.Error_UrlCantContainQueryStringDirectly, nameof(url));
            }

            if (!url.EndsWith("/", StringComparison.Ordinal))
            {
                url += "/";
            }

            Url = url;
            QueryString = queryString;
        }


        public string Url { get; }

        public string QueryString { get; }
    }
}