using EF_Layer.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Bussiness_Logic
{
    public interface ILogic
    {
        List<Patient_M> GetAllPatient();
        Patient_M AddPatient(Patient_M patient);
        Patient_M UpdatePatient(Patient_M patient, int id);
        Patient_M GetByID(int id);
        int login(string email, string password);

        //visitdetails
        public Visit_Details_M AddVisitDetails(Visit_Details_M visit_Details_M);
        public List<Visit_Details_M> GetVisitDetailsById(int id);
        public Visit_Details_M GetParticularVisitById(int id);
        public Visit_Details_M GetVisitByAcceptanceNo(int id);


        //prescription
        public Prescription_M AddPrescription(Prescription_M prescription_M);
        public List<Prescription_M> GetPrescriptionById(int id);

        //patient Exist
        public bool PatientIsExist(string email);
        public bool isExistPhone(string phone);

        //Test

        public Test_M AddTest(Test_M test);

        public List<Test_M> GetTestList(int visitId);



        public int GetTestIdByName(string name);

        public Test_M UpdateTest(Test_M test, int Id);

        public Test DeleteTestByID(int id);





    }
}
