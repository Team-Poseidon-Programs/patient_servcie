using EF_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Layer
{
    public interface IRepo
    {
        // patient info
        List<Patient> GetAllPatient();
        Patient AddPatient(Patient patient);
        Patient UpdatePatient(Patient patient);
        Patient GetByID(int id);

        int login(string email, string password);

        //for visit details

        VisitDetail AddVisitDetails(VisitDetail visitDetail);
        public List<VisitDetail> GetVisitById(int id);
        public VisitDetail GetPaticularVisitById(int id);
        public VisitDetail GetbyAcceptanceId(int id);



        //for prescription
        public Prescription AddPrescription(Prescription prescription);
        public List<Prescription> GetPrescriptionById(int id);


        //for test
        public Test AddTest(Test test);
        public List<Test> GetTestList(int visitId);

        public int GetTestIdByName(string name);
        public Test UpdateTest(Test test);
        public Test DeleteTest(int TestID);



    }
}
