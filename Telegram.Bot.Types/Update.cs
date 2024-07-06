using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Payments;

namespace Telegram.Bot.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Update
{
    [CompilerGenerated]
    private IntPtr intptr_0;

    [CompilerGenerated]
    private object object_0;

    [CompilerGenerated]
    private object object_1;

    [CompilerGenerated]
    private object object_2;

    [CompilerGenerated]
    private object object_3;

    [CompilerGenerated]
    private object object_4;

    [CompilerGenerated]
    private object object_5;

    [CompilerGenerated]
    private object object_6;

    [CompilerGenerated]
    private object object_7;

    [CompilerGenerated]
    private object object_8;

    [CompilerGenerated]
    private object a;

    [CompilerGenerated]
    private object b;

    [CompilerGenerated]
    private object c;

    [CompilerGenerated]
    private object d;

    [JsonProperty("update_id", Required = Required.Always)]
    public int Id
    {
        [CompilerGenerated]
        get
        {
            return (int)(nint)intptr_0;
        }
        [CompilerGenerated]
        set
        {
            intptr_0 = (IntPtr)value;
        }
    }

    [JsonProperty("message", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Message Message
    {
        [CompilerGenerated]
        get
        {
            return (Message)object_0;
        }
        [CompilerGenerated]
        set
        {
            object_0 = value;
        }
    }

    [JsonProperty("edited_message", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Message EditedMessage
    {
        [CompilerGenerated]
        get
        {
            return (Message)object_1;
        }
        [CompilerGenerated]
        set
        {
            object_1 = value;
        }
    }

    [JsonProperty("inline_query", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public InlineQuery InlineQuery
    {
        [CompilerGenerated]
        get
        {
            return (InlineQuery)object_2;
        }
        [CompilerGenerated]
        set
        {
            object_2 = value;
        }
    }

    [JsonProperty("chosen_inline_result", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChosenInlineResult ChosenInlineResult
    {
        [CompilerGenerated]
        get
        {
            return (ChosenInlineResult)object_3;
        }
        [CompilerGenerated]
        set
        {
            object_3 = value;
        }
    }

    [JsonProperty("callback_query", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public CallbackQuery CallbackQuery
    {
        [CompilerGenerated]
        get
        {
            return (CallbackQuery)object_4;
        }
        [CompilerGenerated]
        set
        {
            object_4 = value;
        }
    }

    [JsonProperty("channel_post", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Message ChannelPost
    {
        [CompilerGenerated]
        get
        {
            return (Message)object_5;
        }
        [CompilerGenerated]
        set
        {
            object_5 = value;
        }
    }

    [JsonProperty("edited_channel_post", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Message EditedChannelPost
    {
        [CompilerGenerated]
        get
        {
            return (Message)object_6;
        }
        [CompilerGenerated]
        set
        {
            object_6 = value;
        }
    }

    [JsonProperty("shipping_query", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ShippingQuery ShippingQuery
    {
        [CompilerGenerated]
        get
        {
            return (ShippingQuery)object_7;
        }
        [CompilerGenerated]
        set
        {
            object_7 = value;
        }
    }

    [JsonProperty("pre_checkout_query", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public PreCheckoutQuery PreCheckoutQuery
    {
        [CompilerGenerated]
        get
        {
            return (PreCheckoutQuery)object_8;
        }
        [CompilerGenerated]
        set
        {
            object_8 = value;
        }
    }

    [JsonProperty("poll", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public Poll Poll
    {
        [CompilerGenerated]
        get
        {
            return (Poll)a;
        }
        [CompilerGenerated]
        set
        {
            a = value;
        }
    }

    [JsonProperty("poll_answer", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public PollAnswer PollAnswer
    {
        [CompilerGenerated]
        get
        {
            return (PollAnswer)b;
        }
        [CompilerGenerated]
        set
        {
            b = value;
        }
    }

    [JsonProperty("my_chat_member", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChatMemberUpdated MyChatMemberUpdated
    {
        [CompilerGenerated]
        get
        {
            return (ChatMemberUpdated)c;
        }
        [CompilerGenerated]
        set
        {
            c = value;
        }
    }

    [JsonProperty("chat_member", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public ChatMemberUpdated ChatMemberUpdated
    {
        [CompilerGenerated]
        get
        {
            return (ChatMemberUpdated)d;
        }
        [CompilerGenerated]
        set
        {
            d = value;
        }
    }

    public UpdateType Type
    {
        get
        {
            if (Message != null)
            {
                return UpdateType.Message;
            }
            if (InlineQuery == null)
            {
                if (ChosenInlineResult != null)
                {
                    return UpdateType.ChosenInlineResult;
                }
                if (CallbackQuery == null)
                {
                    if (EditedMessage != null)
                    {
                        return UpdateType.EditedMessage;
                    }
                    if (ChannelPost == null)
                    {
                        if (EditedChannelPost == null)
                        {
                            if (ShippingQuery == null)
                            {
                                if (PreCheckoutQuery == null)
                                {
                                    if (Poll != null)
                                    {
                                        return UpdateType.Poll;
                                    }
                                    if (PollAnswer == null)
                                    {
                                        if (MyChatMemberUpdated != null)
                                        {
                                            return UpdateType.MyChatMemberUpdated;
                                        }
                                        if (ChatMemberUpdated != null)
                                        {
                                            return UpdateType.ChatMemberUpdated;
                                        }
                                        return UpdateType.Unknown;
                                    }
                                    return UpdateType.PollAnswer;
                                }
                                return UpdateType.PreCheckoutQuery;
                            }
                            return UpdateType.ShippingQuery;
                        }
                        return UpdateType.EditedChannelPost;
                    }
                    return UpdateType.ChannelPost;
                }
                return UpdateType.CallbackQuery;
            }
            return UpdateType.InlineQuery;
        }
    }
}
