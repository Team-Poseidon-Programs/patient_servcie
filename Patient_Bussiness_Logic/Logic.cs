using EF_Layer;
using Models;
using EF_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace Patient_Bussiness_Logic
{
    public class Logic : ILogic
    {
        Mapper map = new Mapper();
        EF_repo repo = new EF_repo();
        PatientInfoDbContext context = new PatientInfoDbContext();

        public List<Patient_M> GetAllPatient()
        {
            List<Patient_M> patients = new List<Patient_M>();

            foreach (var i in repo.GetAllPatient())
            {
                patients.Add(map.MapPatient(i));
            }

            return patients;
        }
        public Patient_M AddPatient(Patient_M patient)
        {
            return map.MapPatient(repo.AddPatient(map.mapPatient(patient)));
        }
        public Patient_M UpdatePatient(Patient_M patient, int id)
        {
            var pat = PatientbyID(id);

            pat.Id = patient.Id;
            pat.Email = patient.Email;
            pat.Title = patient.Title;
            pat.FirstName = patient.FirstName;
            pat.LastName = patient.LastName;
            pat.Dob = patient.Dob;
            pat.ContactNumber = patient.ContactNumber;
            pat.Password = patient.Password;
            pat.Gender = patient.Gender;
            pat.Address = patient.Address;

            return map.MapPatient(repo.UpdatePatient(pat));
        }
        public Patient_M GetByID(int id)
        {
            return map.MapPatient(repo.GetByID(id));
        }

        public Patient PatientbyID(int id)
        {
            return context.Patients.Where(ID => ID.Id == id).FirstOrDefault();
        }

        public int login(string email, string password)
        {
            return repo.login(email, password);
        }

        //visit details



        public Visit_Details_M AddVisitDetails(Visit_Details_M visit_Details_M)
        {
            return map.mapVisitDetailEM(repo.AddVisitDetails(map.mapVisitDetailME(visit_Details_M)));
        }



        public List<Visit_Details_M> GetVisitDetailsById(int id)
        {
            var q = repo.GetVisitById(id);
            List<Visit_Details_M> vii = new List<Visit_Details_M>();

            foreach (var i in q)
            {
                vii.Add(map.mapVisitDetailEM(i));
            }
            return vii;
        }

        public Visit_Details_M GetParticularVisitById(int id)
        {
            return map.mapVisitDetailEM(repo.GetPaticularVisitById(id));
        }

        public Visit_Details_M GetVisitByAcceptanceNo(int id)
        {
            return map.mapVisitDetailEM(repo.GetbyAcceptanceId(id));
        }

        //Prescription

        public Prescription_M AddPrescription(Prescription_M prescription_M)
        {
            return map.mapPrescriptionEM(repo.AddPrescription(map.mapPrescriptionME(prescription_M)));
        }

        public List<Prescription_M> GetPrescriptionById(int id)
        {
            var q = repo.GetPrescriptionById(id);

            List<Prescription_M> ms = new List<Prescription_M>();

            foreach (var i in q)
            {
                ms.Add(map.mapPrescriptionEM(i));
            }
            return ms;
        }

        public bool PatientIsExist(string email)
        {
            return repo.ExistingPatient(email);
        }

        public bool isExistPhone(string phone)
        {
            return repo.isExistPhone(phone);
        }



        //Test

        public Test_M AddTest(Test_M test)
        {
            return map.mapTestEM(repo.AddTest(map.mapTestME(test)));
        }

        public List<Test_M> GetTestList(int visitId)
        {
            List<Test_M> testList = new List<Test_M>();

            foreach (var e in repo.GetTestList(visitId))
            {
                testList.Add(map.mapTestEM(e));
            }

            return testList;
        }

        public int GetTestIdByName(string name)
        {
            return repo.GetTestIdByName(name);
        }

        public Test_M UpdateTest(Test_M test, int Id)
        {

            var uTest = TestById(Id);

            uTest.TestName = test.TestName;
            uTest.Notes = test.Notes;
            uTest.Result = test.Result;

            return map.mapTestEM(repo.UpdateTest(uTest));
        }
        public Test TestById(int id)
        {
            return context.Tests.FirstOrDefault(x => x.Id == id);

        }

        public Test DeleteTestByID(int id)
        {
            return map.mapTestME(map.mapTestEM(repo.DeleteTest(id)));
        }

    }
}
