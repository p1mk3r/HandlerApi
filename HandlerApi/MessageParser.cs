using HandlerApi.DTO;
using HandlerApi.Handlers;
using HandlerApi.Requests;
using MediatR;

namespace HandlerApi;

public static class MessageParser
{
    public static IRequest CreateRequestByMessageName(Message message)
    {
        switch (message.Name.ToLower())
        {
            case string str when str.Equals(SupportedHandlers.ReverseWords.ToString(), StringComparison.InvariantCultureIgnoreCase):
                return new ReverseWordsRequest { ValueToReverse = message.Value };
            
            case string str when str.Equals(SupportedHandlers.WordsCount.ToString(), StringComparison.InvariantCultureIgnoreCase):
                return new WordsCountRequest { Words = message.Value };

            default:
                throw new NotImplementedException($"Сообщение '{message.Name}' не поддерживается");
        }
    }
}