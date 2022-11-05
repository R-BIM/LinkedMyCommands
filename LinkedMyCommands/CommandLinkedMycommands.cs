using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace LinkedMyCommands
{

    [TransactionAttribute(TransactionMode.ReadOnly)]
    public class CommandLinkedMycommands : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {


            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;  

            try
            {

                Reference pickedEle = uidoc.Selection.PickObject(ObjectType.Element);
                Element element = doc.GetElement(pickedEle);

                ElementType elType = doc.GetElement(pickedEle) as ElementType;

                if (element != null)
                {
                    TaskDialog.Show("element classifications",
                        "Element ID : " + element.Id.ToString() + Environment.NewLine +
                        "Category : " + element.Category.Name + Environment.NewLine +
                        " Instance : " + element.Name + Environment.NewLine +
                        "type : " + elType.Name + Environment.NewLine +
                        "Family : " + elType.FamilyName); 
                    


                }




                return Result.Succeeded;

            }
            catch (Exception e)

            {
                message = e.Message;    

                return Result.Failed;   
                
            } 
            
            
            
            


        }
    }
}
