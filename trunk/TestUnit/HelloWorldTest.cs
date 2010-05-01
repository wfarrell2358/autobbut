/******************************************************************************
* Copyright (c) 2010 Christian Wiederseiner, Vahid Garousi			           *
* All rights reserved. This program and the accompanying materials           *
* are made available under the terms of the GNU General Public License v3.0  *
* which accompanies this distribution, and is available at                   *
* http://www.gnu.org/licenses/gpl-3.0.html                                   *
******************************************************************************/


using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using autobbut_gui;
using autobbut_testdriver;

/**
* Project supervisor: Vahid Garousi (http://www.ucalgary.ca/~vgarousi/)
* Software Quality Engineering Research Group (SoftQual)
* Department of Electrical and Computer Engineering
* Schulich School of Engineering
* University of Calgary, Alberta, Canada
* http://www.softqual.ucalgary.ca
* @author Christian Wiederseiner
* @version 1.0
*/


namespace TestProject
{

   [TestClass]
   public class HelloWorldTest
   {
      DriverInterface TD = new YourDriver();
      static String FunctionBlock = "HelloWorldFunctionBlock";
      static String FunctionBlockName = "Hello1";
      private TestContext testContextInstance;

      /// <summary>
      ///Gets or sets the test context which provides
      ///information about and functionality for the current test run.
      ///</summary>
      public TestContext TestContext
      {
         get
         {
            return testContextInstance;
         }
         set
         {
            testContextInstance = value;
         }
      }


      #region Init and Tear Down

      [TestInitialize()]
      public void Init()
      {
         TD.setUp();
      }

      [TestCleanup()]
      public void Dispose()
      {
         TD.tearDown();
      }
      #endregion



      [TestMethod]
      public void Testd8f1b652c80b4477aa818521ee147fd4()
      {
         TD.setInputParameter(FunctionBlockName, "A", "Int (16 bit)", "0");
         TD.setInputParameter(FunctionBlockName, "B", "Int (32 bit)", "0");
         xUnitTestParameter sumParam = TD.setOutputParameter(FunctionBlockName, "Sum", "Int (8 bit)");
         xUnitTestParameter errorParam = TD.setOutputParameter(FunctionBlockName, "Error", "Text");

         TD.execute(FunctionBlock, FunctionBlockName);

         Assert.AreEqual("0", TD.getOutputByName(sumParam.PointName));
         Assert.AreEqual("", TD.getOutputByName(errorParam.PointName));
      }



   }
}
