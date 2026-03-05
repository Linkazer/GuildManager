using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace GuildManager
{
    /// <summary>
    /// Catains all data of an API's response.
    /// </summary>
    [Serializable]
    public class ApiErrorResponse
    {
        public Dictionary<string, List<string>> Errors { get; set; }
        public string Title { get; set; }
        public long Status { get; set; }

        /// <summary>
        /// Get the full error message in one string.
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            string message = $"Server Error : <b>{Title}</b> with status <b>{Status}</b>.\n";

            if (Errors != null)
            {
                foreach (KeyValuePair<string, List<string>> err in Errors)
                {
                    message += $"Error at <b>{err.Key}</b> : {err.Value[0]}\n";
                }
            }

            return message;
        }
    }

    /// <summary>
    /// Provides method to make requests to the server's API.
    /// </summary>
    public static class HttpRequests
    {
        private const string URI = "http://localhost:5181/api/";

        public static Action<ApiErrorResponse> OnErrorTriggered;

        /// <summary>
        /// Send a GET request to the server.
        /// </summary>
        /// <typeparam name="Returned">The type of data the server should send us.</typeparam>
        /// <param name="url">The URL used for the request.</param>
        /// <returns>The corresponding data deserialized as Returned type. If none was found, return NULL.</returns>
        public static async Task<Returned> Get<Returned>(string url) where Returned : class
        {
            UnityWebRequest getRequest = CreateRequest(url, RequestType.GET);
            await getRequest.SendWebRequest();

            if (GetRequestResult(getRequest))
            {
                return JsonConvert.DeserializeObject<Returned>(getRequest.downloadHandler.text);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Send a POST request to the server.
        /// </summary>
        /// <typeparam name="Returned">The type of data the server should send us.</typeparam>
        /// <param name="url">The URL used for the request.</param>
        /// <param name="data">The data to send to the server.</param>
        /// <returns>The posted data deserialized as Returned type. If the data wasn't correctely created, return NULL.</returns>
        public static async Task<Returned> Post<Returned>(string url, object data) where Returned : class
        {
            UnityWebRequest postRequest = CreateRequest(url, RequestType.POST, data);
            await postRequest.SendWebRequest();

            if (GetRequestResult(postRequest))
            {
                return JsonConvert.DeserializeObject<Returned>(postRequest.downloadHandler.text);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Send a PUT request to the server.
        /// </summary>
        /// <typeparam name="Returned">The type of data the server should send us.</typeparam>
        /// <param name="url">The URL used for the request.</param>
        /// <param name="data">The data to send to the server.</param>
        /// <returns>The updated data deserialized as Returned type. If the data wasn't correctely updated, return NULL.</returns>
        public static async Task<Returned> Put<Returned>(string url, object data) where Returned : class
        {
            UnityWebRequest putRequest = CreateRequest(url, RequestType.PUT, data);
            await putRequest.SendWebRequest();

            if (GetRequestResult(putRequest))
            {
                return JsonConvert.DeserializeObject<Returned>(putRequest.downloadHandler.text);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Send a DELETE request to the server.
        /// </summary>
        /// <param name="url">The URL used for the request.</param>
        /// <returns>Returns TRUE if the delete was successfull. Otherwise, return FALSE.</returns>
        public static async Task<bool> Delete(string url)
        {
            UnityWebRequest deleteRequest = CreateRequest(url, RequestType.DELETE);
            await deleteRequest.SendWebRequest();

            return GetRequestResult(deleteRequest);
        }

        /// <summary>
        /// Create a new request to the server.
        /// </summary>
        /// <param name="url">The URL used for the request.</param>
        /// <param name="type">The type of request we want to create.</param>
        /// <param name="data">The data to send with the request.</param>
        /// <returns></returns>
        private static UnityWebRequest CreateRequest(string url, RequestType type, object data = null)
        {
            string method = GetRequestMethod(type);

            UnityWebRequest request = new UnityWebRequest(URI + url, method);

            if (data != null)
            {
                var rawData = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
                request.uploadHandler = new UploadHandlerRaw(rawData);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            return request;
        }

        private static string GetRequestMethod(RequestType type)
        {
            switch (type)
            {
                case RequestType.GET:
                    return "GET";
                case RequestType.POST:
                    return "POST";
                case RequestType.PUT:
                    return "PUT";
                case RequestType.DELETE:
                    return "DELETE";
            }

            return "";
        }

        /// <summary>
        /// Get the result of a request.
        /// </summary>
        /// <param name="request">The request to get the result from.</param>
        /// <returns></returns>
        private static bool GetRequestResult(UnityWebRequest request)
        {
            ApiErrorResponse error = null;

            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    return true;
                case UnityWebRequest.Result.ConnectionError:
                    error = new ApiErrorResponse
                    {
                        Title = "Connection Error",
                        Status = request.responseCode
                    };
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    error = JsonConvert.DeserializeObject<ApiErrorResponse>(request.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    error = JsonConvert.DeserializeObject<ApiErrorResponse>(request.downloadHandler.text);
                    break;
            }

            if(error != null)
            {
                OnErrorTriggered?.Invoke(error);
            }

            return false;
        }
    }
}