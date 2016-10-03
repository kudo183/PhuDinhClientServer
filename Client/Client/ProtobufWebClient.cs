using QueryBuilder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace Client
{
    public sealed class ProtobufWebClient
    {
        private static readonly ProtobufWebClient _instance = new ProtobufWebClient();

        public static ProtobufWebClient Instance
        {
            get { return _instance; }
        }

        public DTO.PagingResultDto<T> Get<T>(string controller, string action)
            where T : DTO.IDto
        {
            var uri = GetUri(controller, action);

            var pagingResult = FromBytes<DTO.PagingResultDto<T>>(Get(uri));
            foreach (var item in pagingResult.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            return pagingResult;
        }

        public void Login(string user, string pass)
        {
            var uri = GetUri("user", "token");

            var data = new NameValueCollection();
            data["user"] = user;
            data["pass"] = pass;

            Token = Post(uri, data);
        }

        public string Token { get; set; }

        public DTO.PagingResultDto<T> Post<T>(string controller, string action, QueryExpression qe)
            where T : DTO.IDto
        {
            var uri = GetUri(controller, action);

            var pagingResult = FromBytes<DTO.PagingResultDto<T>>(Post(uri, ToBytes(qe)));
            foreach (var item in pagingResult.Items)
            {
                item.SetCurrentValueAsOriginalValue();
            }
            return pagingResult;
        }

        public string Save<T>(string controller, string action, List<DTO.ChangedItem<T>> changedItem)
        {
            var uri = GetUri(controller, action);

            var response = Post(uri, ToBytes(changedItem));

            return System.Text.Encoding.UTF8.GetString(response, 1, response.Length - 2);
        }

        private byte[] Get(string uri)
        {
            var client = new MyWebClient();
            client.Headers["response"] = "protobuf";
            client.Headers["token"] = Token;

            var response = client.DownloadData(uri);

            return response;
        }

        private byte[] Post(string uri, byte[] data)
        {
            var client = new MyWebClient();
            client.Headers["request"] = "protobuf";
            client.Headers["response"] = "protobuf";
            client.Headers["token"] = Token;

            var response = client.UploadData(uri, data);

            return response;
        }

        private string Post(string uri, NameValueCollection data)
        {
            var client = new MyWebClient();

            //choose json response type because when respone is a string, json is better than protobuf
            client.Headers["response"] = "json";

            var token = client.UploadValues(uri, data);

            //skip begin end double quote
            return System.Text.Encoding.UTF8.GetString(token, 1, token.Length - 2);
        }

        private T FromBytes<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                var r = ProtoBuf.Serializer.Deserialize<T>(ms);

                return r;
            }
        }

        private byte[] ToBytes<T>(T data)
        {
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, data);
                return ms.ToArray();
            }
        }

        private string GetUri(string controller, string action)
        {
            var uri = string.Format("{0}/{1}/{2}",
                Settings.Instance.UriRoot, controller, action);

            return uri;
        }

        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                return request;
            }
        }
    }
}
