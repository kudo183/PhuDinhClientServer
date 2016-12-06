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

        public string Token { get; set; }

        public string[] GetGroups(string user)
        {
            var uri = GetUri("user", "getgroups");

            var data = new NameValueCollection();
            data["user"] = user;

            //choose json response type because when respone is a string, json is better than protobuf
            var response = PostValues(uri, data, "json");

            var text = GetStringFromBytes(response);

            var groups = text.Split(new string[] { "*&*" }, StringSplitOptions.RemoveEmptyEntries);

            return groups;
        }

        public void Login(string user, string pass)
        {
            var uri = GetUri("user", "login");

            var data = new NameValueCollection();
            data["user"] = user;
            data["pass"] = pass;

            //choose json response type because when respone is a string, json is better than protobuf
            var token = PostValues(uri, data, "json");

            Token = GetStringFromBytes(token);
        }

        public void AccessToken(string group)
        {
            var uri = GetUri("user", "accesstoken");

            var data = new NameValueCollection();
            data["group"] = group;

            //choose json response type because when respone is a string, json is better than protobuf
            var token = PostValues(uri, data, "json");

            Token = GetStringFromBytes(token);
        }

        public byte[] Post<T>(string controller, string action, QueryExpression qe) where T : DTO.IDto
        {
            var uri = GetUri(controller, action);

            return Post(uri, ToBytes(qe));
        }

        public string Save<T>(string controller, string action, List<DTO.ChangedItem<T>> changedItem)
        {
            var uri = GetUri(controller, action);

            var response = Post(uri, ToBytes(changedItem));

            return System.Text.Encoding.UTF8.GetString(response, 1, response.Length - 2);
        }

        public byte[] Report(string action, NameValueCollection reportParameters)
        {
            return PostValues(GetUri("report", action), reportParameters, "protobuf");
        }

        private byte[] PostValues(string uri, NameValueCollection reportParameters, string responseType)
        {
            var client = new MyWebClient();
            client.Headers["response"] = responseType;
            client.Headers["token"] = Token;

            return client.UploadValues(uri, reportParameters);
        }

        public T FromBytes<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                var r = ProtoBuf.Serializer.Deserialize<T>(ms);

                return r;
            }
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

        private byte[] ToBytes<T>(T data)
        {
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, data);
                return ms.ToArray();
            }
        }

        private string GetStringFromBytes(byte[] bytes)
        {
            //skip begin, end double quote
            return System.Text.Encoding.UTF8.GetString(bytes, 1, bytes.Length - 2);
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
