using System;
using System.Collections.Generic;

namespace tpns
{
    delegate void Option(Request req);

    class TPNs {
        public static Request NewRequest(params Option[] func)
        {
            var req = new Request();
            for (int i = 0; i < func.Length; i++)
            {
                func[i](req);
            }
            return req;
        }
    }

    class With {

        public static Option AudienceType(string audienceType)
        {
            return delegate(Request req) {
                req.audienceType = audienceType;
            };
        }

        public static Option Platform(string platform) 
        {
            return delegate(Request req) {
                req.platform = platform;
            };
        }

        public static Option Message(Message message)
        {
            return delegate(Request req) {
                req.message = message;
            };
        }

        public static Option Title(string title)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.title = title;
            };
        }

        public static Option Content(string content)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.content = content;
            };
        }

        public static Option AcceptTime(List<AcceptTimeRange> acceptTime)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.acceptTime = acceptTime;
            };
        }

        public static Option ThreadId(string threadId)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.threadId = threadId;
            };
        }

        public static Option ThreadSumText(string threadSumText)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.threadSumText = threadSumText;
            };
        }

        public static Option XGMediaResources(string xgMediaResources)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.xgMediaResources = xgMediaResources;
            };
        }

        public static Option XGMediaAudioResources(string xgMediaAudioResources)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.xgMediaAudioResources = xgMediaAudioResources;
            };
        }

        public static Option AndroidMessage(AndroidMessage android)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.android = android;
            };
        }

        public static Option IOSMessage(iOSMessage ios)
        {
            return delegate(Request req) {
                if (req.message == null){
                    req.message = new Message();
                }
                req.message.ios = ios;
            };
        }

        public static Option MessageType(string type)
        {
            return delegate(Request req) {
                req.messageType = type;
            };
        }

        public static Option TagRules(List<TagRule> tagRules)
        {
            return delegate(Request req) {
                req.tagRules = tagRules;
            };
        }

        public static Option TokenList(List<string> tokenList)
        {
            return delegate(Request req) {
                req.tokenList = tokenList;
            };
        }

        public static Option AccountList(List<string> accountList)
        {
            return delegate(Request req) {
                req.accountList = accountList;
            };
        }

        public static Option Environment(string environment)
        {
            return delegate(Request req) {
                req.environment = environment;
            };
        }

        public static Option UploadId(Int64 uploadId)
        {
            return delegate(Request req) {
                req.uploadId = uploadId;
            };
        }

        public static Option ExpireTime(int expireTime)
        {
            return delegate(Request req) {
                req.expireTime = expireTime;
            };
        }

        public static Option SendTime(string sendTime)
        {
            return delegate(Request req) {
                req.sendTime = sendTime;
            };
        }

        public static Option MultiPkg(bool multiPkg)
        {
            return delegate(Request req) {
                req.multiPkg = multiPkg;
            };
        }

        public static Option PlanId(string planId)
        {
            return delegate(Request req) {
                req.planId = planId;
            };
        }

        public static Option AccountPushType(int accountPushType)
        {
            return delegate(Request req) {
                req.accountPushType = accountPushType;
            };
        }

        public static Option CollapseId(Int64 collapseId)
        {
            return delegate(Request req) {
                req.collapseId = collapseId;
            };
        }

        public static Option PushSpeed(int pushSpeed)
        {
            return delegate(Request req) {
                req.pushSpeed = pushSpeed;
            };
        }

        public static Option TpnsOnlinePushType(int tpnsOnlinePushType)
        {
            return delegate(Request req) {
                req.tpnsOnlinePushType = tpnsOnlinePushType;
            };
        }

        public static Option ForceCollapse(bool forceCollapse)
        {
            return delegate(Request req) {
                req.forceCollapse = forceCollapse;
            };
        }

        public static Option ChannelRules(List<ChannelRule> channelRules)
        {
            return delegate(Request req) {
                req.channelRules = channelRules;
            };
        }

        public static Option LoopParam(LoopParam param)
        {
            return delegate(Request req) {
                req.loopParam = param;
            };
        }

    }
}

