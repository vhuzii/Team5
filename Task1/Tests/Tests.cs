using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models;
using Task1.Services;

namespace Tests
{

    [TestFixture]
    public class Tests
    {
        [Test]
        public void HttpErrorConstructTest()
        {
            DateTime someDate = DateTime.Now;

            HttpError error = new HttpError(404, "Not found", someDate);

            Assert.AreEqual(error.ErrorCode, 404);
            Assert.AreEqual(error.Description, "Not found");
            Assert.AreEqual(error.ErrorTime, someDate);
        }

        [Test]
        public void HttpErrorCompareToTest()
        {
            DateTime someDate = DateTime.Now;

            HttpError error = new HttpError(404, "Not found", someDate);
            HttpError error2 = new HttpError(401, "Unathorized", someDate);

            Assert.AreEqual(error.CompareTo(error2), 1);
            Assert.AreEqual(error2.CompareTo(error), -1);
        }

        [Test]
        public void HttpErrorEqulsTest()
        {
            DateTime someDate = DateTime.Now;

            HttpError error = new HttpError(404, "Not found", someDate);
            HttpError error2 = new HttpError(404, "Not found", someDate);
            HttpError error3 = new HttpError(401, "Unathorized", someDate);
            HttpError error4 = null;

            Assert.True(error.Equals(error2));
            Assert.False(error.Equals(error3));
            Assert.False(error.Equals(error4));
        }

        [Test]
        public void HttpErrorGetHashCodeTest()
        {
            DateTime someDate = DateTime.Now;

            HttpError error = new HttpError(404, "Not found", someDate);
            HttpError error2 = new HttpError(404, "Not found", someDate);
            Assert.AreEqual(error.GetHashCode(), error2.GetHashCode());
        }

        [Test]
        public void HttpErrorToStringTest()
        {
            DateTime someDate = DateTime.Now;

            HttpError error = new HttpError(404, "Not found", someDate);
            HttpError error2 = new HttpError(404, "Not found", someDate);
            Assert.AreEqual(error.ToString(), error2.ToString());
        }

        [Test]
        public void GetHttpErrorsFromFileTest()
        {
            HttpErrorsService service = new HttpErrorsService();
            List<HttpError> errors = service.GetHttpErrorsFromFile(@"..\..\..\Task1\Files\file1.txt").ToList();
            Assert.AreEqual(errors.Count, 6);
            Assert.AreEqual(errors[3].ErrorCode, 401);

            Assert.Throws(typeof(IOException),
                () => service.GetHttpErrorsFromFile(@"..\..\..\Task1\Files\notExistingFile.txt"));
        }

        [Test]
        public void PrintCodesToFileTest()
        {
            HttpErrorsService service = new HttpErrorsService();
            List<HttpError> errors = service.GetHttpErrorsFromFile(@"..\..\..\Task1\Files\file1.txt").ToList();
            service.PrintCodesToFile(errors, @"..\..\..\Task1\Files\file3.txt");

            Assert.Throws(typeof(IOException),
                () => service.PrintCodesToFile(errors, @"..\..\..\Task1\Files\notExistingFile.txt"));

        }

        [Test]
        public void OutoutErrorsTests()
        {
            HttpErrorsService service = new HttpErrorsService();
            List<HttpError> errors = service.GetHttpErrorsFromFile(@"..\..\..\Task1\Files\file1.txt").ToList();
            service.OutputErrors(errors);
        }
            
        [Test]
        public void ReplaceCodesToDescription()
        {
            HttpErrorsService service = new HttpErrorsService();
            List<HttpError> errors = service.GetHttpErrorsFromFile(@"..\..\..\Task1\Files\file1.txt").ToList();
            service.ReplaceCodesToDescription(errors, @"..\..\..\Task1\Files\file2.txt");

            Assert.Throws(typeof(IOException),
                () => service.ReplaceCodesToDescription(errors, @"..\..\..\Task1\Files\notExistingFile.txt"));
        }
    }
}
