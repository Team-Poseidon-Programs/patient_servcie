using AutoFixture;
using Patient_Bussiness_Logic;
using EF_Layer.Entities;
using EF_Layer;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Patient_Services.Controllers;
using Models;

namespace PatientService_Testapi
{
    public class PatientServiceTest

    {
        private readonly IFixture _fixture;
        private readonly Mock<ILogic> _mock;
        private readonly PatientController _controller;
        private readonly PrescriptionController prescription;
        private readonly TestController test;
        private readonly VisitDetailsController visitDetails;
        public PatientServiceTest()
        {
            _fixture = new Fixture();
            _mock = _fixture.Freeze<Mock<ILogic>>();
            _controller = new PatientController(_mock.Object);
            prescription = new PrescriptionController(_mock.Object);
            test = new TestController(_mock.Object);
            visitDetails= new VisitDetailsController(_mock.Object);
        }
    
        [Fact]
        public void Post_AddPatient()
        {
            var request = _fixture.Create<Patient>();
            var Patient = _fixture.Create<Patient_M>();
            _mock.Setup(x => x.AddPatient(Patient));

            var result = _controller.AddPatient(Patient);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _mock.Verify(x => x.AddPatient(Patient), Times.AtLeastOnce());
        }
        [Fact]
        public void Post_AddPatient_NotFound()
        {
            var result = _fixture.Create<Patient_M>();
            _mock.Setup(x => x.AddPatient(result));
            var res = _controller.AddPatient(result);
            res.Should().NotBeNull();
            _mock.Verify(x => x.AddPatient(result), Times.AtLeastOnce());
        }
        [Fact]

        public void Update_Patient()
        {
            var request = _fixture.Create<Patient>();
            var patien = _fixture.Create<Patient_M>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.UpdatePatient(patien,id));

