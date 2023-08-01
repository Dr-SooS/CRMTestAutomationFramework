using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CRMTestAutomationFramework.Core.BusinessObjects
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Categories { get; set; }

        public Contact(Table parameters) {
            FirstName = parameters.Rows[0].FirstOrDefault(value => value.Key.Equals("First Name")).Value;
            LastName = parameters.Rows[0].FirstOrDefault(value => value.Key.Equals("Last Name")).Value;
            Categories = parameters.Rows[0].FirstOrDefault(value => value.Key.Equals("First Name")).Value.Split(",").ToList();
        }
    }
}
