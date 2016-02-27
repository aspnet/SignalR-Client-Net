// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Text;

namespace Microsoft.AspNet.SignalR.Client.Infrastructure
{
    internal static class UrlBuilder
    {
        private static void AppendTransport(StringBuilder urlStringBuilder, string transport)
        {
            if (transport != null)
            {
                urlStringBuilder
                    .Append("&transport=").Append(transport);
            }
        }

        private static void AppendConnectionData(StringBuilder urlStringBuilder, string connectionData)
        {
            if (!string.IsNullOrEmpty(connectionData))
            {
                urlStringBuilder.Append("&connectionData=").Append(connectionData);
            }
        }

        private static void AppendConnectionToken(StringBuilder urlStringBuilder, string connectionToken)
        {
            if (!string.IsNullOrEmpty(connectionToken))
            {
                urlStringBuilder.Append("&connectionToken=").Append(connectionToken);
            }
        }

        private static void AppendQueryString(StringBuilder urlStringBuilder, string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                return;
            }

            if (queryString[0] != '&')
            {
                urlStringBuilder.Append("&");
            }

            if (queryString[0] != '?')
            {
                urlStringBuilder.Append(queryString);
            }
            else
            {
                urlStringBuilder.Append(queryString.Substring(1));
            }
        }

        private static string BuildUrl(string command, string url, string transport, string connectionToken,
             string connectionData, string queryString)
        {
            Debug.Assert(url.EndsWith("/"), "Url should end with slash");

            var urlStringBuilder = new StringBuilder(url);
            urlStringBuilder
                .Append(command)
                .Append("?clientProtocol=1.4");

            AppendTransport(urlStringBuilder, transport);
            AppendConnectionToken(urlStringBuilder, connectionToken);
            AppendConnectionData(urlStringBuilder, connectionData);
            AppendQueryString(urlStringBuilder, queryString);

            return urlStringBuilder.ToString();
        }

        public static string BuildNegotiate(string url, string connectionData, string queryString)
        {
            return BuildUrl("negotiate", url, /*transport*/ null, /*connectionToken*/ null,
                connectionData, queryString).ToString();
        }
    }
}