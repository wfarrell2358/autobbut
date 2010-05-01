using System;
using System.Collections.Generic;
using System.Text;

/******************************************************************************
* Copyright (c) 2010 Christian Wiederseiner, Vahid Garousi			           *
* All rights reserved. This program and the accompanying materials           *
* are made available under the terms of the GNU General Public License v3.0  *
* which accompanies this distribution, and is available at                   *
* http://www.gnu.org/licenses/gpl-3.0.html                                   *
******************************************************************************/

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


namespace autobbut_gui
{
    public class xUnitTestParameter
    {
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string _fcnBlockName = string.Empty;
        public string FunctionBlockName
        {
            get { return _fcnBlockName; }
        }

        public string PointName
        {
            get { return _fcnBlockName + "." + name; }
        }


        public xUnitTestParameter(string fcnBlockName, string name, string type, string value)
        {
            Name = name;
            Type = type;
            Value = value;
            _fcnBlockName = fcnBlockName;
        }

        public xUnitTestParameter(string name, string type, string value)
        {
           Name = name;
           Type = type;
           Value = value;
        }
        public xUnitTestParameter()
        {

        }

    }
}
