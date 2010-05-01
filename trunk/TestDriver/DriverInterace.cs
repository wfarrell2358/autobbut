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
using System.Collections;
using System.Reflection;
using autobbut_gui;

namespace autobbut_testdriver
{

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

   public interface DriverInterface
   {
      /**
       * 
       * Set Input Parameter
       * 
       */
       xUnitTestParameter setInputParameter(string fcnBlockName, string name, string type, string value);

      /**
     * 
     * Set Output Parameter
     * 
     */
        xUnitTestParameter setOutputParameter(string fcnBlockName, string name, string type);


      /* 
       * 
       * Execute in the rocket
       */
        void execute(string fctBlockType, string fctBlockName);






        string getOutputByName(string name);

        void setUp();

        void tearDown();

    
   }
}
