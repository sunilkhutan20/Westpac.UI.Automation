using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Westpac.UI.Automation.Framework;
using BoDi;
using log4net;
using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Westpac.UI.Automation.SpecSteps
{
    public class BaseStep : Steps
    {
        protected ScenarioContext _scenarioContext;
        protected IObjectContainer _container;
        protected ContextObject _context;

        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseStep(ContextObject context)
        {
            _context = context;
          
        }
    }
}
