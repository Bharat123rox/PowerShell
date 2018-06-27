// Copyright 2018 (c) Nutanix. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the repository root for full license information.
// Purpose: Utility source for 'Nutanix.PowerShell.SDK'
// Author: Nutanix
// Copyright: Nutanix, 2018
// Owner: PowerShell@nutanix.com
// Maintainer(s):
//   Jon Kohler  (Nutanix, JonKohler)
//   Alex Guo    (Nutanix, mallochine)

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Management.Automation;

using Newtonsoft.Json;

namespace Nutanix.PowerShell.SDK
{
  public static class NtnxUtil
  {
    public static string Server { get; set; }

    public static HttpClient Client { get; set; }

    // Holds username and password.
    // TODO: might need to GC PSCreds.Password (SecureString) using Dispose
    // method.
    public static PSCredential PSCreds { get; set; }

    // Returns the JSON response a string. Responsibility of caller to parse.
    public static dynamic RestCall(
      string path,
      string requestMethod,
      string requestBody)
    {
      if (string.IsNullOrEmpty(Server) || NtnxUtil.PSCreds == null)
      {
        // TODO: throw exception.
        return null;
      }

      String basePath = "/api/nutanix/v3/";
      HttpResponseMessage result;
      switch (requestMethod)
      {
        case "GET":
          result = Client.GetAsync(new Uri(basePath + path)).Result;
          break;
        case "POST":
          var content = new StringContent(
            requestBody, Encoding.UTF8, "application/json");
          result = Client.PostAsync(new Uri(basePath + path), content).Result;
          content.Dispose();
          break;
        default:
          throw new NtnxException("Invalid HTTP request method: " +
              requestMethod);
      }

      string resultContent = result.Content.ReadAsStringAsync().Result;
      return JsonConvert.DeserializeObject(resultContent);
    }

    public static T[] FromJson<T>(dynamic json, Func<dynamic, T> creator)
    {
      return ((IEnumerable<T>)Enumerable.Select(json.entities, (Func<dynamic, T>)(entity => creator(entity)))).ToArray();
    }

    public static dynamic PassThroughNonNull(string nullcheck)
    {
      if (nullcheck == null)
      {
        throw new NtnxException();
      }

      return true;
    }

    // Return HTTPS header string that will be the auth header for communicating
    // with Nutanix cluster.
    public static string GetAuthHeader()
    {
      var creds = NtnxUtil.PSCreds.GetNetworkCredential();
      string username = creds.UserName;
      string password = creds.Password;
      var encoding = System.Text.Encoding.GetEncoding("UTF-8");
      var encodedAuth = encoding.GetBytes(username + ":" + password);
      string authHeader = System.Convert.ToBase64String(encodedAuth);
      return authHeader;
    }
  }
}