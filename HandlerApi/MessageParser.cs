using HandlerApi.DTO;
using HandlerApi.Handlers;
using HandlerApi.Requests;

namespace HandlerApi;

public static class MessageParser
{
    public static Request CreateRequestByMessageName(Message message) 
    {
        switch (message.Name.ToLower())
        {
            case string str when str.Equals(SupportedHandlers.ReverseWords.ToString(), StringComparison.InvariantCultureIgnoreCase):
                return new ReverseWordsRequest { Value = message.Value };
            
            case string str when str.Equals(SupportedHandlers.WordsCount.ToString(), StringComparison.InvariantCultureIgnoreCase):
                return new WordsCountRequest { Value = message.Value };          
            
            case string str when str.Equals(SupportedHandlers.TwoDigitsSum.ToString(), StringComparison.InvariantCultureIgnoreCase):
                return new TwoDigitsSumRequest { Value = message.Value };

            default:
                throw new NotImplementedException($"Сообщение '{message.Name}' не поддерживается");
        }
    }
}