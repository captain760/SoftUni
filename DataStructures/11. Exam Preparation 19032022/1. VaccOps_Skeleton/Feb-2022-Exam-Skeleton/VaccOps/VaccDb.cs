namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class VaccDb : IVaccOps
    {
        private Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
        private Dictionary<string, Patient> patients = new Dictionary<string, Patient>();

        public void AddDoctor(Doctor doctor)
        {
           if (Exist(doctor))
            {
                throw new ArgumentException();
            }
           doctors.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!Exist(doctor) || Exist(patient))
            {
                throw new ArgumentException();
            }
           
            patients.Add(patient.Name,patient);
            doctors[doctor.Name].Patients.Add(patient);
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!Exist(oldDoctor) || !Exist(newDoctor) || !Exist(patient))
            {
                throw new ArgumentException();
            }
            
                newDoctor.Patients.Add(patient);            
            
                oldDoctor.Patients.Remove(patient);
        }

        public bool Exist(Doctor doctor)
        {
            return doctors.ContainsKey(doctor.Name);
        }

        public bool Exist(Patient patient)
        {
            return patients.ContainsKey(patient.Name);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return doctors.Values;
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            return doctors.Values.Where(x=>x.Popularity == populariry);
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            return doctors.Values.OrderByDescending(x=>x.Patients.Count()).ThenBy(x=>x.Name);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return patients.Values;
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return patients.Values.Where(x=>x.Town == town);
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return patients.Values.Where(x=>x.Age>=lo&&x.Age<=hi);
        }

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            return patients.Values.OrderBy(x=>doctors.Values.FirstOrDefault(y=>y.Patients.Contains(x)).Popularity).ThenByDescending(z=>z.Height).ThenBy(z=>z.Age);  
        }

        public Doctor RemoveDoctor(string name)
        {
            if (!doctors.ContainsKey(name))
            {
                throw new ArgumentException();
            }
            var patientsForDeleting = new List<Patient>();
            foreach (Patient pat in doctors[name].Patients)
            {
                patientsForDeleting.Add(pat);
            }
            foreach (Patient pat in patientsForDeleting)
            {
                patients.Remove(pat.Name); 
            }
            var docToRemove = doctors[name];
            doctors.Remove(name);
            return docToRemove;
        }
    }
}
