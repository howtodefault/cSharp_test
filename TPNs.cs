using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace tpns
{
  
    static class Host
    {
        public const string Guangzhou = "api.tpns.tencent.com";
        public const string Shanghai  = "api.tpns.sh.tencent.com";
        public const string Hongkong  = "api.tpns.hk.tencent.com";
        public const string Singapore = "api.tpns.sgp.tencent.com";
    }

    static class Constants
    {
        //audience type
        public const string AUDIENCE_ALL            = "all";
        public const string AUDIENCE_TAG            = "tag";
        public const string AUDIENCE_TOKEN          = "token";
        public const string AUDIENCE_TOKEN_LIST     = "token_list";
        public const string AUDIENCE_ACCOUNT        = "account";
        public const string AUDIENCE_ACCOUNT_LIST   = "account_list";

        // tag operation type
        public const string TAG_OPERATOR_AND = "AND";
        public const string TAG_OPERATOR_OR  = "OR";

        // platform type
        public const string PLATFORM_ANDROID  = "android";
        public const string PLATFORM_IOS      = "ios";

        // message type
        public const string MESSAGE_NOTIFY  = "notify";
        public const string MESSAGE_MESSAGE = "message";

        // environment type
        public const string ENVIRONMENT_PROD = "product";
        public const string ENVIRONMENT_DEV  = "dev";
    }

    class AndroidMessage {
        public class Action {

            public class ActivityAttribute {
                [JsonProperty("if", NullValueHandling=NullValueHandling.Ignore)] 
                public int iff { get; set; }

                [JsonProperty("pf", NullValueHandling=NullValueHandling.Ignore)] 
                public int pf { get; set; }
            }

            public class BrowserAttribute {
                [JsonProperty("url", NullValueHandling=NullValueHandling.Ignore)] 
                public string url { get; set; }

                [JsonProperty("confirm", NullValueHandling=NullValueHandling.Ignore)]
                public int confirm { get; set; } = 0;
            }

            [JsonProperty("action_type", NullValueHandling=NullValueHandling.Ignore)] 
            public int actionType { get; set; } = 1;

            [JsonProperty("activity", NullValueHandling=NullValueHandling.Ignore)] 
            public string activity { get; set; }

            [JsonProperty("aty_attr", NullValueHandling=NullValueHandling.Ignore)] 
            public ActivityAttribute activityAttr { get; set; }

            [JsonProperty("browser", NullValueHandling=NullValueHandling.Ignore)] 
            public BrowserAttribute browser { get; set; }

            [JsonProperty("intent", NullValueHandling=NullValueHandling.Ignore)] 
            public string intent { get; set; }
        }

        [JsonProperty("n_ch_id", NullValueHandling=NullValueHandling.Ignore)] 
        public string chId { get; set; }

        [JsonProperty("n_ch_name", NullValueHandling=NullValueHandling.Ignore)] 
        public string chName { get; set; }

        [JsonProperty("xm_ch_id", NullValueHandling=NullValueHandling.Ignore)] 
        public string xmChId { get; set; }

        [JsonProperty("hw_ch_id", NullValueHandling=NullValueHandling.Ignore)] 
        public string hwChId { get; set; }

        [JsonProperty("oppo_ch_id", NullValueHandling=NullValueHandling.Ignore)] 
        public string oppoChId { get; set; }

        [JsonProperty("vivo_ch_id", NullValueHandling=NullValueHandling.Ignore)] 
        public string vivoChId { get; set; }

        [JsonProperty("builder_id", NullValueHandling=NullValueHandling.Ignore)] 
        public int buildId { get; set; } = 0;

        [JsonProperty("badge_type", NullValueHandling=NullValueHandling.Ignore)] 
        public int badgeType { get; set; } = -1;

        [JsonProperty("ring", NullValueHandling=NullValueHandling.Ignore)] 
        public int ring { get; set; } = 1;

        [JsonProperty("ring_raw", NullValueHandling=NullValueHandling.Ignore)] 
        public string ringRaw { get; set; }

        [JsonProperty("vibrate", NullValueHandling=NullValueHandling.Ignore)] 
        public int vibrate { get; set; } = 1;

        [JsonProperty("lights", NullValueHandling=NullValueHandling.Ignore)] 
        public int lights { get; set; } = 1;

        [JsonProperty("clearable", NullValueHandling=NullValueHandling.Ignore)] 
        public int clearable { get; set; } = 1;

        [JsonProperty("icon_type", NullValueHandling=NullValueHandling.Ignore)] 
        public int iconType { get; set; } = 0;

        [JsonProperty("icon_res", NullValueHandling=NullValueHandling.Ignore)] 
        public string iconRes { get; set; }

        [JsonProperty("style_id", NullValueHandling=NullValueHandling.Ignore)] 
        public int styleId { get; set; } = 0;

        [JsonProperty("small_icon", NullValueHandling=NullValueHandling.Ignore)] 
        public string smallIcon { get; set; }

        [JsonProperty("action", NullValueHandling=NullValueHandling.Ignore)] 
        public Action action { get; set; }

        [JsonProperty("custom_content", NullValueHandling=NullValueHandling.Ignore)] 
        public string customContent { get; set; }

        [JsonProperty("show_type", NullValueHandling=NullValueHandling.Ignore)] 
        public int showType { get; set; } = 2;

        [JsonProperty("icon_color", NullValueHandling=NullValueHandling.Ignore)] 
        public int iconColor { get; set; } = 0;
    }

    class iOSMessage {
        public class Aps {
            [JsonProperty("alert", NullValueHandling=NullValueHandling.Ignore)] 
            public Dictionary<string, string> alert { get; set; }

            [JsonProperty("badge_type", NullValueHandling=NullValueHandling.Ignore)] 
            public int badgeType { get; set; } = 0;

            [JsonProperty("category", NullValueHandling=NullValueHandling.Ignore)] 
            public string category { get; set; }

            [JsonProperty("content-available", NullValueHandling=NullValueHandling.Ignore)] 
            public int contentAvailable { get; set; } = 0;

            [JsonProperty("sound", NullValueHandling=NullValueHandling.Ignore)] 
            public string sound { get; set; }

            [JsonProperty("mutable-content", NullValueHandling=NullValueHandling.Ignore)] 
            public int mutableContent { get; set; } = 1;

        }
        [JsonProperty("aps", NullValueHandling=NullValueHandling.Ignore)] 
        public Aps aps { get; set; }

        [JsonProperty("custom", NullValueHandling=NullValueHandling.Ignore)] 
        public string custom { get; set; }
    }

    class TagRule {
        public class TagItem {
            [JsonProperty("tags", NullValueHandling=NullValueHandling.Ignore)] 
            public List<string> tags { get; set; }

            [JsonProperty("is_not", NullValueHandling=NullValueHandling.Ignore)] 
            public bool isNot { get; set; } = false;

            [JsonProperty("tags_operator", NullValueHandling=NullValueHandling.Ignore)] 
            public string tagsOperator { get; set; }

            [JsonProperty("items_operator", NullValueHandling=NullValueHandling.Ignore)] 
            public string itemsOperator { get; set; }

            [JsonProperty("tag_type", NullValueHandling=NullValueHandling.Ignore)] 
            public string tagType { get; set; }
        }

        [JsonProperty("tag_items", NullValueHandling=NullValueHandling.Ignore)] 
        public List<TagItem> tagItems { get; set; }

        [JsonProperty("is_not", NullValueHandling=NullValueHandling.Ignore)] 
        public bool isNot { get; set; } = false;

        [JsonProperty("operator", NullValueHandling=NullValueHandling.Ignore)] 
        public string Operator { get; set; }
    }

    class AcceptTimeRange {
        public class AcceptTime {
            [JsonProperty("hour", NullValueHandling=NullValueHandling.Ignore)] 
            public string hour { get; set; }

            [JsonProperty("min", NullValueHandling=NullValueHandling.Ignore)] 
            public string min { get; set; }
        }

        [JsonProperty("start", NullValueHandling=NullValueHandling.Ignore)] 
        public AcceptTime start { get; set; }

        [JsonProperty("end", NullValueHandling=NullValueHandling.Ignore)] 
        public AcceptTime end { get; set; }
    }

    class Message {
        [JsonProperty("title", NullValueHandling=NullValueHandling.Ignore)] 
        public string title { get; set; }

        [JsonProperty("content", NullValueHandling=NullValueHandling.Ignore)] 
        public string content { get; set; }

        [JsonProperty("accept_time", NullValueHandling=NullValueHandling.Ignore)] 
        public List<AcceptTimeRange> acceptTime { get; set; }

        [JsonProperty("thread_id", NullValueHandling=NullValueHandling.Ignore)] 
        public string threadId { get; set; }

        [JsonProperty("thread_sumtext", NullValueHandling=NullValueHandling.Ignore)] 
        public string threadSumText { get; set; }

        [JsonProperty("xg_media_resources", NullValueHandling=NullValueHandling.Ignore)] 
        public string xgMediaResources { get; set; }

        [JsonProperty("xg_media_audio_resources", NullValueHandling=NullValueHandling.Ignore)] 
        public string xgMediaAudioResources { get; set; }

        [JsonProperty("android", NullValueHandling=NullValueHandling.Ignore)] 
        public AndroidMessage android { get; set; }

        [JsonProperty("ios", NullValueHandling=NullValueHandling.Ignore)] 
        public iOSMessage ios { get; set; }
    }

    class ChannelRule {
        [JsonProperty("channel", NullValueHandling=NullValueHandling.Ignore)] 
        public string channel { get; set; }

        [JsonProperty("disable", NullValueHandling=NullValueHandling.Ignore)] 
        public bool disable { get; set; }
    }

    class LoopParam {
        [JsonProperty("startDate", NullValueHandling=NullValueHandling.Ignore)] 
        public string startDate { get; set; }

        [JsonProperty("endDate", NullValueHandling=NullValueHandling.Ignore)] 
        public string endDate { get; set; }

        [JsonProperty("loopType", NullValueHandling=NullValueHandling.Ignore)] 
        public int loopType { get; set; } = 0;

        [JsonProperty("loopDayIndexs", NullValueHandling=NullValueHandling.Ignore)] 
        public List<uint> loopDayIndexs { get; set; }

        [JsonProperty("DayTimes", NullValueHandling=NullValueHandling.Ignore)] 
        public List<string> dayTimes { get; set; }
    }

    class Request {
        [JsonProperty("audience_type", NullValueHandling=NullValueHandling.Ignore)] 
        public string audienceType { get; set; }

        [JsonProperty("platform", NullValueHandling=NullValueHandling.Ignore)] 
        public string platform{ get; set; }

        [JsonProperty("message", NullValueHandling=NullValueHandling.Ignore)] 
        public Message message { get; set; }

        [JsonProperty("message_type", NullValueHandling=NullValueHandling.Ignore)] 
        public string messageType { get; set; }

        [JsonProperty("tag_rules", NullValueHandling=NullValueHandling.Ignore)] 
        public List<TagRule> tagRules { get; set; }

        [JsonProperty("token_list", NullValueHandling=NullValueHandling.Ignore)] 
        public List<string> tokenList { get; set; }

        [JsonProperty("account_list", NullValueHandling=NullValueHandling.Ignore)] 
        public List<string> accountList { get; set; }

        [JsonProperty("environment", NullValueHandling=NullValueHandling.Ignore)] 
        public string environment { get; set; }

        [JsonProperty("upload_id", NullValueHandling=NullValueHandling.Ignore)] 
        public Int64 uploadId { get; set; } = 0;

        [JsonProperty("expire_time", NullValueHandling=NullValueHandling.Ignore)] 
        public int expireTime { get; set; } = 259200;

        [JsonProperty("send_time", NullValueHandling=NullValueHandling.Ignore)] 
        public string sendTime { get; set; }

        [JsonProperty("multi_pkg", NullValueHandling=NullValueHandling.Ignore)] 
        public bool multiPkg { get; set; } = false;

        [JsonProperty("plan_id", NullValueHandling=NullValueHandling.Ignore)] 
        public string planId { get; set; }

        [JsonProperty("account_push_type", NullValueHandling=NullValueHandling.Ignore)] 
        public int accountPushType { get; set; } = 0;

        [JsonProperty("collapse_id", NullValueHandling=NullValueHandling.Ignore)] 
        public Int64 collapseId { get; set; } = 0;

        [JsonProperty("push_speed", NullValueHandling=NullValueHandling.Ignore)] 
        public int pushSpeed { get; set; } = 0;

        [JsonProperty("tpns_online_push_type", NullValueHandling=NullValueHandling.Ignore)] 
        public int tpnsOnlinePushType { get; set; } = 0;

        [JsonProperty("force_collapse", NullValueHandling=NullValueHandling.Ignore)] 
        public bool forceCollapse { get; set; } = false;

        [JsonProperty("channel_rules", NullValueHandling=NullValueHandling.Ignore)] 
        public List<ChannelRule> channelRules { get; set; }

        [JsonProperty("loop_param", NullValueHandling=NullValueHandling.Ignore)] 
        public LoopParam loopParam { get; set; }

        public void Validate() {
            if (audienceType == null || audienceType.Length == 0) {
                throw new ArgumentException("audienceType is empty");
            }

            if (audienceType != Constants.AUDIENCE_ALL
                    && audienceType != Constants.AUDIENCE_TAG
                    && audienceType != Constants.AUDIENCE_TOKEN
                    && audienceType != Constants.AUDIENCE_TOKEN_LIST
                    && audienceType != Constants.AUDIENCE_ACCOUNT
                    && audienceType != Constants.AUDIENCE_ACCOUNT_LIST)
            {
                throw new ArgumentException("invalid audience_type", audienceType);
            }

            if (audienceType == Constants.AUDIENCE_TOKEN || audienceType == Constants.AUDIENCE_TOKEN_LIST) 
            {
                if (tokenList == null || tokenList.Count == 0)
                {
                    throw new ArgumentException("tokenList is empty");
                }
            }

            if (audienceType == Constants.AUDIENCE_ACCOUNT || audienceType == Constants.AUDIENCE_ACCOUNT_LIST) 
            {
                if (accountList == null || accountList.Count == 0)
                {
                    throw new ArgumentException("accountList is empty");
                }
            }

            if (audienceType == Constants.AUDIENCE_TAG && (tagRules == null || tagRules.Count == 0))
            {
                throw new ArgumentException("tagRules is empty");
            }

            if (platform == null || platform.Length == 0) 
            {
                throw new ArgumentException("platform is empty");
            }

            if (platform != Constants.PLATFORM_IOS && platform != Constants.PLATFORM_ANDROID)
            {
                throw new ArgumentException("invalid platform", platform);
            }

            if (platform == Constants.PLATFORM_IOS)
            {
                if (environment == null || environment.Length == 0)
                {
                    throw new ArgumentException("environment is empty");
                }

                if (environment != Constants.ENVIRONMENT_PROD && environment != Constants.ENVIRONMENT_DEV)
                {
                    throw new ArgumentException("invalid environment", platform);
                }
            }

            if (messageType == null || messageType.Length == 0)
            {
                throw new ArgumentException("messageType is empty");
            }

            if (messageType != Constants.MESSAGE_NOTIFY && messageType != Constants.MESSAGE_MESSAGE)
            {
                throw new ArgumentException("invalid messageType", messageType);
            }

            if (message == null) 
            {
                throw new ArgumentException("message is empty");
            }


        }
    }

    class Response {
        [JsonProperty("ret_code", NullValueHandling=NullValueHandling.Ignore)] 
        public int retCode { get; set; }

        [JsonProperty("err_msg", NullValueHandling=NullValueHandling.Ignore)] 
        public string errMsg { get; set; }

        [JsonProperty("push_id", NullValueHandling=NullValueHandling.Ignore)] 
        public object pushId { get; set; }

        [JsonProperty("result", NullValueHandling=NullValueHandling.Ignore)] 
        public string result { get; set; }
    }

    class Stub {
        private string signature;
        private string host;

        public Stub(uint accessId, string secretKey, string address)
        {
            var tmp = accessId.ToString() + ":" + secretKey;
            signature = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(tmp));

            host = address;
            if (address.IndexOf("http://") < 0 && address.IndexOf("https://") < 0) {
                host = "https://" + host;
            }
        }

        public Response Push(Request request) 
        {
            request.Validate();

            string data = JsonConvert.SerializeObject(request);
            var body = new StringContent(data, Encoding.UTF8, "application/json");
            var url = host + "/v3/push/app";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization","Basic " + signature);
                var response = client.PostAsync(url, body).Result;

                string result = response.Content.ReadAsStringAsync().Result;
                Response resp = JsonConvert.DeserializeObject<Response>(result);
                return resp;
            }
        }
    }
}
