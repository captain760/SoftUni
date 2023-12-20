namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FitGym : IGym
    {
        private Dictionary<int, Member> members = new Dictionary<int, Member>();
        private Dictionary<int, Trainer> trainers = new Dictionary<int, Trainer>();

        public void AddMember(Member member)
        {
            if (members.ContainsKey(member.Id))
            {
                throw new ArgumentException();
            }
            members.Add(member.Id, member);
        }

        public void HireTrainer(Trainer trainer)
        {
           if (trainers.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }
           trainers.Add(trainer.Id, trainer);   
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!members.ContainsKey(member.Id))
            {
                members.Add(member.Id, member);
            }
            if (!trainers.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }
            if (members[member.Id].Trainer != null)
            {
                throw new ArgumentException();
            }
            member.Trainer = trainer;
            members[member.Id].Trainer = trainer;
            trainers[trainer.Id].Members.Add(member);

           
        }

        public bool Contains(Member member)
        {
            return members.ContainsKey(member.Id);
        }

        public bool Contains(Trainer trainer)
        {
            return trainers.ContainsKey(trainer.Id);
        }

        public Trainer FireTrainer(int id)
        {
            if (!trainers.ContainsKey(id))
            {
                throw new ArgumentException();
            }
            Trainer tr = trainers[id];
            trainers.Remove(id);
            foreach (var m in members.Values)
            {
                if (m.Trainer.Id == id)
                {
                    m.Trainer = null;
                }
            }
            return tr;
        }

        public Member RemoveMember(int id)
        {
            if (!members.ContainsKey(id))
            {
                throw new ArgumentException();
            }
            Member member = members[id];
            members.Remove(id);
            foreach(var t in trainers.Values)
            {
                if (t.Members.Contains(member))
                {
                    t.Members.Remove(member);
                }
            } 
            return member;
        }

        public int MemberCount => members.Count;
        public int TrainerCount => trainers.Count;

        public IEnumerable<Member> 
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            return members.Values.OrderBy(x => x.RegistrationDate)
                                 .ThenByDescending(n => n.Name);
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            return trainers.Values.OrderBy(p => p.Popularity);
        }

        public IEnumerable<Member> 
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
           return trainers[trainer.Id].Members.OrderBy(x => x.RegistrationDate)
                                              .ThenBy(n=>n.Name);
        }

        public IEnumerable<Member> 
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
           return members.Values.Where(x=>x.Trainer.Popularity>=lo && x.Trainer.Popularity<=hi)
                                .OrderBy(v=>v.Visits)
                                .ThenBy(n=>n.Name);
        }

        public Dictionary<Trainer, HashSet<Member>> 
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            Dictionary<Trainer, HashSet<Member>> resultNotSorted = new Dictionary<Trainer, HashSet<Member>>();
            foreach(var tr in trainers.Values) 
            {
                resultNotSorted.Add(tr,tr.Members);
            }
            return resultNotSorted.OrderBy(x=>x.Key.Members.Count)
                                  .ThenBy(x=>x.Key.Popularity)
                                  .ToDictionary(x=>x.Key, y=>y.Value);
        }
    }
}