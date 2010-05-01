
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


using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Test.VariationGeneration;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.ComponentModel;



namespace autobbut_gui
{
   public partial class xUnitTestSuiteGenerator : Form
   {

      const string TestHeader = "[TestMethod]";
      const string Assert = "Assert.AreEqual";

      Model model;
      Dictionary<string, Parameter> ParamDictionary = null;
      Dictionary<string, string> dataxUnitTestSuiteGenerator = new Dictionary<string, string>();
      Dictionary<string, string> dataTestOutput = new Dictionary<string, string>();

      BackgroundWorker bWorkerXUNIT;
      BackgroundWorker bWorkerCSV;

      public static Dictionary<string, xUnitTestParameter> inputList = null;

      public xUnitTestSuiteGenerator()
      {
         InitializeComponent();
      }

      #region generateXUNIT
      private void generateButtonXUNIT_Click(object sender, EventArgs e)
      {
         if (initModel())
         {
            
            bWorkerXUNIT = new BackgroundWorker();
            bWorkerXUNIT.WorkerSupportsCancellation = true;
            bWorkerXUNIT.WorkerReportsProgress = true;
            bWorkerXUNIT.ProgressChanged += bXUNIT_ProgressChanged;
            bWorkerXUNIT.DoWork += generateTestSuiteCode;
            bWorkerXUNIT.RunWorkerCompleted += bXUNIT_Completed;
            
            progressBarXUNIT.Visible = true;

            generateCSVButton.Enabled = false;
            generateXunitButton.Enabled = false;
            bWorkerXUNIT.RunWorkerAsync();    
         }
      }

      private void bXUNIT_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         progressBarXUNIT.Value = e.ProgressPercentage;

      }

      private void bXUNIT_Completed(object sender, RunWorkerCompletedEventArgs e)
      {
         progressBarXUNIT.Visible = false;
         generateCSVButton.Enabled = true;
         generateXunitButton.Enabled = true;
      }



      #endregion

      private void generateButtonCSV_Click(object sender, EventArgs e)
      {
         if (initModel())
         {
            bWorkerCSV = new BackgroundWorker();
            bWorkerCSV.WorkerReportsProgress = true;
            bWorkerCSV.WorkerSupportsCancellation = true;
            bWorkerCSV.ProgressChanged += bCSV_ProgressChanged;
            bWorkerCSV.DoWork += generateCSV;
            bWorkerCSV.RunWorkerCompleted += bCSV_Completed;
            progressBarCSV.Visible = true;
            generateCSVButton.Enabled = false;
            generateXunitButton.Enabled = false;
            bWorkerCSV.RunWorkerAsync();    
         }
      }

      public class ProgressValueEventArgs : EventArgs
      {
         public ProgressValueEventArgs(int currentValue, int totalValue)
         {
            this.currentValue = currentValue;
            this.totalValue = totalValue;
         }

         // The fire event will have two pieces of information-- 
         // 1) Where the fire is, and 2) how "ferocious" it is.  

         public int currentValue;
         public int totalValue;

      }   