            var result = _controller.UpdatePatient(patien, id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _mock.Verify(x => x.UpdatePatient(patien, id), Times.AtLeastOnce());
        }
        [Fact]
        public void Update_Patient_NotFound()
        {

            var res = _fixture.Create<Patient_M>();
           
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.UpdatePatient(res,id)).Throws(new Exception("Not Found"));
            var req = _controller.UpdatePatient(res, id);
            req.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.UpdatePatient(res, id), Times.AtLeastOnce());
        }
        [Fact]
        public void Get_all_Patient() 
        {
            var request = _fixture.Create<List<Patient_M>>();
            _mock.Setup(x => x.GetAllPatient()).Returns(request);

            var result = _controller.GetAllPatient();
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
               .Should().NotBeNull()
               .And.BeOfType(request.GetType());
            _mock.Verify(x => x.GetAllPatient(), Times.AtLeastOnce());
        }
        [Fact]
        public void Get_all_Patient_Details_NotFound()
        {
            var physicianMock = _fixture.Create<IEnumerable<Patient_M>>();
            _mock.Setup(x => x.GetAllPatient()).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = _controller.GetAllPatient();
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetAllPatient(), Times.AtLeastOnce());
        }
        
        [Fact]
        public void Get_by_ID()
        {
            var AppontmentMock = _fixture.Create<Patient_M>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetByID(id)).Returns(AppontmentMock);
            var result = _controller.GetbyID(id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.GetByID(id), Times.AtLeastOnce());
        }
        [Fact]
        public void Get_by_Id_NotFound()
        {
            var physicianMock = _fixture.Create<IEnumerable<Patient_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetByID(id)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = _controller.GetbyID(id);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetByID(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetPatientExist()
        {
            var AppontmentMock = _fixture.Create<bool>();
            var email = _fixture.Create<string>();
            _mock.Setup(x => x.PatientIsExist(email)).Returns(AppontmentMock);
            var result = _controller.PatientExist(email);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.PatientIsExist(email), Times.AtLeastOnce());
        }
        [Fact]
        public void GetPatientNotExist()
        {
            var physicianMock = _fixture.Create<IEnumerable<Patient_M>>();
            var email = _fixture.Create<string>();
            _mock.Setup(x => x.PatientIsExist(email)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = _controller.PatientExist(email);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.PatientIsExist(email), Times.AtLeastOnce());
        }
        [Fact]
        public void patientLogin()
        {
            var AppontmentMock = _fixture.Create<int>();
            var email = _fixture.Create<string>();
            var password= _fixture.Create<string>();
            _mock.Setup(x => x.login(email, password)).Returns(AppontmentMock);
            var result = _controller.patientlogin(email, password);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.login(email, password), Times.AtLeastOnce());
        }
        [Fact]
        public void patientLogin_NotFound() 
        {
            var physicianMock = _fixture.Create<IEnumerable<Patient_M>>();
            var email = _fixture.Create<string>();
            var password = _fixture.Create<string>();
            _mock.Setup(x => x.login(email, password)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = _controller.patientlogin(email, password);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.login(email, password), Times.AtLeastOnce());
        }
        //prescriptionController
        [Fact]
        public void PostPrescription()
        {
            var request = _fixture.Create<Patient>();
            var prescription_M = _fixture.Create<Prescription_M>();
            _mock.Setup(x => x.AddPrescription(prescription_M));

            var result = prescription.AddPrescription(prescription_M);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _mock.Verify(x => x.AddPrescription(prescription_M), Times.AtLeastOnce());
        }
        [Fact]
        public void PostPrescription_NotFound() 
        {
            var request = _fixture.Create<Patient>();
            var result = _fixture.Create<Prescription_M>();
            _mock.Setup(x => x.AddPrescription(result));
            var res = prescription.AddPrescription(result);
            res.Should().NotBeNull();
            _mock.Verify(x => x.AddPrescription(result), Times.AtLeastOnce());
        }
        [Fact]
        public void GetPrescriptionById() 
        {
            var AppontmentMock = _fixture.Create<List<Prescription_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetPrescriptionById(id)).Returns(AppontmentMock);
            var result = prescription.GetPrescriptionById(id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.GetPrescriptionById(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetPrescriptionById_NotFound()
        {
            var physicianMock = _fixture.Create<IEnumerable<Patient_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetPrescriptionById(id)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = prescription.GetPrescriptionById(id);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetPrescriptionById(id), Times.AtLeastOnce());
        }
       
        [Fact]
        public void PostTest()
        {
            var request = _fixture.Create<Patient>();
            var prescription_M = _fixture.Create<Test_M>();
            _mock.Setup(x => x.AddTest(prescription_M));

            var result = test.AddTest(prescription_M);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _mock.Verify(x => x.AddTest(prescription_M), Times.AtLeastOnce());
        }
        [Fact]
        public void PostTest_NotFound()
        {
            var request = _fixture.Create<Patient>();
            var result = _fixture.Create<Test_M>();
            _mock.Setup(x => x.AddTest(result)).Throws(new Exception("Details Not Found"));
            var res = test.AddTest(result);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.AddTest(result), Times.AtLeastOnce());
        }
        [Fact]
        public void GetTestListbyid()
        {
            var AppontmentMock = _fixture.Create<List<Test_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetTestList(id)).Returns(AppontmentMock);
            var result = test.GetTestListbyVisitId(id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.GetTestList(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetTestListbyid_NotFound()
        {
            var physicianMock = _fixture.Create<IEnumerable<Patient_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetTestList(id)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = test.GetTestListbyVisitId(id);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetTestList(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetTestIdbyname()
        {
            var AppontmentMock = _fixture.Create<int>();
            var name = _fixture.Create<string>();
            _mock.Setup(x => x.GetTestIdByName(name)).Returns(AppontmentMock);
            var result = test.GetTestIdByName(name);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.GetTestIdByName(name), Times.AtLeastOnce());
        }
        [Fact]
        public void GetTestIdbyName_NotFound()
        {
            var physicianMock = _fixture.Create<int>();
            var name = _fixture.Create<string>();
            _mock.Setup(x => x.GetTestIdByName(name)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = test.GetTestIdByName(name);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetTestIdByName(name), Times.AtLeastOnce());
        }
        [Fact]
        public void putTest()
        {
            var request = _fixture.Create<Patient>();
            var _test = _fixture.Create<Test_M>();
            var id = _fixture.Create<int>();
            
            _mock.Setup(x => x.UpdateTest(_test, id));

            var result = test.UpdateTest(_test, id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _mock.Verify(x => x.UpdateTest(_test, id), Times.AtLeastOnce());
        }
        [Fact]
        public void PutTest_NotFound() 
        {
            var request = _fixture.Create<Patient>();
            var result = _fixture.Create<Test_M>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.UpdateTest(result,id)).Throws(new Exception("Details Not Found"));
            var res = test.UpdateTest(result,id);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.UpdateTest(result, id), Times.AtLeastOnce());
        }
        //visitdetail controller
        //name visitDetails
        [Fact]
        public void PostVisitDetails()
        {
            var request = _fixture.Create<Patient>();
            var visit_Details_M = _fixture.Create<Visit_Details_M>();
            _mock.Setup(x => x.AddVisitDetails(visit_Details_M));

            var result = visitDetails.AddVisitDetails(visit_Details_M);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _mock.Verify(x => x.AddVisitDetails(visit_Details_M), Times.AtLeastOnce());
        }
        [Fact]
        public void PostVisitDetails_NotFound()
        {
            var request = _fixture.Create<Patient>();
            var result = _fixture.Create<Visit_Details_M>();
       
            _mock.Setup(x => x.AddVisitDetails(result)).Throws(new Exception("Details Not Found"));
            var res = visitDetails.AddVisitDetails(result);
            res.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.AddVisitDetails(result), Times.AtLeastOnce());
        }
        [Fact]
        public void GetVisitDetailsById()
        {
            var AppontmentMock = _fixture.Create<List<Visit_Details_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetVisitDetailsById(id)).Returns(AppontmentMock);
            var result = visitDetails.GetVisitDetailsById(id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.GetVisitDetailsById(id), Times.AtLeastOnce());
        }
        [Fact]
        
        public void GetVisitDetailsById_NotFound()
        {
            var physicianMock = _fixture.Create<List<Visit_Details_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetVisitDetailsById(id)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = visitDetails.GetVisitDetailsById(id);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetVisitDetailsById(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetParticularVisitDetailsById()
        {
            var AppontmentMock = _fixture.Create<Visit_Details_M>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetParticularVisitById(id)).Returns(AppontmentMock);
            var result = visitDetails.GetParticularVisitDetailsById(id);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                 .Should().NotBeNull()
                 .And.BeOfType(AppontmentMock.GetType());
            _mock.Verify(x => x.GetParticularVisitById(id), Times.AtLeastOnce());
        }
        [Fact]
        public void GetParticularVisitDetailsById_NotFound()
        {
            var physicianMock = _fixture.Create<List<Visit_Details_M>>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.GetParticularVisitById(id)).Throws(new Exception("Something Went Wrong"));

            // Act
            var result = visitDetails.GetParticularVisitDetailsById(id);
            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>();
            _mock.Verify(x => x.GetParticularVisitById(id), Times.AtLeastOnce());
        }
    }
}