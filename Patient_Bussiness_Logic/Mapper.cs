using Models;
using EF_Layer.Entities;

namespace Patient_Bussiness_Logic
{
    public class Mapper
    {
        // model to entity
        public Patient mapPatient(Patient_M patient)
        {
            return new Patient()
            {
                Id = patient.Id,
                Email = patient.Email,
                Title = patient.Title,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Dob = patient.Dob,
                ContactNumber = patient.ContactNumber,
                Password = patient.Password,
                Gender = patient.Gender,
                Address = patient.Address
            };
        }

        // entity to model
        public Patient_M MapPatient(Patient patient)
        {
            return new Patient_M()
            {
                Id = patient.Id,
                Email = patient.Email,
                Title = patient.Title,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Dob = patient.Dob,
                ContactNumber = patient.ContactNumber,
                Password = patient.Password,
                Gender = patient.Gender,
                Address = patient.Address
            };
        }

        //Visit Detail


        public VisitDetail mapVisitDetailME(Visit_Details_M visit_Details_M)
        {
            return new VisitDetail()
            {
                Id = visit_Details_M.Id,
                PatientId = visit_Details_M.PatientId,
                Height = visit_Details_M.Height,
                Weight = visit_Details_M.Weight,
                BloodPressureSystolic = visit_Details_M.BloodPressureSystolic,
                BloodPressureDiastolic = visit_Details_M.BloodPressureDiastolic,
                BodyTemperature = visit_Details_M.BodyTemperature,
                RespirationRate = visit_Details_M.RespirationRate,
                BloodGroup = visit_Details_M.BloodGroup,
                NurseEmail = visit_Details_M.NurseEmail,
                PhysicianEmail = visit_Details_M.PhysicianEmail,
                AppointmentId = visit_Details_M.AppointmentId,
                KeyNotes = visit_Details_M.KeyNotes
            };
        }

        public Visit_Details_M mapVisitDetailEM(VisitDetail vi)
        {
            return new Visit_Details_M()
            {
                Id = vi.Id,
                PatientId = vi.PatientId,
                Height = vi.Height,
                Weight = vi.Weight,
                BloodPressureSystolic = vi.BloodPressureSystolic,
                BloodPressureDiastolic = vi.BloodPressureDiastolic,
                BodyTemperature = vi.BodyTemperature,
                RespirationRate = vi.RespirationRate,
                BloodGroup = vi.BloodGroup,
                NurseEmail = vi.NurseEmail,
                PhysicianEmail = vi.PhysicianEmail,
                AppointmentId = vi.AppointmentId,
                KeyNotes = vi.KeyNotes

            };
        }

        //Prescription



        public Prescription mapPrescriptionME(Prescription_M pi)
        {
            return new Prescription()
            {
                Id = pi.Id,
                VisitDetailsId = pi.VisitDetailsId,
                PrescriptionName = pi.PrescriptionName,
                Dosage = pi.Dosage,
                Notes = pi.Notes
            };
        }

        public Prescription_M mapPrescriptionEM(Prescription pi)
        {
            return new Prescription_M()
            {
                Id = pi.Id,
                VisitDetailsId = pi.VisitDetailsId,
                PrescriptionName = pi.PrescriptionName,
                Dosage = pi.Dosage,
                Notes = pi.Notes
            };
        }


        //model to entity
        public Test mapTestME(Test_M test)
        {
            return new Test()
            {
                Id = test.Id,
                VisitDetailsId = test.VisitDetailsId,
                TestName = test.TestName,
                Result= test.Result,
                Notes= test.Notes
            };
        }

        //entity to model
        public Test_M mapTestEM(Test test)
        {
            return new Test_M()
            {
                Id = test.Id,
                VisitDetailsId = test.VisitDetailsId,
                TestName = test.TestName,
                Result= test.Result,
                Notes= test.Notes
        };
        }


    }
}