      private void bCSV_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         progressBarCSV.Value = e.ProgressPercentage;
      }


      private void updateProgressText(object sender, ProgressValueEventArgs e)
      {
         textProgress.Text = e.currentValue + "/" + e.totalValue;
         textProgress.Invalidate();
      }

      private void bCSV_Completed(object sender, RunWorkerCompletedEventArgs e)
      {
         progressBarCSV.Visible = false;
         generateCSVButton.Enabled = true;
         generateXunitButton.Enabled = true;
      }

      private string getPrefixText()
      {
         if (prefixTextField.Text != "")
            return prefixTextField.Text;
         return null;
      }

      private int getWayValue()
      {
         int wayValue = int.Parse(wayField.Value.ToString());
         if (wayValue == 0)
            wayValue = model.Parameters.Count;
         return wayValue;
      }

      #region model
      private bool initModel()
      {
         resetModel();

         if ((model = createModel(inputGridView)) != null)
         {
            associateDataToModel(inputGridView);

            // check if the user has entered at least one input parameter
            if (model.Parameters.Count < 1)
            {
               MessageBox.Show("You should enter at least one input parameter.");
               return false;
            }        
            return true;
         }
         return false;
      }

      private void resetModel()
      {
         model = null;
      }


      private void associateDataToModel(DataGridView inputGridView)
      {
         foreach (DataGridViewRow inputRow in inputGridView.Rows)
         {
            // Make sure it's not an empty row. 
            if (!inputRow.IsNewRow)
            {
               string paramName = inputRow.Cells[0].Value + "";
               if (dataxUnitTestSuiteGenerator.ContainsKey(paramName))
               {
                  string valueString = dataxUnitTestSuiteGenerator[paramName];
                  string[] valueSplitted = Regex.Split(valueString, "\r\n");
                  for (var i = 0; i < valueSplitted.Length; i++)
                  {
                     valueSplitted[i] = valueSplitted[i].Trim();
                     if (valueSplitted[i] == "") continue;
                     //Param 0, Type 1, Value 2

                     //Parameter object contains: Param, Type, Value
                     ParamDictionary[paramName].Add(inputRow.Cells[0].Value
                        + "," + inputRow.Cells[1].Value + "," + valueSplitted[i] + ","
                        + System.Guid.NewGuid().ToString());
                  }
               }
            }
         }

      }

      //create test paramater based on the list of paramater set in the GUI. Avoid duplicate value.
      private Model createModel(DataGridView inputGridView)
      {
         ParamDictionary = new Dictionary<string, Parameter>();

         // stop if no data
         if (inputGridView.Rows.Count <= 1)
         {
            MessageBox.Show("No Data to process.");
            return null;
         }

         xUnitTestParameter p = new xUnitTestParameter();
         foreach (DataGridViewRow inputGridRow in inputGridView.Rows)
         {
            // Make sure it's not an empty row. 
            if (!inputGridRow.IsNewRow)
            {
               if (inputGridRow.Cells[0].Value != null)
               {
                  p.Name = inputGridRow.Cells[0].Value.ToString();
                  if (inputGridRow.Cells[1].Value != null)
                  {
                     ParamDictionary.Add(p.Name, new Parameter(p.Name));
                  }
                  else
                  {
                     MessageBox.Show("Type not specified.");
                     return null;
                  }
               }
            }
         }

         return new Model(ParamDictionary.Values);
      }
      #endregion

      #region fillGUIValue
      private string fillBoundaryValues(string param, string type)
      {
         Random r = new Random(System.DateTime.Now.Millisecond);
         //    Parameter p = new Parameter(param);
         string result = "";
         switch (type)
         {

            case "Digital":
               result += "False" + "\r\n";
               result += "True" + "\r\n";
               break;

            case "Float (32 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               result += float.MinValue + "\r\n";
               result += "-3.40282299999999999999999999999999999999999999" + "\r\n";
               //result += "-3.40282300000000000000000000000000000000000001" + "\r\n";
               result += float.MaxValue + "\r\n";
               result += "3.40282299999999999999999999999999999999999999" + "\r\n";
               //result += "3.40282300000000000000000000000000000000000001" + "\r\n";
               result += "0.0" + "\r\n";
               result += (r.NextDouble() * float.MinValue) + "\r\n";
               result += (r.NextDouble() * float.MaxValue) + "\r\n";

               break;


            case "Float (64 bit)":
               //Parameter object contains: Param, Type, Value, Guid

               result += double.MinValue + "\r\n";
               result += "-1.7976931348623199999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999" + "\r\n";
               //result += "-1.7976931348623200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001" + "\r\n";
               result += double.MaxValue + "\r\n";
               result += "1.7976931348623199999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999" + "\r\n";
               //result += "1.7976931348623200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001" + "\r\n";
               result += "0.0" + "\r\n";
               result += (r.NextDouble() * double.MinValue) + "\r\n";
               result += (r.NextDouble() * double.MaxValue) + "\r\n";

               break;
            case "Int (8 bit)":
               //Parameter object contains: Param, Type, Value, Guid

               result += "0" + "\r\n";
               result += r.Next(0, sbyte.MaxValue) + "\r\n";
               result += r.Next(sbyte.MinValue, 0) + "\r\n";
               result += sbyte.MinValue + "\r\n";
               //result += (sbyte.MinValue - 1) + "\r\n";
               result += (sbyte.MinValue + 1) + "\r\n";
               result += sbyte.MaxValue + "\r\n";
               result += (sbyte.MaxValue - 1) + "\r\n";
               //result += (sbyte.MaxValue + 1) + "\r\n";
               break;

            case "Int (16 bit)":
               //Parameter object contains: Param, Type, Value, Guid

               result += "0" + "\r\n";
               result += r.Next(0, Int16.MaxValue) + "\r\n";
               result += r.Next(Int16.MinValue, 0) + "\r\n";
               result += Int16.MinValue + "\r\n";
               //result += (Int16.MinValue - 1) + "\r\n";
               result += (Int16.MinValue + 1) + "\r\n";
               result += Int16.MaxValue + "\r\n";
               result += (Int16.MaxValue - 1) + "\r\n";
               //result += (Int16.MaxValue + 1) + "\r\n";

               break;

            case "Int (32 bit)":
               //Parameter object contains: Param, Type, Value, Guid

               result += "0" + "\r\n";
               result += r.Next(0, Int32.MaxValue) + "\r\n";
               result += r.Next(Int32.MinValue, 0) + "\r\n";
               result += Int32.MinValue + "\r\n";
               //result += "-2147483649" + "\r\n";
               result += (Int32.MinValue + 1) + "\r\n";
               result += Int32.MaxValue + "\r\n";
               result += (Int32.MaxValue - 1) + "\r\n";
               //result += "2147483648" + "\r\n";
               break;
            case "Int (64 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               result += "0" + "\r\n";
               result += 2 * r.Next(0, Int32.MaxValue) + "\r\n";
               result += 2 * r.Next(Int32.MinValue, 0) + "\r\n";
               result += Int64.MinValue + "\r\n";
               //result += "-9223372036854775809" + "\r\n";
               result += (Int64.MinValue + 1) + "\r\n";
               result += Int64.MaxValue + "\r\n";
               result += (Int64.MaxValue - 1) + "\r\n";
               //result += "9223372036854775808" + "\r\n";

               break;
            case "Unsigned Int (8 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               result += -1 + "\r\n";
               result += 0 + "\r\n";
               result += 1 + "\r\n";
               result += r.Next(0, byte.MaxValue) + "\r\n";
               result += byte.MaxValue + "\r\n";
               result += (byte.MaxValue - 1) + "\r\n";
               result += (byte.MaxValue + 1) + "\r\n";
               break;

            case "Unsigned Int (16 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               result += -1 + "\r\n";
               result += 0 + "\r\n";
               result += 1 + "\r\n";
               result += r.Next(0, UInt16.MaxValue) + "\r\n";
               result += UInt16.MaxValue + "\r\n";
               result += (UInt16.MaxValue - 1) + "\r\n";
               result += (UInt16.MaxValue + 1) + "\r\n";
               break;

            case "Unsigned Int (32 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               result += -1 + "\r\n";
               result += 0 + "\r\n";
               result += 1 + "\r\n";
               result += 2 * r.Next(0, Int32.MaxValue) + "\r\n";
               result += UInt32.MaxValue + "\r\n";
               result += "4294967294" + "\r\n";
               result += "4294967296" + "\r\n";
               break;
            case "Unsigned Int (64 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               result += -1 + "\r\n";
               result += 0 + "\r\n";
               result += 1 + "\r\n";
               result += 4 * r.Next(0, Int32.MaxValue) + "\r\n";
               result += UInt64.MaxValue + "\r\n";
               result += "18446744073709551614" + "\r\n";
               result += "18446744073709551616" + "\r\n";
               break;
         }
         return result;
      }
      private bool fillOutOfRangeValues(string value, string type)
      {

         switch (type)
         {
            case "Float (32 bit)":
               if (value.Equals("3.40282300000000000000000000000000000000000001") || value.Equals("-3.40282300000000000000000000000000000000000001"))
                  return true;
               return false;
            case "Float (64 bit)":
               if (value.Equals("1.7976931348623200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001") || value.Equals("-1.7976931348623200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001"))
                  return true;
               return false;
            case "Int (8 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               if (value.Equals("-129") || value.Equals("+128"))
                  return true;
               return false;
            case "Int (16 bit)":
               //Parameter object contains: Param, Type, Value, Guid
               if (value.Equals("32768") || value.Equals("-32769"))
                  return true;
               return false;
            case "Int (32 bit)":
               //Parameter object contains: Param, Type, Value, Guid

               if (value.Equals("2147483648") || value.Equals("-2147483649"))
                  return true;
               return false;
            case "Int (64 bit)":
               if (value.Equals("9223372036854775808") || value.Equals("-9223372036854775809"))
                  return true;
               return false;
            case "Unsigned Int (8 bit)":
               if (value.Equals("256") || value.Equals("-1"))
                  return true;
               return false;
            case "Unsigned Int (16 bit)":
               if (value.Equals("65536") || value.Equals("-1"))
                  return true;
               return false;
            case "Unsigned Int (32 bit)":
               if (value.Equals("4294967296") || value.Equals("-1"))
                  return true;
               return false;
            case "Unsigned Int (64 bit)":
               if (value.Equals("18446744073709551616") || value.Equals("-1"))
                  return true;
               return false;
            default:
               return false;
         }
      }
      #endregion

      #region utilites
      private void openFile(string file, string tool)
      {
         System.Diagnostics.Process proc = new System.Diagnostics.Process();
         proc.EnableRaisingEvents = false;
         proc.StartInfo.FileName = tool;
         proc.StartInfo.Arguments = file;
         proc.Start();
      }

      private void openFileInExcel(string fileName)
      {
         System.Diagnostics.Process proc = new System.Diagnostics.Process();
         proc.EnableRaisingEvents = false;
         proc.StartInfo.FileName = "excel";
         proc.StartInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName;
         proc.Start();
      }

      private static void writeCSV(StringBuilder sbInput, string path, String fileNameTblInput)
      {

         try
         {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path + "\\" + fileNameTblInput, false))
            { // Write the stringbuilder text to the the file. 
               sw.WriteLine(sbInput.ToString());
            }
         }
         catch (IOException e)
         {
            if (e.Message.Contains("because it is being used by another process"))
            {
               MessageBox.Show("CSV file already in use by another process. Please close it before to override.");
            }


         }
      }

      #endregion

      private void generateTestSuiteCode(object sender, DoWorkEventArgs e)
      {        
         string testSuiteCode = ""; 

         IEnumerable<Variation> generatedVariations = model.GenerateVariations(getWayValue(), 1234);
         float progressMaximum = generatedVariations.Count();
         int progressIncrement = 0;



         foreach (Variation v in generatedVariations)
         {
            bWorkerXUNIT.ReportProgress((int) ((progressIncrement / progressMaximum) * 100));
           // progressEvent(xUnitTestSuiteGenerator, new ProgressValueEventArgs(progressIncrement, (int)progressMaximum));
            progressIncrement++;
            inputList = new Dictionary<string, xUnitTestParameter>();
            Guid guid = Guid.NewGuid();
            // remove -'s from the random string 
            string guidstring = Regex.Replace(guid.ToString(), "-", "");
            // start generating the test method one by one
            testSuiteCode += TestHeader + Environment.NewLine;
            // test method signature
            testSuiteCode += "public void Test"+getPrefixText()+ 
               guidstring + "()" + Environment.NewLine + "{" 
               + Environment.NewLine;

            // feeding the input parameters in to the test code
            foreach (Parameter param in model.Parameters)
            {
               xUnitTestParameter input = new xUnitTestParameter();
               input.Name = v[param.Name].ToString().Split(new Char[] { ',' })[0];
               input.Type = v[param.Name].ToString().Split(new Char[] { ',' })[1];
               input.Value = v[param.Name].ToString().Split(new Char[] { ',' })[2];

               testSuiteCode += "TD.setInputParameter(FunctionBlockName,\"" + input.Name + "\", \"" +
                  input.Type + "\", \"" + input.Value + "\" );" + Environment.NewLine;

               inputList.Add(input.Name, input);
            }
            testSuiteCode += Environment.NewLine;

            // feeding the output parameters in to the test code
            foreach (DataGridViewRow outputRow in outputGridView.Rows)
            {
               // Make sure it's not an empty row. 
               if (!outputRow.IsNewRow)
               {
                  testSuiteCode += "xUnitTestParameter " + outputRow.Cells[0].Value.ToString().ToLower() +
                     "Param = TD.setOutputParameter(FunctionBlockName,\"" + outputRow.Cells[0].Value + "\",\"" +
                     outputRow.Cells[1].Value + "\");" + Environment.NewLine;
               }
            }

            // exercise the component under test
            testSuiteCode += Environment.NewLine + "TD.execute(FunctionBlock, FunctionBlockName);" +
               Environment.NewLine + Environment.NewLine;

            string errorMsg = "";
            // generate expected output placeholders
            foreach (DataGridViewRow outputRow in outputGridView.Rows)
            {
               // Make sure it's not an empty row. 
               if (!outputRow.IsNewRow)
               {
                  string valueOracle = "";
                  string outputType = "";
                  string processedString = "";
                  if (dataTestOutput.ContainsKey(outputRow.Cells[0].Value.ToString()))
                  {
                     valueOracle = dataTestOutput[outputRow.Cells[0].Value.ToString()];
                     outputType = outputRow.Cells[1].Value.ToString();
                  }
                  if (!valueOracle.Equals(""))
                  {
                     string codeToProcess;
                     if (makeCast(outputType).Equals("string"))
                     {
                        codeToProcess = "using autobbut_gui; using System;" + Environment.NewLine +
                           "public class MyStringManipulator : IStringManipulator" + Environment.NewLine +
                           "{" + Environment.NewLine +
                           "    public string processString(string aString)" + Environment.NewLine +
                           "     {" + Environment.NewLine +
                           "return (((" + valueOracle + ").ToString())).ToString();" + Environment.NewLine +
                           "}}";
                     }
                     else
                     {
                        codeToProcess = "using autobbut_gui; using System;" + Environment.NewLine +
                        "public class MyStringManipulator : IStringManipulator" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public string processString(string aString)" + Environment.NewLine +
                        "     {" + Environment.NewLine +
                        "return (" + makeCast(outputType) + ".Parse((" + valueOracle + ").ToString())).ToString();" + Environment.NewLine +
                        "}}";
                     }
                     codeToProcess = addCast(codeToProcess, makeCast(outputType));
                     try
                     {
                        processedString = ScriptRunner.RunScript(codeToProcess, "");
                     }
                     catch (OverflowException e2)
                     {
                        processedString = "";
                        errorMsg = e2.Message;
                     }
                  }
                  //FIXME: error output has to be after all the output in the row
                  if (!errorMsg.Equals("") && (outputRow.Cells[0].Value.ToString().Contains("Error")
                        || outputRow.Cells[0].Value.ToString().Contains("error")))
                  {
                     testSuiteCode += Assert+"(\"" + errorMsg + "\",TD.getOutputByName(" + outputRow.Cells[0].Value.ToString().ToLower() +
                       "Param.PointName));" + Environment.NewLine;
                     errorMsg = "";
                  }
                  else
                  {
                     string displayprocessedString = "XXX";
                     if (!(outputRow.Cells[0].Value.ToString().Contains("Error")
                        || outputRow.Cells[0].Value.ToString().Contains("error")) && processedString != "")
                     {
                        displayprocessedString = processedString;
                     }
                     if ((outputRow.Cells[0].Value.ToString().Contains("Error")
                        || outputRow.Cells[0].Value.ToString().Contains("error")) && processedString == "")
                     {
                        displayprocessedString = processedString;
                     }

                     testSuiteCode += Assert+"(\"" + displayprocessedString + "\",TD.getOutputByName(" + outputRow.Cells[0].Value.ToString().ToLower() +
                        "Param.PointName));" + Environment.NewLine;
                  }
               }
            }
            testSuiteCode += "}" + Environment.NewLine + Environment.NewLine;
            bWorkerXUNIT.ReportProgress((int)((progressIncrement / progressMaximum) * 100));
         }
         

         string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         string fname = "testcase.txt";
         System.IO.File.WriteAllText(path + "\\" + fname, testSuiteCode);
         MessageBox.Show("Data saved");
         openFile(path + "\\" + fname, "Notepad");

         return;
      }


      private void generateCSV(object sender, DoWorkEventArgs e)
      {
         StringBuilder sbInput = new StringBuilder(), sbAssocInput = new StringBuilder(), sbAssocOutput = new StringBuilder();
         
         // Column headers 
         sbInput.Append("id, parameter, type, value" + Environment.NewLine);
         sbAssocInput.Append("tc_id, input_id" + Environment.NewLine);
         sbAssocOutput.Append("tc_id, parameter, type, expectOutput, actualOutput" + Environment.NewLine);

         IEnumerable<Variation> generatedVariations = model.GenerateVariations(getWayValue(), 1234);
         float progressMaximum = generatedVariations.Count();
         int progressIncrement = 0;
         foreach (Variation v in generatedVariations)
         {
            bWorkerCSV.ReportProgress((int)((progressIncrement / progressMaximum) * 100));
            progressIncrement++;
            inputList = new Dictionary<string, xUnitTestParameter>();
            Guid guid = Guid.NewGuid();
            // remove -'s from the random string 
            string guidstring = getPrefixText()+Regex.Replace(guid.ToString(), "-", "");

            // feeding the input parameters in to the test code
            foreach (Parameter param in model.Parameters)
            {
               xUnitTestParameter input = new xUnitTestParameter();
               input.Name = v[param.Name].ToString().Split(new Char[] { ',' })[0];
               input.Type = v[param.Name].ToString().Split(new Char[] { ',' })[1];
               input.Value = v[param.Name].ToString().Split(new Char[] { ',' })[2];

               inputList.Add(input.Name, input);

               Guid guid2 = Guid.NewGuid();
               string idParam = getPrefixText() + Regex.Replace(guid2.ToString(), "-", "");
               sbInput.Append(""+idParam+","+input.Name+","+ input.Type+","+input.Value + Environment.NewLine);
               sbAssocInput.Append(""+guidstring+","+idParam+ Environment.NewLine);

            }

            string errorMsg = "";
            // generate expected output placeholders
            foreach (DataGridViewRow outputRow in outputGridView.Rows)
            {
               // Make sure it's not an empty row. 
               if (!outputRow.IsNewRow)
               {
                  string valueOracle = "";
                  string outputType = "";
                  string processedString = "";
                  if (dataTestOutput.ContainsKey(outputRow.Cells[0].Value.ToString()))
                  {
                     valueOracle = dataTestOutput[outputRow.Cells[0].Value.ToString()];
                     outputType = outputRow.Cells[1].Value.ToString();
                  }
                  if (!valueOracle.Equals(""))
                  {
                     string codeToProcess;
                     if (makeCast(outputType).Equals("string"))
                     {
                        codeToProcess = "using autobbut_gui; using System;" + Environment.NewLine +
                           "public class MyStringManipulator : IStringManipulator" + Environment.NewLine +
                           "{" + Environment.NewLine +
                           "    public string processString(string aString)" + Environment.NewLine +
                           "     {" + Environment.NewLine +
                           "return (((" + valueOracle + ").ToString())).ToString();" + Environment.NewLine +
                           "}}";
                     }
                     else
                     {
                        codeToProcess = "using autobbut_gui; using System;" + Environment.NewLine +
                        "public class MyStringManipulator : IStringManipulator" + Environment.NewLine +
                        "{" + Environment.NewLine +
                        "    public string processString(string aString)" + Environment.NewLine +
                        "     {" + Environment.NewLine +
                        "return (" + makeCast(outputType) + ".Parse((" + valueOracle + ").ToString())).ToString();" + Environment.NewLine +
                        "}}";
                     }
                     codeToProcess = addCast(codeToProcess, makeCast(outputType));
                     try
                     {
                        processedString = ScriptRunner.RunScript(codeToProcess, "");
                     }
                     catch (OverflowException e2)
                     {
                        processedString = "";
                        errorMsg = e2.Message;
                     }
                  }
                  //FIXME: error output has to be after all the output in the row
                  if (!errorMsg.Equals("") && (outputRow.Cells[0].Value.ToString().Contains("Error")
                        || outputRow.Cells[0].Value.ToString().Contains("error")))
                  {
                       sbAssocOutput.Append(guidstring+","+ outputRow.Cells[0].Value.ToString().ToLower()+","+outputRow.Cells[1].Value+","+ 
                           errorMsg+",XXX" + Environment.NewLine);
                 
                     errorMsg = "";
                  }
                  else
                  {
                     sbAssocOutput.Append(guidstring + "," + outputRow.Cells[0].Value.ToString().ToLower() + "," + outputRow.Cells[1].Value + "," +
                           processedString + ",XXX" + Environment.NewLine);
                  }
               }
            }
            bWorkerCSV.ReportProgress((int)((progressIncrement / progressMaximum) * 100));


         }
         string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         String fileNameTblInput = "tbl_test_case_input.csv";
         String fileNameTblAssocInput = "tbl_tc_input_assoc.csv";
         String fileNameTblOutput = "tbl_test_output.csv";
         writeCSV(sbInput, path, fileNameTblInput);
         writeCSV(sbAssocInput, path, fileNameTblAssocInput);
         writeCSV(sbAssocOutput, path, fileNameTblOutput);
         openFileInExcel(fileNameTblInput);
         openFileInExcel(fileNameTblAssocInput);
         openFileInExcel(fileNameTblOutput);

         //   // Confirm to the user it has been completed.
         MessageBox.Show("CSV files generated");


         return;
      }



      #region type_handle
      private string makeCast(string value)
      {
         switch (value)
         {
            case "Float (32 bit)":
               return "float";
            case "Float (64 bit)":
               return "double";
            case "Int (8 bit)":
               return "sbyte";
            case "Int (16 bit)":
               return "Int16";
            case "Int (32 bit)":
               return "Int32";
            case "Int (64 bit)":
               return "Int64";
            case "Unsigned Int (8 bit)":
               return "byte";
            case "Unsigned Int (16 bit)":
               return "UInt16";
            case "Unsigned Int (32 bit)":
               return "UInt32";
            case "Unsigned Int (64 bit)":
               return "UInt64";
            case "Text":
               return "string";
            case "Digital":
               return "bool";
            default:
               throw new Exception();
         }
      }

      private string addCast(string codeToProcess, string outputcast)
      {
         foreach (KeyValuePair<string, xUnitTestParameter> rp in inputList)
         {
            if (makeCast(rp.Value.Type) == "string")
            {
               codeToProcess = codeToProcess.Replace("[" + rp.Value.Name + "]", "(xUnitTestSuiteGenerator.inputList[\"" + rp.Value.Name + "\"].Value)");
            }
            else
            {
               codeToProcess = codeToProcess.Replace("[" + rp.Value.Name + "]", "(" + outputcast + ")(" + makeCast(rp.Value.Type) + ".Parse(xUnitTestSuiteGenerator.inputList[\"" + rp.Value.Name + "\"].Value))");
            }
         }
         return codeToProcess;
      }
