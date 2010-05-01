using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;

/*
 * Based on the exemple on http://www.codestrider.com/
 */

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
    public class ScriptRunner
    {


       public static string RunScript(string scriptCode, string scriptParameter)
        {
          
            CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
          
            //configure parameters
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = false;
            parameters.IncludeDebugInformation = false;
            string reference;
            // Set reference to current assembly - this reference is a hack for the example..
            reference = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parameters.ReferencedAssemblies.Add(reference + "\\xUnitTestSuiteGenerator.exe");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("mscorlib.dll");

            //compile
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, new string[] { scriptCode });

            if (results.Errors.Count == 0)
            {

                IStringManipulator compiledScript=(IStringManipulator)FindInterface(results.CompiledAssembly, "IStringManipulator");
                try
                {
                   return compiledScript.processString(scriptParameter);//run the script, pass the string param..
                }catch(OverflowException e){
                   throw e;

                }


            }
            else
            {
                foreach(CompilerError anError in results.Errors)
                {
                    MessageBox.Show(anError.ErrorText);
                }
                //handle compilation errors here
                //..use results.errors collection
                throw new Exception("Compilation error...");
            }
        }

        private static object FindInterface(Assembly anAssembly, string interfaceName)
        {
            // find our interface type..
            foreach (Type aType in anAssembly.GetTypes())
            {
                if (aType.GetInterface(interfaceName, true) != null)
                    return anAssembly.CreateInstance(aType.FullName);
            }
            return null;
        }
    }

     public partial interface IStringManipulator
    {
        string processString(string aString);
    }
}

