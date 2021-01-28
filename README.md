# tpns-server-sdk/cs
## 概述
[腾讯移动推送](https://cloud.tencent.com/product/tpns) 是腾讯云提供的一款支持**百亿级**消息的移动App推送平台，开发者可以调用c# SDK访问腾讯移动推送服务。

## 使用说明
1. 接口和参数，可以参看[官网](https://cloud.tencent.com/document/product/548/39060) ，注意，本代码只支持推送接口。

2. 全量推送
   ```
   using System;
   using System.Collections.Generic;
   using Newtonsoft.Json;

   using tpns;

   class Program
   {
       static void Main(string[] args)
       {
           var ios = new iOSMessage();
           ios.custom = "{\"key\":\"value\"}";

           var req = TPNs.NewRequest(
                         With.AudienceType(Constants.AUDIENCE_ALL),
                         With.MessageType(Constants.MESSAGE_NOTIFY),
                         With.Platform(Constants.PLATFORM_IOS),
                         With.Title("this-title"),
                         With.Content("this-content"),
                         With.Environment(Constants.ENVIRONMENT_DEV),
                         With.IOSMessage(ios)
                     );

           string data = JsonConvert.SerializeObject(req);
           Console.WriteLine(data);
           var stub = new Stub(123456, "abcdef", Host.Guangzhou);
           var resp = stub.Push(req);
           Console.Write(resp.retCode.ToString() + " " + resp.errMsg + "\n");
       }
   }

   ```

3. 单设备推送
   ```
   using System;
   using System.Collections.Generic;
   using Newtonsoft.Json;

   using tpns;

   class Program
   {
       static void Main(string[] args)
       {
           var ios = new iOSMessage();
           ios.custom = "{\"key\":\"value\"}";

           var tokenList = new List<string>();
           tokenList.Add("token1");

           var req = TPNs.NewRequest(
                         With.AudienceType(Constants.AUDIENCE_TOKEN),
                         With.MessageType(Constants.MESSAGE_NOTIFY),
                         With.Platform(Constants.PLATFORM_IOS),
                         With.Title("this-title"),
                         With.Content("this-content"),
                         With.TokenList(tokenList),
                         With.Environment(Constants.ENVIRONMENT_DEV),
                         With.IOSMessage(ios)
                     );

           string data = JsonConvert.SerializeObject(req);
           Console.WriteLine(data);
           var stub = new Stub(123456, "abcdef", Host.Guangzhou);
           var resp = stub.Push(req);
           Console.Write(resp.retCode.ToString() + " " + resp.errMsg + "\n");
       }
   }

   ```
4. 设备列表推送
   ```
   using System;
   using System.Collections.Generic;
   using Newtonsoft.Json;

   using tpns;

   class Program
   {
       static void Main(string[] args)
       {
           var ios = new iOSMessage();
           ios.custom = "{\"key\":\"value\"}";

           var tokenList = new List<string>();
           tokenList.Add("token1");
           tokenList.Add("token2");

           var req = TPNs.NewRequest(
                         With.AudienceType(Constants.AUDIENCE_TOKEN_LIST),
                         With.MessageType(Constants.MESSAGE_NOTIFY),
                         With.Platform(Constants.PLATFORM_IOS),
                         With.Title("this-title"),
                         With.Content("this-content"),
                         With.TokenList(tokenList),
                         With.Environment(Constants.ENVIRONMENT_DEV),
                         With.IOSMessage(ios)
                     );

           string data = JsonConvert.SerializeObject(req);
           Console.WriteLine(data);
           var stub = new Stub(123456, "abcdef", Host.Guangzhou);
           var resp = stub.Push(req);
           Console.Write(resp.retCode.ToString() + " " + resp.errMsg + "\n");
       }
   }

   ```

5. 单账号推送
   ```
   using System;
   using System.Collections.Generic;
   using Newtonsoft.Json;

   using tpns;

   class Program
   {
       static void Main(string[] args)
       {
           var ios = new iOSMessage();
           ios.custom = "{\"key\":\"value\"}";

           var accountList = new List<string>();
           tokenList.Add("account1");

           var req = TPNs.NewRequest(
                         With.AudienceType(Constants.AUDIENCE_ACCOUNT),
                         With.MessageType(Constants.MESSAGE_NOTIFY),
                         With.Platform(Constants.PLATFORM_IOS),
                         With.Title("this-title"),
                         With.Content("this-content"),
                         With.TokenList(tokenList),
                         With.Environment(Constants.ENVIRONMENT_DEV),
                         With.IOSMessage(ios)
                     );

           string data = JsonConvert.SerializeObject(req);
           Console.WriteLine(data);
           var stub = new Stub(123456, "abcdef", Host.Guangzhou);
           var resp = stub.Push(req);
           Console.Write(resp.retCode.ToString() + " " + resp.errMsg + "\n");
       }
   }
 
   ```
   
6. 账号列表推送
   ```
   using System;
   using System.Collections.Generic;
   using Newtonsoft.Json;

   using tpns;

   class Program
   {
       static void Main(string[] args)
       {
           var ios = new iOSMessage();
           ios.custom = "{\"key\":\"value\"}";

           var accountList = new List<string>();
           tokenList.Add("account1");
           tokenList.Add("account2");

           var req = TPNs.NewRequest(
                         With.AudienceType(Constants.AUDIENCE_ACCOUNT_LIST),
                         With.MessageType(Constants.MESSAGE_NOTIFY),
                         With.Platform(Constants.PLATFORM_IOS),
                         With.Title("this-title"),
                         With.Content("this-content"),
                         With.TokenList(tokenList),
                         With.Environment(Constants.ENVIRONMENT_DEV),
                         With.IOSMessage(ios)
                     );

           string data = JsonConvert.SerializeObject(req);
           Console.WriteLine(data);
           var stub = new Stub(123456, "abcdef", Host.Guangzhou);
           var resp = stub.Push(req);
           Console.Write(resp.retCode.ToString() + " " + resp.errMsg + "\n");
       }
   }
   
   ```
   
7. 标签推送
   ```
   using System;
   using System.Collections.Generic;
   using Newtonsoft.Json;
   
   using tpns;

   class Program
   {
       static void Main(string[] args)
       {
           var ios = new iOSMessage();
           ios.custom = "{\"key\":\"value\"}";

           var tagItem1 = new TagRule.TagItem();
           tagItem1.tags = new List<string>();
           tagItem1.tags.Add("guangdong");
           tagItem1.tags.Add("hunan");
           tagItem1.tagsOperator = Constants.TAG_OPERATOR_OR;
           tagItem1.itemsOperator = Constants.TAG_OPERATOR_OR;
           tagItem1.tagType = "xg_auto_province";
    
           var tagItem2 = new TagRule.TagItem();
           tagItem2.tags = new List<string>();
           tagItem2.tags.Add("20200408");
           tagItem2.tagsOperator = Constants.TAG_OPERATOR_OR;
           tagItem2.itemsOperator = Constants.TAG_OPERATOR_AND;
           tagItem2.tagType = "xg_auto_active";
    
           var tagRule = new TagRule();
           tagRule.tagItems = new List<TagRule.TagItem>();
           tagRule.tagItems.Add(tagItem1);
           tagRule.tagItems.Add(tagItem2);
           tagRule.Operator =  Constants.TAG_OPERATOR_OR;
           
           var tagRules = new List<TagRule>();
           tagRules.Add(tagRule);
           var req = TPNs.NewRequest(
                         With.AudienceType(Constants.AUDIENCE_TAG),
                         With.MessageType(Constants.MESSAGE_NOTIFY),
                         With.Platform(Constants.PLATFORM_IOS),
                         With.Title("this-title"),
                         With.Content("this-content"),
                         With.TagRules(tagRules),
                         With.Environment(Constants.ENVIRONMENT_DEV),
                         With.IOSMessage(ios)
                     );
    
           string data = JsonConvert.SerializeObject(req);
           Console.WriteLine(data);
           var stub = new Stub(123456, "abcdef", Host.Guangzhou);
           var resp = stub.Push(req);
           Console.Write(resp.retCode.ToString() + " " + resp.errMsg + "\n");
        }
   }

   ```
8. 其它
   可以具体参看官网文档，填充Request结构体，然后调用Stub.Push发起请求。代码也提供了通过With.XXX方式来填充Request结构体
