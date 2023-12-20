using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {
        private Dictionary<string, HashSet<Message>> messagesByChannel = new Dictionary<string, HashSet<Message>>();
        private Dictionary<string, Message> messages = new Dictionary<string, Message>();
        public int Count => messages.Count;

        public bool Contains(Message message)
        {
            return messages.ContainsKey(message.Id);
        }

        public void DeleteMessage(string messageId)
        {
            if (!messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
            Message message = GetMessage(messageId);
            messages.Remove(messageId);
            messagesByChannel[message.Channel].Remove(message);
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
        {
            return messages.Values.OrderByDescending(x => x.Reactions.Count).ThenBy(x=>x.Timestamp).ThenBy(x=>x.Content.Length);
        }

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            if (!messagesByChannel.ContainsKey(channel))
            {
                throw new ArgumentException();
            }
            return messagesByChannel[channel];

            
                
        }

        public Message GetMessage(string messageId)
        {
            if (!messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
            return messages.Values.FirstOrDefault(x => x.Id == messageId);

            
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            var msgs = messages.Values.Where(m => m.Timestamp >= lowerBound && m.Timestamp <= upperBound)
                                      .OrderByDescending(m => messagesByChannel[m.Channel].Count);
            return msgs;

            //Predicate<int> inRange = (x) => x >= lowerBound && x <= upperBound;
            //return messages.Values.Where(x => inRange(x.Timestamp)).OrderByDescending((msg) => messagesByChannel[msg.Channel].Count);
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
        {
            var msgs = messages.Values.Where(x => reactions.All(m => x.Reactions.Contains(m)))
                                      .OrderByDescending(z => z.Reactions.Count)
                                      .ThenBy(z => z.Timestamp);
                                      
            return msgs;            
        }

        public IEnumerable<Message> GetTop3MostReactedMessages()
        {
            return messages.Values.OrderByDescending(x => x.Reactions.Count).Take(3);
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            var msg = GetMessage(messageId);
            msg.Reactions.Add(reaction);

        }

        public void SendMessage(Message message)
        {
            messages.Add(message.Id, message);
            if (!messagesByChannel.ContainsKey(message.Channel))
            {
                messagesByChannel[message.Channel] = new HashSet<Message>();
            }            
            messagesByChannel[message.Channel].Add(message);
        }
    }
}