#endregion

      #region gui_event
      private void selectedRow(object sender, EventArgs e)
      {
         DataGridViewRow c = inputGridView.CurrentRow;
         if (c != null)
         {
            //afficher les infos dans le textBoxValue
            if ((c.Cells[0].Value != null))
            {
               //si vide, cree une donnee vide
               string param = c.Cells[0].Value.ToString();
               if (param == "") return;

               if (dataxUnitTestSuiteGenerator.ContainsKey(param))
               {
                  textBoxValue.Text = dataxUnitTestSuiteGenerator[param];
                  textBoxValue.Update();
               }
               else
               {
                  textBoxValue.Clear();
                  if (c.Cells[1].Value != null)
                  {
                     string type = c.Cells[1].Value.ToString();
                     if (type != "")
                     {
                        textBoxValue.Text = fillBoundaryValues(param, type);
                        textBoxValue.Update();
                     }
                  }
               }
            }
            else
            {
               textBoxValue.Clear();
            }
         }
      }

      private void textBoxValue_TextChanged(object sender, EventArgs e)
      {
         DataGridViewRow c = inputGridView.CurrentRow;
         if (c != null)
         {
            if ((c.Cells[0].Value != null))
            {
               //si vide, cree une donnee vide
               string key = c.Cells[0].Value.ToString();
               if (key == "") return;

               if (!dataxUnitTestSuiteGenerator.ContainsKey(key))
               {
                  dataxUnitTestSuiteGenerator.Add(key, textBoxValue.Text);
               }
               //sinon recupere les donnees
               else
               {
                  dataxUnitTestSuiteGenerator[key] = textBoxValue.Text;
               }
            }
         }
      }

      private void cellValidated(object sender, DataGridViewCellEventArgs e)
      {
         if (e.ColumnIndex == 1)
         {
            DataGridViewRow c = inputGridView.CurrentRow;
            if (c != null)
            {
               //afficher les infos dans le textBoxValue
               if ((c.Cells[0].Value != null))
               {
                  string param = c.Cells[0].Value.ToString();
                  if (param == "") return;

                  if (c.Cells[1].Value != null)
                  {
                     textBoxValue.Clear();
                     string type = c.Cells[1].Value.ToString();
                     if (type != "")
                     {
                        switch (type)
                        {
                           /*Float (32 bit)
                           Float (64 bit)
                           Int (8 bit)
                           Int (16 bit)
                           Int (32 bit)
                           Int (64 bit)
                           Unsigned Int (8 bit)
                           Unsigned Int (16 bit)
                           Unsigned Int (32 bit)
                           Unsigned Int (64 bit)
                           Text
                           TimeInterval
                           DateTime
                           E-mail
                           Digital
                            */

                           case "Float (32 bit)":
                           case "Float (64 bit)":
                           case "Int (8 bit)":
                           case "Int (16 bit)":
                           case "Int (32 bit)":
                           case "Int (64 bit)":
                              if (textBoxValue.Lines.Count() <= 7)
                                 textBoxValue.Clear();
                              break;
                           case "Unsigned Int (8 bit)":
                           case "Unsigned Int (16 bit)":
                           case "Unsigned Int (32 bit)":
                           case "Unsigned Int (64 bit)":
                              if (textBoxValue.Lines.Count() <= 7)
                                 textBoxValue.Clear();
                              break;

                           // default:
                           //TOdo: add missing type

                        }
                        textBoxValue.Text = fillBoundaryValues(param, type);
                        textBoxValue.Update();
                     }
                  }
               }
            }
         }
      }


      private void btnExit_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void textOracle_TextChanged(object sender, EventArgs e)
      {
         DataGridViewRow c = outputGridView.CurrentRow;
         if (c != null)
         {
            if ((c.Cells[0].Value != null))
            {
               //si vide, cree une donnee vide
               string key = c.Cells[0].Value.ToString();
               if (key == "") return;

               if (!dataTestOutput.ContainsKey(key))
               {
                  dataTestOutput.Add(key, oracleCode.Text);
               }
               //sinon recupere les donnees
               else
               {
                  dataTestOutput[key] = oracleCode.Text;
               }
            }
         }
      }

      private void outputSelectedRow(object sender, EventArgs e)
      {

         DataGridViewRow c = outputGridView.CurrentRow;
         if (c != null)
         {

            //afficher les infos dans le oracleCode
            if ((c.Cells[0].Value != null))
            {
               //si vide, cree une donnee vide
               string param = c.Cells[0].Value.ToString();
               if (param == "") return;

               if (dataTestOutput.ContainsKey(param))
               {
                  oracleCode.Text = dataTestOutput[param];
                  oracleCode.Update();
               }
               else
               {
                  oracleCode.Clear();
               }

            }
            else
            {
               oracleCode.Clear();
            }
         }
      }
      #endregion






   }
}


