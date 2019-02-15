using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager;
using Ninject;

namespace FileManagerTests
{
    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void GetFileVerionOneTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                string version = file.Invoker("-v","c:\test.txt");
                Assert.IsNotNull(version);
            }
        }

        [TestMethod]
        public void GetFileVerionTwoTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                string version = file.Invoker("--v", "c:\test.txt");
                Assert.IsNotNull(version);
            }
        }

        [TestMethod]
        public void GetFileVerionThreeTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                string version = file.Invoker("/v", "c:\test.txt");
                Assert.IsNotNull(version);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFileVerionInvalidCommandTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                string version = file.Invoker("/f", "c:\test.txt");
            }
        }

        [TestMethod]
        public void GetFileSizeOneTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                int size = Convert.ToInt32(file.Invoker("-s", "c:\test.txt"));
                Assert.IsNotNull(size);
                Assert.IsTrue(size>=100000);
            }
        }

        [TestMethod]
        public void GetFileSizeTwoTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                int size = Convert.ToInt32(file.Invoker("--s", "c:\test.txt"));
                Assert.IsNotNull(size);
                Assert.IsTrue(size >= 100000);
            }
        }

        [TestMethod]
        public void GetFileSizeThreeTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                int size = Convert.ToInt32(file.Invoker("/s", "c:\test.txt"));
                Assert.IsNotNull(size);
                Assert.IsTrue(size >= 100000);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFileSizeInvalidCommandTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                int size = Convert.ToInt32(file.Invoker("-t", "c:\test.txt"));
            }
        }

        [TestMethod]
        public void GetCommandsTest()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IOperation>().To<Operation>();
                var file = kernel.Get<Operation>();
                int numberOfCommads = file.GetCommands;
                Assert.AreEqual(2,numberOfCommads);
            }
        }
    }
}
