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

        //var resp = stub.Push(req);
        //Console.Write(resp.ret_code.ToString() + " " + resp.err_msg + "\n");
    }
}
