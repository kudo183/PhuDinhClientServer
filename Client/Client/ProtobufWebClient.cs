using System.IO;

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

        public T Get<T>(string controller, string action, string json)
        {
            var uri = string.Format("{0}/{1}/{2}?json={3}",
                Settings.Instance.UriRoot, controller, action, json);

            return Get<T>(uri);
        }

        public T Get<T>(string controller, string action)
        {
            var uri = string.Format("{0}/{1}/{2}",
                Settings.Instance.UriRoot, controller, action);

            return Get<T>(uri);
        }

        public T Get<T>(string uri)
        {
            var client = System.Net.WebRequest.CreateHttp(uri);
            client.Headers["response"] = "protobuf";
            client.Headers["token"] = Token;
            var response = client.GetResponse();
            var responseStream = response.GetResponseStream();

            var ms = new MemoryStream();
            responseStream.CopyTo(ms, 4096);
            ms.Position = 0;

            var r = ProtoBuf.Serializer.Deserialize<T>(ms);

            return r;
        }
    }
}
