using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Kubernetes
{
    public class Controller : IController
    {
        private HashSet<Pod> controlers = new HashSet<Pod>();

        public bool Contains(string podId)
        {
            var pod = controlers.Where(p=>p.Id == podId).FirstOrDefault();
            return controlers.Contains(pod);
        }

        public void Deploy(Pod pod)
        {
            if (!controlers.Contains(pod))
            {
                controlers.Add(pod);
            }
            else throw new ArgumentException();
        }

        public Pod GetPod(string podId)
        {
            var pod = controlers.Where(p => p.Id == podId).FirstOrDefault();
            
            if (pod!=null)
            {
                return pod;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            return controlers.Where(p => p.Port>= lowerBound && p.Port<=upperBound);
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
           return controlers.Where(p=>p.Namespace.Equals(@namespace));
        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            return controlers.OrderByDescending(p=>p.Port).ThenBy(p=>p.Namespace);
        }

        public int Size()=>controlers.Count;

        public void Uninstall(string podId)
        {
            var pod = controlers.Where(p => p.Id == podId).FirstOrDefault();
            if (pod!=null)
            {
                controlers.Remove(pod);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Upgrade(Pod pod)
        {
            if (!Contains(pod.Id))
            {
                controlers.Add(pod);
            }
            else
            {
                var oldPod = controlers.Where(p => p.Id == pod.Id).First();
                oldPod.ServiceName = pod.ServiceName;
                oldPod.Port = pod.Port;
                oldPod.Namespace = pod.Namespace;

                //Uninstall(pod.Id);
                //Deploy(pod);
            }
        }
    }
}