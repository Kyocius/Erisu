using Erisu.Model;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Erisu.Service.Network;

public class HttpHelper
{
    public static int BufferSize { get; set; } = 1024 * 1024;

    public static readonly HttpClient HttpClient;

    static HttpHelper() => HttpClient = new HttpClient();

    /// <summary>
    /// GET Method
    /// </summary>
    /// <param name="url"></param>
    /// <param name="authorization"></param>
    /// <param name="httpCompletionOption"></param>
    /// <returns></returns>
    public static async Task<HttpResponseMessage> HttpGetAsync(string url, Tuple<string, string> authorization = default, HttpCompletionOption httpCompletionOption = HttpCompletionOption.ResponseContentRead)
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

        if (authorization != null) 
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorization.Item1, authorization.Item2);

        var responseMessage = await HttpClient.SendAsync(requestMessage, httpCompletionOption, CancellationToken.None);

        if (responseMessage.StatusCode.Equals(HttpStatusCode.Found))
        {
            string redirectUrl = responseMessage.Headers.Location.AbsoluteUri;

            responseMessage.Dispose();
            GC.Collect();

            return await HttpGetAsync(redirectUrl, authorization, httpCompletionOption);
        }

        return responseMessage;
    }
}